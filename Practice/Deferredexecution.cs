// class Program{
//     static void Main()
//     {
//         List<int> num=new List<int>{10,20,30,40};

//         var deferredquery=num.Where(x=>x>15);
//         num.Add(45);

//         foreach(var n in deferredquery)
//         {
//             Console.Write(" "+n);
//         }
//         Console.WriteLine();

//         var immediate =num.Where(x=>x>15).ToList();
//         num.Add(50);
//         foreach(var n in immediate)
//         {
//             Console.Write(" "+n);
//         }
//         Console.WriteLine();


//         List<int> list1=new List<int>{10,20,30,40,50,60};

//         int half=list1.Count()/2;

//         List<int> list2=list1.Take(half).ToList();
//         foreach(var l in list2)
//         {
//             Console.Write(" "+l);
//         }
//         Console.WriteLine();
//     }
// }



// int[] numbers = {1,2,3,4,5,6,7};

//         IEnumerable<int> result = numbers.SkipWhile(n => n < 5);

//         foreach (int n in result)
//         {
//             Console.WriteLine(n);
//         }
