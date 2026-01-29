// class Program
// {

//     public string CleanseAndInvert(string password)
//     {
//         if(password == null || password.Length < 6)
//         {
//             return "";
//         }
//         foreach(char c in password)
//         {
//             if(!char.IsLetter(c))
//             return "";
//         }

//         password=password.ToLower();

//         string newpass="";
//         foreach(char c in password)
//         {
//             if((int)c%2!=0)
//             newpass+=c;
//         }
//         char[] arr=newpass.ToCharArray();
//         Array.Reverse(arr);

//         for(int i = 0; i < arr.Length; i++)
//         {
//             if (i % 2 == 0)
//             {
//                 arr[i]=char.ToUpper(arr[i]);
//             }
//         }
//         return new string(arr);
//     }
//     public static void Main(string[] args)
//     {
//         Console.WriteLine("Enter the word: ");
//         String input=Console.ReadLine();
//         Program p=new Program();
//         string res=p.CleanseAndInvert(input);

//         if (res == "")
//         {
//             Console.WriteLine("Invalid Input");
//         }
//         else
//         {
//             Console.WriteLine("The Generated key is - "+ res);
//         }
//     }
// }