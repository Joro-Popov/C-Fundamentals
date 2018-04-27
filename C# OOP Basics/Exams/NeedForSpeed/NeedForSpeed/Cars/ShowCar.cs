using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShowCar : Car
{
    private int stars;
    
    public ShowCar(string brand, string model, int prodYear, int hp, int acceleration, int suspension, int durability, int stars) 
        : base(brand, model, prodYear, hp, acceleration, suspension, durability)
    {
        this.Stars = stars;
    }

    public int Stars
    {
        get { return stars; }
        private set { stars = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"{this.Stars} *");
        return sb.ToString().Trim();
    }

    public void IncreaseStars(int index)
    {
        this.Stars += index;
    }
}
