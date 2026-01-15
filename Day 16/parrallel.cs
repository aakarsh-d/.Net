// using System;
// //Parrallel.For(Start,end,body)
// // Parallel.For(0,5,i=>
// // {
// //     Console.WriteLine($"Processing item {i}");
// // });

// class Program
// {
//     static void Main()
//     {
//         int[] num=new int[10];
//         for(int i=0;i<num.Length;i++)
//             num[i]=i+1;
//         int sum=0;

//         Parallel.For(0, num.Length, i =>
//         {
//             sum+=num[i];
//         });
//         Console.WriteLine(sum);

//         Parallel.For(
//             0,
//             num.Length,
//             ()=>0,
//             (i, loopState, localSum) =>
//             {
//                 return localSum+num[i];
//             },
//             localSum=>
//             {
//                 Interlocked.Add(ref sum, localSum);
//             }
//         );
//         Console.WriteLine("Sum: "+sum);
//     }
// }