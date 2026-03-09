    // using System.Diagnostics;

    // class Jewellery
    // {
    //     public string Id{get;set;}
    //     public string Type{get;set;}
    //     public string Material{get;set;}
    //     public int Price{get;set;}

    // }

    // class JewelleryUtility
    // {
    //     public Dictionary<string,string> GetJewelleryDetails(string id)
    //     {
    //         Dictionary<string,string> res=new Dictionary<string,string>();

    //         foreach(var j in Program.jewelleryDetails)
    //         {
    //             if(j.Value.Id.Equals(id))
    //             {
    //                 string val=j.Value.Type+"_"+j.Value.Material;
    //                 res.Add(j.Value.Id,val);
    //                 return res;
    //             }
    //         }
    //         return res;
    //     }

    //     public Dictionary<string,Jewellery> UpdateJewelleryProce(string id,int price)
    //     {
    //         Dictionary<string,Jewellery> result=new Dictionary<string,Jewellery>();

    //         foreach(var j in Program.jewelleryDetails)
    //         {
    //             if (j.Value.Id.Equals(id))
    //             {
    //                 j.Value.Price=price;
    //                 result.Add(j.Value.Id,j.Value);
    //                 return result;
    //             }
    //         }
    //             return result;
    //     }
    // }

    // class Program
    // {
    //     public static Dictionary<int ,Jewellery> jewelleryDetails = new Dictionary<int,Jewellery>();
    //     public static void Main()
    //     {
    //         jewelleryDetails.Add(1, new Jewellery { Id = "JW01", Type = "Bracelet", Material = "Silver", Price = 2000 });
    //         jewelleryDetails.Add(2, new Jewellery { Id = "JW02", Type = "Ring", Material = "Platinum", Price = 1000 });
    //         jewelleryDetails.Add(3, new Jewellery { Id = "JW03", Type = "Necklace", Material = "Gold", Price = 6000 });
    //         jewelleryDetails.Add(4, new Jewellery { Id = "JW04", Type = "Chain", Material = "Silver", Price = 5000 });


    //         JewelleryUtility jw=new JewelleryUtility();
    //         bool run=true;

    //         while (run)
    //         {
    //             Console.WriteLine("1. Get Jewellery Details");
    //             Console.WriteLine("2. Update Price");
    //             Console.WriteLine("3. Exit");
    //             Console.WriteLine();
    //             Console.WriteLine("Enter your choice");

    //             int choice=Convert.ToInt32(Console.ReadLine());

    //             switch(choice)
    //             {
    //             case 1:
    //                 Console.WriteLine("Enter Jewellery Id");
    //                 string id1=Console.ReadLine();

    //                 var details=jw.GetJewelleryDetails(id1);
    //                 if(details.Count==0)
    //                 Console.WriteLine("Jewelley Id not found");
    //                 else
    //                     {
    //                         foreach(var d in details)
    //                         {
    //                             Console.WriteLine(d.Key+" "+d.Value);
    //                         }
    //                     }
    //                     Console.WriteLine();
    //             break;
    //             case 2:
    //                 Console.WriteLine("Enter the jew id");
    //                 string id2=Console.ReadLine();

    //                 Console.WriteLine("Enter the price to be update");
    //                 int price =Convert.ToInt32(Console.ReadLine());
    //                 var updated=jw.UpdateJewelleryProce(id2,price);
    //                     if (updated.Count == 0)
    //                     {
    //                         Console.WriteLine("Jewel not found");
    //                     }
    //                     else
    //                     {
    //                         foreach(var d in updated)
    //                         {
    //                             Jewellery j=d.Value;
    //                             Console.WriteLine("Id : "+j.Id+", Price : "+j.Price);
    //                         }

    //                     }
    //                     Console.WriteLine();
                        
    //             break;
                
    //             case 3:
    //             Console.WriteLine("Thank You");
    //             run=false;
    //             break;


    //             }
    //         }
    //     }
    // }