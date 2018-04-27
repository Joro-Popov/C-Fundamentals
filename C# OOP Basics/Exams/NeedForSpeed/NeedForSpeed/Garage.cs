using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Garage
{
    private Dictionary<int,Car> parkedCars;
    
    public Garage()
    {
        this.parkedCars = new Dictionary<int, Car>();
    }
    
    public void AddParticipant(int id, Car participant)
    {
        this.parkedCars[id] = participant;
    }

    public Car UnparkParticipant(int id)
    {
        Car participant = this.parkedCars[id];
        this.parkedCars.Remove(id);
        return participant;
    }

    public void TuneParkedCars(int tuneIndex, string addOn)
    {
        if (this.parkedCars.Count > 0)
        {
            foreach (var car in this.parkedCars)
            {
                Car current = car.Value;
                current.IncreaseHP(tuneIndex);
                current.IncreaseSuspension(tuneIndex);

                if (current is PerformanceCar)
                {
                    (current as PerformanceCar).IncreaseAddOns(addOn);
                }
                else if (current is ShowCar)
                {
                    (current as ShowCar).IncreaseStars(tuneIndex);
                }
            }
        }
    }

    public Car CarInfo(int id)
    {
        return this.parkedCars[id];
    }
    
}
