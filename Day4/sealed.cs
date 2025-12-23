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


