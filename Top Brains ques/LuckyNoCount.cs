using System;

class Program
{
    static double CircleArea(double ra)
    {
        return Math.Round(Math.PI*ra*ra,2,MidpointRounding.AwayFromZero);
    }
    static void Main()
    {
        double radius=double.Parse(Console.ReadLine());
        Console.WriteLine(CircleArea(radius));
    }
}
