﻿using Projekt_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    public partial class ParcelsWindow : Window
    {
        public static Collection<Parcel> AllParcels { get; } = new ObservableCollection<Parcel>();
        public ParcelsWindow()
        {
            InitializeComponent();

            SetSizes();

            SetStatuses();

            if (AllParcels.Count==0&&ClientsWindow.AllClients.Count>1)
            {
                AllParcels.Add(new Parcel(100, "Jana Kilińskiego 1, 15-089 Białystok", 12, "s", "new", ClientsWindow.AllClients[0], ClientsWindow.AllClients[0].firstName+" "+ ClientsWindow.AllClients[0].surname));
                AllParcels.Add(new Parcel(120, "Champ de Mars, 5 Av. Anatole France", 6, "xl", "delivered", ClientsWindow.AllClients[1], ClientsWindow.AllClients[1].firstName+" "+ ClientsWindow.AllClients[1].surname));
                AllParcels.Add(new Parcel(400, "plac Defilad 1, 00-901 Warszawa", 5, "l", "new", ClientsWindow.AllClients[2], ClientsWindow.AllClients[2].firstName+" "+ ClientsWindow.AllClients[2].surname));
                ClientsWindow.AllClients[0].myParcels.Add(AllParcels[0]);
                ClientsWindow.AllClients[1].myParcels.Add(AllParcels[1]);
                ClientsWindow.AllClients[2].myParcels.Add(AllParcels[2]);
            }

            Collection<Client> allClients = ClientsWindow.AllClients;
            ComboBoxClients.ItemsSource = allClients;

            this.Resources.MergedDictionaries.Add(MainWindow.Dictionary);
            this.Resources.MergedDictionaries.Add(MainWindow.Theme);
            ListParcels.ItemsSource = AllParcels;
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

        private void BackClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private static ListCollectionView View
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(AllParcels);
            }
        }

        private void TxtBoxAdressChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //nizej z trasa od pb
            if (ListParcels.SelectedIndex>=0)
            {
                wbMaps.Navigate("https://www.google.pl/maps/dir/Politechnika+Bia%C5%82ostocka,+Wiejska,+Bia%C5%82ystok/"+AllParcels[ListParcels.SelectedIndex].Adress);
            }

        }

        private void BtnAddClicked(object sender, RoutedEventArgs e)
        {
            CreateParcelWindow createParcelWindow = new();
            createParcelWindow.ShowDialog();
        }

        private void BtnPrintClicked(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(this, "Printing page");
            }
        }

        private void FilterIdDataChanged(object sender, TextChangedEventArgs e)
        {

            View.Filter = delegate (object item)
            {
                if (item is Parcel parcel)
                {
                    return (parcel.Recipient.id.ToString() == FilterId.Text);
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
