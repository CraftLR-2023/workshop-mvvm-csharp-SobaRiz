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
using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using Microsoft.Build.Locator;

#pragma warning disable CS2001

namespace Wpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            // code à exécuter lorsque le ToggleButton est activé
            Console.WriteLine("Toggle Activé");
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            // code à exécuter lorsque le ToggleButton est désactivé
            Console.WriteLine("Toggle Désactivé");
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // code à exécuter lorsque la case est cochée
            Console.WriteLine("Checkbox Checked");
        }
        private void ClickRetour(object sender, RoutedEventArgs e)
        {
            // code à exécuter lorsque la case est cochée
            Console.WriteLine("Retour demandé !");
        }
        private void LangEN(object sender, RoutedEventArgs e)
        {
            // code à exécuter lorsque la case est cochée
            Console.WriteLine("Let's Go !");
        }
        private void LangFR(object sender, RoutedEventArgs e)
        {
            // code à exécuter lorsque la case est cochée
            Console.WriteLine("C'est parti les amis !");
        }
        private void ClickParametres(object sender, RoutedEventArgs e)
        {
            // code à exécuter lorsque la case est cochée
            Console.WriteLine("Ouverture de la joute !");
        }
        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            // code à exécuter lorsque la case est cochée
            Console.WriteLine("Enregistrons les infos dans le json.");
        }
    }
}
