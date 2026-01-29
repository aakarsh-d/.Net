// using System;
// using System.Diagnostics;
// using DialingCodesApp;
// namespace DialingCodesApp
// {
//     public static class DialingCodes
//     {
//         public static Dictionary<int,string> GetEmptyDictionary()
//         {
//             return new Dictionary<int,string>();
//         }
//         public static Dictionary<int,string> GetExistingDictionary()
//         {
//             Dictionary<int,string> dialingcode=new Dictionary<int,string>();
//             dialingcode.Add(1, "United States of America");
//             dialingcode.Add( 55, "Brazil");
//             dialingcode.Add(91 ,"India");
//             return dialingcode;
//         }
//         public static Dictionary<int,string> AddCountryToEmptyDicitionary( int countrycode, string countryname)
//         {
//             Dictionary<int,string> dic=new Dictionary<int,string>();
//             dic.Add(countrycode, countryname);
           

//             return dic;
//         }
//         public static Dictionary<int,string> AddCountryToExistingDicitionary(Dictionary<int,string> existingdic, int countrycode, string countryname)
//         {
//             if (existingdic.ContainsKey(countrycode))
//             {
//                 existingdic[countrycode]=countryname;
//             }
//             else 
//             existingdic.Add(countrycode,countryname);

//             return existingdic;
//         }
//         public static string GetCountryNameFromDictionary(Dictionary<int, string> dictionary, int countrycode)
//         {
//             if (dictionary.ContainsKey(countrycode))
//             {
//                 return dictionary[countrycode];
//             }
//             return " ";
//         }

//         public static bool CheckCodeExists(Dictionary<int,string> existingDictionary, int countrycode)
//         {
//             if (existingDictionary.ContainsKey(countrycode))
//             {
//                 return true;
//             }
//             return false;
//         }
//         public static Dictionary<int,string> UpdateDictionary(Dictionary<int,string> existingDictionary,int countrycode,string countryname)
//         {
//             if (existingDictionary.ContainsKey(countrycode))
//             {
//                 existingDictionary[countrycode]=countryname;
//             }
//             return existingDictionary;
//         }
//         public static Dictionary<int,string> RemoveCountryFromDictionary(Dictionary<int,string> existingDictionary,int countrycode)
//         {
//             if (existingDictionary.ContainsKey(countrycode))
//             {
//                 existingDictionary.Remove(countrycode);
//             }
//             return existingDictionary;
//         }
//         public static string LongestCountryName(Dictionary<int,string> existingDictionary)
//         {
//             if(existingDictionary.Count==0)
//             {
//                 return "";
//             }

//             string LongestCountryName=" ";
//             foreach(string country in existingDictionary.Values)
//             {
//                 if(country.Length>LongestCountryName.Length)
//                 LongestCountryName=country;
//             }
//             return LongestCountryName;
//         }
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         Dictionary<int,string> emptydic=DialingCodes.GetEmptyDictionary();
//         Console.WriteLine("{ }empty dict count:"+emptydic.Count);

//         Dictionary<int,string> task2=DialingCodes.GetExistingDictionary();
//         foreach(var item in task2)
//         Console.WriteLine(item.Key+" : "+item.Value);

//         //task 3
//         int code;
//         string name;
//         code=Convert.ToInt32(Console.ReadLine());
//         name=Console.ReadLine();
//         Dictionary<int,string> task3=DialingCodes.AddCountryToEmptyDicitionary(code,name);
//         foreach(var item in task3)
//         Console.WriteLine(item.Key+" : "+item.Value);

//         //task4
        
//         int code4;
//         string name4;
//         code4=Convert.ToInt32(Console.ReadLine());
//         name4=Console.ReadLine();
//         DialingCodes.AddCountryToExistingDicitionary(task2,code4,name4);
//         foreach(var item in task2)
//         Console.WriteLine(item.Key+" : "+item.Value);

//         //taask 5

//         Console.WriteLine("Task 5: COuntry code to search");
//         int codetosearch=Convert.ToInt32(Console.ReadLine());
//         string res=DialingCodes.GetCountryNameFromDictionary(task2,codetosearch);
//         Console.WriteLine(res);

//         //task 6

//         Console.WriteLine("TAsk 6: Enter code to check");
//         int codetocheck=Convert.ToInt32(Console.ReadLine());
//         Console.WriteLine(DialingCodes.CheckCodeExists(task2,codetocheck));


//         // Task 7

//         int code7;
//         string name7;
//         code7=Convert.ToInt32(Console.ReadLine());
//         name7=Console.ReadLine();
//         DialingCodes.UpdateDictionary(task2, code7 ,name7);
//         foreach(var item in task2)
//         Console.WriteLine(item.Key+" : "+item.Value);

//         //task 8

//         //removing lastly entered
//         DialingCodes.RemoveCountryFromDictionary(task2,code7);
//         Console.WriteLine("Task 8 : REMOVE COUNTRY");
//         foreach(var item in task2)
//         Console.WriteLine(item.Key+" : "+item.Value);

//         //task 9
//         Console.WriteLine("Task 9");
//         Console.WriteLine(DialingCodes.LongestCountryName(task2));

//     }
// }