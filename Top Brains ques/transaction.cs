using System;

public class Solution
{
    public int FinalBalance(int initialBalance, int[] transactions)
    {
        int balance = initialBalance;

        foreach (int t in transactions)
        {
            if (t >= 0)
                balance += t;
            else
            {
                int withdraw = -t;
                if (balance >= withdraw)
                    balance -= withdraw;
            }
        }

        return balance;
    }
}
