using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _05_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // citac
        private int pocitadlo = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Kliknuti(object sender, RoutedEventArgs e)
        {
            pocitadlo += 1;

            if (pocitadlo < 2)
                Popisek.Content = "Výborně!!!";
            else
                Popisek.Content = pocitadlo.ToString();

        }
    }
}
