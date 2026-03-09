
// 9) Character Counter - String Analytics

// Given input string, count occurrences of each character using dictionary.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string t = Console.ReadLine();
        string text=t.ToLower();
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        // TODO: Build frequency and display sorted output
        foreach(var v in text)
        {
            if(charCount.ContainsKey(v))
            charCount[v]++;
            else
            charCount[v]=1;
        }
        foreach(var entry in new SortedDictionary<char, int>(charCount))
        {
            Console.WriteLine($"{entry.Key} -> {entry.Value}");
        }
    }
}

