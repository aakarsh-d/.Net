using System;

public class Solution
{
    public double ConvertToCentimeters(int feet)
    {
        return Math.Round(feet * 30.48, 2, MidpointRounding.AwayFromZero);
    }
}
