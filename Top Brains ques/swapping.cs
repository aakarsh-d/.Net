using System;

class Program
{
    static void Swap(ref int a, ref int b)
    {
        a=a+b;
        b=a-b;
        a=a-b;
    }

    static void Main()
    {
        int x=10, y=20;

        Swap(ref x, =ref y);

        Console.WriteLine($"x = {x}, y = {y}");
    }
}
