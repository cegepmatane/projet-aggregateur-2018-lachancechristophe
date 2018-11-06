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

namespace TP2_ProjetAgregateur
{
    /// <summary>
    /// Logique d'interaction pour VuePokeAPI.xaml
    /// </summary>
    public partial class VuePokeAPI : Window
    {
        List<Pokemon> listePokemon;
        public VuePokeAPI()
        {
            InitializeComponent();
        }

        private void ListboxPokemon_Loaded(object sender, RoutedEventArgs e)
        {
            PokeapiDAO pokeapiDAO = new PokeapiDAO();
            listePokemon = pokeapiDAO.GetPokemon();

            foreach (Pokemon p in listePokemon)
                ListboxPokemon.Items.Add(p.numero + " - " + p.nom);
            //TOTO Garder juste les 10 premiers pokemon
            // Refaire des requetes pour plus d'info sur ceux la
        }
    }
}
