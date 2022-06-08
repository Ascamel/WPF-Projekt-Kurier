using Projekt_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy CreateParcelWindow.xaml
    /// </summary>
    /// 

    public partial class CreateParcelWindow : Window
    {
        Parcel NewParcel = new();
        
        public CreateParcelWindow()
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(MainWindow.dictionary);
            this.Resources.MergedDictionaries.Add(MainWindow.theme);
            SetSizes();
            SetStatuses(); 
            Collection<Client> allClients = ClientsWindow.AllClients;
            ComboBoxClients.ItemsSource = allClients;
            this.DataContext = NewParcel;
        }

        public void SetSizes()
        {
            ComboBoxSize.Items.Add("xs");
            ComboBoxSize.Items.Add("s");
            ComboBoxSize.Items.Add("m");
            ComboBoxSize.Items.Add("l");
            ComboBoxSize.Items.Add("xl");
        }

        public void SetStatuses()
        {
            ComboBoxStatus.Items.Add("new");
            ComboBoxStatus.Items.Add("in delivery");
            ComboBoxStatus.Items.Add("delivered");
        }

        private void BtnCancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }

        private void BtnAddClicked(object sender, RoutedEventArgs e)
        {
            
            Random random = new Random();

            NewParcel.Id = random.Next();
            if (NewParcel.Adress == null || NewParcel.Weight==0|| NewParcel.Size==null||NewParcel.Recipient==null||NewParcel.Status==null)
            {
                return;
            }
            NewParcel.ClientName = NewParcel.Recipient.firstName+" "+NewParcel.Recipient.surname;
            NewParcel.Recipient.myParcels.Add(NewParcel);
            ParcelsWindow.AllParcels.Add(this.NewParcel);
            
            this.Close();
        }
    }
}
