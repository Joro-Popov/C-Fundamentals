using System;

public class Car
{
    private const double TANK_CAPACITY = 160;

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.HP = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public Tyre Tyre
    {
        get { return tyre; }
        private set { tyre = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        private set
        {
            if (value > TANK_CAPACITY)
            {
                value = TANK_CAPACITY;
            }
            if (value < 0)
            {
                throw new ArgumentException(OutputMessages.OutOfFuel);
            }
            fuelAmount = value;
        }
    }

    public int HP
    {
        get { return hp; }
        private set { hp = value; }
    }

    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    public void ChangeTyre(Tyre newTyre)
    {
        this.tyre = newTyre;
    }

    public void ReduceFuelAmount(int trackLength, double fuelConsumptionPerKM)
    {
        this.FuelAmount -= trackLength * fuelConsumptionPerKM;
    }
}