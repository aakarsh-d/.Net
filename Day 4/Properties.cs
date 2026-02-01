// using System;
// class Student
// {
//     private string name;
//     private int age;
//     private int marks;
//     public string Name
//     {
//         get{return name;}
//         set{name=value;}
//     }
//     public int Age
//     {
//         get{return age;}
//         set{if(value>0 && value<100) age=value;}
//     }

// }

// class Program
// {
//     static void Main()
//     {
//         Student s=new Student();
//         s.Name="Aakarsh";
//         s.Age=21;
//         Console.WriteLine($"Name: {s.Name}, Age: {s.Age}");
//     }
// }

// Properties Implementation


// PART A: Auto-Implemented Property
// Requirement
// Store the Student ID.
// Rules:
// ● No validation required
// ● Direct get and set allowed
// Task Instruction
// Use an auto-implemented property.
// Hint
// Auto-implemented properties do not require a private backing field.
// PART B: Read-Only Property
// Requirement
// Calculate Result Status based on marks.
// Rules:
// ● Marks ≥ 40 → “Pass”
// ● Marks < 40 → “Fail”
// ● Value should be readable
// ● Value should NOT be set from outside
// Task Instruction
// Create a read-only property.
// PART C: Write-Only Property
// Requirement
// Store Password securely.
// Rules:
// ● Password can be set
// ● Password must NOT be readable
// ● Password length must be at least 6 characters
// Task Instruction
// Create a write-only property.
// PART D: Normal Property with Validation (Revision)
// Requirement
// ● Name cannot be empty
// ● Age must be greater than 0
// ● Marks must be between 0 and 100




// using System;
// public class Student
// {
//     private string name;
//     private int age;
//     private int marks;
//     private string password;
//     public int studentId{get;set;}
//     public int RegistrationNo{get;private set;}
//     public int AdmissionYear{get;init;}
//     public double Percentage=>(marks/100.0)*100;

//     public Student(int regno)
//     {
//         RegistrationNo=regno;
//     }
//     public string Name
//     {
//         get{return name;}
//         set{if(!string.IsNullOrEmpty(value)) name=value;}
//     }
//     public int Age
//     {
//         get{return age;}
//         set{if(value>0)age=value;}
//     }
//     public int Marks
//     {
//         get{return marks;}
//         set{if(value>=0 && value<=100)marks=value;}
//     }
//     public string Result
//     {
//         get{return marks>=40?"Pass":"Fail";}
//     }
//     public string Password
//     {
//         set{if(value.Length>=6)password=value;}
//     }
//     // private string name{get;set;}
//     // private int result{get }
//     // private string password{ set {password=value;}}

// }
// class Program
// {
//     static void Main(){
//     Student s=new Student(5001)
//     {
//         AdmissionYear=2015
//     };
//     s.Name="Aakarsh";
//     s.studentId=123;
//     s.Age=12;
//     s.Marks=85;
//     s.Password="Hello";
//     Console.WriteLine("\nName:" +s.Name);
//     Console.WriteLine("\nAge:" +s.Age);
//     Console.WriteLine("\nMarks:" +s.Marks);
//     Console.WriteLine("\nResult:" +s.Result);
//     Console.WriteLine("\nAdmission Year: " +s.AdmissionYear);
//     // Console.WriteLine("\nPassword:" +s.Password); // will not work cuz pvt
//     Console.WriteLine("\nStudent Id:" +s.studentId);
//     Console.WriteLine("\nReg No:" +s.RegistrationNo);
//     Console.WriteLine("\nPercentage:" +s.Percentage);

//     }
// }