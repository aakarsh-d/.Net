// // // class Program{
// // using System;
// // // using System.Collections.Generic;
// // public abstract class EmployeeRecord
// //     {
// //         public string EmployeeName;
// //         public double[] WeeklyHours;
// //         public abstract double GetMonthlyPay();

// //     }

// // class FullTimeEmployee: EmployeeRecord{
// //     double HourlyRate;
// //     double MonthlyBonus;

// //     public abstract override double GetMonthlyPay()
// //     {
// //         double sum=WeeklyHours.Sum();
// //         return (WeeklyHours*HourlyRate)+MonthlyBonus;
// //     }
// // }

// // class ContractEmployee: EmployeeRecord
// // {
// //     double HourlyRate;
// //     public abstract override double GetMonthlyPay()
// //     {
// //         double sum=WeeklyHours.Sum();
// //         return (WeeklyHours * HourlyRate);
// //     }

// // }

// // class Payroll
// // {
// //     public static List<EmployeeRecord> PayrollBoard;


// //     public void RegisterEmployee(EmployeeRecord record)
// //     {
// //         PayrollBoard().Add(record);
// //     }

// //     public Dictionary<string,int> GetOverTimeWeekCounts(List<EmployeeRecord>records, double hoursThreshold)
// //     {

        
// //     }
// //     public  double CalculareAverageMonthlyPay()
// //     {
        
// //     }
// // }



// using System;
// using System.Collections.Generic;

// // =====================
// // ABSTRACT BASE CLASS
// // =====================
// public abstract class EmployeeRecord
// {
//     public string EmployeeName { get; set; }
//     public double[] WeeklyHours { get; set; }

//     public abstract double GetMonthlyPay();
// }

// // =====================
// // FULL TIME EMPLOYEE
// // =====================
// public class FullTimeEmployee : EmployeeRecord
// {
//     public double HourlyRate { get; set; }
//     public double MonthlyBonus { get; set; }

//     public override double GetMonthlyPay()
//     {
//         double totalHours = 0;
//         foreach (double h in WeeklyHours)
//         {
//             totalHours += h;
//         }

//         return (totalHours * HourlyRate) + MonthlyBonus;
//     }
// }

// // =====================
// // CONTRACT EMPLOYEE
// // =====================
// public class ContractEmployee : EmployeeRecord
// {
//     public double HourlyRate { get; set; }

//     public override double GetMonthlyPay()
//     {
//         double totalHours = 0;
//         foreach (double h in WeeklyHours)
//         {
//             totalHours += h;
//         }

//         return totalHours * HourlyRate;
//     }
// }

// // =====================
// // PAYROLL SERVICE
// // =====================
// public class PayrollService
// {
//     public static List<EmployeeRecord> PayrollBoard = new List<EmployeeRecord>();

//     public void RegisterEmployee(EmployeeRecord record)
//     {
//         PayrollBoard.Add(record);
//     }

//     public Dictionary<string, int> GetOvertimeWeekCounts(
//         List<EmployeeRecord> records, double hoursThreshold)
//     {
//         Dictionary<string, int> result = new Dictionary<string, int>();

//         foreach (EmployeeRecord emp in records)
//         {
//             int count = 0;

//             foreach (double hours in emp.WeeklyHours)
//             {
//                 if (hours >= hoursThreshold)
//                 {
//                     count++;
//                 }
//             }

//             if (count > 0)
//             {
//                 result.Add(emp.EmployeeName, count);
//             }
//         }

//         return result;
//     }

//     public double CalculateAverageMonthlyPay()
//     {
//         if (PayrollBoard.Count == 0)
//             return 0;

//         double totalPay = 0;

//         foreach (EmployeeRecord emp in PayrollBoard)
//         {
//             totalPay += emp.GetMonthlyPay(); // Polymorphism
//         }

//         return totalPay / PayrollBoard.Count;
//     }
// }

// // =====================
// // PROGRAM (MAIN)
// // =====================
// class Program
// {
//     static void Main()
//     {
//         PayrollService service = new PayrollService();
//         int choice;

//         do
//         {
//             Console.WriteLine("\n1. Register Employee");
//             Console.WriteLine("2. Show Overtime Summary");
//             Console.WriteLine("3. Calculate Average Monthly Pay");
//             Console.WriteLine("4. Exit");
//             Console.WriteLine("\nEnter your choice:");
//             choice = int.Parse(Console.ReadLine());

//             switch (choice)
//             {
//                 case 1:
//                     Console.WriteLine("\nSelect Employee Type (1-Full Time, 2-Contract):");
//                     int type = int.Parse(Console.ReadLine());

//                     Console.WriteLine("\nEnter Employee Name:");
//                     string name = Console.ReadLine();

//                     Console.WriteLine("\nEnter Hourly Rate:");
//                     double rate = double.Parse(Console.ReadLine());

//                     double[] hours = new double[4];
//                     Console.WriteLine("\nEnter weekly hours (Week 1 to 4):");
//                     for (int i = 0; i < 4; i++)
//                     {
//                         hours[i] = double.Parse(Console.ReadLine());
//                     }

//                     if (type == 1)
//                     {
//                         Console.WriteLine("\nEnter Monthly Bonus:");
//                         double bonus = double.Parse(Console.ReadLine());

//                         FullTimeEmployee fte = new FullTimeEmployee
//                         {
//                             EmployeeName = name,
//                             HourlyRate = rate,
//                             MonthlyBonus = bonus,
//                             WeeklyHours = hours
//                         };

//                         service.RegisterEmployee(fte);
//                     }
//                     else
//                     {
//                         ContractEmployee ce = new ContractEmployee
//                         {
//                             EmployeeName = name,
//                             HourlyRate = rate,
//                             WeeklyHours = hours
//                         };

//                         service.RegisterEmployee(ce);
//                     }

//                     Console.WriteLine("\nEmployee registered successfully");
//                     break;

//                 case 2:
//                     Console.WriteLine("\nEnter hours threshold:");
//                     double threshold = double.Parse(Console.ReadLine());

//                     Dictionary<string, int> summary =
//                         service.GetOvertimeWeekCounts(PayrollService.PayrollBoard, threshold);

//                     if (summary.Count == 0)
//                     {
//                         Console.WriteLine("\nNo overtime recorded this month");
//                     }
//                     else
//                     {
//                         foreach (var item in summary)
//                         {
//                             Console.WriteLine($"{item.Key} - {item.Value}");
//                         }
//                     }
//                     break;

//                 case 3:
//                     double avg = service.CalculateAverageMonthlyPay();
//                     Console.WriteLine($"\nOverall average monthly pay: {avg}");
//                     break;

//                 case 4:
//                     Console.WriteLine("\nLogging off — Payroll processed successfully!");
//                     break;

//                 default:
//                     Console.WriteLine("\nInvalid choice");
//                     break;
//             }

//         } while (choice != 4);
//     }
// }
