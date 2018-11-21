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
        public CtrlCrypto ctrl;
        public VueCrypto(CtrlCrypto ctrlCrypto)
        {
            InitializeComponent();
            ctrl = ctrlCrypto;
        }

        public void actionPremier(object sender, RoutedEventArgs e)
        {
            ctrl.premierCrypto();
        }

        public void actionDernier(object sender, RoutedEventArgs e)
        {
            ctrl.dernierCrypto();
        }

        public void actionSuivant(object sender, RoutedEventArgs e)
        {
            ctrl.prochainCrypto();
        }

        public void actionPrecedent(object sender, RoutedEventArgs e)
        {
            ctrl.precedentCrypto();
        }
    }
}
