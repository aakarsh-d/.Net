

using System.Data.Common;
using System.Reflection.Metadata;

class User
{
    public int Id;
    public string Name;

}
class Program
{
    static void Main()
    {
        User user = new User{Id=1,Name="Bob"};

        using(BinaryWriter writer=new BinaryWriter(File.Open("user.bin", FileMode.Create)))
        {
            writer.Write(user.Id);
            writer.Write(user.Name);
            user.Id=2;
            user.Name="Alice";
            writer.Write(user.Id);
            writer.Write(user.Name);
        }
        Console.WriteLine("Binary Data Saved");

        using (BinaryReader reader=new BinaryReader(File.Open("user.bin",FileMode.Open)))
        {
            Console.WriteLine(reader.ReadInt32());
            Console.WriteLine(reader.ReadString());
        }
    }
}