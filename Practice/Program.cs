
// // using System;

// // Console.WriteLine("Practice project is running successfully");


// void Increment(int x)
// {
//     x++;

// }
// class Program
// {
//     static void Main(string[] args)
//     {
// int a=5;
// Increment(a);
//     }}


// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Program
// {  
//     // Hardcoded item details (already provided in template)
//     public static SortedDictionary<string, long> itemDetails =
//         new SortedDictionary<string, long>()
//         {
//             { "Pen", 150 },
//             { "Notebook", 300 },
//             { "Pencil", 100 },
//             { "Eraser", 50 }
//         };

//     // Find item details by sold count
//     public static SortedDictionary<string, long> FindItemDetails(long soldCount)
//     {
//         SortedDictionary<string, long> result = new SortedDictionary<string, long>();

//         //Write your Logic below
//         foreach(var s in itemDetails)
//         {
//             if(s.Value==soldCount)
//                 result.Add(s.Key,s.Value);
//         }

//         return result;
//     }

//     // Find minimum and maximum sold items
//     public static List<string> FindMinandMaxSoldItems()
//     {
//         List<string> result = new List<string>();
//         //Write your Logic below
//         long maxsold=itemDetails.Values.Max();
//         long minsold=itemDetails.Values.Min();
//         foreach(var s in itemDetails)
//         {
//             if(s.Value==minsold) result.Add(s.Key);
//         }

//         foreach(var s in itemDetails){
//             if(s.Value==maxsold) result.Add(s.Key);
//         }

//         return result;
//     }

//     // Sort items by sold count
//     public static Dictionary<string, long> SortByCount()
//     {
//         Dictionary<string, long> sortedResult =null;
//           //Write your logic below 
//           sortedResult=itemDetails.OrderBy(p=>p.Value).ToDictionary(p=>p.Key,p=>p.Value);

//         return sortedResult;
//     }

//     static void Main(string[] args)
//     {
//         // Hardcoded sold count
//         long soldCount = 100;

//         // Call FindItemDetails
//         SortedDictionary<string, long> foundItems = FindItemDetails(soldCount);

//         if (foundItems.Count == 0)
//         {
//             Console.WriteLine("Invalid sold count");
//         }
//         else
//         {
//             Console.WriteLine("Item Details:");
//             foreach (var item in foundItems)
//             {
//                 Console.WriteLine(item.Key + " : " + item.Value);
//             }
//         }

//         // Find minimum and maximum sold items
//         List<string> minMaxItems = FindMinandMaxSoldItems();
//        //Write your code below
//         Console.WriteLine("Minimum Sold Item: "+minMaxItems[0]);
//         Console.WriteLine("Maximum Sold Item: "+minMaxItems[1]);
//         // Sort items by sold count
//         Dictionary<string, long> sortedItems = SortByCount();
//         Console.WriteLine("Items Sorted by Sold Count:");
//         //Write your code below
//         Dictionary<string,long> sortbycount=SortByCount();
//         foreach(var i in sortbycount){
//             Console.WriteLine($"{i.Key} : {i.Value}");
//         }
        
//     }
// }





// using System.Data.SqlClient;
// SqlConnection con = new SqlConnection();


// using Microsoft.Data.SqlClient;

// string cs =
//     "Server=(localdb)\\MSSQLLocalDB;Database=YourDB;Trusted_Connection=True;";

// using SqlConnection con = new SqlConnection(cs);
// con.Open();
// Console.WriteLine("Connected");







public class Student
{
    public string Id{get;set;}
    public string Name{get;set;}
    public string Course{get;set;}
    public int Marks{get;set;}
}

public class StudentUtility
{
    public Dictionary<string,string> GetStudentsDetail(string id)
    {
        Dictionary<string,string> res=new Dictionary<string,string>();
        foreach(var i in Program.studentsDetails.Values)
        {
            if (i.Id == id)
            {
                res.Add(i.Id,i.Name+"_"+i.Course);
                break;
            }
        }
        return res;

    }


    public Dictionary<string,Student> UpdateStudentMarks(string id,int marks)
    {
        Dictionary<string,Student> res=new Dictionary<string,Student>();
        foreach(var i in Program.studentsDetails.Values)
        {
            if (i.Id == id)
            {
                i.Marks=marks;
                res.Add(i.Id,i);
                break;
            }
        }
            return res;
    }

}

public class Program
{
    public static Dictionary<int,Student> studentsDetails;
    static void Main()
    {
        studentsDetails=new Dictionary<int,Student>();
        studentsDetails.Add(1,new Student
        {
            Id="1",
            Name="B",
            Course="C",
            Marks=67
        }) ;  
         studentsDetails.Add(1,new Student
        {
            Id="3",
            Name="c",
            Course="D",
            Marks=67
        }) ;  

        StudentUtility su=new StudentUtility();
        bool r=true;

        while (r)
        {
            Console.WriteLine("1.Get Student Details");
            Console.WriteLine("2.Update Marks");
            Console.WriteLine("3.Exit");
            Console.WriteLine("Enter your choice");
            int choice=int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                Console.WriteLine("Enter the students id");
                string id1=Console.ReadLine();

                var details=su.GetStudentsDetail(id1);
                    if (details.Count == 0)
                    {
                        Console.WriteLine("Studetn id not found");
                    }
                    else
                    {
                        foreach(var d in details)
                        {
                            Console.WriteLine(d.Key+" "+d.Value);
                        }
                    }
                    break;

                    case 2:
                    Console.WriteLine("Enter student id");
                    string id2=Console.ReadLine();

                    Console.WriteLine("Enter your marks");

                    int marks=int.Parse(Console.ReadLine());

                    var upd=su.UpdateStudentMarks(id2,marks);

                    if(upd.Count == 0)
                    {
                        Console.WriteLine("Student id not found");
                        
                    }
                    else
                    {
                        foreach(var u in upd)
                        {
                            Console.WriteLine(u.Key+" "+u.Value);
                        }
                    }
                    break;

                    case 3:
                    Console.WriteLine("Thank You");
                    r=false;
                    break;
            }
        }
    }   

}



