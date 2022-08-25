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
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
            LoadSettings();
            CheckLanguage();
            CheckTheme();
        }

        private void LoadSettings()
        {
            if(MainWindow.Dictionary.Source !=null)
            {
                if (MainWindow.Dictionary.Source == new Uri("\\Languages\\Language-Eng.xaml", UriKind.Relative))
                {
                    RadEnglish.IsChecked = true;
                }
                else
                {
                    RadPolish.IsChecked = true;
                }
            }

            if (MainWindow.Theme.Source !=null)
            {
                if (MainWindow.Theme.Source == new Uri("\\Themes\\LightTheme.xaml", UriKind.Relative))
                {
                    RadBrightTheme.IsChecked = true;
                }
                else
                {
                    RadDarkTheme.IsChecked = true;
                }
            }
        }

         private void CheckTheme()
         {
            if (RadBrightTheme.IsChecked == true)
            {
                MainWindow.Theme.Source = new Uri("\\Themes\\LightTheme.xaml", UriKind.Relative);
            }
            else if (RadDarkTheme.IsChecked == true)
            {
                MainWindow.Theme.Source = new Uri("\\Themes\\DarkTheme.xaml", UriKind.Relative);
            }

            this.Resources.MergedDictionaries.Add(MainWindow.Theme);
        }

        private void CheckLanguage()
        {
            if (RadEnglish.IsChecked == true)
            {
                MainWindow.Dictionary.Source = new Uri("\\Languages\\Language-Eng.xaml", UriKind.Relative);
            }
            else if (RadPolish.IsChecked == true)
            {
                MainWindow.Dictionary.Source = new Uri("\\Languages\\Language-Pol.xaml", UriKind.Relative);
            }

            this.Resources.MergedDictionaries.Add(MainWindow.Dictionary);
        }

        private void BackClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RadPolishChecked(object sender, RoutedEventArgs e)
        {
            CheckLanguage();
        }

        private void RadEnglishChecked(object sender, RoutedEventArgs e)
        {
            CheckLanguage();
        }

        private void RadDarkThemeChecked(object sender, RoutedEventArgs e)
        {
            CheckTheme();
        }

        private void RadBrightThemeChecked(object sender, RoutedEventArgs e)
        {
            CheckTheme();
        }
    }
}
