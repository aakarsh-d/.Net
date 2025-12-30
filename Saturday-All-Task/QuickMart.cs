// using System.Diagnostics;
// using System.Reflection.Metadata;
// using System.Runtime.CompilerServices;

// public class SaleTransaction
// {
//     public string InvoiceNo;
//     public string CustomerName;
//     public string ItemName;
//     public int Quantity;
//     public decimal PurchaseAmount;
//     public decimal SellingAmount;
//     public string PorfitOrLossStatus="";
//     public decimal ProfitorLossAmount;
//     public decimal ProfitMarginPercent;
    
// }

// public class Transactions
// {
//     public static SaleTransaction LastTransaction=null;
//     public static bool HasLastTransaction=false;
//     public static void Createorregister()
//     {
//     SaleTransaction sale=new SaleTransaction();
//     do{
//     Console.Write("Enter Invoice No: ");
//     sale.InvoiceNo=Console.ReadLine();
//     }while(string.IsNullOrWhiteSpace(sale.InvoiceNo) );

//     // Console.WriteLine();

//     Console.Write("Enter Customer Name: ");
//     sale.CustomerName=Console.ReadLine();

//     // Console.WriteLine();

//     Console.Write("Enter Item Name: ");
//     sale.ItemName=Console.ReadLine();

//     // Console.WriteLine();
    
//     // taking quantity and even checking <0
//         do
//         {
//             Console.Write("Enter Quantity: (only Positive) ");
//             sale.Quantity=Convert.ToInt32(Console.ReadLine());
//             // sale.Quantity=decimal.TryParse(Console.ReadLine(),out sale.Quantity);
//         }while(sale.Quantity<0);

//     //taking purchase amount and even checking condition
//         do{
//             Console.Write("Enter Purchase Amount :");
//         }
//         while(!decimal.TryParse(Console.ReadLine(), out sale.PurchaseAmount) || sale.PurchaseAmount <0);
        
//     // taking selling amount 
//         do{
//             Console.Write("Enter Selling Amount :");
//         }
//         while(!decimal.TryParse(Console.ReadLine(), out sale.SellingAmount) || sale.SellingAmount <=0);
    
//     if(sale.SellingAmount>sale.PurchaseAmount)
//         {
//             sale.PorfitOrLossStatus="PROFIT";
//             sale.ProfitorLossAmount=sale.SellingAmount-sale.PurchaseAmount;
//         }
//     else if (sale.SellingAmount < sale.PurchaseAmount)
//         {
//             sale.PorfitOrLossStatus="LOSS";
//             sale.ProfitorLossAmount=sale.PurchaseAmount-sale.SellingAmount;
//         }
//     else if(sale.SellingAmount == sale.PurchaseAmount)
//         {
//             sale.PorfitOrLossStatus="BREAK-EVEN";
//             sale.ProfitorLossAmount=0;
//         }

//     sale.ProfitMarginPercent=(sale.ProfitorLossAmount/sale.PurchaseAmount)/100;

//     LastTransaction=sale;
//     HasLastTransaction=true;

//     Console.Write("\nTransactions saved succesfully");
//     Console.WriteLine("Status: "+sale.PorfitOrLossStatus);
//     Console.WriteLine("Profit/Loss Amount: "+sale.ProfitorLossAmount.ToString("F2"));
//     Console.WriteLine("Profit Margin (%): "+sale.ProfitMarginPercent.ToString("F2"));
//     }

//     public static void View()
//     {

//         if (!HasLastTransaction)
//         {
//             Console.WriteLine("No Transaction available");
//         }


//         Console.WriteLine("-------------- Last Transaction --------------");
//         Console.WriteLine($"InvoiceNo: {LastTransaction.InvoiceNo}");
//         Console.WriteLine($"Customer: {LastTransaction.CustomerName}");
//         Console.WriteLine($"Item: {LastTransaction.ItemName}");
//         Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
//         Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount}");
//         Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount}");
//         Console.WriteLine($"Status: {LastTransaction.PorfitOrLossStatus}");
//         Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitorLossAmount}");
//         Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent}");
        

//     }


//     public static void Calculation()
//     {
//         if (!HasLastTransaction)
//         {
//             Console.WriteLine("No Transaction available");
//         }
//         if(LastTransaction.SellingAmount> LastTransaction.PurchaseAmount){
//             LastTransaction.PorfitOrLossStatus="PROFIT";
//             LastTransaction.ProfitorLossAmount=LastTransaction.SellingAmount-LastTransaction.PurchaseAmount;
//         }
//         else if (LastTransaction.SellingAmount < LastTransaction.PurchaseAmount)
//         {
//             LastTransaction.PorfitOrLossStatus="LOSS";
//             LastTransaction.ProfitorLossAmount=LastTransaction.PurchaseAmount-LastTransaction.SellingAmount;
//         }
//         else if(LastTransaction.SellingAmount == LastTransaction.PurchaseAmount)
//         {
//             LastTransaction.PorfitOrLossStatus="BREAK-EVEN";
//             LastTransaction.ProfitorLossAmount=0;
//         }
//         LastTransaction.ProfitMarginPercent=(LastTransaction.ProfitorLossAmount/LastTransaction.PurchaseAmount)/100;

//     // LastTransaction=sale;
//     HasLastTransaction=true;
//     Console.WriteLine("Recomputing the Profit/Loss ");
//     View();
//     }

// }

        

    


// class Program
// {
//     public static void Main()
//     {
//         int option;
//         do{
//         Console.WriteLine("================== QuickMart Traders ==================");
//         Console.WriteLine("1. Create New Transactions (Enter Purchase & selling Details)");
//         Console.WriteLine("2. View Last Transaction");
//         Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
//         Console.WriteLine("4. Exit");

//         Console.WriteLine("Enter your option: ");
//         option=Convert.ToInt32(Console.ReadLine());
//             switch (option)
//             {
//                 case 1:
//                     Transactions.Createorregister();
//                     break;
//                 case 2:
//                 Transactions.View();
//                     break;
//                 case 3:
//                     Transactions.Calculation();
//                     break;
//                 case 4:
//                     Console.WriteLine("Thank You. Application Closed normally.");
//                     break;
//                 default:
//                     Console.WriteLine("Invalid Option");
//                     break;

//             }
//     }while(option!=4);
// }
// }