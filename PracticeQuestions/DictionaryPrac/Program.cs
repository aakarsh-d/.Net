
// // 2) Student Marks - Update Existing Key

// // Store student names and marks. If a student exists, update mark; otherwise add new student.

// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         Dictionary<string, int> marks = new Dictionary<string, int>
//         {
//             { "Asha", 78 },
//             { "Bala", 82 }
//         };

//         string student = Console.ReadLine();
//         int newMark = int.Parse(Console.ReadLine());
//         // TODO: Add or update mark
//         if (marks.ContainsKey(student))
//         {
//             marks[student]=newMark;
//         }
//         else
//         {
//             marks.Add(student,newMark);
//             Console.WriteLine("Updated");
//         }
//     }
// }

