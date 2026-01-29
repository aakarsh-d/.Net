
// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Student
// {
//     public string Name;
//     public string Grade;
//     public int Marks;
// }

// class Program
// {
//     static void Main()
//     {
//         // Create three objects and assign values
//         List<Student> students = new List<Student>
//         {
//             new Student { Name = "Aman", Marks = 75 },
//             new Student { Name = "Neha", Marks = 55 },
//             new Student { Name = "Rohit", Marks = 62 }
//         };

//         // LINQ Select with Pass / Fail
//         var result = students.Select(s => new
//         {
//             s.Name,
//             Grade = s.Marks > 60 ? "Pass" : "Fail"
//         });

//         // Print result
//         foreach (var r in result)
//         {
//             Console.WriteLine($"{r.Name} - {r.Grade}");
//         }

//         // Just to see the type (as in your screenshot)
//         Console.WriteLine(result.GetType());
//     }
// }


// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;

// class Student
// {
//     public string Name;
//     public string Grade;
//     public int Marks;
// }

// class Program
// {
//     static void Main()
//     {
        
//         List<Student> students = new List<Student>
//         {
//             new Student { Name = "A", Marks = 75 },
//             new Student { Name = "B", Marks = 55 },
//             new Student { Name = "C", Marks = 62 }
//         };

        
//         var result = students.Select(s => new
//         {
//             s.Name,s.Marks,
//             Grade = s.Marks > 60 ? "Pass" : "Fail"
//         }).ToList;

//         var st=students.OrderBy(e=> e.Marks);
//         foreach (var r in result)
//         {
//             Console.WriteLine($"{r.Name} - {r.Grade}");
//         }
//         foreach (var r1 in st)
//         {
//             Console.WriteLine($"{r1.Name} - {r1.Grade}");
//         }

//         Console.WriteLine(result.GetType());
//         Student  fS= students.First();
//         Console.WriteLine(fS.Name);
//     }
// }



// class Employee
// {
//     public string Name { get; set; }
//     public int Salary { get; set; }
// }
// class Program{
// List<Employee> employees = new List<Employee>
// {
//     new Employee { Name = "Amit", Salary = 50000 },
//     new Employee { Name = "Ravi", Salary = 70000 },
//     new Employee { Name = "Neha", Salary = 60000 }
// };
// var sortedBySalary = employees.OrderBy(e => e.Salary);
// var sortedBySalary = employees.OrderBy(e => e.Name);
// }