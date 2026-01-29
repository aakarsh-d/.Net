

using System.Collections.Specialized;
using System.Text;

public delegate bool IsEligibleScholarship(Student std);

class Student
{
    public int RollNo{ get; set;}
    public string Name{ get; set;}
    public int Marks{ get; set;}
    public char SportsGrade{get; set;}

    public static string GetEligibleStudent(List<Student> studentsList, IsEligibleScholarship isELigible)
    {
       StringBuilder st=
    }
}

public class Program
{

    public static ScholarshipElibility(Student std)
    {
        if(std.Marks>80 && std.SportsGrade == 'A')
        {
            return true;
        }
        return false;
    }
    static void Main(string[] args)
    {
        
    }
}