using System;

// 2.
//a. Add Square & Triangle & Cube
//b. Add function to get volume for the supported shapes
//c. noting that cube shape only support volume calculation

public interface IAreaCalculator
{
    public double TotalArea();
}

public interface IVolumeCalculator
{
    public double TotalVolume();
}


public class Rectangle : IAreaCalculator
{
    public double Height { get; set; }
    public double Wight { get; set; }

    public double TotalArea() => this.Height * this.Width;

}

//square will inherit from rectangle
public class Square : IAreaCalculator
{
    double sideLength { get; set; }
    public double TotalArea() =>  this.sideLength * this.sideLength;
}

public class Circle: IAreaCalculator
{
    public double Radius { get; set; }
    public double TotalArea() =>this.Radius * this.Radius * Math.PI;
}


public class Cube:IVolumeCalculator
{
    public double Sidelength { get; set; }

    public double TotalVolume() => this.Sidelength * this.Sidelength * this.Sidelength;
    
}


public class Triangle:IAreaCalculator
{
    public double Base { get; set; }
    public double Height { get; set; }

    public double TotalArea() => 0.5 * Base * Height;

}


public class AreaCalculator
{
    public double TotalArea(IAreaCalculator[] shapes)
    {
        double area = 0;
        foreach (var x in shapes)
        {
            area += x.TotalArea();
        }
        return area;
    }
}

