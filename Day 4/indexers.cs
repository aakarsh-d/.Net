// class StudentCollection
// {
//     private string[] students = { "Aakarsh", "Rahul", "Neha" };

//     public string GetStudent(int index)
//     {
//         return students[index];
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         StudentCollection sc = new StudentCollection();
//     Console.WriteLine(sc.GetStudent(0));
//     }
// }


// indexers

// class box
// {
//     private int[] data=new int[3];
//     public int this[int index]
//     {
//         get{return data[index];}
//         set{data[index]=value;}
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         box b= new box();
//         b[0]=20;
//         b[1]=30;
//         Console.WriteLine(b[0]);
//         Console.WriteLine(b[1]);

//     }
// }


// ------------------

// class Name
// {
//     private string name="Hello";
//     private string name2="me";
//     public string this[string msg]
//     {
//         get{
//             if(msg=="first") return name;
//             else if(msg=="second") return name2;
//             else return "Wrong";
//         }
//     }
// }
// class Program
// {
//     static void Main()
//     {Name n=new Name();
//     Console.WriteLine(n["first"]);
//     Console.WriteLine(n["second"]);

//     }
// }


// ------------------------

// class EmployeeDirectory
// {
//     private Dictionary<int,string> employee=new Dictionary<int,string>();

//     public string this[int id]
//     {
//         get{return employee[id];}
//         set{employee[id]=value;} // it will set value of particular id

//     }
//     public string this[string name]
//     {
//         get{ return employee.FirstOrDefault(e=>e.Value==name).Value;}
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         EmployeeDirectory e=new EmployeeDirectory();
//         e[101]="deku";
//         Console.WriteLine(e[101]);
//         Console.WriteLine(e["deku"]);

//     }
// }


//---------------------------------------------------


// class Library
// {
//     private Dictionary<int,string>dict=new Dictionary<int, string>();

//     public string this[int id]
//     {
//         get{return dict.ContainsKey(id)?dict[id]:"Book not found";}
//         set{dict[id]=value;}
//     }
//     public string this[string name]
//     {
//         get{return dict.FirstOrDefault(e=>e.Value==name).Value;}
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         Library lib=new Library();
//         lib[101]="C++";
//         lib[102]="C#";
//         lib[103]="Python";
//         Console.WriteLine(lib[101]);
//         Console.WriteLine(lib[102]);
//         Console.WriteLine(lib[103]);
//         Console.WriteLine(lib["p"]);
//         Console.WriteLine(lib[105]);



//     }
// }