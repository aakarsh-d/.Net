
// // // class Student
// // // {
// // //     public int Id{get;set;}
// // //     public string Attendance{get;set;}

// // //     // public Student(int id,string attendance)
// // //     // {
// // //     //     Id = id;
// // //     //     Attendance = attendance;
// // //     // }


// // //     // public Dictionary<int,bool?> isValid(int id)
// // //     // {
// // //     //     Dictionary<int,bool?> result = new Dictionary<int,bool?>();

// // //     //     if()
// // //     // }

// // // }
// // class Program
// // {
// //     static void Main()
// //     {
// //         Dictionary<int,bool?> attendance=new Dictionary<int,bool?>();
// //         string Data=Console.ReadLine();
// //         string[] data=Data.Replace(" ","").Split(',');
        

// //         Student student= new Student();
// //         foreach(var d in data)
// //         {
// //             var parts=d.Split(":");
// //             attendance[id]=parts[0];

// //             attendance[status]=null;
// //             if (parts.Length > 1)
// //             {
// //                 if(parts[1].Equals("Present"))
// //                 status=true;
// //             }
// //             // student.Id = int.Parse(data.Split(":")[i]);
// //             // student.Attendance = data.Split(":")[i++];
// //         }

// //         foreach(var s in student)
// //         {
// //             Console.WriteLine(s.Key, " -> " ,s.Value);
// //         }
// //         var present=
// //         Console.WriteLine("Total Present: ");


// //     }
// // }

// using System;
// using System.Collections.Generic;
// using System.Text;

// class Program
// {
//     static void Main()
//     {
//         string input = "101:Present,102:Absent,103:Present,104:,105:Present,ABC:Present,106:Absent";

//         Dictionary<int, bool?> attendance = new Dictionary<int, bool?>();

//         string[] entries = input.Split(',');

//         foreach (var entry in entries)
//         {
//             string[] parts = entry.Split(':');

//             if (parts.Length != 2)
//                 continue;

//             // Safe parsing of Student I D
//             if (!int.TryParse(parts[0], out int studentId))
//                 continue; // Ignore invalid IDs like ABC

//             string status = parts[1].Trim();

//             if (string.IsNullOrWhiteSpace(status))
//             {
//                 attendance[studentId] = null;
//             }
//             else if (status.Equals("Present"))
//             {
//                 attendance[studentId] = true;
//             }
//             else if (status.Equals("Absent"))
//             {
//                 attendance[studentId] = false;
//             }
//         }

//         // Generate Report
//         StringBuilder report = new StringBuilder();

//         report.AppendLine("Attendance Report");
//         report.AppendLine("-----------------");

//         int presentCount = 0;
//         int absentCount = 0;
//         int notMarkedCount = 0;

//         foreach (var record in attendance)
//         {
//             string statusText;

//             if (record.Value == true)
//             {
//                 statusText = "Present";
//                 presentCount++;
//             }
//             else if (record.Value == false)
//             {
//                 statusText = "Absent";
//                 absentCount++;
//             }
//             else
//             {
//                 statusText = "Not Marked";
//                 notMarkedCount++;
//             }

//             report.AppendLine($"{record.Key} -> {statusText}");
//         }

//         report.AppendLine();
//         report.AppendLine($"Total Present: {presentCount}");
//         report.AppendLine($"Total Absent: {absentCount}");
//         report.AppendLine($"Not Marked: {notMarkedCount}");

//         Console.WriteLine(report.ToString());
//     }
// }
