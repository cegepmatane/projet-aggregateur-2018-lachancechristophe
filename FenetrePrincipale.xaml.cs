
using System.IO;
using System.Windows;


namespace TP2_ProjetAgregateur
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class FenetrePrincipale : Window
    {

        ControlleurPrincipal ctrl;

        public FenetrePrincipale()
        {
            if (!Directory.Exists("images")) Directory.CreateDirectory("images");
            if (!Directory.Exists("images\\pokemon")) Directory.CreateDirectory("images\\pokemon");
            if (!Directory.Exists("images\\crypto")) Directory.CreateDirectory("images\\crypto");
            ctrl = new ControlleurPrincipal(this);
            InitializeComponent();
        }

        private void actionPokeapi_Ouvrir(object sender, RoutedEventArgs e)
        {
            ctrl.ShowPokeAPI();
            
        }

        private void actionCrypto_Ouvrir(object sender, RoutedEventArgs e)
        {
            ctrl.ShowCrypto();
        }

        private void actionVulnerabilite_Ouvrir(object sender, RoutedEventArgs e)
        {
            ctrl.ShowVulnerabilites();
        }

        private void actionSeisme_Ouvrir(object sender, RoutedEventArgs e)
        {
            ctrl.ShowSeisme();
        }

        private void actionSlack_Ouvrir(object sender, RoutedEventArgs e)
        {
            ctrl.ShowSlack();
        }
    }
}
