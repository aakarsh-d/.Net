// using System;
// using System.IO;

// class User
// {
//     public int Id;
//     public string Name;

// }
// class Program
// {
//     static void Main()
//     {
//         User user =new User{ Id =1, Name="Alice"};

//        using (StreamWriter writer=new StreamWriter("user.txt"))
//         {
//             writer.WriteLine(user.Id);
//             writer.WriteLine(user.Name);
//             user.Id=2;
//             user.Name="Bob";
//             writer.WriteLine(user.Id);
//             writer.WriteLine(user.Name);

//         }
//         using (StreamReader reader =new StreamReader("user.txt"))
//         {
//             string content;
//             // while((content=reader.ReadLine())!=null){
//             // Console.WriteLine(content);}
//             user.Id=int.Parse(reader.ReadLine());
//             user.Name=reader.ReadLine();
//         }
//         Console.WriteLine($"User Loaded: {user.Id} , {user.Name}");
//     }
// }