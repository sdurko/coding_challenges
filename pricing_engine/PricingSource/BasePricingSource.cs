using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace PricingSource
{
    public class PricingSourceBase : IPricingSource
    {
        readonly IDictionary<string, CancellationTokenSource> _underlyingsSubscriptions;

        private readonly object _locker = new object();


        public event Action<QuoteUpdate> OnPriceUpdateArrived;

        public PricingSourceBase()
        {
            _underlyingsSubscriptions = new Dictionary<string, CancellationTokenSource>();
        }

        public void Start()
        {
            
        }

        public void Stop()
        {
            lock (_locker)
            {
                foreach (var token in _underlyingsSubscriptions.Values)
                    token.Cancel();
            }
        }

        public void Subscribe(string tickerSymbol)
        {
            var symbol = GetKey(tickerSymbol);

            lock (_locker)
            {
                if (!_underlyingsSubscriptions.ContainsKey(symbol))
                {
                    var tokenSource = new CancellationTokenSource();

                    _underlyingsSubscriptions.Add(symbol, tokenSource);

                    //Start the updates
                    var test = Task.Factory.StartNew(() => StartQuoteUpdates(symbol, tokenSource.Token), 
                        tokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                } 
            }
        }

        public void UnSubscribe(string tickerSymbol)
        {
            var symbol = GetKey(tickerSymbol);

            lock(_locker)
            {
                CancellationTokenSource tokenSource;

                if (_underlyingsSubscriptions.TryGetValue(symbol, out tokenSource))
                {
                    tokenSource.Cancel();
                    _underlyingsSubscriptions.Remove(symbol);
                }
            }
        }

        public void Dispose()
        {
            lock (_locker)
            {
                var keys = _underlyingsSubscriptions.Keys.ToList();

                foreach(var key in keys)
                    _underlyingsSubscriptions.Remove(key);

                _underlyingsSubscriptions.Clear();
            }
        }

        private string GetKey(string tickerSymbol)
        {
            return tickerSymbol.Trim().ToUpper();
        }

        private void PublishQuote(QuoteUpdate quoteUpdate)
        {
            if(this.OnPriceUpdateArrived != null)
                this.OnPriceUpdateArrived(quoteUpdate);
        }

        private void StartQuoteUpdates(string tickerSymbol, CancellationToken token)
        {
            var random = new Random();
            var quote = new QuoteUpdate(tickerSymbol, (random.NextDouble() * (random.NextDouble() * 10)));
            
            while (true)
            {
                if (token.IsCancellationRequested)
                    return;

                quote.Last = GetPriceTick(random.NextDouble(),quote.Last);
                quote.Ask = GetPriceTick(random.NextDouble(), quote.Ask);
                quote.Bid = GetPriceTick(random.NextDouble(), quote.Bid);
                quote.Volume += Convert.ToInt32(random.NextDouble() * 100);

                PublishQuote(quote);

                Thread.Sleep(100);
            }
        }

        private double GetPriceTick(double randomNumber,double priceBase)
        {
            return randomNumber > .5 ? priceBase + randomNumber / 100 : priceBase - randomNumber / 100;
        }
    }
}