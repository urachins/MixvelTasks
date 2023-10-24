namespace MixShape.Tests;

public class MixShapeTests
{
    double Precision;

   [SetUp]
    public void Setup()
    {
        int DecimalsPrecision = 10;
        Precision = Math.Pow(10, -DecimalsPrecision);
    }

    [TestCase(3, 4, 5, 6)]
    [TestCase(30, 40, 50, 600)]
    [TestCase(2, 2, 2, 1.7320508075)]
    public void Triangle_GetArea_Tests(double a, double b, double c, double expected)
    {
        var shp = new Triangle(a, b, c);
        var actual = shp.GetArea();
        Assert.That(Math.Abs(actual - expected) , Is.LessThanOrEqualTo(Precision));
    }

    [TestCase(3, 4, 5, true)]
    [TestCase(4, 4, 5, false)]
    public void Triangle_IsRight_Tests(double a, double b, double c, bool expected)
    {
        var shp = new Triangle(a, b, c);
        var actual = shp.IsRight();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(1, Math.PI)]
    [TestCase(10, Math.PI * 100)]
    [TestCase(0, 0)]
    public void Circle_GetArea_Tests(double r, double expected)
    {
        var shp = new Circle(r);
        var actual = shp.GetArea();
        Assert.That(Math.Abs(actual - expected), Is.LessThanOrEqualTo(Precision));
    }



}