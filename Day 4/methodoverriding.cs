    // Method Overriding
    // A derived class can modify the behavior of a base class method.

    //runtime polymorphism

    // in parent class it gives genreic behaviour but in child class we can give specific behaviour
    // Base Class
    // class Animal


    // virtual → parent says: “you MAY change this”

    // override → child says: “I AM changing this”
    // {
    //     public virtual void Sound()
    //     {
    //         Console.WriteLine("Animal makes sound");
    //     }
    // }
    // Derived Class
    // class Dog : Animal
    // {
    //     public override void Sound()
    //     {
    //         Console.WriteLine("Dog barks");
    //     }
    //     public static void Main()
    //     {
    //         Animal myAnimal = new Animal(); // Create an Animal object
    //         Animal myDog = new Dog();       // Create a Dog object

    //         myAnimal.Sound(); // Outputs: Animal makes sound
    //         myDog.Sound();    // Outputs: Dog barks
    //     }
    // }


    // class Animal
    // {
    //     public virtual void Sound()
    //     {
    //         Console.WriteLine("Animal makes sound");
    //     }
    // }
    // Derived Class
    // class Dog : Animal
    // {
    //     public override void Sound()
    //     {
    //         base.Sound(); // to call the parent methhod without getting overridden
    //         Console.WriteLine("Dog barks");

    //     }
    //     public static void Main(){
    //         Dog dog = new Dog();   
    //         dog.Sound();
    //     }
    // }
