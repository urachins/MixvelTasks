namespace MixShape;

public abstract class Shape
{
    public abstract double GetArea();
    public abstract bool CheckValid();
    public void RaiseValidError()
    {
        if(!CheckValid())  throw new Exception("Invalid parameters of shape : " + this.GetType().Name);
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }
    public Circle(double radius) => this.Radius = radius;
    public override double GetArea()
    {
        RaiseValidError();
        return Math.PI * Math.Pow(Radius, 2);
    }
    public override bool CheckValid() => Radius >= 0;
}

public class Triangle : Shape
{
    private double[] arSides => new double[3] {this.SideA, SideB, SideC }.OrderBy(x => x).ToArray();
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public Triangle(double sideA, double sideB, double sideC) =>
            (this.SideA, this.SideB, this.SideC) = (sideA, sideB, sideC);
    
    public override double GetArea()
    {
        RaiseValidError();
        double p = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }

    public bool IsRight() => Math.Pow(arSides[2], 2) == Math.Pow(arSides[0], 2) + Math.Pow(arSides[1], 2);

    public override bool CheckValid() => (arSides[0] > 0 && arSides[2] < (arSides[0] + arSides[1]));
}
