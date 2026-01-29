
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        // StringBuilder sb=new StringBuilder();
        // sb.Append("Hello").Append("Append");
        // sb.Append(" ");
        // sb.Append("World");
        // sb.AppendLine();
        // sb.AppendLine("Line");
        // sb.Insert(0,"Start");
        // sb.Replace("Old","New");
        // // sb.Clear();
        // Console.WriteLine(sb.ToString());

        // Console.WriteLine(GC.GetTotalMemory(false));
        // StringBuilder st=new StringBuilder();
        // for(int i = 0; i < 10000; i++)
        // {
        //     st.Append(i);
        // }
        // string res=st.ToString();

        // Console.WriteLine(GC.GetTotalMemory(false));

        // StringBuilder s1=new StringBuilder("Hello");
        // StringBuilder s2=new StringBuilder("Hello");

        // Console.WriteLine(s1.Equals(s2));
        // Console.WriteLine(s1==(s2));
        // StringBuilder s3= s2;
        String str1= new String("Hello");
        String str2= new String("Hello");
        String st1= "Hello";
        String st2= "Hello";
        Console.WriteLine(st1==(st2));
        Console.WriteLine(st1.Equals(st2));
        Console.WriteLine(Object.ReferenceEquals(st1,st2));
        Console.WriteLine(Object.ReferenceEquals(str1,str2));

        Console.WriteLine(str1==(str2));
        Console.WriteLine(str1.Equals(str2));
        // Console.WriteLine("Equals in string: "+st1==(st2));
        // Console.WriteLine(s3.Equals(s2));
        // int* p1 =&s1;  // this is not allowed in strings
        // int* p2 =&s2;
        // int* p3 =&s3;
        // Console.WriteLine((long )p1);
        // Console.WriteLine((long )p2);
        // Console.WriteLine((long )p3);
    }
}