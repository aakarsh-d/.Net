// using System;
// namespace HelloWorldApp{
// class Employee{
//     int Id;
//     string Name;
//     string Department;
//     float Salary;
//     char Gender;
//     public void AcceptDetails()
//     {
//         Console.WriteLine("Enter Employees Details:");
//         Console.WriteLine("Enter Employees ID:");
//         Id=Convert.ToInt32(Console.ReadLine());  //explicit conversion
//         //Id=int.Parse(Console.ReadLine());
//         // Console.ReadLine(Id);
//         Console.WriteLine("Enter Employees Name:");
//         Name=Console.ReadLine();
//         // Console.ReadLine(Name);
//         Console.WriteLine("Enter Employees Department:");
//         // Console.ReadLine(Department);
//         Department=Console.ReadLine();
//         Console.WriteLine("Enter Employees Salary:");    
//         Salary=Convert.ToSingle(Console.ReadLine());    
//         // Console.ReadLine(Salary);
//         Console.WriteLine("Enter Employees Gender:");
//         Gender=Convert.ToChar(Console.ReadLine());
//         // Console.ReadLine(Gender);
//     }
//     public void DisplayDetails()
//     {
//         Console.WriteLine("Employees Details are:");
//         Console.WriteLine($"Employee ID is {Id}");
//         Console.WriteLine($"Employee Name is {Name}");
//         Console.WriteLine($"Employee Department is {Department}");    
//         Console.WriteLine($"Employee Salary is {Salary}");
//         Console.WriteLine($"Employee Gender is {Gender}");
//     }
// }}