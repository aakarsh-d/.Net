class Patient
{
    public int PatientId { get; }
    public string Name { get; set; }
    public int Age { get; set; }

    private string medicalHistory;

    public Patient(int id, string name, int age)
    {
        PatientId = id;
        Name = name;
        Age = age;
    }

    public void SetMedicalHistory(string history)
    {
        medicalHistory = history;
    }

    public string GetMedicalHistory()
    {
        return medicalHistory;
    }
}

class Doctor{
    public static int TotalDoctors;
    public readonly string LicenseNUmber;
    public string Name{ get; set;}
    public string Specialization{ get; set;}

    static Doctor(){
        TotalDoctors=0;
    }
    
    public Doctor(string name, string specialization, string license)        
    {
        Name=name;
        Specialization=specialization;            
        LicenseNUmber=license;
        TotalDoctors++;
    }

}

class Cardiologist : Doctor
{
    public Cardiologist(string name,string license) : base(name," cardiology", license){}

}
class Program
{
    public static void Main()
    {
        
        Cardiologist c=new Cardiologist("Deku","12RL");
        Cardiologist c1=new Cardiologist("Dekuu","122RL");
        Console.WriteLine(c.Name);
        Console.WriteLine(c.Specialization);
        Console.WriteLine("Total Dr: "+Doctor.TotalDoctors);
        Console.WriteLine("Total Dr: "+Cardiologist.TotalDoctors);
    }
}