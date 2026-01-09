

// using System.Data.Common;
// using System.Text.Json;

// class User
// {
//     public int ID;
//     public string Name;
// }
// class Program{
//     static void Main()
//     {
//         User user =new User{ ID=1,Name="Alice"};
//         string json =JsonSerializer.Serialize(user);

//         File.WriteAllText("user.json",json);
//         Console.WriteLine("User Serialized successfully");
//     }
// }

// using System.Reflection.Metadata;
// using System.Text.Json;

// class User
// {
//     public int ID{ get; set;}
//     public string Name{ get; set;}
// }
// class Program
// {
//     static void Main()
//     {
//         string json=File.ReadAllText("user.json");
//         User user =JsonSerializer.Deserialize<User>(json);
//         Console.WriteLine($"User Loaded: {user.ID}, {user.Name}");
// }
// }


using System.Data.Common;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

[Serializable]
public class User
{
    public int ID{ get; set;}
    public string Name{ get; set;}
}
class Program
{
    static void Main()
    {
        User user=new User{ ID=1,Name="Alice"};
        XmlSerializer serializer = new XmlSerializer(typeof(User));
        using (FileStream fs =new FileStream("user.xml", FileMode.Create))
        {
            serializer.Serialize(fs,user);
        }
        Console.WriteLine(typeof(User));
        Console.WriteLine("XML serialized");
    }
}