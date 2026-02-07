// class Parent
// {
//     public Parent(int x)
//     {
//         Console.WriteLine("Parent constructor: " + x);
//     }
// }

// class Child : Parent
// {
//     public Child() : base(10)
//     {
//         Console.WriteLine("Child constructor");
//     }

// public static void Main()
// {
//     Child c = new Child();
//     Console.WriteLine(c);
// }
// }



// class Person
// {
//     public string Name;

//     public Person(string name)
//     {
//         Name = name;
//     }
// }

// class Student : Person
// {
//     public int RollNo;

//     public Student(string name, int roll) : base(name)
//     {
//         RollNo = roll;
//     }
// public static void Main()
// {
//     Student s = new Student("Mufasa", 101);
//     Console.WriteLine("Name: " + s.Name);
//     Console.WriteLine("Roll No: " + s.RollNo);
// }
// }


// parameter less constructor of base class is called automatically


// Single Inheritance
// One base class, one derived class.
// class Animal
// {
//     public void Eat()
//     {
//         Console.WriteLine("Animal eats");
//     }
// }

// class Dog : Animal
// {
//     public void Bark()
//     {
//         Console.WriteLine("Dog barks");
//     }


// }
// class Program
// {
//     public static void Main()
//     {
//         Dog d = new Dog();
//         d.Eat();
//         d.Bark(); // we can access both methods
//     }
// }

// Multilevel Inheritance exists but not multiple inheritance in C#



                                                        // A ------ B
                                                        // |
                                                        // |           Hierarchical Inheritance
                                                        // |
                                                        // C

                                                        // A------C
                                                        //        |         Multilevel Inheritance
                                                        //        |
                                                        //        B


                                    // Diamond Question 
                                    // It happens when a class inherits from two classes that both inherit from the same base class.

                                        //     A
                                        //    / \
                                        //   B   C
                                        //    \ /
                                        //     D



                                    // interface -> it defenies what a class should do not how to do it
                                    // It does not contain implementation
                                    //     It only declares a contract


// interface IPrintable
// {
//     void Print();
// }

// interface IScannable
// {
//     void Scan();
// }

// class Machine : IPrintable, IScannable
// {
//     public void Print()
//     {
//         Console.WriteLine("Printing");
//     }

//     public void Scan()
//     {
//         Console.WriteLine("Scanning");
//     }
    
// }