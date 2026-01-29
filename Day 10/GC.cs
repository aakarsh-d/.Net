// class Program
// {
//     public static void Main(string[] args)
//     {
//         Console.WriteLine("Creating Objects ...");
//         List<MyClass> list = new List<MyClass>();

//         // for (int i = 0; i < 5; i++)
//         // {
//         //     list.Add(new MyClass());
//         // }

//         // GC.Collect();
//         // GC.WaitForPendingFinalizers();

//         for(int i = 0; i < 5; i++)
//         {
//             MyClass obj =new MyClass();
//         }
//         GC.Collect();
//         GC.WaitForPendingFinalizers();
//         Console.WriteLine("Forcing garbage collection...");
//     }
// }

// class MyClass
// {
//     ~MyClass()
//     {
//         Console.WriteLine("Finalizer called object collected");
//     }
// }