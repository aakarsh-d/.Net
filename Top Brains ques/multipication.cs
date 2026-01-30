using System;

public class Solution
{
    public int[] MultiplicationRow(int n, int upto)
    {
        int[] result = new int[upto];

        for (int i = 1; i <= upto; i++)
            result[i - 1] = n * i;

        return result;
    }
}
