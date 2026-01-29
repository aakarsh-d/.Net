// using System.ComponentModel.DataAnnotations;
// using System.Data.Common;
// using System.Net.Mail;

// class Program
// {
//     static (int Sum, int Avg,int diff)Calc(int a,int b){
//         return (a+b, (a+b)/2, a-b);
//     }

//     public static void Main(string[] args)
//     {
//         var student = ( Id: 101 , Name: "Amit");
//         (int,string) student1 = ( Id: 101 , Name: "Amit");
//         var obj= new {Name="Amit", Age=22};
//         Console.WriteLine(student.GetType());
//         Console.WriteLine(student1.GetType());
//         Console.WriteLine(obj.GetType());
//         Console.WriteLine(Calc(10,20));
//         Console.WriteLine(obj.GetType());

//     }
// }



// returning multiple values from a method

// using Microsoft.VisualBasic;

// class Program
// {
//     static (bool IsValid , string message) ValidateUser(string username){
//         if(string.IsNullOrEmpty(username)) return (false, "Username is required");

//         return (true,"Valid user");
//     }


// public static void Main(){
//     var response=ValidateUser("Admin");
//     Console.WriteLine(response.message);}
// }


//deconstructing a tuple

// using System.Data.Common;
// using Microsoft.VisualBasic;

// class Program
// {
//     static void Main()
//     {
//         var person = (Id: 101 , Name:"Neha"); //creating a tuple
//         Console.WriteLine(person.Id); // print 1

//         var (id,name)=person;
//         Console.WriteLine(id);
//         Console.WriteLine(id.GetType());
//         Console.WriteLine(person.GetType());

//         var(_,userName)=person; // _ to not get the value (as u cannot only use username in this case so use _ to skip that)
//         Console.WriteLine(userName.GetType());
//         Console.WriteLine(person.Name);
//     }
// }


// class Student
// {
//     public int Id { get; set; }
//     public string Name { get; set; }

//     public void Deconstruct(out int id, out string name)
//     {
//         id = Id;
//         name = Name;
//     }

//     public static void Main()
//     {
//         var s = new Student { Id = 1, Name = "Amit" };
//         Console.WriteLine(s.GetType());
//         // s.GetType();
//         var (sid, sname) = s;                                                                                                                                                                                                                                                                                                                   
//         Console.WriteLine(sid);
//         Console.WriteLine(sname);
// }
// }