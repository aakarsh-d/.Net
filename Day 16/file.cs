

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Start reading file...");
  
        string content=await File.ReadAllTextAsync("data.txt");
        Console.WriteLine(content);
        Console.WriteLine("End of program");
    }
}