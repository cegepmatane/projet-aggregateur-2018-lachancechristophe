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
        CtrlPokemon ctrl;

        public VuePokemon(CtrlPokemon ctrlPokemon)
        {
            InitializeComponent();
            ctrl = ctrlPokemon;
        }

        private void actionPremier(object sender, RoutedEventArgs e)
        {
            ctrl.premierPkmn();
        }

        private void actionPrecedent(object sender, RoutedEventArgs e)
        {
            ctrl.precedentPkmn();
        }

        private void actionSuivant(object sender, RoutedEventArgs e)
        {
            ctrl.prochainPkmn();
        }

        private void actionLast(object sender, RoutedEventArgs e)
        {
            ctrl.dernierPkmn();
        }

    }
}