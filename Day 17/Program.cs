using System.Diagnostics;

// class Program
// {
//     static void Main()
//     {
//         Process cp=Process.GetCurrentProcess();
//         Console.WriteLine("current : "+cp.Id);
//         Console.WriteLine("process name: "+cp.ProcessName);
//         Console.WriteLine(cp.StartTime);
//         Console.WriteLine(cp.WorkingSet64);
//         Console.WriteLine(cp.TotalProcessorTime);
//         Console.WriteLine(cp.Threads);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         // Create a new thread
//         Thread worker = new Thread(DoWork);

//         // Start the thread
//         worker.Start();

//         Console.WriteLine("Main thread continues...");

//         // Optional: Wait for worker thread to finish
//         worker.Join();
//         Console.WriteLine("Main thread finished");
//     }

//     static void DoWork()
//     {
//         for (int i = 1; i <= 5; i++)
//         {
//             Console.WriteLine("Worker thread: " + i);
//             Thread.Sleep(500); // Simulate work
//         }
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Process.Start("Command Prompt.exe");

//     }
// }

// class Program
// {
//     static int counter=0;
//     static object lockobj=new object();
//     static void Main()
//     {
//         Thread t1=new Thread(Increment);
//         Thread t2=new Thread(Increment);
//         t1.Start();
//         t2.Start();
//         t1.Join();
//         t2.Join();
//         Console.WriteLine(counter);
//     }
//     static void Increment()
//     {
//         for(int i = 0; i < 10000; i++)
//         {
//             lock(lockobj)
//             counter++;
//         }
//     }
// }