using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;
    private bool isNotInRace;
    
    protected Car(string brand, string model, int prodYear, int hp, int acceleration,
               int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = prodYear;
        this.Horsepower = hp;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
        this.IsNotInRace = true;
    }

    public bool IsNotInRace
    {
        get { return isNotInRace; }
        set { isNotInRace = value; }
    }

    public int Durability
    {
        get { return durability; }
        private set { durability = value; }
    }

    public int Suspension
    {
        get { return suspension; }
        protected set { suspension = value; }
    }

    public int Acceleration
    {
        get { return acceleration; }
        private set { acceleration = value; }
    }

    public int Horsepower
    {
        get { return horsepower; }
        protected set { horsepower = value; }
    }

    public int YearOfProduction
    {
        get { return yearOfProduction; }
        private set { yearOfProduction = value; }
    }

    public string Model
    {
        get { return model; }
        private set { model = value; }
    }

    public string Brand
    {
        get { return brand; }
        private set { brand = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        sb.AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s");
        sb.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return sb.ToString().Trim();
    }

    public int GetOverallPerformance()
    {
        return (this.Horsepower / this.Acceleration) + (this.Suspension + this.Durability);
    }

    public int GetEnginePerformance()
    {
        return this.Horsepower / this.Acceleration;
    }

    public int GetSuspensionPerformance()
    {
        return this.Suspension + this.Durability;
    }

    public int GetTimePerformance(int raceLength)
    {
        int performance = raceLength * ((this.Horsepower / 100) * this.Acceleration);
        return performance;
    }

    public void IncreaseHP(int index)
    {
        this.Horsepower += index;
    }

    public void IncreaseSuspension(int index)
    {
        this.Suspension += (index / 2);
    }

    public void ReduceDurability(int length)
    {
        this.Durability -= (length * length);
    }
}
