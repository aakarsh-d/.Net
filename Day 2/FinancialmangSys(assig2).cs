// Assignment  - Day 2

// using System;
// using System.Runtime;
// namespace FMS
// {
//     class Account
//     {
//     public void FinanceSystem()
//     {
//         Debit debit = new Debit();
//         Credit credit = new Credit();
//         while(true){Console.WriteLine("Main Menu Options");
//         Console.WriteLine("1. Debit Operations");
//         Console.WriteLine("2. Credit Operations");
//         Console.WriteLine("3. Exit");
//         int a=0;
//         a=Convert.ToInt32(Console.ReadLine());
//         switch (a)   
//         {
//             case 1:
//                 debit.FinanceSystemDebit();
//                 break;
//             case 2:
//                 credit.FinanceSystemCredit();
//                 break;
//             case 3:
//                { Console.WriteLine("Exiting the Finance Management System. Goodbye!");
//                 return;}
//         }
//         }
//     }
// }
//     class Debit
//     {
//         int a=0;
//         int Amount=0;
//         public void FinanceSystemDebit()
//         {
//         while(true){Console.WriteLine("Welcome to the Finance Management Debit System");
//             Console.WriteLine("1. ATM Withdraw Limit validation");
//             Console.WriteLine("2. EMI Burden Evaluation");
//             Console.WriteLine("3. Transaction History Analysis");
//             Console.WriteLine("4. Minimum Balance Check");
//             Console.WriteLine("5. Back to Main Menu");
//             a=Convert.ToInt32(Console.ReadLine());
//             switch (a)
//             {
//                 case 1:
//                     ATMWithdrawLimitValidation();
//                     break;
//                 case 2:
//                     EMIBurdenEvaluation();
//                     break;
//                 case 3:
//                     TransactionHistoryAnalysis();
//                     break;
//                 case 4:
//                     MinimumBalanceCheck();
//                     break;
//                 case 5:
//                     {Account account= new Account();
//                     account.FinanceSystem();
//                     break;}
//                    }
//             }
//         }
//         public void ATMWithdrawLimitValidation()
//         {
//             int Amount=Convert.ToInt32(Console.ReadLine());
//             Console.WriteLine("ATM Withdraw Limit Validation");
//             if(Amount>40000)
//             {
//                 Console.WriteLine("Alert: Withdraw limit exceeded. Cannot withdraw more than 40000 in a single transaction.");
//             }
//             else
//             {
//                 Console.WriteLine("Withdraw amount is within the limit.");
//             }
//         }
//         public void EMIBurdenEvaluation()
//         {   
//             int MonthlyIncome=Convert.ToInt32(Console.ReadLine());
//             int EMIAmount=Convert.ToInt32(Console.ReadLine());
//             if(MonthlyIncome%40<EMIAmount)
//             {
//                 Console.WriteLine("Alert: EMI burden is too high. Consider reducing EMI amount.");
//             }
//             else
//             {
//                 Console.WriteLine("EMI burden is acceptable.");
//             }

//         }
//         public void TransactionHistoryAnalysis()
//         {
//             int transaction=0;
//             Console.WriteLine("Number of transactions:"+transaction);
//             transaction=Convert.ToInt32(Console.ReadLine());
//             for(int i=1;i<=transaction;i++)
//             {
//                 Console.Write("Transaction Amount for "+i+": ");
//                 int amt=Convert.ToInt32(Console.ReadLine());
//                 if(amt>0)
//                 Amount-=amt;
//                 else 
//                 {Console.WriteLine("Skipping amount");
//                 continue;}
//             }
//             Console.WriteLine("Balance "+Amount);
//         }
//         public void MinimumBalanceCheck()
//         {
//             Amount=Convert.ToInt32(Console.ReadLine());

//             Console.WriteLine("Minimum Balance Check");
//             if(Amount<2000 )
//             {
//                 Console.WriteLine("Alert: Penalty Applicable. Balance below minimum required balance.");
//             }
//             else
//             {
//                 Console.WriteLine("Balance is above minimum required balance.");
//             }
//         }
//     }
//     class Credit
//     {
//         int a=0;
//         int Amount=0;
//         public void FinanceSystemCredit()
//         {
//         while(true){ Console.WriteLine("Welcome to the Finance Management Credit System");
//             Console.WriteLine("1. NetSalary Credit Calculation");
//             Console.WriteLine("2. FD Maturity Calculation");
//             Console.WriteLine("3. Credit Card Points");
//             Console.WriteLine("4. Bonus Eligibility Check");
//             Console.WriteLine("5. Back to Main Menu");
            
//             a=Convert.ToInt32(Console.ReadLine());
//             switch (a)
//             {
//                 case 1:
//                     NetSalaryCreditCalc();
//                     break;
//                 case 2:
//                     FDMaturityCalc();
//                     break;
//                 case 3:
//                     CreditCardPoints();
//                     break;
//                 case 4:
//                     BonusEligibiltyCheck();
//                     break;
//                 case 5:
//                     {Account account= new Account();
//                     account.FinanceSystem();
//                     break;}
//                 }
//             }
//         }
//         public void NetSalaryCreditCalc()
//         {
//             int GrossSalary=Convert.ToInt32(Console.ReadLine());
//             int FixedDeductions=10 % GrossSalary;
//             int NetSalary=GrossSalary-FixedDeductions;
//             Console.WriteLine("Net Salary is : "+NetSalary);
//         }
//         public void FDMaturityCalc()
//         {
//             int principalAmount=Convert.ToInt32(Console.ReadLine());
//             double rateOfInterest=Convert.ToDouble(Console.ReadLine());
//             int timePeriod=Convert.ToInt32(Console.ReadLine());
//             double SimpleInterest=(principalAmount*rateOfInterest*timePeriod)/100;
//             double MaturityAmount=principalAmount+SimpleInterest;
//             Console.WriteLine("Maturity Amount is : "+MaturityAmount);
//         }
//         public void CreditCardPoints()
//         {
//             int totalcardspend=Convert.ToInt32(Console.ReadLine());
//             int points=totalcardspend/100;
//             Console.WriteLine("Rewards Points Earned: "+points);
//         }
//         public void BonusEligibiltyCheck()
//         {
//             int AnnualIncome=Convert.ToInt32(Console.ReadLine());
//             int YearsOfService=Convert.ToInt32(Console.ReadLine());
//             if(AnnualIncome>500000 && YearsOfService>5)
//             {
//                 Console.WriteLine("Employee is Eligible for Bonus");
//             }
//             else
//             {
//                 Console.WriteLine("Employee is not Eligible for Bonus");
//             }
//         }
//     }
// }