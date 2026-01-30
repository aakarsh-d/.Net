using System;
using System.Collections.Generic;

public class Student
{
    public string Name{get;set;}
    public int Age{get;set;}
    public int Marks{get;set;}

    public override string ToString()
    {
        return $"{Name} | Age: {Age} | Marks: {Marks}";
    }
}

public class StudentComparer:IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        if (x==null&&y==null) return 0;
        if (x==null)return 1;
        if (y==null)return -1;

        int marksCompare=y.Marks.CompareTo(x.Marks);
        if (marksCompare != 0)
            return marksCompare;

        return x.Age.CompareTo(y.Age);
    }
}

class Program
{
    static void Main()
    {
        List<Student>students = new()
        {
            new Student{Name="A",Age=21, Marks= 85 },
            new Student{Name="B",Age=19,Marks=90},
            new Student{Name="C",Age=18, Marks=90}
        };

        students.Sort(new StudentComparer());

        foreach(var s in students)
            Console.WriteLine(s);
    }
}
