using System;

public class Solution
{
    public int SumPositiveUntilZero(int[] nums)
    {
        int sum = 0;

        foreach (int x in nums)
        {
            if (x == 0)
                break;

            if (x < 0)
                continue;

            sum += x;
        }

        return sum;
    }
}
