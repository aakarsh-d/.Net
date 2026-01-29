// class Profram
// {
//     static void Main()
//     {
//         Thread worker=new Thread(DoWork);
//         worker.Start();
//         Console.WriteLine("Main thread continues...");
//     }
//     static void DoWork()
//     {
//         for(int i = 1; i <= 5; i++)
//         {
//             Console.WriteLine("Worker Thread: "+i);
//             Thread.Sleep(1000);
//         }
//     }
// }