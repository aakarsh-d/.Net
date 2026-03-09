// // class Program
// // {
// //     static void Main(){
// //     int[] num={ 1,2,3,4,5,6};
// //     var evenNum = num.Where(n=> n%2==0); //LINQ

// //     Console.WriteLine(evenNum.GetType());
// //     var n1=(num.Where(n=>n>3).Select(n=>n*2));
// //     Console.WriteLine(n1.GetType());
// //     // Console.WriteLine(n1);
// //     Console.WriteLine("Even numbers are: ");
// //     foreach(var n in evenNum)
// //         {
// //             Console.Write(n+" ");
// //         }

// // }
// // }



// class Student
// {
//     public string Name { get; set; }
//     public string Grade { get; set;}
//     public int Marks { get; set;}
// }
// class Program
// {
//     static void Main()
//     {
//         List<Student> students = new List<Student>()
//         {
//             new Student { Name = "Amit", Marks = 75 },
//             new Student { Name = "Riya", Marks = 55 },
//             new Student { Name = "Neha", Marks = 90 }
//         };

//         var result = students.Select(s => new
//         {
//             s.Name,
//             Grade = s.Marks > 60 ? "Pass" : "Fail"
//         }).ToList();
//         var ascending = result.OrderBy(r=>r.Grade);
//         var descending = result.OrderByDescending(r=>r.Grade);

//         Console.WriteLine(result.GetType());
//         foreach (var r in result)
//         {
//             Console.WriteLine("name: "+r.Name+"  grade  "+r.Grade);
//         }
//         foreach (var r in ascending)
//         {
//             Console.WriteLine(r);
//         }
//         foreach (var r in descending)
//         {
//             Console.Write(r);
//         }

//     }
// }


// class Program
// {
//     static void Main()
//     {
//         int[] numbers={1,2,3,4,5,6};

//         var evenNum= from n in numbers where n%2==0 select n;
//         Console.WriteLine("Output: ");
//         foreach(var n in evenNum)
//         {
//             Console.WriteLine( n);
//         }

//         //even no

//         evenNum=numbers.Where(n=>n%2==0);
//         foreach(var n in evenNum)
//         {
//             Console.WriteLine( n);
//         }

//         //max no
//         int maxNum=numbers.Max();
//         Console.WriteLine("Max: "+maxNum);


//         //Linq  in collection

//         List <int> no=new List<int>(){10,20,30,40,45};
//         var res=no.Where(n=>n>30);
//         foreach(var n in res)
//         {
//             Console.Write(" "+n);
//         }

//         //select (to manipulate inside brackets )

//         var sq=numbers.Select(n=>n*n);
//         foreach(var n in sq)
//         {
//             Console.WriteLine(n);
//         }

//         var ordered=numbers.OrderBy(n=>n);
//         foreach(var n in ordered)
//         {
//             Console.WriteLine(n);
//         }

//         // OrderBydescending(n=>n)
//         // Take(3)
//         //Skip(2)
//         //num.Count();
//         //num.Sum();
//         //num.Min();
//         //num.FirstOrDefault(n=>n>40);
//         //num.Any(n=>n>25);

//         // 3. OrderBy
//         // Console.WriteLine("\n3. OrderBy");
//         // var ordered = numbers.OrderBy(n => n);
//         // Print(ordered);

//         // 4. OrderByDescending
//         Console.WriteLine("\n4. OrderByDescending");
//         Print(numbers.OrderByDescending(n => n));

//         // 5. Take
//         Console.WriteLine("\n5. Take ( first 3 )");
//         Print(numbers.Take(3));

//         // 6. Skip
//         Console.WriteLine("\n6. Skip ( first 2 )");
//         Print(numbers.Skip(2));

//         // 7. Count
//         Console.WriteLine("\n7. Count");
//         Console.WriteLine(numbers.Count());

//         // 8. Sum
//         Console.WriteLine("\n8. Sum");
//         Console.WriteLine(numbers.Sum());

//         // 9. Max
//         Console.WriteLine("\n9. Max");
//         Console.WriteLine(numbers.Max());

//         // 10. Min
//         Console.WriteLine("\n10. Min");
//         Console.WriteLine(numbers.Min());

//         // 11. Average
//         Console.WriteLine("\n11. Average");
//         Console.WriteLine(numbers.Average());

//         // 12. FirstOrDefault
//         Console.WriteLine("\n12. FirstOrDefault ( > 50 )");
//         Console.WriteLine(numbers.FirstOrDefault(n => n > 50));

//         // 13. Any
//         Console.WriteLine("\n13. Any ( > 25 )");
//         Console.WriteLine(numbers.Any(n => n > 25));

//         // 14. Distinct
//         Console.WriteLine("\n14. Distinct");
//         Print(numbers.Distinct());

//         // 15. Aggregate
//         Console.WriteLine("\n15. Aggregate ( Multiply All )");
//         int product = numbers.Aggregate((a, b) => a * b);
//         Console.WriteLine(product);
//     }

// // List<string> a="Mari","Shiva","Arjun",Daniel,"University"

// // 1.) find total no of elements using linq
// // 2.) list all the name that are more than 4 char





// // using System.Collections.Generic;
// // using System.Linq;
// // using System;
// //     public class Student
// //     {
// //         public int StudentId { get; set;}
// //         public string Name { get; set;}
// //     }
// //     public class Courses
// //     {
// //         public int StudentId { get; set;}  
// //         public int CourseName { get;set;}
// //     }
// //     class Program{
    
// //     static void Main()
// //     {
// //     List<Student> student=new List<Student>
// //     {
// //         new Student(StudentId=1,Name="Ravi"),
// //         new Student(StudentId=2,Name="Anu"),
// //         new Student(studentId=3,Name="Ravi")
// //     };

// //     List<Courses> course=new List<Courses>
// //     {
// //         new Courses(StudentId=1,CourseName="C++"),
// //         new Courses(StudentId=2,CourseName="Python"),
// //         new Courses(StudentId=3,CourseName="C#"),
// //     };

// //     var res= from s in student join c in course on s.StudenetId equals c.StudenetId
// //     select new {StudentName=s.Name,
// //     CourseName=c.CoursesName};
    

// //     Console.WriteLine("Inner Join:\n");
// //     foreach(var i in res)
// //         {
// //             Console.WriteLine(i.StudentId);
// //             Console.WriteLine(i.StudentName);
// //             Console.WriteLine(i.CourseName);
// //         }
// //     }
// // }

// using System;
// using System.Collections.Generic;
// using System.Linq;

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Students collection
//            List<Student> students = new List<Student>
//            {
//                new Student { StudentId = 1, StudentName = "Ravi" },
//                new Student { StudentId = 2, StudentName = "Anu" },
//                new Student { StudentId = 3, StudentName = "Kumar" }
//            };

//            // Courses collection
//            List<Course> courses = new List<Course>
//            {
//                new Course { StudentId = 1, CourseName = "C#" },
//                new Course { StudentId = 1, CourseName = "SQL" },
//                new Course { StudentId = 2, CourseName = ".NET" }
//            };

//            // INNER JOIN using LINQ (Query Syntax)
//            var result =
//                from s in students
//                join c in courses
//                    on s.StudentId equals c.StudentId
//                select new
//                {
//                    StudentName = s.StudentName,
//                    CourseName = c.CourseName
//                };

//            // Print result
//            Console.WriteLine("\nINNER JOIN RESULT:");

//            foreach (var item in result)
//            {
//                Console.WriteLine($"{item.StudentName} - {item.CourseName}");
//            }
//        }
   
//    // Student class
//    class Student
//    {
//        public int StudentId { get; set; }
//        public string StudentName { get; set; }
//    }

//    // Course class
//    class Course
//    {
//        public int StudentId { get; set; }
//        public string CourseName { get; set; }
//    }
// }

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> elements = new List<string>
        {
            "Mari", "Shiva", "Arjun", "Daniel", "University"
        };

        // Q1: count all elements
        var res = elements.Count();
        Console.WriteLine("Total Elements: " + res);

        // Q2: list all names that are more than 4 characters long
        var cLength = elements.Where(n => n.Length > 4);

        foreach (var element in cLength)
        {
            Console.WriteLine("Elements with more than 4 chars: " + element);
        }

        // Q3: list all names that start with A
        var startA = elements.Where(n => n.StartsWith("A"));

        foreach (var element in startA)
        {
            Console.WriteLine("Elements starting with A: " + element);
        }

        // Q4: take only first 2 characters of each name
        var r = elements.Select(n => n.Substring(0, 2));

        foreach (var item in r)
        {
            Console.WriteLine("First 2 chars: " + item);
        }
    }
}
