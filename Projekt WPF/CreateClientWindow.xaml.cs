using Projekt_WPF.Models;
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
using System.Windows.Shapes;

namespace Projekt_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy CreateClientWindow.xaml
    /// </summary>
    public partial class CreateClientWindow : Window
    {
        private readonly Client newclient = new();
        public CreateClientWindow()
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(MainWindow.Dictionary);
            this.Resources.MergedDictionaries.Add(MainWindow.Theme);
            this.DataContext = newclient;
        }

        private void BtnAddClicked(object sender, RoutedEventArgs e)
        {
            Random random = new();
            newclient.id = random.Next();
            newclient.myParcels = new();
            if(newclient.adress == null || newclient.surname == null||newclient.firstName == null || newclient.phone == 0 || newclient.email == null )
            {
                return;
            }
            ClientsWindow.AllClients.Add(this.newclient);
            this.Close();
        }

        private void BtnCancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChckBoxCompanyClicked(object sender, RoutedEventArgs e)
        {
            if (ChckBoxCompany.IsChecked == true)
            {
                DPanelCompany.IsEnabled = true;
            }
            else
            {
                DPanelCompany.IsEnabled = false;
            }
        }
    }
}
