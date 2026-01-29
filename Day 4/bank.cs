// class Student
// {
//         string name;
//         int age;
//         int marks;
//         int studentID;
//         string password;

//         public string Name
//     {
//         get{return name;}
//         set{
//             if(value !=" "){
//                 name=value;
//             }
//         }
//     }
//     public int Age{
//         get{return age;}
//         set{
//             if(value>0){
//                 age=value;
//             }
//         }
//     }
//     public int Marks
// {
//     get{return marks;}
//     set{
//         if(value>=0 && value<=100)
//         {
//             marks=value;
//         }
//     }
   
// }
//     public int StudentID
//     {
//        get{return studentID;} 
//        set{studentID=value;}
//     } 
//     public string Password//write-only
//     {
//         get{return password;}
//         set
//         {
//             if (value.Length >= 6)
//             {
//                 password=value;
//             }
//         }
//     }
//     public string Result//read only
//     {
//         get
//         {
//             if (marks >= 40)
//             {
//                 return "Pass";
//             }
//             else
//             {
//                 return "Fail";
//             }
//         }
//     }
// }
// class P
// {
//     public static void Main()
//     {
//         Student s=new Student();
//         s.Name="mufasa";
//         s.Age=22;
//         s.Marks=35;
//         s.Password="7638";
//         s.StudentID=56;
//         Console.WriteLine(s.Name);
//         Console.WriteLine(s.Age);
//         Console.WriteLine(s.Marks);
//         Console.WriteLine(s.Password);
//         Console.WriteLine(s.Result);
//         Console.WriteLine(s.StudentID);
//     }
// }