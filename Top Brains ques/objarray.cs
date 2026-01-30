using System;

public class Solution
{
    public int SumIntegers(object[] values)
    {
        int sum = 0;

        foreach (object v in values)
            if (v is int x)
                sum += x;

        return sum;
    }
}
