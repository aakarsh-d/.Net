using System;

public class Solution
{
    public string FormatTime(int totalSeconds)
    {
        int m = totalSeconds / 60;
        int s = totalSeconds % 60;

        return m + ":" + s.ToString("D2");
    }
}
