// // using System;
// // delegate void ErrorDelegate(string message);
// // class Program
// // {
// //     static void Main()
// //     {
// //         ErrorDelegate errorHandler =delegate(string msg)
// //         {
// //             Console.WriteLine("Error: "+msg);
// //         };
// //         errorHandler("File not found");
// //     }
// // }


// using System;

// class Button
// {
//     public delegate void ClickHandler();

//     public event ClickHandler Clicked; //
//     public void Click()
//     {
//         Clicked?.Invoke();
//     }

// }

// class Program
// {
//     static void Main()
//     {
//         Button btn = new Button();

//         btn.Clicked+=() => Console.WriteLine("Button was clicked");
//         btn.Clicked+=() => Console.WriteLine("clicked");
//         btn.Clicked+=() => Console.WriteLine("Resume");

//         btn.Click();
//     }
// }