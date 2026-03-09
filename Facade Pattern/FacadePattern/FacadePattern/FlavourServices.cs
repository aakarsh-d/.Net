using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class FlavourServices
    {
        public string GetFlavour()
        {
            Console.WriteLine("Checking available flavour...");
            return "Vanilla Ice Cream";
        }
    }
}
