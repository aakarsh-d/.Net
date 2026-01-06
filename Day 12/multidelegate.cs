// using System;

// delegate void OrderDelegate(string orderId);

// class NotificationService
// {
//     public void SendEmail(string id)
//     {
//         Console.WriteLine("Email sent for Order "+id);
//     }
//     public void SendSMS(string id)
//     {
//         Console.WriteLine("SMS send for Order "+id);
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         NotificationService service = new NotificationService();
//         OrderDelegate notify=null;
//         notify+=service.SendEmail;
//         notify+=service.SendSMS;

//         notify("ORD1001");
//     }
// }