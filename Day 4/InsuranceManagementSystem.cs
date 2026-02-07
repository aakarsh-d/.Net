using System;

using System.Collections.Generic;

sealed class SecurityModule
{
    public void Authenticated(){
    Console.WriteLine("User Authenticated");
    }
}

abstract class InsurancePolicy
{
    public int PolicyNum{get;init;}
    private double premium;
    public double Premium{get{return premium;} set{if(value>0)
                    premium=value;}}
    public string PolicyHolderName{get;set;}
    
    public InsurancePolicy(int num,string name,double prem){
        PolicyNum=num;
        PolicyHolderName=name;
        Premium=prem;
    }
    public virtual double CalculatePremium()
    {
        return premium;
    }
    public void ShowPolicy()
    {
        Console.WriteLine("Insurance Policy");

    }
}

class LifeInsurance : InsurancePolicy
{
    public LifeInsurance(int num,string name,double prem)
                    :base(num,name,prem){}
    public override double CalculatePremium()
    {
        return Premium+50;
    }
    public new void ShowPolicy()
    {
        Console.WriteLine("Lide Insurance Policy");
    }
}

class HealthInsurance : InsurancePolicy
{
    public HealthInsurance(int num,string name,double prem)
                        :base(num,name,prem){}
    public sealed override double CalculatePremium()
    {
        return Premium+200;
    }
}

class PolicyDirectory
{
    private List<InsurancePolicy>policies=new List<InsurancePolicy>();
    public InsurancePolicy this[int index]
    {
        get{return policies[index];}
    }
    public InsurancePolicy this[string name]
    {
        get{return policies.Find(p=>p.PolicyHolderName==name);}
    }
    public void AddPolicy(InsurancePolicy policy)
    {
        policies.Add(policy);
    }
}

class Program
{
    public static void Main()
    {
        SecurityModule authenticate=new SecurityModule();

        authenticate.Authenticated();

        LifeInsurance life=new LifeInsurance(1,"Deku",600);
        HealthInsurance health=new HealthInsurance(2,"She",900);

        PolicyDirectory policy=new PolicyDirectory();
        policy.AddPolicy(life);
        policy.AddPolicy(health);

        Console.WriteLine(policy[0].PolicyHolderName);
        Console.WriteLine(policy[1].PolicyHolderName);


        InsurancePolicy i=life;
        i.ShowPolicy();
        life.ShowPolicy();


    }
}