
// // 4) Login Attempt Tracker - Increment Value

// // Track failed login attempts per user. Increment attempts whenever a username is received.

// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         string[] attempts = { "raj", "kavi", "raj", "raj", "kavi" };
//         Dictionary<string, int> failedAttempts = new Dictionary<string, int>();
//         // TODO: Count attempts and print users with attempts >= 3
//         foreach(var attempt in attempts){
//         if(failedAttempts.ContainsKey(attempt))
//         failedAttempts[attempt]++;
//         else
//         failedAttempts[attempt]=1;
//         }
//         foreach(var a in failedAttempts)
//             if (a.Value >=3)
//             {
//                 Console.WriteLine(a.Key+$" Locked {a.Value} entries");
//             }
//     }
// }

