// using System;
// namespace FCS
// {

//     class FinanceControlSystem
//     {
//         int age=0;
//         int MonthlyIncome=0;
//     public void FinanceSystem()
//     {
//     int a=0;
   

//     while(true){
//     Console.WriteLine("Finance Control System");
//     Console.WriteLine("1. Loan Eligibility");
//     Console.WriteLine("2. Income Tax Calculation");
//     Console.WriteLine("3. Transaction Entry System");
//     Console.WriteLine("4. Exit");
//     a=Convert.ToInt32(Console.ReadLine());
    
//         switch (a)
//     {
//         case 1: 
//             LoanEligibility();
//             break;
//         case 2:
//             IncomeTaxCalc();
//             break;
//         case 3:
//             TransactionEntrySys();
//             break;
//         case 4:
//             Exit();
//             return;
//     }
//     }
//     }
    
//     public void LoanEligibility()
//     {
//         Console.WriteLine("Enter your age:");
//         age=Convert.ToInt32(Console.ReadLine());
//         Console.WriteLine("Enter your monthly income:");
//         MonthlyIncome=Convert.ToInt32(Console.ReadLine());
//         // int AnnualIncome=MonthlyIncome*12;
//             if (age >= 21 && MonthlyIncome>=30000)
//             {
//                 Console.WriteLine("You are eligible for loan");
//             }
//             else
//             {
//                 Console.WriteLine("You are not eligible for loan");
//             }
//     }
//     public void IncomeTaxCalc()
//     {
//         // int AnnualIncome=0;
//         //  Console.WriteLine("Finance Control System");
//         // Console.WriteLine("Enter your age:");
//         // age=Convert.ToInt32(Console.ReadLine());
//         Console.WriteLine("Enter your monthly income:");
//         MonthlyIncome=Convert.ToInt32(Console.ReadLine());
//         int AnnualIncome=MonthlyIncome*12;
//         // AnnualIncome=Convert.ToInt32(Console.ReadLine());
//         if(AnnualIncome<=250000)
//         {
//             Console.WriteLine("No tax");
//         }
//         else if(AnnualIncome>250000 && AnnualIncome<=500000)
//         {
//             int tax=AnnualIncome*5/100;
//             Console.WriteLine($"Tax is 5% and amount is {tax}");
//         }
//         else if(AnnualIncome>500000 && AnnualIncome<=1000000)
//         {
//             int tax=AnnualIncome*20/100;
//             Console.WriteLine($"Tax is 20% and amount is {tax}");
            
//         }
//         else
//         {
//             int tax=AnnualIncome*30/100;
//             Console.WriteLine($"Tax is 30% and amount is {tax}");
//         }
//     }
//     public void TransactionEntrySys()
//     {
//         Console.WriteLine("Enter your monthly income:");
//         MonthlyIncome=Convert.ToInt32(Console.ReadLine());
//         int balance=MonthlyIncome;
//         for(int i = 1; i <= 5; i++)
//             {
//                 Console.WriteLine("Deposit or Withdraw (D/W):");
//                 char choice = Convert.ToChar(Console.ReadLine());
//                 if(choice == 'D')
//                 {
//                     Console.WriteLine("Enter amount to deposit:");
//                     int amount = Convert.ToInt32(Console.ReadLine());
//                     balance += amount;
//                 }
//                 else if(choice == 'W')
//                 {
//                     Console.WriteLine("Enter amount to withdraw:");
//                     int amount = Convert.ToInt32(Console.ReadLine());
//                     balance -= amount;
//                 }
//             }
//             Console.WriteLine("Balance is: "+ balance);
//     }
//     public void Exit()
//     {
//         Console.WriteLine("Exiting Finance Control System");
//     }
//     }
// }
