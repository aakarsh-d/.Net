class Shipment
{
    public string ShipmentCode{get;set;}
    public string TransportMode{get;set;}
    public double Weight{get;set;}
    public int StorageDays{get;set;}
}

class ShipmentDetails : Shipment
{
    public bool ValidateShipmentCode()
    {
        if(ShipmentCode.Length!=7)
        return false;

        if(!ShipmentCode.StartsWith("GC#"))
        return false;

        string numericPart=ShipmentCode.Substring(3);
        foreach(var n in numericPart)
        {
            if(!char.IsDigit(n))
            return false;
        }
        return true;
    }
    public double CalculateTotalCost()
    {
        double ratePerKg=0;

        switch (TransportMode)
        {
            case "Sea":
            ratePerKg=15.00;
            break;
            case "Air":
            ratePerKg=50.00;
            break;
            case "Land":
            ratePerKg=25.00;

            break;  
            default:
            Console.WriteLine("Invalid");
            break;
              }    
        double totalCost=(Weight*ratePerKg)+Math.Sqrt(StorageDays);

        return Math.Round(totalCost,2);
    }
}

class Program
{
    public static void Main()
    {

        ShipmentDetails shipment=new ShipmentDetails();


          Console.WriteLine("Enter Shipment Code:");
            shipment.ShipmentCode = Console.ReadLine();

            if (!shipment.ValidateShipmentCode())
            {
                Console.WriteLine("Invalid shipment code");
                return;
            }

            Console.WriteLine("Enter Transport Mode:");
            shipment.TransportMode = Console.ReadLine();

            Console.WriteLine("Enter Weight:");
            shipment.Weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Storage Days:");
            shipment.StorageDays = Convert.ToInt32(Console.ReadLine());

            double totalCost = shipment.CalculateTotalCost();

            Console.WriteLine("The total shipping cost is " + totalCost.ToString("F2"));
        
    }
}