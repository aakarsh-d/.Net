// using System;
// using System.Runtime.InteropServices;
// class array
// {
//     // int[] num;
//     // int[] num= new int[5];
    
//     public static void Main()
//     {

//         // array dec and initialization
//     int[] num={1,2,3,4,5};
//         foreach(int i in num)
//         {
//         Console.Write(i+" ");
//         }
//         Console.WriteLine();
//         foreach(int i in num)
//         Array.Reverse(num,0,num.Length);
//         foreach(int i in num)
//         {
//         Console.Write(i+" ");
//         }
//         Console.WriteLine();
//         Array.Clear(num,0,num.Length);
//         foreach(int i in num)
//         {
//         Console.Write(i+" ");
//         }
//         Console.WriteLine();

//         // array copy 
//         int[] src={1,2,3};
//         int[] dest=new int[3];

//         Array.Copy(src,dest,3);
//         foreach(int i in dest)
//         {
//         Console.Write(i+" ");
//         }
//         Console.WriteLine();
//         int[] dest2=new int[3];
//         Array.Copy(src,dest2,2);
//         foreach(int i in dest2)
//         {
//         Console.Write(i+" ");
//         }
//         Console.WriteLine();

//         int[] resizenum={1,2};
//         Array.Resize(ref resizenum,0);
//         Console.WriteLine(resizenum.Length);
//         Array.Resize(ref resizenum,4);
//         Console.WriteLine(resizenum.Length);
//         int[] resizenum1={1,2,3};
//         Array.Resize(ref resizenum1,0);
//         Console.WriteLine(resizenum1.Length);

//         // without ref it is not working
//         // Array.Resize(resizenum,0);
//         // foreach(int i in resizenum)
//         // Console.WriteLine(resizenum);


//         // array.exist
//         int[] array={10,20,30,40};
//         bool found = Array.Exists(array, x => x > 10);
//         Console.WriteLine(found);
    
// }
// }