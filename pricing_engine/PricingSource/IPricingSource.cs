using System;

namespace PricingSource
{
    public interface IPricingSource : IDisposable
    {
        void Start();

        void Stop();

        void Subscribe(string tickerSymbol);

        void UnSubscribe(string tickerSymbol);

        event Action<QuoteUpdate> OnPriceUpdateArrived;
    }
}