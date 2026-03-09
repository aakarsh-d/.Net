// using System;
// using System.Collections;
// using System.Linq;

// class Program
// {
//     static void Main()
//     {
        
//         ArrayList list = new ArrayList() { 1, "Mari", "MCA", 2000 };

//         var onlyIntegers = list.OfType<int>();

//         Console.WriteLine("Only integers:");
//         foreach (var i in onlyIntegers)
//             Console.WriteLine(i);


//         // -------------------------------
//         // 2. String array contains 7 names
//         //    Find the names that start with 'A'
//         // -------------------------------
//         string[] names =
//         {
//             "Arjun", "Aman", "Ravi", "Shiv",
//             "Ankit", "Kunal", "Dev"
//         };

//         var startWithA = names
//                             .Where(n => n.StartsWith("A"));

//         Console.WriteLine("\nNames starting with A:");
//         foreach (var n in startWithA)
//             Console.WriteLine(n);


//         // -------------------------------
//         // 3. Find the names that end with 'v'
//         //    and add "Mr " to it
//         // -------------------------------
//         var endWithV_AddMr = names
//                                 .Where(n => n.EndsWith("v"))
//                                 .Select(n => "Mr " + n);

//         Console.WriteLine("\nNames ending with v (with Mr added):");
//         foreach (var n in endWithV_AddMr)
//             Console.WriteLine(n);
//     }
// }


// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;

// class Program
// {
//     static void Main()
//     {
//         // ------------------------------------
//         // 1. Pick only integers using IEnumerable
//         // ------------------------------------
//         ArrayList list = new ArrayList() { 1, "Mari", "MCA", 2000 };

//         IEnumerable<int> onlyIntegers = list.OfType<int>();

//         Console.WriteLine("Only integers:");
//         foreach (int i in onlyIntegers)
//             Console.WriteLine(i);


//         // ------------------------------------
//         // 2. String array (7 names)
//         //    Find names starting with 'A'
//         // ------------------------------------
//         string[] names =
//         {
//             "Arjun", "Aman", "Ravi", "Shiv",
//             "Ankit", "Kunal", "Dev"
//         };

//         IEnumerable<string> startWithA =
//             names.Where(n => n.StartsWith("A"));

//         Console.WriteLine("\nNames starting with A:");
//         foreach (string n in startWithA)
//             Console.WriteLine(n);


//         // ------------------------------------
//         // 3. Names ending with 'v'
//         //    and add "Mr "
//         // ------------------------------------
//         IEnumerable<string> endWithV_AddMr =
//             names
//                 .Where(n => n.EndsWith("v"))
//                 .Select(n => "Mr " + n);

//         Console.WriteLine("\nNames ending with v (with Mr added):");
//         foreach (string n in endWithV_AddMr)
//             Console.WriteLine(n);
//     }
// }
