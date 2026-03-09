using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class ConeServices
    {
        public string GetCone()
        {
            Console.WriteLine("Preparing cone...");
            return "Cone";
        }
    }
}
