class Calculator
{
    static int a = 4;
    static int b = 5;
    static int num = 6;
    static void calculate()
    {
        
        static int add(int a, int b)
        {
            Console.WriteLine(num);
            return a + b;
        }
        int addition = add(a, b);
        Console.WriteLine("Addition of a and b: " + addition);
    }
}