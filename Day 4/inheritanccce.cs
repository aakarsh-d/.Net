// // Creating Inheritance
// // Inheritance is created using the colon (:) symbol.
// class Vehicle
// {
//     public void Start()
//     {
//         Console.WriteLine("Vehicle started");
//     }
// }

// class Car : Vehicle
// {
//     public void Drive()
//     {
//         Console.WriteLine("Car is driving");
//     }
// }
// public static void Main()
// {   
// Car c = new Car();
// c.Start();   // inherited method
// c.Drive();   // own method
// }

// class Vehicle
// {
//     public void Horn(){
//     Console.WriteLine("Beep!BEEP!");
//     }
// }
// class Car : Vehicle
// {
//     public void drive()
//     {
//         Console.WriteLine("Driving");
//     }
// }
// class Program{
// static void Main(){
// Car c= new Car();
// c.Horn();
// c.drive();
// }
// }

// class Animal
// {
//     public virtual void Sound()
//     {
//         Console.WriteLine("Animal makes sound");
//     } 
// }
// class Dog: Animal
// {
//     public override void Sound()
//     {
//         base.Sound();
//         Console.WriteLine("Dog Barks");
//     }
// }
// class Program
// {
//     public static void Main()
//     {
//         Animal a=new Dog();
//         // Animal b=new Animal();  
//         a.Sound();
//         // b.Sound();
//     }
// }