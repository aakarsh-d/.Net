// Day - 08 (Saturday)
// class CreatorStats
// {
//     public string CreatorName
//     { 
//         get; 
//         set; 
//     }
//     public double[] WeeklyLikes
//     { 
//         get; 
//         set;
//     }

// }

// class Program
// {
//     public static List<CreatorStats> EngagementBoard=new List<CreatorStats>();
//     public void RegisterCreator(CreatorStats record)
//     {
//         EngagementBoard.Add(record);
//     }

//     public Dictionary<string,int> GetTopPostCounts(List<CreatorStats> record, double likeThreshold)
//     {
//         Dictionary<string,int> result=new Dictionary<string,int>();
//         foreach(CreatorStats creator in record)
//         {
//             int ct=0;
//             foreach(double likes in creator.WeeklyLikes)
//             {
//                 if(likes>= likeThreshold)
//                 {
//                     ct++;
//                 }
//             }
//             if (ct > 0)
//             {
//                     result.Add(creator.CreatorName,ct);            
//             }
//         }
//             return result;

        
//     }

//     public double CalculateAvgLikes()
//     {
//         double totalLikes=0;
//         int totalWeeks=0;
//         foreach(CreatorStats creator in EngagementBoard)
//         {
//             foreach(double likes in creator.WeeklyLikes)
//             {
//                 totalLikes+=likes;
//                 totalWeeks++;
//             }
//         }
//         if(totalWeeks==0) return 0;

//         return totalLikes/totalWeeks;
//     }
//     public static void Main()
//     {

//         Program p=new Program();

//         int option=0;
//         do
//         {
//             Console.WriteLine("1. Register Creator");
//             Console.WriteLine("2. Show Top Posts");
//             Console.WriteLine("3. Calculate Average Likes");
//             Console.WriteLine("4. Exit");
//             option=Convert.ToInt32(Console.ReadLine());
//             switch (option)
//             {
//                 case 1: 
//                     CreatorStats creator=new CreatorStats();
//                     Console.Write("Enter Creator Name: ");
//                     creator.CreatorName=Console.ReadLine();
//                     creator.WeeklyLikes=new double[4];

//                     for(int i = 0; i < 4; i++)
//                     {
//                         Console.Write("Enter Weekly likes (week 1-4) :");
//                         creator.WeeklyLikes[i]=double.Parse(Console.ReadLine());
//                     }

//                     p.RegisterCreator(creator); // creator added succesfully

//                     Console.Write("Creator Registered Succesfully");
//                     Console.WriteLine();
//                     break;
//                 case 2: 

//                     Console.Write("Enter Like Threshold: ");
//                     double threshold=double.Parse(Console.ReadLine());

//                     Dictionary<string,int> topPosts = p.GetTopPostCounts(EngagementBoard,threshold);
//                     //  created a dic that will prompt a ref to engagement boards having creator data and min threshold 
//                     if (topPosts.Count == 0)
//                     {
//                         Console.Write("No Top-Performing posts this week");
//                     }
//                     else
//                     {
//                         foreach(var items in topPosts)
//                         {
//                             Console.Write($"{items.Key} - {items.Value}");
//                         }
//                     }
//                     break;
//                 case 3: 
//                     double avg=p.CalculateAvgLikes();
//                     Console.Write($"Overall average weekly likes: {avg}");
//                     break;
//                 case 4: 
//                     Console.WriteLine("Loging Off - Keep Creating with StreamBuzz!");
//                     break;
//                 default:
//                     Console.WriteLine("Invalid Option.");
//                     break;
//             }
//         }while(option!=4);
//     }
// }
