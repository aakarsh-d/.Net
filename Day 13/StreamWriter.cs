// using System.IO;

// class Program
// {
//     static void Main()
//     {
//         using(StreamWriter writer=new StreamWriter("log.txt"))
//         {
//             writer.WriteLine("Application Started");
//             writer.WriteLine("Processing Data");
//             writer.WriteLine("Application ENded");
//         }
//         using (StreamReader reader=new StreamReader("log.txt"))
//         {
//             string content;
//             while((content=reader.ReadLine())!=null)
//             {
//                 Console.WriteLine(content);
//             }
//         }
//     }
// }