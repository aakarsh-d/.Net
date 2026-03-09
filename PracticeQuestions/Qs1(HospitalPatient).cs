// public class Patient
// {
// // TODO: Add properties with get/set accessors
// // TODO: Add constructor
//     public int Id{get;set;}
//     public string Name{get;set;}
//     public int Age{get;set;}
//     public string Condition{get;set;}

//     public Patient(int id,string name,int age,string condition){
//         Id=id;
//         Name=name;
//         Age=age;
//         Condition=condition;

//     }
// }
// // Task 2: Implement HospitalManager class
// public class HospitalManager
// {
// private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
// private Queue<Patient> _appointmentQueue = new Queue<Patient>();
// // Add a new patient to the system
// public void RegisterPatient(int id, string name, int age, string condition)
// {
//         // TODO: Create patient and add to dictionary
//         if (!_patients.ContainsKey(id))
//         {
//             Patient patient=new Patient(id,name,age,condition);
//             // _patients.Add(id,new Patient(id,name,age,condition));
//             _patients.Add(id,patient);
//         }
//         else
//         {
//             Console.WriteLine("Patient already exists");
//         }
// }
// // Add patient to appointment queue
// public void ScheduleAppointment(int patientId)
// {

//         // TODO: Find patient and add to queue
//         if (_patients.ContainsKey(patientId))
//         {
//             _appointmentQueue.Enqueue(_patients[patientId]);
//         }
//         else 
//         Console.WriteLine("Patient not found");
// }
// // Process next appointment (remove from queue)
// public Patient ProcessNextAppointment()
// {
// // TODO: Return and remove next patient from queue
//     if(_appointmentQueue.Count>0)
//     return _appointmentQueue.Dequeue();

//     return null;
// }
// // Find patients with specific condition using LINQ
// public List<Patient> FindPatientsByCondition(string condition)
// {
// // TODO: Use LINQ to filter patients
//     return _patients.Values.Where(x=>x.Condition.Equals(condition,StringComparison.OrdinalIgnoreCase)).ToList();
// }
// }
// class Program
// {
//     static void Main(){
//     HospitalManager hp=new HospitalManager();
//     hp.RegisterPatient(1,"John Doe",45,"Hypertension");
//     hp.RegisterPatient(2,"Jane Smith",32,"Diabetics");

//     hp.ScheduleAppointment(1);
//     hp.ScheduleAppointment(2);

//     var nextPatient=hp.ProcessNextAppointment();
//     Console.WriteLine(nextPatient.Name);

//     var patientbycondition=hp.FindPatientsByCondition("Diabetics");
//     Console.WriteLine(patientbycondition.Count);
// }}