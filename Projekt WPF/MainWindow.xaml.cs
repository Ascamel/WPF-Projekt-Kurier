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
        private static ResourceDictionary dictionary = new();
        private static ResourceDictionary theme = new();

        public static ResourceDictionary Dictionary { get => dictionary; set => dictionary=value; }
        public static ResourceDictionary Theme { get => theme; set => theme=value; }

        public MainWindow()
        {
            InitializeComponent();

            Dictionary.Source = new Uri("\\Languages\\Language-Eng.xaml", UriKind.Relative);
            Theme.Source = new Uri("\\Themes\\LightTheme.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(Dictionary);
            this.Resources.MergedDictionaries.Add(Theme);
        }

        private void OptionsClicked(object sender, RoutedEventArgs e)
        {
            OptionsWindow optionsWindow = new();
            optionsWindow.ShowDialog();
        }

        private void ParcelsClicked(object sender, RoutedEventArgs e)
        {
            ParcelsWindow parcelsWindow = new();
            parcelsWindow.ShowDialog();
        }

        private void ClientsClicked(object sender, RoutedEventArgs e)
        {
            ClientsWindow clientsWindow = new();
            clientsWindow.ShowDialog();
        }

       
    }
}
