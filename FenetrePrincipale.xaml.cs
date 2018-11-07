
using System.Windows;


namespace TP2_ProjetAgregateur
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class FenetrePrincipale : Window
    {

        Controlleur ctrl;

        public FenetrePrincipale()
        {
            ctrl = new Controlleur(this);
            InitializeComponent();
        }

        private void btnPokeapi_Click(object sender, RoutedEventArgs e)
        {
            ctrl.ShowPokeAPI();
        }

        private void btnCrypto_Click(object sender, RoutedEventArgs e)
        {
            ctrl.ShowCrypto();
        }

        private void btnVulnerabilite_Click(object sender, RoutedEventArgs e)
        {
            ctrl.ShowVulnerabilites();
        }

        private void btnSeismes_Click(object sender, RoutedEventArgs e)
        {
            ctrl.ShowSeisme();
        }

        private void btnSlack_Click(object sender, RoutedEventArgs e)
        {
            ctrl.ShowSlack();
        }
    }
}
