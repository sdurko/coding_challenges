using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using DomainObjects;
using System.Linq;

namespace Pricing_Sheet
{
    public class MainWindowViewModel
    {
        readonly QuoteUpdater _quoteUpdater;
        readonly ObservableCollection<Quote> _quotes = new ObservableCollection<Quote>();
        readonly Dispatcher _dispatcher = null;
        readonly Object _locker = new object();

        public ObservableCollection<Quote> Quotes
        {
            get { return _quotes; }
        }

        public MainWindowViewModel(Dispatcher dispatcher)
        {
            this._dispatcher = dispatcher;

            _quoteUpdater = new QuoteUpdater();
            _quoteUpdater.OnQuoteUpdate += QuoteUpdater_OnQuoteUpdate;
            _quoteUpdater.Start();
        }

        public void Subscribe(string tickerSymbol)
        {
            _quoteUpdater.Subscribe(tickerSymbol);
        }

        public void UnSubscribe(string tickerSymbol)
        {
            _quoteUpdater.UnSubscribe(tickerSymbol);
        }

        public void Stop()
        {
            _quoteUpdater.Stop();
        }

        private void QuoteUpdater_OnQuoteUpdate(Quote quoteUpdate)
        {
            lock (_locker)
            {
                var quote = _quotes.FirstOrDefault(x => x.Symbol == quoteUpdate.Symbol);

                if (quote == null)
                {
                    _dispatcher.BeginInvoke(new Action(() => _quotes.Add(quoteUpdate)), null);
                }
                else
                {
                    quote.Change = quote.Last - quoteUpdate.Last;
                    quote.PercentChange = quote.Change*100;
                    quote.Last = quoteUpdate.Last;
                    quote.Bid = quoteUpdate.Bid;
                    quote.Ask = quoteUpdate.Ask;
                    quote.Volume = quoteUpdate.Volume;
                }
            }
        }
    }
}