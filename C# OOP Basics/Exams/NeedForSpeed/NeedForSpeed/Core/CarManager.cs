using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CarManager
{
    private CarFactory carFactory;
    private RaceFactory raceFactory;
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;
    
    public CarManager()
    {
        this.carFactory = new CarFactory();
        this.raceFactory = new RaceFactory();
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }
    
    public void Register(int id, string type, string brand, string model, int yearOfProduction, 
                         int horsepower, int acceleration, int suspension, int durability)
    {
        cars[id] = this.carFactory.CreateCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
    }

    public string Check(int id)
    {
        Car car = null;

        if (this.cars.ContainsKey(id))
        {
            car = this.cars[id];
        }
        else
        {
            car = this.garage.CarInfo(id);
        }
        return car.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        this.races[id] = this.raceFactory.CreateRace(type, length, route, prizePool);
    }

    public void Open(int id, string type, int length, string route, int prizePool, int param)
    {
        this.races[id] = this.raceFactory.CreateRace(type, length, route, prizePool,param);
    }

    public void Participate(int carId, int raceId)
    {
        if (this.races.ContainsKey(raceId) && this.cars.ContainsKey(carId))
        {
            Race race = this.races[raceId];
            Car participant = this.cars[carId];
            race.AddParticipant(participant);
            participant.IsNotInRace = false;
        }
    }

    public string Start(int id)
    {
        Race race = this.races[id];

        if (race.Participants.Count() == 0)
        {
            throw new ArgumentException("Cannot start the race with zero participants.");
        }
        foreach (var car in race.Participants)
        {
            car.IsNotInRace = true;
        }
        this.races.Remove(id);
        return race.ToString();
    }

    public void Park(int id)
    {
        Car participant = this.cars[id];

        if (participant.IsNotInRace)
        {
            this.garage.AddParticipant(id, participant);
            this.cars.Remove(id);
        }
    }

    public void Unpark(int id)
    {
        Car participant = this.garage.UnparkParticipant(id);
        this.cars[id] = participant;
    }

    public void Tune(int tuneIndex, string addOn)
    {
        this.garage.TuneParkedCars(tuneIndex, addOn);
    }
}
