// try
// {
//     Task t=Task.Run(()=> throw new Exception("Task Error"));
//     t.Wait();
// }
// catch (AggregateException ex)
// {
//     Console.WriteLine(ex.InnerException[0].message);
// }

// Task t1=Task.Run(()=>Console.WriteLine("Task 1"));
// Task t2=Task.Run(()=>Console.WriteLine("Task 2"));
// Task.WhenAll(t1,t2).ContinueWith(t=>Console.WriteLine("All TAsk Comlpeted"));