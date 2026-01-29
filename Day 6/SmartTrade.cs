// //Mini Project: SmartTrade – Real-Time Trading System Using Advanced C#

// // task 1 
// struct PriceSnapshot{
//     public string StockSymbol;
//     public double StockPrice;
// }

// // task 2 base trade abstraction

// abstract class Trade{
//     public int TradeID;
//     public string Symbol;
//     public int Quantity;

//     public abstract double CalculateTradeVal();

//     public override string ToString(){
//         return $"Trade ID : {TradeID}, Symbol : {Symbol}, Quantity : {Quantity} ";

//     }
// }

// //task 3

// class EquityTrade : Trade{
//     public double?MarketPrice;

//     public override double CalculateTradeVal(){
//         double res = MarketPrice??0;
//         return res*Quantity;
//     }
//     public override string ToString(){
//         return base.ToString() + $"MarketPrice : {MarketPrice}";
//     }
    
// }
// //task 5
// public static class TradeAnalytics
// {
//     public static int TotalTrades;
   
//     public static void DisplayAnalytics(){
//         Console.WriteLine("Total Trades in list : "+ TotalTrades);
//     }
// }

// //task 4 

// class TradeRepository<T> where T : Trade{
//     private List<T> trades = new List<T>();
//     // public int tradenumber;
//     public void AddTrade(T trade){
//         trades.Add(trade);
//         TradeAnalytics.TotalTrades++;
//     }
//     public void Display(){
//         foreach( T trade in trades){
//             Console.WriteLine(trade);
//         } 
//     }
// }

// // task 6 
// public static class Extensions{
//     public static double BrokerageCalc(this double amount){
//         return amount * 0.5;
//     }
//     public static double TaxCalc(this double amount){
//         return amount *0.18;
//     }
// }
// class Program {
//     public static void Main(string[] args) {

//         PriceSnapshot pc = new PriceSnapshot(){
//             StockSymbol="AAPL",
//             StockPrice=1789
//         };
//         Console.WriteLine($"Stock Symbol: {pc.StockSymbol}");
//         Console.WriteLine($"Stock Price: {pc.StockPrice}");
//         EquityTrade trade = new EquityTrade{
//             TradeID=101,
//             Symbol="LTI",
//             Quantity=16932
//         };
//         Console.WriteLine(trade.ToString());

//         // task 3 output market price withpresent and null
//         EquityTrade trade1 = new EquityTrade{
//             TradeID=101,
//             Symbol="LTI",
//             Quantity=16932,
//             MarketPrice=123
//         };
//         Console.WriteLine(trade1.ToString());
//         EquityTrade trade2=new EquityTrade{
//             TradeID=102,
//             Symbol="IFY",
//             Quantity=147893,
//             MarketPrice=null
//         };
//         Console.WriteLine(trade2.ToString());

//         TradeRepository<EquityTrade> repo = new TradeRepository<EquityTrade>();

//         repo.AddTrade(trade1);
//         repo.AddTrade(trade2);
//         Console.WriteLine("Repository Contents : ");
//         repo.Display();

//         TradeAnalytics.DisplayAnalytics();

//         //task 6 
//         double tradeval=trade1.CalculateTradeVal();
//         Console.WriteLine("Tax : "+tradeval);
//         double brokercharge=tradeval.BrokerageCalc();
//         Console.WriteLine("Broker Charge : " +brokercharge);
//         double Tax=tradeval.TaxCalc();
//         Console.WriteLine("Tax : "+Tax);


//     }
// }


















// // 
// // //task 1 Market price snapshot
// // struct PriceSnapshot{
// //     public string StockSymbol;
// //     public double StockPrice;
    
// // }

// // //task 2 Base Trade Abstraction

// // abstract class Trade{
// //     int TradeId;
// //     string Symbol;
// //     int Quantity;

// //     public abstract double CalculateTradeValue();
// //     public override string ToString(){
// //         return $" TradeId : {TradeId}, Symbol : {Symbol}, Qty: {Quantity}";
// //     }
// // }

// // // task 3 Equity Trade Implementation

// // class EquityTrade : Trade {
// //     double? MarketPrice;
// //     public override double CalculateTradeValue(){
// //         int result = MarketPrice?? 0;
// //         return result * Quantity;
// //     }

// // }
// // // task 4 Genric Trade Repo

// // class TradeRepository<T> where T : Trade
// // {
// //     private List<T> trades= new List<T>();
// //     public int tradenumber;
// //     public void addTrade(T trade){
// //         trade.Add(trade);
// //         tradenumber++;
// //     }
// // }

// // class Program{
// //     static void Main(string[] args){
// //         PriceSnapshot snapshot= new PriceSnapshot();
// //         {
// //             StockSymbol="LTI";
// //             StockPrice=149;
// //         }
// //         Console.WriteLine($"Stock Symbol : {snapshot.StockSymbol}");
// //         Console.WriteLine($"Stock Price : {snapshot.Price}");

// //     EquityTrade temptrade = new EquityTrade{
// //         TradeId= 1,
// //         Symbol="TCS",
// //         Quantity= 100
// //     };
// //     Console.WriteLine(temptrade);


// //     temptrade.MarketPrice = 150.99;
// //     Console.WriteLine($"Trade Value: {tempTrade.CalculateTradeValue()}");

// //     temptrade.MarketPrice = null;
// //     Console.WriteLine($"Trade Value: {tempTrade.CalculateTradeValue()}");


// //     // task 4 -> output atleast 2 trades and show repo content

// //     // TradeRespository<EquityTrade> repo =new TradeRespository<EquityTrade>();
// //     // repo.AddTrade
// //     }
// // }