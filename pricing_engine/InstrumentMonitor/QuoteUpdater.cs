using System;
using System.Threading;
using System.Collections.Concurrent;
using DomainObjects;
using MarketDataServices;

namespace Pricing_Sheet
{ 
    public delegate void QuoteUpdate(Quote quote);

    internal class QuoteUpdater : IDisposable
    {
        readonly ISimulationEngine _simulationEngine;
        readonly BlockingCollection<Quote> _queue = new BlockingCollection<Quote>();
        CancellationTokenSource _cancellationToken;

        public event QuoteUpdate OnQuoteUpdate;
        
        internal QuoteUpdater()
        {
            _simulationEngine = new SimulationEngine();
        }
        
        public void Start()
        {
            _simulationEngine.OnQuoteUpdate += SimulationEngine_OnQuoteUpdate;
            _simulationEngine.Initialize(3);
            _simulationEngine.Start();

            _cancellationToken = new CancellationTokenSource();


            var updateThread = new Thread(new ThreadStart(()=>
            {
                try
                {
                    foreach (var quote in _queue.GetConsumingEnumerable(_cancellationToken.Token))
                    {
                        if (_cancellationToken.Token.IsCancellationRequested)
                            break;

                        OnQuoteUpdate(quote);
                    }  
                }
                catch(Exception e)
                {
                    Console.WriteLine("Cancel requested. Exiting Update thread.");
                }
            }));

            updateThread.Start();
        }

        public void Subscribe(string tickerSymbol)
        {
            _simulationEngine.Subscribe(tickerSymbol);
        }

        public void UnSubscribe(string tickerSymbol)
        {
            _simulationEngine.Unsubscribe(tickerSymbol);
        }

        public void Stop()
        {
            _simulationEngine.Stop();
            _cancellationToken.Cancel();
        }

        public void Dispose()
        {
            Stop();
        }

        private void SimulationEngine_OnQuoteUpdate(Quote quote)
        {
            _queue.Add(quote);
        }
    }
}