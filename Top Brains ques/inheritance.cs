using System;

public class Solution
{
    abstract class Employee
    {
        public abstract decimal GetPay();
    }

    class HourlyEmployee : Employee
    {
        decimal rate, hours;

        public HourlyEmployee(decimal r, decimal h)
        {
            rate = r;
            hours = h;
        }

        public override decimal GetPay()
        {
            return rate * hours;
        }
    }

    class SalariedEmployee : Employee
    {
        decimal salary;

        public SalariedEmployee(decimal s)
        {
            salary = s;
        }

        public override decimal GetPay()
        {
            return salary;
        }
    }

    class CommissionEmployee : Employee
    {
        decimal commission, baseSalary;

        public CommissionEmployee(decimal c, decimal b)
        {
            commission = c;
            baseSalary = b;
        }

        public override decimal GetPay()
        {
            return baseSalary + commission;
        }
    }

    public decimal TotalPayroll(string[] employees)
    {
        decimal total = 0;

        foreach (string e in employees)
        {
            if (string.IsNullOrWhiteSpace(e))
                continue;

            string[] p = e.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Employee emp = null;

            if (p[0] == "H" && p.Length == 3)
                emp = new HourlyEmployee(decimal.Parse(p[1]), decimal.Parse(p[2]));
            else if (p[0] == "S" && p.Length == 2)
                emp = new SalariedEmployee(decimal.Parse(p[1]));
            else if (p[0] == "C" && p.Length == 3)
                emp = new CommissionEmployee(decimal.Parse(p[1]), decimal.Parse(p[2]));

            if (emp != null)
                total += emp.GetPay();
        }

        return Math.Round(total, 2, MidpointRounding.AwayFromZero);
    }
}
