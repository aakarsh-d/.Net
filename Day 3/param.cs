// class Param
// {
//     public int Sum(params int[] numbers)  
//     // methods can have only one params keyword

//     // params must be the last parameter in the method signature
//     //no params are allowed after params
//     // default second last parameter
//     //we cannot use params with ref or in or out keywords
//     {
//         int total = 0;
//         foreach(int n in numbers)
//         {
//             total+=n;
//         }
//         return total;
//     }

// }
// class R
// {
//     public static void Main()
//     {
//         Param p= new Param();
//         // int[] numbers = new int[10];
//         // numbers[0]=1;
//         // numbers[1]=2;   
//         Console.WriteLine(p.Sum(10,20,30));
//         Console.WriteLine(p.Sum(10,20,30,40,50));
//     }
// }