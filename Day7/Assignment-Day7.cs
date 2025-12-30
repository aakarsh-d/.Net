
// // using System;

// // class Program
// // {
// //     public static void Main(String[] args)
// //     {
// //         // Console.WriteLine("Enter Size :");
// //         // int size = Convert.ToInt32(Console.ReadLine());

// //         // int[] arr = new int[size];

// //         // Console.WriteLine("Enter Products: ");
// //         // for (int i = 0; i < size; i++)
// //         // {
// //         //     int a = Convert.ToInt32(Console.ReadLine());
// //         //     if (a > 0)
// //         //     {
// //         //         arr[i] = a;
// //         //     }
// //         // }

// //         // // Sort
// //         // Array.Sort(arr);
// //         // Console.Write("Sorted : ");
// //         // foreach(int i in arr)
// //         // {
// //         //     Console.WriteLine(i);
// //         // }
// //         // // Calculate average (without LINQ)
// //         // int res = 0;
// //         // for (int i = 0; i < size; i++)
// //         // {
// //         //     res += arr[i];
// //         // }
// //         // res /= size;

// //         // Console.WriteLine("Average of prices: " + res);

// //         // // Replace below average with 0
// //         // for (int i = 0; i < size; i++)
// //         // {
// //         //     if (arr[i] < res)
// //         //     {
// //         //         arr[i] = 0;
// //         //     }
// //         // }

// //         // // Resize array
// //         // int oldlen = arr.Length;
// //         // Array.Resize(ref arr, oldlen + 5);

// //         // // Fill new positions with average
// //         // for (int i = oldlen; i < arr.Length; i++)
// //         // {
// //         //     arr[i] = res;
// //         // }

// //         // // Display final array with index
// //         // Console.WriteLine("Final Array:");
// //         // for (int i = 0; i < arr.Length; i++)
// //         // {
// //         //     Console.WriteLine("Index " + i + " : " + arr[i]);
// //         // }


// //         //task 2

// //         Console.WriteLine("Enter No of branches: ");
// //         int a=3;
// //         int branches=Convert.ToInt32(Console.ReadLine()); 
// //         Console.WriteLine("Enter No of months: ");
// //         int months=Convert.ToInt32(Console.ReadLine()); 
// //         int[,] branchsales=new int[branches,months];
// //         Console.WriteLine("Enter Sales Data: ");
// //         for(int i = 0; i < branches; i++)
// //         {
// //             for(int j = 0; j < months; j++)
// //             {
// //                 Console.Write($"Branch {i}, Month {j}: ");
// //                 branchsales[i,j]=Convert.ToInt32(Console.ReadLine());
// //             }
// //         }
// //         int highestsales=int.MinValue;
// //         for(int i=0;i<branches;i++)
// //         {
// //             int branchtotal=0;
// //             for(int j = 0; j < months; j++)
// //             {
// //                 branchtotal+=branchsales[i,j];
// //                 if (branchsales[i, j] > highestsales)
// //                 {
// //                     highestsales=branchsales[i, j];;
// //                 }
// //             }
// //             Console.WriteLine("Total Sales for Branch "+i+" : "+branchtotal);

// //         }
// //         Console.WriteLine("Highest monthly sales accros all branches : "+highestsales);
    

        
// //     }
// // }




using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //   TASK 1
        Console.WriteLine("\nTASK 1: PRODUCT PRICE ANALYSIS");

        Console.Write("Enter number of products: ");
        int pCount = int.Parse(Console.ReadLine());

        int[] prices = new int[pCount];

        for (int i = 0; i < pCount; i++)
        {
            Console.Write("Enter price: ");
            int val = int.Parse(Console.ReadLine());
            prices[i] = val > 0 ? val : 0;
        }

        int sum = 0;
        for (int i = 0; i < pCount; i++)
            sum += prices[i];

        int avgPrice = sum / pCount;

        Array.Sort(prices);

        for (int i = 0; i < pCount; i++)
            if (prices[i] < avgPrice)
                prices[i] = 0;

        int oldLen = prices.Length;
        Array.Resize(ref prices, oldLen + 5);

        for (int i = oldLen; i < prices.Length; i++)
            prices[i] = avgPrice;

        Console.WriteLine("Final Product Price Array:");
        for (int i = 0; i < prices.Length; i++)
            Console.WriteLine("Index " + i + " : " + prices[i]);

//   Task 2
        Console.WriteLine("\nTASK 2: BRANCH SALES ANALYSIS");

        Console.Write("Enter number of branches: ");
        int branches = int.Parse(Console.ReadLine());

        Console.Write("Enter number of months: ");
        int months = int.Parse(Console.ReadLine());

        int[,] branchSales = new int[branches, months];

        for (int i = 0; i < branches; i++)
        {
            for (int j = 0; j < months; j++)
            {
                Console.Write($"Branch {i}, Month {j}: ");
                branchSales[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int highestSale = int.MinValue;

        for (int i = 0; i < branches; i++)
        {
            int branchTotal = 0;

            for (int j = 0; j < months; j++)
            {
                branchTotal += branchSales[i, j];
                if (branchSales[i, j] > highestSale)
                    highestSale = branchSales[i, j];
            }

            Console.WriteLine("Total sales for Branch " + i + " : " + branchTotal);
        }

        Console.WriteLine("Highest monthly sale: " + highestSale);

        //  Task 3
        Console.WriteLine("\nTASK 3: PERFORMANCE-BASED EXTRACTION");

        int[][] jaggedSales = new int[branches][];

        for (int i = 0; i < branches; i++)
        {
            int count = 0;

            for (int j = 0; j < months; j++)
                if (branchSales[i, j] >= avgPrice)
                    count++;

            jaggedSales[i] = new int[count];

            int idx = 0;
            for (int j = 0; j < months; j++)
                if (branchSales[i, j] >= avgPrice)
                    jaggedSales[i][idx++] = branchSales[i, j];
        }

        for (int i = 0; i < jaggedSales.Length; i++)
        {
            Console.Write("Branch " + i + ": ");
            if (jaggedSales[i].Length == 0)
                Console.Write("No qualifying sales");
            else
                foreach (int v in jaggedSales[i])
                    Console.Write(v + " ");
            Console.WriteLine();
        }

        // task
        
        Console.WriteLine("\nTASK 4: CUSTOMER TRANSACTION CLEANING");

        Console.Write("Enter number of customer IDs: ");
        int cCount = int.Parse(Console.ReadLine());

        List<int> customers = new List<int>();
        for (int i = 0; i < cCount; i++)
            customers.Add(int.Parse(Console.ReadLine()));

        int originalCount = customers.Count;

        HashSet<int> uniqueCustomers = new HashSet<int>(customers);
        customers = new List<int>(uniqueCustomers);

        Console.WriteLine("Cleaned Customer IDs:");
        foreach (int id in customers)
            Console.Write(id + " ");

        Console.WriteLine("\nDuplicates removed: " + (originalCount - customers.Count));

        /* ================= TASK 5 ================= */
        Console.WriteLine("\nTASK 5: FINANCIAL TRANSACTION FILTERING");

        Console.Write("Enter number of transactions: ");
        int tCount = int.Parse(Console.ReadLine());

        Dictionary<int, double> transactions = new Dictionary<int, double>();

        for (int i = 0; i < tCount; i++)
        {
            Console.Write("Transaction ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Amount: ");
            double amt = double.Parse(Console.ReadLine());

            if (!transactions.ContainsKey(id))
                transactions.Add(id, amt);
        }

        SortedList<int, double> highValue = new SortedList<int, double>();

        foreach (KeyValuePair<int, double> kv in transactions)
            if (kv.Value >= avgPrice)
                highValue.Add(kv.Key, kv.Value);

        Console.WriteLine("High-Value Transactions:");
        foreach (KeyValuePair<int, double> kv in highValue)
            Console.WriteLine(kv.Key + " -> " + kv.Value);

        /* ================= TASK 6 ================= */
        Console.WriteLine("\nTASK 6: PROCESS FLOW MANAGEMENT");

        Console.Write("Enter number of operations: ");
        int opCount = int.Parse(Console.ReadLine());

        Queue q = new Queue();
        Stack s = new Stack();

        for (int i = 0; i < opCount; i++)
        {
            string op = Console.ReadLine();
            q.Enqueue(op);
            s.Push(op);
        }

        Console.WriteLine("Processed Operations:");
        while (q.Count > 0)
            Console.WriteLine(q.Dequeue());

        Console.WriteLine("Undo Operations:");
        for (int i = 0; i < 2 && s.Count > 0; i++)
            Console.WriteLine(s.Pop());

        /* ================= TASK 7 ================= */
        Console.WriteLine("\nTASK 7: LEGACY DATA RISK");

        Console.Write("Enter number of users: ");
        int uCount = int.Parse(Console.ReadLine());

        Hashtable table = new Hashtable();
        ArrayList legacyList = new ArrayList();

        for (int i = 0; i < uCount; i++)
        {
            Console.Write("Username: ");
            string user = Console.ReadLine();

            Console.Write("Role: ");
            string role = Console.ReadLine();

            table[user] = role;
            legacyList.Add(user);
            legacyList.Add(role);
            legacyList.Add(i); // mixed type
        }

        Console.WriteLine("\nHashtable Data:");
        foreach (DictionaryEntry d in table)
            Console.WriteLine(d.Key + " -> " + d.Value);

        Console.WriteLine("\nArrayList Data (Mixed Types):");
        foreach (object obj in legacyList)
            Console.WriteLine(obj);
    }
}
