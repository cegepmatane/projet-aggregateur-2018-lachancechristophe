using System;
using System.Collections.Generic;
using System.IO;
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

namespace TP2_ProjetAgregateur
{
    /// <summary>
    /// Logique d'interaction pour VueCrypto.xaml
    /// </summary>
    public partial class VueCrypto : Window
    {
        int current = 0;
        List<Cryptomonnaie> listeCrypto;
        List<BitmapImage> imageCrypto;
        public VueCrypto()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CryptomonnaieDAO cryptomonnaieDAO = new CryptomonnaieDAO();

            listeCrypto = cryptomonnaieDAO.listerMonnaies();
            imageCrypto = new List<BitmapImage>();

            for (int i = 0; i < 15; i++)
            {

                imageCrypto.Add(new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\crypto\\" + listeCrypto[i].illustration)));
            }
            chargerMonnaie(0);
        }

        private void chargerMonnaie(int n)
        {
            if (n < 0 || n > 15) return;

            lblNomSymbole.Content = listeCrypto[n].symbole + " - " + listeCrypto[n].nom;
            lblAlgo.Content = "Algorithme: " + listeCrypto[n].algorithme;
            lblNombre.Content = "Nombre: " + listeCrypto[n].nombre.ToString();

            imgIcone.Source = imageCrypto[n];
            
            current = n;
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            chargerMonnaie(0);
        }

        private void btnPrecedent_Click(object sender, RoutedEventArgs e)
        {
            if (current <= 0) return;
            chargerMonnaie(--current);
        }

        private void btnSuivant_Click(object sender, RoutedEventArgs e)
        {
            if (current >= listeCrypto.Count - 1) return;
            chargerMonnaie(++current);
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            chargerMonnaie(listeCrypto.Count - 1);
        }
    }
}
