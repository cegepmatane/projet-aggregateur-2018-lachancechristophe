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
    /// Logique d'interaction pour VueVulnerabilites.xaml
    /// </summary>
    public partial class VuePokemon : Window
    {
        int current = 0;
        List<Pokemon> listePokemon;
        List<BitmapImage> imagePokemon;

        public VuePokemon()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PokeapiDAO pokeapiDAO = new PokeapiDAO();

            listePokemon = new List<Pokemon>();
            imagePokemon = new List<BitmapImage>();

            for (int i = 1; i <= 10; i++)
            {
                listePokemon.Add(pokeapiDAO.GetPokemonDetails(i));
                imagePokemon.Add(new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\pokemon\\" + i.ToString() + ".png")));
            }
            chargerPokemon(0);
        }

        private void chargerPokemon(int n)
        {
            if (n < 0 || n > 10) return;

            lblNom.Content = listePokemon[n].nom;
            lblHauteur.Content = "Hauteur: " + listePokemon[n].hauteur;
            lblNumero.Content = "Numéro: " + listePokemon[n].numero;
            
            imgFace.Source = imagePokemon[n];
            lstAttaques.Items.Clear();
            foreach (string a in listePokemon[n].attaques)
                lstAttaques.Items.Add(a);
            current = n;
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            chargerPokemon(0);
        }

        private void btnPrecedent_Click(object sender, RoutedEventArgs e)
        {
            if (current <= 0) return;
            chargerPokemon(--current);
        }

        private void btnSuivant_Click(object sender, RoutedEventArgs e)
        {
            if (current >= listePokemon.Count - 1) return;
            chargerPokemon(++current);
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            chargerPokemon(listePokemon.Count - 1);
        }
    }
}