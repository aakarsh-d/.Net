class Program
{
    static void Main()
    {
        var seller = new GoldSellerService();
        var Weighing = new WeighingService();
        var evaluation = new EvaluationService();
        var pricing = new PricingService();
        var payment=new PaymentService();

        seller.GoldSubmitted += Weighing.Weigh;
        Weighing.GoldWeighed += evaluation.Evaluate;
        evaluation.GoldEvaluated += pricing.CalculatePrice;
        pricing.PriceCalculated += payment.Pay;

        seller.SubmitGold("Gold123");
    }
public class GoldSellerService 
{
    public event Action<string> GoldSubmitted;

        public void SubmitGold(string goldId)
        {
            Console.WriteLine($"Gold {goldId} submitted");

            GoldSubmitted?.Invoke(goldId);
        }
    }



    public class WeighingService
    {
        public event Action<string,double> GoldWeighed;
        public void Weigh(string goldId)
        {
            double weight = 10.5;
            Console.WriteLine($"Gold {goldId} weighed");
            GoldWeighed?.Invoke(goldId,weight);
        }
    }


    public class EvaluationService
    {
        public event Action<string, double, int> GoldEvaluated;

        public void Evaluate(string goldId, double weight)
        {
            int karat = 22; 
            Console.WriteLine($"Gold {goldId} evaluated: {karat}K");

            GoldEvaluated?.Invoke(goldId, weight, karat);
        }
    }

    public class PricingService
    {
        public event Action<string, double> PriceCalculated;

        public void CalculatePrice(string goldId, double weight, int karat)
        {
            double ratePerGram = 5000; // example
            double price = weight * ratePerGram * (karat / 24.0);

            Console.WriteLine($"Price calculated for {goldId}: {price}");

            PriceCalculated?.Invoke(goldId, price);
        }
    }

    public class PaymentService
    {
        public void Pay(string goldId, double amount)
        {
            Console.WriteLine($"Payment of {amount} done for {goldId}");
        }
    }
}
