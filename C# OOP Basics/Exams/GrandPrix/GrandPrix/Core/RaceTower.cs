using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private bool hasWinner;
    private Track track;
    private Driver winner;
    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;
    private Dictionary<string, Driver> registeredDrivers;
    private Dictionary<Driver, string> unfinishedDrivers;

    public RaceTower()
    {
        this.HasWinner = false;
        this.track = new Track();
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
        this.registeredDrivers = new Dictionary<string, Driver>();
        this.unfinishedDrivers = new Dictionary<Driver, string>();
    }
    
    public Driver Winner
    {
        get { return winner; }
        private set { winner = value; }
    }
    
    public bool HasWinner
    {
        get { return hasWinner; }
        private set { hasWinner = value; }
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track.TotalLaps = lapsNumber;
        this.track.TrackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var name = commandArgs[1];
            var driver = this.driverFactory.CreateDriver(commandArgs, this.tyreFactory);
            this.registeredDrivers[name] = driver;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reason = commandArgs[0];
        string name = commandArgs[1];
        this.registeredDrivers[name].IncreaseTotalTime(20);

        switch (reason)
        {
            case "Refuel":
                double fuelAmount = double.Parse(commandArgs[2]);
                this.registeredDrivers[name].Car.Refuel(fuelAmount);
                break;

            case "ChangeTyres":
                string tyreType = commandArgs[2];
                List<string> tyreArgs = commandArgs.Skip(2).ToList();

                Tyre tyre = this.tyreFactory.CreateTyre(tyreArgs);

                this.registeredDrivers[name].Car.ChangeTyre(tyre);

                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int lapsToComplete = int.Parse(commandArgs[0]);
        StringBuilder sb = new StringBuilder();

        try
        {
            this.track.TotalLaps -= lapsToComplete;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        for (int lap = 0; lap < lapsToComplete; lap++)
        {
            this.track.CurrentLap++;

            IncreaseTotalTime();
            ReduceFuelAmount();
            ReduceDegradation();
            CheckForOvertake(sb);
        }

        if (this.track.TotalLaps == 0)
        {
            this.HasWinner = true;
            this.Winner = this.registeredDrivers.OrderBy(d => d.Value.TotalTime).FirstOrDefault().Value;
        }

        return sb.ToString().Trim();
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        int position = 1;

        sb.AppendLine($"Lap {this.track.CurrentLap}/{this.track.TotalLaps + this.track.CurrentLap}");

        foreach (var driver in this.registeredDrivers.OrderBy(d => d.Value.TotalTime))
        {
            Driver currentDriver = driver.Value;

            sb.AppendLine($"{position} {currentDriver.Name} {currentDriver.TotalTime:f3}");
            position++;
        }

        foreach (var driver in this.unfinishedDrivers.OrderByDescending(d => d.Key.TotalTime))
        {
            Driver currentDriver = driver.Key;
            string failureReason = driver.Value;

            sb.AppendLine($"{position} {currentDriver.Name} {failureReason}");
            position++;
        }

        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string newWeather = commandArgs[0];
        this.track.Weather = (Weather)Enum.Parse(typeof(Weather), newWeather);
    }

    private void IncreaseTotalTime()
    {
        foreach (var driver in this.registeredDrivers)
        {
            Driver currentDriver = driver.Value;
            currentDriver.IncreaseTotalTimeInRace(this.track.TrackLength);
        }
    }

    private void ReduceFuelAmount()
    {
        for (int index = 0; index < this.registeredDrivers.Count; index++)
        {
            string key = this.registeredDrivers.Keys.ToList()[index];
            Driver currentDriver = this.registeredDrivers[key];

            try
            {
                currentDriver.Car.ReduceFuelAmount(this.track.TrackLength, currentDriver.FuelConsumptionPerKM);
            }
            catch (Exception ex)
            {
                RemoveFromRace(currentDriver, ex.Message);
                index--;
            }
        }
    }

    private void ReduceDegradation()
    {
        for (int index = 0; index < this.registeredDrivers.Count; index++)
        {
            string key = this.registeredDrivers.Keys.ToList()[index];
            Driver currentDriver = this.registeredDrivers[key];

            try
            {
                currentDriver.Car.Tyre.ReduceDegradation();
            }
            catch (Exception ex)
            {
                string reason = ex.Message;
                RemoveFromRace(currentDriver, ex.Message);
                index--;
            }
        }
    }

    private bool CheckForCrash(Driver firstDriver, ref int overtakeTime)
    {
        if (firstDriver is AggressiveDriver && firstDriver.Car.Tyre is UltrasoftTyre)
        {
            overtakeTime = 3;
            if (this.track.Weather == Weather.Foggy)
            {
                return true;
            }
        }
        else if (firstDriver is EnduranceDriver && firstDriver.Car.Tyre is HardTyre)
        {
            overtakeTime = 3;
            if (this.track.Weather == Weather.Rainy)
            {
                return true;
            }
        }
        return false;
    }

    private void CheckForOvertake(StringBuilder sb)
    {
        int overtakeTime = 2;
        bool hasCrashed = false;

        var orderedDrivers = this.registeredDrivers
                        .OrderByDescending(d => d.Value.TotalTime)
                        .ToDictionary(k => k.Key, v => v.Value).Keys.ToList();

        for (int index = 0; index < orderedDrivers.Count - 1; index++)
        {
            var firstDriver = this.registeredDrivers[orderedDrivers[index]];
            var secondDriver = this.registeredDrivers[orderedDrivers[index + 1]];

            double TimeDiff = Math.Abs(firstDriver.TotalTime - secondDriver.TotalTime);

            hasCrashed = CheckForCrash(firstDriver, ref overtakeTime);

            if (TimeDiff <= overtakeTime)
            {
                if (hasCrashed)
                {
                    RemoveFromRace(firstDriver, OutputMessages.Crashed);
                }
                else
                {
                    firstDriver.ReduceTotalTime(overtakeTime);
                    secondDriver.IncreaseTotalTime(overtakeTime);
                    sb.AppendLine($"{firstDriver.Name} has overtaken {secondDriver.Name} on lap {this.track.CurrentLap}.");
                }
            }
        }
    }

    private void RemoveFromRace(Driver driver, string reason)
    {
        this.unfinishedDrivers[driver] = reason;
        this.registeredDrivers.Remove(driver.Name);
    }
}