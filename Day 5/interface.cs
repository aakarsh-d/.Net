// interface IPrintable
// {
//     void Print();
//     void Scan();
//     // int Count;
// }

// class Report : IPrintable
// {
//     public void Print()
//     {
//         Console.WriteLine("Printing report");
//     }
//     public void Scan()
//     {
//         Console.WriteLine("Printing report");
//     }
//     // if we will callonly Print then it will give error Interfaces cannot contain instance fields
//     // 'Report' does not implement interface member 'IPrintable.Scan()'
//     public static void Main(string[] args)
//     {
//         Report report = new Report();
//         // ref Report p = report;
//         report.Print();
//         report.Scan();

//     }
// }