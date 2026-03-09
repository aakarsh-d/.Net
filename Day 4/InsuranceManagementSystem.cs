// using System;
// using System.Collections.Generic;

// // ---------------- SECURITY ----------------
// sealed class SecurityModule
// {
//     public void Authenticate()
//     {
//         Console.WriteLine("User Authenticated");
//     }
// }

// // BASE POLICY ----------------
// abstract class InsurancePolicy
// {
//     public int PolicyNum { get; init; }

//     private double premium;
//     public double Premium
//     {
//         get { return premium; }
//         set
//         {
//             if (value > 0)
//                 premium = value;
//         }
//     }

//     public string PolicyHolderName { get; set; }

//     protected InsurancePolicy(int number, string name, double premium)
//     {
//         PolicyNum = number;
//         PolicyHolderName = name;
//         Premium = premium;
//     }

//     public virtual double CalculatePremium()
//     {
//         return Premium;
//     }

//     public void ShowPolicy()
//     {
//         Console.WriteLine("Insurance Policy");
//     }
// }

// class LifeInsuranceType : InsurancePolicy
// {
//     public LifeInsuranceType(int number, string name, double premium)
//         : base(number, name, premium) { }

//     public override double CalculatePremium()
//     {
//         return Premium + 50;
//     }

//     public new void ShowPolicy()
//     {
//         Console.WriteLine("Life Insurance Policy");
//     }
// }

// class HealthInsurance : InsurancePolicy
// {
//     public HealthInsurance(int number, string name, double premium)
//         : base(number, name, premium) { }

//     public sealed override double CalculatePremium()
//     {
//         return Premium + 2000;
//     }
// }

// class PolicyDirectory
// {
//     private List<InsurancePolicy> policies = new List<InsurancePolicy>();

//     public InsurancePolicy this[int index]
//     {
//         get { return policies[index]; }
//     }

//     public InsurancePolicy this[string name]
//     {
//         get { return policies.Find(p => p.PolicyHolderName == name); }
//     }

//     public void AddPolicy(InsurancePolicy policy)
//     {
//         policies.Add(policy);
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         SecurityModule s = new SecurityModule();
//         s.Authenticate();

//         LifeInsuranceType life = new LifeInsuranceType(1, "Deku", 300);
//         HealthInsurance hi = new HealthInsurance(2, "dll", 900);

//         PolicyDirectory pd = new PolicyDirectory();
//         pd.AddPolicy(life);
//         pd.AddPolicy(hi);

//         Console.WriteLine(pd[0].PolicyHolderName);
//         Console.WriteLine(pd["Deku"].PolicyNum);

//         Console.WriteLine(life.CalculatePremium());
//         Console.WriteLine(hi.CalculatePremium());

//         InsurancePolicy ip = life;
//         ip.ShowPolicy();     // base method
//         life.ShowPolicy();   // hidden method
//     }
// }



// // using System;
// // using System.Collections.Generic;
// // sealed class SecurityModule{
// //     public void authenticate(){
// //         Console.WriteLine("User Authenticated");
// //     }
// // }

// // abstract class InsurancePolicy{
// //     public int PolicyNum{ get; init; }
// //     private double premium;
// //     public double Premium{
// //         get{ return premium; }
// //         set{
// //             if( value > 0 ){
// //                 premium =value;
// //             }
// //         }
// //         }
// //         public string PolicyHolderName{ get; set; }
// //         protected InsurancePolicy(int number,string name, double premium){
// //             PolicyNum = number;
// //             PolicyHolderName=name;
// //             Premium=premium;


// //         }
// //         public virtual double CalculatePremium(){
// //             return Premium;
// //         }
// //         public void ShowPolicy(){
// //             Console.WriteLine("Insurance Policy");
// //         }
    

// //     class LifeInsuranceType: InsurancePolicy{
// //         public LifeInsuranceType( int number, string name, double premium ): base(number,name,premium){}
// //         // base calls parent constructor 
// //     public override double CalculatePremium(){
// //         //changing parent logic
// //         return Premium+50;
// //     }
// //     public new void ShowPolicy()
// //     {
// //         // hides parents methods
// //         Console.WriteLine("Life Insurance Policy");
// //     }
// //     }
// //     class HealthInsurance:InsurancePolicy{
// //         public HealthInsurance(int number,string name,double premium ): base(number,name, premium){}
// //         public sealed override double CalculatePremium(){
// //             return Premium+2000;
// //         }
// // }
// //     class PolicyDirectory
// //     {
// //         private List<InsurancePolicy> policies = new List<InsurancePolicy>();
// //         public InsurancePolicy this[int index]
// //         {
// //             get { return policies[index];}
// //         }
// //         public InsurancePolicy this[string name]{
// //             get {
// //                 return policies.Find(p => p.PolicyHolderName==name);
// //             }
// //         }
// //     public void AddPolicy(InsurancePolicy policy){
// //         policies.Add(policy);
// //     }
// //     }
// // }


// // class Program
// // {
// //     public static void Main()
// //     // {
// //     //    SecurityModule s=new SecurityModule();
// //     //    s.authenticate();
// //     //    LifeInsuranceType life=new LifeInsuranceType()
// //     // {
// //     //     name ="Deku",
// //     //     number=1,
// //     //     premium=300
// //     // };

// //     // HealthInsurance hi= new HealthInsurance(){
// //     //     number=2, 
// //     //     name="dll",
// //     //     premium=900
// //     // };
// //     // PolicyDirectory PD = new PolicyDirectory();
// //     // PD.AddPolicy(life);
// //     // PD.AddPolicy(hi);
// //     // Console.WriteLine(PD[0].name);
// //     // Console.WriteLine(PD["Deku"].number);
// //     // Console.WriteLine(life.CalculatePremium());
// //     // Console.WriteLine(hi.CalculatePremium());

// //     // InsurancePolicy ip= life;
// //     // ip.ShowPolicy();
// //     // life.ShowPolicy();

// //     SecurityModule s = new SecurityModule();
// //         s.Authenticate();

// //         LifeInsuranceType life = new LifeInsuranceType(1, "Deku", 300);
// //         HealthInsurance hi = new HealthInsurance(2, "dll", 900);

// //         PolicyDirectory pd = new PolicyDirectory();
// //         pd.AddPolicy(life);
// //         pd.AddPolicy(hi);

// //         Console.WriteLine(pd[0].PolicyHolderName);
// //         Console.WriteLine(pd["Deku"].PolicyNum);

// //         Console.WriteLine(life.CalculatePremium());
// //         Console.WriteLine(hi.CalculatePremium());

// //         InsurancePolicy ip = life;
// //         ip.ShowPolicy();     // base method
// //         life.ShowPolicy();   // hidden method
// //     // }
// // }