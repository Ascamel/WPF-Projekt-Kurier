using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_WPF
{


    public partial class MainWindow : Window
    {
        public static ResourceDictionary dictionary = new ResourceDictionary();
        public static ResourceDictionary theme = new ResourceDictionary();

        public MainWindow()
        {
            InitializeComponent();

            dictionary.Source = new Uri("\\Languages\\Language-Eng.xaml", UriKind.Relative);
            theme.Source = new Uri("\\Themes\\LightTheme.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(dictionary);
            this.Resources.MergedDictionaries.Add(theme);
        }

        private void OptionsClicked(object sender, RoutedEventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.ShowDialog();
        }

        private void ParcelsClicked(object sender, RoutedEventArgs e)
        {
            ParcelsWindow parcelsWindow = new ParcelsWindow();
            parcelsWindow.ShowDialog();
        }

        private void ClientsClicked(object sender, RoutedEventArgs e)
        {
            ClientsWindow clientsWindow = new ClientsWindow();
            clientsWindow.ShowDialog();
        }

       
    }
}
