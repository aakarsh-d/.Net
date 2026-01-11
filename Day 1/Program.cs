using System;
using System.Diagnostics;
using System.Globalization;
// using GameApp;
// using FCS;
// using FMS;
using BankApp;
// using HelloWorldApp;
// using CalculatorApp;
using MathOps;
class HelloWorld
{
    public static void Main()
    {
    //     Employee emp = new Employee();
    //     emp.AcceptDetails();
    //     emp.DisplayDetails();
        // Console.WriteLine("Hello, World!");
        // Calculator calc = new Calculator();
        // calc.Add();
        // calc.Subtract();
        // calc.Multiply();
        // calc.Divide();
        // calc.Modulus();
        // Console.ReadLine();

        // q1) print hello world
        // Console.WriteLine("Hello, world!!");
        //q2) write c# to read a number and display it 
        // int num=0;
        // Console.WriteLine("ENter a number :");
        // num=Convert.ToInt32(Console.ReadLine());
        // Console.WriteLine("The number you entered is :"+num);        

        // Q3) Write a prog t read a float point number from user 
        // float fl=0.0f;
        // Console.WriteLine("Enter a float number :");
        // fl=Convert.ToSingle(Console.ReadLine());
        // Console.WriteLine($"The float number u entered is : {fl}");

        // Q4) wRITE A C# to read a string from user and display it
        // string name=string.Empty;

        // name=Console.ReadLine();
        // Console.WriteLine($"Your name : {name}");        

        //q6) write a c# pprogram to find the area of circle 

        // float area=0.0f;
        // float r=0;
        // Console.WriteLine("Enter the radius of circle:");
        // r=Convert.ToSingle(Console.ReadLine());
        // area=(22/7)*r*r;
        // Console.WriteLine($"The area of circle is : {area}");

        // q7) write a c# program to check even or odd number
        // int n;
        // Console.WriteLine("Enter a number:");
        // n=Convert.ToInt32(Console.ReadLine());
        // if(n%2==0)
        // {
        //     Console.WriteLine("The number is even");
        // }
        // else
        // {
        //     Console.WriteLine("The number is odd");
        // }

        // }
        // q8) write a c# to find the greatest of 2 numbers
        // int a,b;
        // Console.WriteLine("Enter 1 no:");
        // a=Convert.ToInt32(Console.ReadLine());
        // Console.WriteLine("Enter 2 no:");
        // b=Convert.ToInt32(Console.ReadLine());
        // if (a > b)
        // {
        //     Console.WriteLine("a is greater");
        // }
        // else if (b > a)
        // {
        //     Console.WriteLine("b is greater");
        // }
        // else if(a==b)
        // {
        //     Console.WriteLine("Both are equal");
        // }
        // q9) Write a c# to find whether a given number is positive , negative or zero
        // int num;
        // Console.WriteLine("Enter a number:");
        // num=Convert.ToInt32(Console.ReadLine());
        // if(num==0)
        // {
        //     Console.WriteLine($"The num is zero {num}");
        // }
        // else if(num>0)
        // {
        //     Console.WriteLine($"The num is positive {num}");
        // }
        // else
        // {
        //     Console.WriteLine($"The num is negative {num}");
        // }

        // Q10) write a c# program to check gretest of three

        // int a,b,c;
        // Console.WriteLine("Enter the first num:");
        // a=Convert.ToInt32(Console.ReadLine());
        // Console.WriteLine("Enter the second num:");
        // b=Convert.ToInt32(Console.ReadLine());
        // Console.WriteLine("Enter the third num:");
        // c=Convert.ToInt32(Console.ReadLine());
        // if(a>b && a>c)
        // {
        //     Console.WriteLine($"{a} is greatest");
        // }
        // else if(b>a && b > c)
        // {
        //     Console.WriteLine($"{b} is greatest");
        // }
        // else if(c>a && c>b)
        // {
        //     Console.WriteLine($"{c} is greatest");
        // }
        // char a;
        // a=Convert.ToChar(Console.ReadLine());
        // Console.WriteLine(a);
        // switch(a)
        // {
        //     case 'a':
        //     Console.WriteLine($" {a} is Vowel");
        //     break;
        //     case 'e':
        //     Console.WriteLine($" {a} is Vowel");
        //     break;
        //     case 'i':
        //     Console.WriteLine($" {a} is Vowel");
        //     break;
        //     case 'o':
        //     Console.WriteLine($" {a} is Vowel");
        //     break;
        //     case 'u':
        //     Console.WriteLine($" {a} is Vowel");
        //     break;
        //     case 'A':
        //     Console.WriteLine($" {a} is Vowel");
        //     break;
        //     case 'E':
        //     Console.WriteLine($" {a} is Vowel");
        //     break;
        //     case 'I':
        //     Console.WriteLine($" {a} is Vowel");
        //     break;
        //     case 'O':
        //     Console.WriteLine($" {a} is Vowel");
        //     break;
        //     case 'U':
        //     Console.WriteLine($" {a} is Vowel");
        //     break;
        //     default:
        //     Console.WriteLine($" {a} is Consonant");
        //     break;
        // }


        // string st=string.Empty;
        // int length=0;
        // // string l=string.Empty;
        // Console.WriteLine("Enter a string:");
        // st=Console.ReadLine();
        // length=st.Length;
        // Console.WriteLine($"The original string length is : {length}");
        // st=st.ToUpper();
        // Console.WriteLine($"The uppercase string is : {st}");
        // Console.WriteLine("");

        // int a,b;
        // // Console.WriteLine("Enter first number:");
        // a=Convert.ToInt32(Console.ReadLine()); 
        // b=Convert.ToInt32(Console.ReadLine()); 
        // // Console.WriteLine("Enter Second number:");
        // // int swap;
        // Console.WriteLine($"Before swapping : a={a} b={b}");
        // a=a+b; 
        // b=a-b; 
        // a=a-b;
        // Console.WriteLine($"After swapping : a={a} b={b}");

        //day 2 practice

        // int ct=0;
        // while(ct<5)
        // {
        //     Console.WriteLine(ct);
        //     ct++;
        // }

        // int c=5;
        // while(c>0)
        // {
        //     Console.WriteLine(c);
        //     c--;
        // }

        //do while 
        // int count=0;
        // do 
        // {
        //     Console.WriteLine(count);
        //     count++;
        // }
        // while(count<=5);

        
        // int a;
        // int b;
       
        // Console.WriteLine("Enter a range to print its table:");
        // a=Convert.ToInt32(Console.ReadLine());
        // b=Convert.ToInt32(Console.ReadLine());
        // for(int j=a;j<=b;j++){
        //     Console.WriteLine("Table of "+j);
        // for(int i=1;i<=10;i++)
        // {
        //     Console.WriteLine($"{j} x {i} = {j*i}");
        // }}
        

        
        // Game g = new Game();
        // g.game();


        // FinanceControlSystem fcs = new FinanceControlSystem();
        // fcs.FinanceSystem();

        // Account account= new Account();
        // account.FinanceSystem();
    //   
        // BankAcc acc=new BankAcc();
        // acc.accNum=123456;
        // acc.Balance=1000.50;
        // Employe emp=new Employe();
        // emp.empName=101;    
        // emp.empSalary=0.0f;
        // emp.Display();  

        //programe.cs
        MathOps ops = new MathOps();
        int a = ops.add(1, 2);
        Console.WriteLine("Sum of two integers: " + a);
        double b = ops.add(1.0, 2.0);
        Console.WriteLine("Sum of two doubles: " + b);
    }
}
