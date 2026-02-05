using System;
using System.Text;
using System.Globalization;

class Program
{
    static string CleanInventoryName(string s)
    {
        if (string.IsNullOrEmpty(s))
            return s;
        StringBuilder sb = new StringBuilder();
        sb.Append(s[0]);
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] != s[i - 1])
                sb.Append(s[i]);
        }
        string cl = sb.ToString();
        string[] words = cl.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i=0;i<words.Length;i++)
        {
            string w=words[i].ToLower();
            words[i]=char.ToUpper(w[0]) + w.Substring(1);
        }
        return string.Join(" ",words);
    }
    static void Main()
    {
        string input=" llapppptop bag ";
        Console.WriteLine(CleanInventoryName(input));
    }
}
