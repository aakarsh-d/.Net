// using System;

// delegate void PaymentDelegate(decimal amount);

// class PaymentService
// {
//     public void ProcessPayment(decimal amount)
//     {
//         Console.WriteLine("Payment of "+amount+" processed succesfullt.");

//     }
// }
// static class PaymentExtensions
// {
//     public static bool IsValidPayment(this decimal amount)
//     {
//         return amount > 0  && amount <=1_000_000;
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         PaymentService service = new PaymentService();
//         PaymentDelegate payment=service.ProcessPayment; // refernce to method
//         // payment(5000);
//         decimal amount=5000;
//         if(amount.IsValidPayment())
//         {
//             payment(amount);
//         }
//         else
//         {
//             Console.WriteLine("Invalid");
//         }
//     }

// }