using System.ComponentModel;

namespace DomainObjects
{
    public class Quote : ObservableObject
    {
        double _high, _low, _last, _bid, _ask, _change, _percentChange;
        int _volume; 
        string _symbol;

        public string Symbol
        {
            get { return _symbol; }
            set
            {
                if (value != _symbol)
                {
                    _symbol = value;
                    OnPropertyChanged("Symbol");
                }
            }
        }

        public double High
        {
            get { return _high; }
            set
            {
                _high = value;
                OnPropertyChanged("High");
            }
        }

        public double Low
        {
            get { return _low; }
            set
            {
                _low = value;
                OnPropertyChanged("Low");
            }
        }

        public double Last
        {
            get { return _last; }
            set
            {
                if (value != _last)
                {
                    _last = value;
                    OnPropertyChanged("Last");
                }
            }
        }

        public double Bid
        {
            get { return _bid; }
            set
            {
                if (value != _bid)
                {
                    _bid = value;
                    OnPropertyChanged("Bid");
                }
            }
        }

        public double Ask
        {
            get { return _ask; }
            set
            {
                if (value != _ask)
                {
                    _ask = value;
                    OnPropertyChanged("Ask");
                }
            }
        }

        public int Volume
        {
            get { return _volume; }
            set
            {
                if (value != _volume)
                {
                    _volume = value;
                    OnPropertyChanged("Volume");
                }
            }
        }

        public double Change
        {
            get { return _change; }
            set
            {
                _change = value;
                OnPropertyChanged("Change");
            }
        }

        public double PercentChange
        {
            get { return _percentChange; }
            set
            {
                _percentChange = value;
                OnPropertyChanged("PercentChange");
            }
        }
    }
}
