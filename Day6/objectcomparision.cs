// class Portfolio
// {
//     public string Name;

//     public override bool Equals(object obj)
//     {
//         Portfolio p = obj as Portfolio;
//         return p != null && p.Name == Name;
//     }
//     public override int GetHashCode(){
//         return Name.GetHashCode();
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Portfolio p1 = new Portfolio { Name = "Growth" };
//         Portfolio p2 = new Portfolio { Name = "Growth" };

//         Console.WriteLine(p1.Equals(p2));
//         Console.WriteLine(p1.GetHashCode());
//         Console.WriteLine(p2.GetHashCode());
//     }
// }