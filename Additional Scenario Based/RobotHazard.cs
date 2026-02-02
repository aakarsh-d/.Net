
//Robot Hazard

using System;
   public class RobotSafetyException:Exception
{
    public RobotSafetyException(string message):base(message){}
}

class RobotHazardAuditor
{
    public double CalculateHazardRisk(double armPrecision,int workerDensity,string machineryState)
    {
        if(armPrecision<0.0 || armPrecision>1.0)
        throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
        if(workerDensity<1 || workerDensity>20)
        throw new RobotSafetyException("Error: Worker density must be 1-20");
        
        double machineRiskFactor;
        if(machineryState=="Worn") machineRiskFactor=1.3;
        else if(machineryState=="Faulty") machineRiskFactor=2.0;
        else if(machineryState=="Critical") machineRiskFactor=3.0;
        else throw new RobotSafetyException("Error: Unsupported machinerey state");

        double hazardRisk=(((1.0-armPrecision)*15.0)+(workerDensity*machineRiskFactor));
        return hazardRisk;
    }
}
class Program{
    public static void Main()
    {
        try{
            RobotHazardAuditor aud=new RobotHazardAuditor();
            Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
            double armPr=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Worker Density (1 - 20):");
            int workerDensity=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical)");
            string machineryState=(Console.ReadLine());

            double res=aud.CalculateHazardRisk(armPr,workerDensity,machineryState);
            Console.WriteLine("Robot Hazard Score: "+res);
        }
        catch(RobotSafetyException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
