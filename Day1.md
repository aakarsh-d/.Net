# Day 01 – C# Basics

This folder contains basic C# programs written as part of my .NET learning journey.

---

// Program to Print Hello World

```csharp
using System;
// using HelloWorldApp;
// using CalculatorApp;
class HelloWorld
{
    public static void Main()
    {
        // q1) print hello world
        Console.WriteLine("Hello, world!!");
    }
}

2 Program to Read a Number and Display It

using System;
class HelloWorld
{
    public static void Main()
    {
        int num=0;
        Console.WriteLine("ENter a number :");
        num=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("The number you entered is :"+num);        
    }
}


3 Program to Read a Floating Point Number

using System;
class HelloWorld
{
    public static void Main()
    {
        float fl=0.0f;
        Console.WriteLine("Enter a float number :");
        fl=Convert.ToSingle(Console.ReadLine());
        Console.WriteLine($"The float number u entered is : {fl}");
    }
}


Q4) write a C# to read a string from user and display it
string name=string.Empty;
name=Console.ReadLine();
Console.WriteLine($"Enter your name : {name}");


5 Program to Perform All Arithmetic Operations

class Calculator
{
    int number1;
    int number2;    
    int res;

    public void Add()
    {
        Console.WriteLine("Enter first number:");
        number1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        number2=Convert.ToInt32(Console.ReadLine());
        res=number1+number2;
        Console.WriteLine($"Addition is {res}");
    }

    public void Subtract()
    {
        Console.WriteLine("Enter first Number:");
        number1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second Number:");
        number2=Convert.ToInt32(Console.ReadLine());
        res=number1-number2;
        Console.WriteLine($"Subtraction is {res}");
    }

    public void Multiply()
    {
        Console.WriteLine("Enter first Number:");
        number1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second Number:");
        number2=Convert.ToInt32(Console.ReadLine());
        res=number1*number2;
        Console.WriteLine($"Multiplication is {res}");
    }

    public void Divide()
    {
        Console.WriteLine("Enter first Number:");
        number1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second Number:");
        number2=Convert.ToInt32(Console.ReadLine());
        res=number1/number2;
        Console.WriteLine($"Division is {res}");
    }

    public void Modulus()
    {
        Console.WriteLine("Enter first Number:");
        number1=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second Number:");
        number2=Convert.ToInt32(Console.ReadLine());
        res=number1%number2;
        Console.WriteLine($"Modulus is {res}");
    }
}

6 Program to Find Area of Circle

float area=0.0f;
float r=0;
Console.WriteLine("Enter the radius of circle:");
r=Convert.ToSingle(Console.ReadLine());
area=(22/7)*r*r;
Console.WriteLine($"The area of circle is : {area}");


7  Program to check even or odd

int n;
Console.WriteLine("Enter a number:");
n=Convert.ToInt32(Console.ReadLine());
if(n%2==0)
{
    Console.WriteLine("The number is even");
}
else
{
    Console.WriteLine("The number is odd");
}

8 Program to find greatest of two numbers

int a,b;
Console.WriteLine("Enter 1 no:");
a=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter 2 no:");
b=Convert.ToInt32(Console.ReadLine());
if (a > b)
{
    Console.WriteLine("a is greater");
}
else if (b > a)
{
    Console.WriteLine("b is greater");
}
else
{
    Console.WriteLine("Both are equal");
}

9 Program to Check Positive, Negative or Zero

int num;
Console.WriteLine("Enter a number:");
num=Convert.ToInt32(Console.ReadLine());
if(num==0)
{
    Console.WriteLine($"The num is zero {num}");
}
else if(num>0)
{
    Console.WriteLine($"The num is positive {num}");
}
else
{
    Console.WriteLine($"The num is negative {num}");
}

10 Program to check gretesst of 3 numbers

int a,b,c;
Console.WriteLine("Enter the first num:");
a=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the second num:");
b=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the third num:");
c=Convert.ToInt32(Console.ReadLine());
if(a>b || a>c)
{
    Console.WriteLine($"{a} is greatest");
}
else if(b>a || b > c)
{
    Console.WriteLine($"{b} is greatest");
}
else
{
    Console.WriteLine($"{c} is greatest");
}


Program to check vowels using switch case

char a;
a=Convert.ToChar(Console.ReadLine());
switch(a)
{
    case 'a':
    case 'e':
    case 'i':
    case 'o':
    case 'u':
    case 'A':
    case 'E':
    case 'I':
    case 'O':
    case 'U':
        Console.WriteLine($" {a} is Vowel");
        break;
    default:
        Console.WriteLine($" {a} is Consonant");
        break;
}


String Operations (uppercase and length)

string st=string.Empty;
int length=0;
Console.WriteLine("Enter a string:");
st=Console.ReadLine();
length=st.Length;
Console.WriteLine($"The original string length is : {length}");
st=st.ToUpper();
Console.WriteLine($"The uppercase string is : {st}");

Swap 2 no without temp var

int a,b;
a=Convert.ToInt32(Console.ReadLine()); 
b=Convert.ToInt32(Console.ReadLine()); 
Console.WriteLine($"Before swapping : a={a} b={b}");
a=a+b; 
b=a-b; 
a=a-b;
Console.WriteLine($"After swapping : a={a} b={b}");
