using System.Windows;

namespace Pricing_Sheet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mwvm = null;

        public MainWindow()
        {
            InitializeComponent();

            _mwvm = new MainWindowViewModel(this.Dispatcher);

            this.DataContext = _mwvm;
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mwvm.Stop();
        }

        //TODO: Make these commands in the view model
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _mwvm.Subscribe(this.TextBoxTickerSymbol.Text.Trim().ToUpper());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _mwvm.UnSubscribe(this.TextBoxTickerSymbol.Text.Trim().ToUpper());
        }

        private void TextBoxTickerSymbol_GotFocus(object sender, RoutedEventArgs e)
        {
            this.TextBoxTickerSymbol.Clear();
        }
    }
}