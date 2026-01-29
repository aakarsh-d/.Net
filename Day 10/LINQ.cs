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