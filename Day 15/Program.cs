
// using System.Reflection;

// Assembly assembly=Assembly.GetExecutingAssembly();
// gets the currentl running assembly and stores in var named assembly

// Simple meaning
// “Give me information about the program that is running right now.”

// Assembly a=Assembly.Load("System.Linq");
// Assembly a1=Assembly.Load("System.xml");
// Console.WriteLine(a.GetName().Name);
// Console.WriteLine(a.GetName().Version);
// Console.WriteLine(a1.GetName().Name);
// Console.WriteLine(a.Location);
// Console.WriteLine(a1.FullName);
// Console.WriteLine(a1.Location);
// // Console.WriteLine("Is DLL: ");
// Assembly.LoadFrom("MyPlugin.dll");


using System.Reflection;
using System.Reflection.Metadata;

class Car
{
    // public int Id;
    public int Id{get;set;}
    public string Name{get;set;}
    public int speed;
    public Car(){Console.WriteLine("Hello");}

    public Car(int id,string name)
    {
        Id=id;
        Name=name;
        Console.WriteLine("Parameterized Constructor");
    }

    public void Caring()
    {
        Console.WriteLine("Car is caring");
    }
    public void Carsss(int id,string name)
    {
        Console.WriteLine("Hello");
    }
}
class Program{
    static void Main(){
        // TYPE/
        Type type =typeof(Car);
        // Console.WriteLine(type.FullName);
        Car mycar=new Car();
        // Type type1=mycar.GetType();
        // Console.WriteLine(type1.FullName);
        // Type type2 = Type.GetType("MyApp.Models.Car");
        // Console.WriteLine(type2.FullName);

        // METHODINFO
        // Type type=typeof(Car);
        // Console.WriteLine("Method Info: ");
        // MethodInfo method=type.GetMethod("Caring");
        // method.Invoke(mycar,null);
        //invoke is used to execute the method dynamically

        //PropertyInfo
        Console.WriteLine("PropertyInfo :");
        // Type type=typeof(Car);
        PropertyInfo prop=type.GetProperty("Id");
        if (prop != null)
        {
        prop.SetValue(mycar,123);
        Console.WriteLine(mycar.Id);
        Console.WriteLine(prop.Name);
            
        }
        PropertyInfo[] prop1=type.GetProperties();
        foreach(PropertyInfo p in prop1)
        {
            Console.WriteLine(p.Name);
            Console.WriteLine(p.PropertyType);
        }

        //FieldInfo
        Console.WriteLine("FieldInfo: ");
        FieldInfo field=type.GetField("speed");
        if (field != null)
        {
            field.SetValue(mycar,100);
            Console.WriteLine(field.GetValue(mycar)); //reads field val dynamically
            Console.WriteLine(field.Name); // name of the field
            Console.WriteLine(field.FieldType); // field type
        }

        Console.WriteLine("ConstructorInfo: ");

        ConstructorInfo[] constructorInfo=type.GetConstructors();
        foreach(ConstructorInfo ci in constructorInfo)
        {
            Console.WriteLine(ci.Name);
            Console.WriteLine("Parameter Count: "+ci.GetParameters().Length);
        }
        // .ctor - internally constructors are named as ctor

        ConstructorInfo CInfo=type.GetConstructor(Type.EmptyTypes);
        Car car1=(Car)CInfo.Invoke(null);
        // a new obj is created and stored in obj;
        Console.Write("Constructor: "+car1); 
        ConstructorInfo CInfo2=type.GetConstructor(new Type[] { typeof(int), typeof(string)});
        // we have defined this so it will search for a consts in a class that matches the given parameter types
        Car car2=(Car)CInfo2.Invoke(new object[]{102,"BMW"});
        //creating obj dynamically 
        Console.Write("Car Id from param consts: ");
        Console.Write(car2.Id);
        Console.WriteLine();
        Console.Write("Car Name from param consts: ");
        Console.WriteLine(car2.Name);

        Console.WriteLine("Parameter Info: ");
        MethodInfo method=type.GetMethod("Carsss");
        ParameterInfo[] parameterInfos=method.GetParameters();
        // method is methodinfo object an getparameters fetches all the parameters of method
        foreach(ParameterInfo pi in parameterInfos)
        {
            Console.WriteLine(pi.Name+ " : "+pi.ParameterType );
        }

        Assembly assembly=Assembly.GetExecutingAssembly();
        foreach(Type type1 in assembly.GetTypes())
        {
            Console.WriteLine("Class: " + type1.Name);
        foreach (MethodInfo method1 in type1.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            Console.WriteLine("  Method: " + method1.Name);
        }
}

        
}
}