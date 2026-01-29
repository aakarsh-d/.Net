// class Patient
// {
//     public int PatientId { get; }
//     public string Name { get; set; }
//     public int Age { get; set; }

//     private string medicalHistory;

//     public Patient(int id, string name, int age)
//     {
//         PatientId = id;
//         Name = name;
//         Age = age;
//     }

//     public void SetMedicalHistory(string history)
//     {
//         medicalHistory = history;
//     }

//     public string GetMedicalHistory()
//     {
//         return medicalHistory;
//     }
// }

// class Doctor{
//     public static int TotalDoctors;
//     public readonly string LicenseNUmber;
//     public string Name{ get; set;}
//     public string Specialization{ get; set;}

//     static Doctor(){
//         TotalDoctors=0;
//     }

//     public Doctor(string name, string specialization, string license)        
//     {
//         Name=name;
//         Specialization=specialization;            
//         LicenseNUmber=license;
//         TotalDoctors++;
//     }

// }

// class Cardiologist : Doctor
// {
//     public Cardiologist(string name,string license) : base(name," cardiology", license){}

// }
// class Program
// {
//     public static void Main()
//     {

//         Cardiologist c=new Cardiologist("Deku","12RL");
//         Cardiologist c1=new Cardiologist("Dekuu","122RL");
//         Console.WriteLine(c.Name);
//         Console.WriteLine(c.Specialization);
//         Console.WriteLine("Total Dr: "+Doctor.TotalDoctors);
//         Console.WriteLine("Total Dr: "+Cardiologist.TotalDoctors);
//     }
// }



// Assignment project - Hostpital Management System

using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

class Patient
{
    public int PatientId {get;}
    public string Name{get; set;}
    public int Age{get; set;} 
    private string medicalHisotry;

    public Patient(int id, string name,int age)
    {
        PatientId=id;
        Name=name;
        Age=age;
    }

    public void setMedicalHistory(string history)
    {
        medicalHisotry=history;
    }
    public string getMedicalHistory()
    {

        return medicalHisotry;
    }
}

class Doctor
{
    public static int TotalDoctors;
    public readonly string LicenseNumber;
    public string Name{get;set;}
    public string Speciliazation{get;set;}
    static Doctor()
    {
        TotalDoctors=0;
    }
    public Doctor(string name,string spec,string LicNo)
    {
        Name=name;
        Speciliazation=spec;
        LicenseNumber=LicNo;
        TotalDoctors++;
    }
}

// class Cardiologist:Doctor
// {
    
// }

class Appointment
{
    public static void Schedule(Patient p, Doctor d)
    {
        Console.WriteLine($"Appointment for {p.Name} is Scheduled with Dr. {d.Name}");
    }
    public static void Schedule(Patient p,Doctor d,DateTime date,string mode = "Offline")
    {
        Console.WriteLine($"Appointment Scheduled for {date.ToShortDateString()} {mode}");
    }
}

class DiagnosisService
{
    public static void Evaluate(in int age,ref string condition, 
    out string riskLevel,params int[] testScores)
    {
        int total=0;
        foreach(int score in testScores) total+=score;
        static bool IsCritical(int total){ return total>250;}

        if(IsCritical(total)||age>60){condition="Critical"; riskLevel="High";}
        else riskLevel="Moderate";
    }
}

class Billing
{
    public double ConsultationFee{get;set;}
    public double TestCharges{get;set;}
    public double RoomCharges{get;set;}
    public double Total()
    {
        return ConsultationFee+TestCharges+RoomCharges;
    }
}

class Insurance
{
    public static double ApplyCoverage(double billAmount,int coveragePercent)
    {
        double discount=(billAmount*coveragePercent)/100;
        return billAmount-discount;
    }
}

class InputHelper
{
    public static int ReadAge(string input)
    {
        if(int.TryParse(input,out int age)) return age;

        throw new Exception("Invalid Age Input");
    }
}
class HospitalSystem
{
    public const string HospitalName="SmartCare Hospital";
    static HospitalSystem()
    {
        Console.WriteLine($"{HospitalName} is Booting up...");
    }
}
class Program
{
    static int CalculateStayDay(int days)
    {
        if(days<=0) return 0;
        return 1+CalculateStayDay(days-1);
    }
   static void Main(){
    Patient patient=new Patient(1,"Deku",21);
    patient.setMedicalHistory("No prior illnesses");
    patient.getMedicalHistory();

    Doctor doctor=new Doctor("Dr. Deku","Cardiology","LIC145");
    Appointment.Schedule(patient,doctor);
    Appointment.Schedule(patient,doctor,DateTime.Now,"Online");

    string condition="Stable";
    string riskLevel;
    int age=patient.Age;
    DiagnosisService.Evaluate(in age,ref condition,out riskLevel,80,90,85);



    Billing bill=new Billing //Object initializer
    {
        ConsultationFee=500,
        TestCharges=1500,
        RoomCharges=2000
    };
    Console.WriteLine($"TotalBill: {bill.Total()}");

    //After Insurance

    double finalAmt=Insurance.ApplyCoverage(bill.Total(),20);
    Console.WriteLine($"Final amount after insurance: {finalAmt}");

    }   
    
}