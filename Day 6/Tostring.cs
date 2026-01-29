class Trade
{
    public int TradeId;
    public double Amount;

    public override string ToString()
    {
        return $"Trade Id : {TradeId}, Amount : {Amount}";
    }
    public static void Main()
    {
        Trade t=new Trade()
        {
            TradeId=101, Amount=50000
        };
        Console.WriteLine(t);
    }
}