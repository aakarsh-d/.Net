// using System;
// using System.Security.Cryptography.X509Certificates;

// class ResourceHandler : IDisposable
// {
//     public ResourceHandler(){
//         Console.WriteLine("Resouce Acquired");
//     }
//     public void Dispose()
//     {
//         Console.WriteLine("Resource released");
//     }
// }


using System;

class Program
{
    static void Main()
    {
        Console.WriteLine($"Total Memory Before GC: {GC.GetTotalMemory(false)} bytes");

        for (int i = 0; i < 10000; i++)
        {
            object obj = new object(); // Gen 0 allocation
        }

        Console.WriteLine($"Total Memory After Object Creation: {GC.GetTotalMemory(false)} bytes");

        GC.Collect(); 
        GC.WaitForPendingFinalizers();

        Console.WriteLine($"Total Memory After GC: {GC.GetTotalMemory(false)} bytes");
        Console.WriteLine($"Generation of a new object: {GC.GetGeneration(new object())}");
    }
}