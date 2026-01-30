// using System;
// using System.Collections.Generic;


// class Program
// {
//         public static void Main(string[] args)
//         {
//             List<int> num = new List<int>();
//             List<int> num2 = new List<int>();
//             List<int> num3 = new List<int>();
//             List<int> num4 = new List<int>();

//             for (int i = 1; i <= 100; i++)
//             {
//                 num.Add(i);

//                 if (i % 2 == 0)
//                     num2.Add(i);

//                 if (i % 3 == 0)
//                     num3.Add(i);

//                 if (i % 2 != 0 && i % 3 != 0)
//                     num4.Add(i);
//             }

//             Console.WriteLine("First List:");
//             foreach (int i in num)
//                 Console.Write(i + " ");

//             Console.WriteLine("\n\nSecond List:");
//             foreach (int i in num2)
//                 Console.Write(i + " ");

//             Console.WriteLine("\n\nThird List:");
//             foreach (int i in num3)
//                 Console.Write(i + " ");

//             Console.WriteLine("\n\nFourth List:");
//             foreach (int i in num4)
//                 Console.Write(i + " ");
//         }
//     }



using System.Runtime.CompilerServices;


interface IGear
{
    public void Gear1();
    public void Gear2();
    public void Gear3();
   
}
public abstract class Gear2
{
    public abstract void Gear4();
    public abstract void Gear5();
    public virtual void ReverseGear()
    {
        Console.WriteLine("Reverse");
    }
}

class MariCar : Gear2,IGear
{
    public void Gear1()
    {
        Console.WriteLine("Gear 1 Tested");
    }
    public void Gear2()
    {
        Console.WriteLine("Gear 2 Tested");
    }
    public void Gear3()
    {
        Console.WriteLine("Gear 3 Tested");
    }
    public override void Gear4()
    {
        Console.WriteLine("Gear 4 Tested");
    }
    public override void Gear5()
    {
        Console.WriteLine("Gear 5 Tested");
    }
    // public void Gear6()
    // {
    //     Console.WriteLine("Gear 6 Tested");
    // }
    
}
delegate int Add(int a,int b,int c);
delegate int Subt(int d,int e);
delegate int FindLength(string s);
class Program
{
     static int add(int a,int b,int c)
    {
        return a+b+c;
    }
     static int subt(int d,int e)
    {
        return d-e;
    }
    static int Findlength(string s)
    {
        return s.Length;
    }
    public static void Main(string[] args)
    {
        MariCar car = new MariCar();
        // var car = new MariCar();
        car.Gear1();
        car.Gear2();
        car.Gear3();
        car.Gear4();
        car.Gear5();
        car.ReverseGear();

        Add a=add;
        Subt s=subt;
        FindLength f=Findlength;

        Console.WriteLine("Addition: "+a(10,20,30));
        Console.WriteLine("Subtraction: "+s(10,20));
        Console.WriteLine("Length of Hello: "+f("Hello"));

       
    }
}