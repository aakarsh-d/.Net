
// // 1) Inventory Lookup - Product Stock Finder

// // Create a dictionary for product code and stock count. Read a product code and print stock if present; otherwise print "Not Found".

// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         Dictionary<string, int> inventory = new Dictionary<string, int>
//         {
//             { "P101", 25 },
//             { "P102", 0 },
//             { "P103", 14 }
//         };

//         string inputCode = Console.ReadLine();
//         // TODO: Implement lookup and print result

//         if(inventory.TryGetValue(inputCode,out int val))
//         {
//             Console.WriteLine(val);
//         }
//         // if (inventory.ContainsKey(inputCode))
//         // {
//         //     Console.WriteLine(inventory[inputCode]);
//         // }
//         else 
//         Console.WriteLine("Not Found");
//     }
// }

