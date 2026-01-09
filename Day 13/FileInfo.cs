// using System;
// using System.IO;

// class Program
// {
//     static void Main()
//     {
//         FileInfo file=new FileInfo("sample.txt");

//         if (!file.Exists)
//         {
//             using (StreamWriter writer =file.CreateText())
//             {
//                 writer.WriteLine("FileINFO class");
//             }
        
//         }
//         Console.WriteLine("File Name: "+ file.Name);
//         Console.WriteLine("File Size: "+ file.Length+" Bytes");
//         Console.WriteLine("Created on: "+ file.CreationTime);
//     }
// }