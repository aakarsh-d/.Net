// class Calculator
// {
//     public static void Divide(int a, int b, out int quotient, out int remainder)
//     {
//         quotient = a / b;
//         remainder = a % b;
//     }
// }

// class Pr
// {
//     static void Main()
//     {
//         int q, r;   // no initialization required

//         Calculator.Divide(10, 3, out q, out r);

//         Console.WriteLine("Quotient = " + q);
//         Console.WriteLine("Remainder = " + r);
//     }
// }


// class Student
// {
//     public static void GetResult(int marks, out string grade)
//     {
//         if (marks >= 60)
//             grade = "Pass";
//         else
//             grade = "Fail";
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         string result;
//         Student.GetResult(75, out result);
//         Console.WriteLine(result);
//     }
// }