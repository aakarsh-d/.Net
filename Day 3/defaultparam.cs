// using System;
// using System.Reflection.Metadata.Ecma335;

// class Food
// {
// // void OrderFood(string food, int quantity = 1, bool takeAway) // // Default parameter must be at the end
// void OrderFood(string food, int quantity = 1, params string[] addons, bool takeAway = false)

// {
//     Console.WriteLine($"{food} x {quantity}, TakeAway: {takeAway}");
// }
//     public static void Main(string[] args)
//     {
//         Food f = new Food();
//         f.OrderFood("Burger");
//         f.OrderFood("Pizza", quantity: 2);
//         f.OrderFood(food: "Sandwich", takeAway: true);
//         f.OrderFood(addons: "Cheese");

//     }
// }