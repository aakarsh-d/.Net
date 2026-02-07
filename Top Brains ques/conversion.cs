using System;

class Program
{
    static double ConvertToCm(int feet)
    {
        return Math.Round(feet * 30.48, 2, MidpointRounding.AwayFromZero);
    }

    static void Ma