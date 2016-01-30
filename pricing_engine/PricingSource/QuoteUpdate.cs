namespace PricingSource
{
    public class QuoteUpdate
    {
        public string TickerSymbol = string.Empty;
        public double Last { get; set;}
        public double Bid { get; set;}
        public double Ask { get; set;}
        public int Volume { get; set; }

        public QuoteUpdate(string tickerSymbol,double lastPrice)
        {
            TickerSymbol = tickerSymbol;
            Last = lastPrice;
            Bid = lastPrice - 1.00;
            Ask = lastPrice + 1.00;
            Volume = 100;
        }
    }
}