using Projekt_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
    public partial class ClientsWindow : Window
    {
        public static Collection<Client> AllClients { get; } = new ObservableCollection<Client>();

        public static Collection<Parcel> ClientsPackages { get; } = new ObservableCollection<Parcel>();

        public Collection<Parcel> AllParcels = ParcelsWindow.AllParcels;
        public ClientsWindow()
        {
            InitializeComponent();

            if(AllClients.Count == 0)
            {
                AllClients.Add(new Client(1,"Adam", "Małysz", "Juchnowiec", 111222333, "am@gmail.com", true, 77788899,new List<Parcel>()));
                AllClients.Add(new Client(2,"Tomasz", "Kowal", "Białystok", 000444555, "TK@gmail.com", false, null, new List<Parcel>()));
                AllClients.Add(new Client(6, "Sebastian", "Kondraciuk", "Lewickie", 123456789, "sebastiankondraciuk1@gmail.com", false, null, new List<Parcel>()));
            }

            this.Resources.MergedDictionaries.Add(MainWindow.dictionary);
            this.Resources.MergedDictionaries.Add(MainWindow.theme);
            ListClients.ItemsSource = AllClients;



        }

        private ListCollectionView View
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(AllClients);
            }
        }

        private void BackClicked(object sender, RoutedEventArgs e)
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

        private void BtnAddClicked(object sender, RoutedEventArgs e)
        {
            CreateClientWindow createClientWindow = new CreateClientWindow();
            createClientWindow.ShowDialog();
        }

        private void BtnRemoveClicked(object sender, RoutedEventArgs e)
        {
            if (ListClients.SelectedIndex>=0)
            {
                if(AllClients[ListClients.SelectedIndex].myParcels.Count != 0)
                {
                    foreach(var tmp in AllClients[ListClients.SelectedIndex].myParcels)
                    {
                        AllParcels.Remove(tmp);
                    }
                }

                AllClients.RemoveAt(ListClients.SelectedIndex);
            }
        }



        private void FilterIdDataChanged(object sender, TextChangedEventArgs e)
        {
            View.Filter = delegate (object item)
            {
                Client client = item as Client;
                if (client != null)
                {
                    return (client.id.ToString() == FilterId.Text);
                }
                return false;
            };

            if (FilterId.Text == "")
            {
                View.Filter=null;
            }

        }
    }
}
