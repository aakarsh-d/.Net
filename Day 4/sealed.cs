// class Parent
// {
//     public virtual void Show()
//     {
//         Console.WriteLine("Parent Show");
//     }
// }

// class Child : Parent
// {
//     public sealed override void Show()
//     {
//         Console.WriteLine("Child Show");
//     }

// }
// class m : Child 
// {
//     public override void Show()
//     {
//         Console.Write("kkk");  // we cannot call this as we cannot override inherited member 'Child.Show()' because it is sealed
//     }
//     public static void Main(string[] args){
//         Child parent = new Child();
//         parent.Show();
//     }
// }


//sealed class

// sealed class Animal
// {
//     public void sound()
//     {
//         Console.WriteLine("Animal makes sound");
//     }
// }
// class Cow:Animal
// {
//     // public void sound()
//     // {
//     //     Console.WriteLine("mmmmmm");   
//     // }
// }
// class Program
// {
//     // s.sound();
//     public static void Main()
//     {
//     Animal s= new Cow();

//     }
// }


// sealed method

// class Vehicle()
// {
//     public virtual void Engine()
//     {
//         Console.WriteLine("Engine revives");
//     }

// }
// class Car : Vehicle
// {
//     public sealed override void Engine()
//     {
//         base.Engine();
//         Console.WriteLine("enginennnennenenenne");
//     }
// }
// class Bus : Car
// {
//     public override void Engine()
//     {
//         Console.WriteLine("fnajnla");   
//     }
    
// }
// class Program
// {
//     static void Main()
//     {
//         // Bus b=new Bus();
//         Car c=new 
//         b.Engine();
//     }
// }
