using System;

public class Solution
{
    public int SumParsedIntegers(string[] tokens)
    {
        int sum = 0;
        int value;

        foreach (string t in tokens)
            if (int.TryParse(t, out value))
                sum += value;

        return sum;
    }
}
