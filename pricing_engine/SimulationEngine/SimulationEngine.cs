using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DomainObjects;
using PricingSource;

namespace MarketDataServices
{
    public interface ISimulationEngine
    {
        void Start();
        void Stop();

        void Initialize(int numberOfSources);
        void UnInitialize();

        void Subscribe(string tickerSymbol);
        void Unsubscribe(string tickerSymbol);

        event Action<Quote> OnQuoteUpdate;
    }

    public class SimulationEngine : ISimulationEngine
    {
        readonly IDictionary<int,IPricingSource> _pricingSources;
        static readonly Object _locker = new object();
        int _numberOfSources;
        
        public event Action<Quote> OnQuoteUpdate;


        public SimulationEngine()
        {
            _pricingSources = new Dictionary<int,IPricingSource>();
        }

        public void Initialize(int numberOfSources)
        {
            _numberOfSources = numberOfSources;

            for (int x = 1; x <= _numberOfSources; x++)
            {
                var pricingSource = new PricingSourceBase();
                pricingSource.OnPriceUpdateArrived += UpdateArrived;

                lock(_locker)
                {
                    _pricingSources.Add(x, pricingSource);
                }
            }
        }

        public void UnInitialize()
        {
            lock(_locker)
            {
                for (int x = 1; x <= _numberOfSources; x++)
                {
                    _pricingSources[x].OnPriceUpdateArrived -= UpdateArrived;
                    _pricingSources[x].Dispose();
                    _pricingSources.Remove(x);
                }
            }
        }

        public void Start()
        {
            lock(_locker)
            {
                foreach (var pricingSource in _pricingSources.Values)
                    pricingSource.Start();
            }
        }

        public void Stop()
        {
            lock (_locker)
            {
                foreach (var pricingSource in _pricingSources.Values)
                    pricingSource.Stop();
            }
        }

        public void Subscribe(string tickerSymbol)
        {
            GetPricingSource(tickerSymbol).Subscribe(tickerSymbol);
        }

        public void Unsubscribe(string tickerSymbol)
        {
            GetPricingSource(tickerSymbol).UnSubscribe(tickerSymbol);
        }

        private void UpdateArrived(QuoteUpdate quoteUpdate)
        {
            if(OnQuoteUpdate != null)
            {
                OnQuoteUpdate(new Quote()
                                  {
                                      Ask = quoteUpdate.Ask,
                                      Bid = quoteUpdate.Bid,
                                      Last = quoteUpdate.Last,
                                      Symbol = quoteUpdate.TickerSymbol,
                                      Volume = quoteUpdate.Volume
                                  });
            }
        }

        private string GetFirstLetterOfSymbol(string tickerSymbol)
        {
            var result = "";

            if(!string.IsNullOrEmpty(tickerSymbol) && tickerSymbol.Length >= 1)
                result = tickerSymbol.Substring(0, 1).ToUpper();

            return result;
        }

        private int GetPricingSourceId(string firstLetterOfSymbol)
        {
            if (Regex.IsMatch(firstLetterOfSymbol, "[A-H]"))
                return 1;
            
            return Regex.IsMatch(firstLetterOfSymbol, "[I-Q]") ? 2 : 3;
        }

        private IPricingSource GetPricingSource(string tickerSymbol)
        {
            IPricingSource result = null;

            lock(_locker)
            {
                _pricingSources.TryGetValue(GetPricingSourceId(GetFirstLetterOfSymbol(tickerSymbol)), out result);
            }

            return result;
        }
    }
}