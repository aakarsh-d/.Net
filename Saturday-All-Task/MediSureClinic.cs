// public class PatientBill
// {
//     public string BillId="";
//     public string PatientName="";
//     public bool HasInsurance;
//     public decimal ConsultationFee;
//     public decimal LabCharges;
//     public decimal MedicineCharges;
//     public decimal GrossAmount;
//     public decimal DiscountAmount;
//     public Decimal FinalPayable;

//     // public static PatentBill LastBill;
// }


// public class BillingService
// {
//     public static PatientBill LastBill;
//     public static bool HasLastBill=false;

//     // Bill id validation
//     public static void CreateBill()
//     {
//         PatientBill bill = new PatientBill();
//         do{
//             Console.Write("Enter Bill Id:");
//             bill.BillId=Console.ReadLine();
//         }
//         while(string.IsNullOrWhiteSpace(bill.BillId));
    

//     //Patient Name
//     Console.WriteLine("Enter Patient Name");
//     bill.PatientName=Console.ReadLine();


//     //Insurance
//     Console.WriteLine("Is the patient insured? (Y/N)");
//     char choice=Console.ReadLine().ToUpper()[0];
//     bill.HasInsurance=(choice=='Y');
    


//     // Fees

//     bill.ConsultationFee=ReadDecimal("Enter Consultation Fee: ", mustBeGreaterThanZero : true);
//     bill.LabCharges=ReadDecimal("Enter Lab Fee: ", mustBeGreaterThanZero : false);
//     bill.MedicineCharges=ReadDecimal("Enter Medicine Fee: ", mustBeGreaterThanZero : false);
//     // bill.ConsultationFee=Convert.ToDecimal(Console.ReadLine("Enter Consultation Fee: ", mustBeGreaterThanZero : true));
//     // bill.LabCharges=Convert.ToDecimal(Console.ReadLine("Enter Lab Fee: ", mustBeGreaterThanZero : false));
//     // bill.MedicineCharges=Convert.ToDecimal(Console.ReadLine("Enter Medicine Fee: ", mustBeGreaterThanZero : false));


//     //Calcuation 

//     bill.GrossAmount=bill.ConsultationFee+bill.LabCharges+bill.MedicineCharges;
//         if (bill.HasInsurance)
//         {
//             bill.DiscountAmount=bill.GrossAmount*0.10m;
//         }
//         else
//         {
//             bill.DiscountAmount=0;
//         }

//         bill.FinalPayable=bill.GrossAmount-bill.DiscountAmount;


//         LastBill=bill;
//         HasLastBill=true;

//         Console.WriteLine("\n Bill Created Succesfully");
//         Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
//         Console.WriteLine($"Discount Amount: {bill.DiscountAmount:F2}");
//         Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
//         Console.WriteLine("------------------------------------------------------------");
//     }

//     public static void ViewLastBill()
//     {
//         if (!HasLastBill)
//         {
//             Console.WriteLine("No bill available. Please create a new bill first.");
//             return;
//         }
//         Console.WriteLine("\n-----------Last Bill-----------");
//         Console.WriteLine($"BillId: {LastBill.BillId}");
//         Console.WriteLine($"Patient : {LastBill.PatientName}");
//         Console.WriteLine($"Insured : {(LastBill.HasInsurance ? "Yes" : "No") }");
//         Console.WriteLine($"Consultation Fee : {LastBill.ConsultationFee:F2} ");
//         Console.WriteLine($"Lab Charge : {LastBill.LabCharges:F2}");
//         Console.WriteLine($"Medicine Charge : {LastBill.MedicineCharges:F2}");
//         Console.WriteLine($"Gross Amount : {LastBill.GrossAmount:F2}");
//         Console.WriteLine($"Discount Amount : {LastBill.DiscountAmount:F2}");
//         Console.WriteLine($"Final Payable : {LastBill.FinalPayable:F2}");
//         Console.WriteLine("--------------------------------");
//         Console.WriteLine("------------------------------------------------------------");

//     }


//     public static void clear()
//     {
//         LastBill=null;
//         HasLastBill=false;

//         Console.WriteLine("Last Bill Cleared.");
        
//     }
// private static decimal ReadDecimal(string message, bool mustBeGreaterThanZero)
// {
//     while (true)
//     {
//         Console.Write(message);
//         string? input = Console.ReadLine();

//         if (decimal.TryParse(input, out decimal value))
//         {
//             if (mustBeGreaterThanZero && value <= 0)
//             {
//                 Console.WriteLine("Value must be greater than 0.");
//             }
//             else if (!mustBeGreaterThanZero && value < 0)
//             {
//                 Console.WriteLine("Value cannot be negative.");
//             }
//             else
//             {
//                 return value;
//             }
//         }
//         else
//         {
//             Console.WriteLine("Invalid number. Try again.");
//         }
//     }
// }


//     // private static decimal ReadDecimal(string message, bool mustBeGreaterThanZero)
//     // {
//     //     decimal val;
// //         while (true)
// //         {
// //             Console.Write(message);
// //             val=Convert.ToDecimal(Console.ReadLine);
// //             if (mustBeGreaterThanZero || val <= 0)
// //             {
// //                 Console.WriteLine("Value must be greater than 0");
// //             }
// //             else if(!mustBeGreaterThanZero && val < 0)
// //             {
// //                 Console.WriteLine("Value cannot be negative");
// //             }
// //             else
// //             {
// //                 break;
// //             }
// //             return val;
// //         }
// //     }
// // }
// }
// class Program
// {
//     public static void Main()
//     {
//         int option;
//         do
//         {
//             Console.WriteLine("\n================MediSure Clinic Billing ==============");
//             Console.WriteLine("1. Create New Bill (Enter Patient Details)");
//             Console.WriteLine("2. View Last Bill");
//             Console.WriteLine("3. Clear Last Bill");
//             Console.WriteLine("4. Exit");
//             Console.WriteLine("Enter Your Option: ");
//             option=Convert.ToInt32(Console.ReadLine());
//             switch (option )
//             {
//                 case 1:
//                 BillingService.CreateBill();
//                 break;
//                 case 2:
//                 BillingService.ViewLastBill();
//                 break;
//                 case 3:
//                 BillingService.clear();
//                 break;
//                 case 4:
//                 Console.WriteLine("Thank You. Application Closed Normally.");
//                 break;
//                 default:
//                 Console.WriteLine("Invalid Option.");
//                 break;
//             }
//         }while(option<4 || option!=4 );
//     }
// }
