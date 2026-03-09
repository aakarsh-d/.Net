// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         int[] employeeIds = { 1001, 1002, 1001, 1003, 1002, 1001 };
//         Dictionary<int, int> attendance = new Dictionary<int, int>();
//         // TODO: Build frequency map and print
//         foreach(var id in employeeIds)
//         {
//             if (attendance.ContainsKey(id))
//             {
//                 attendance[id]++;
//             }
//             else
//             {
//                 attendance[id]=1;
//             }
//         }

//         foreach(var id in attendance)
//         {
//             Console.WriteLine($"{id.Key} -> {id.Value}");
//         }
//     }
// }