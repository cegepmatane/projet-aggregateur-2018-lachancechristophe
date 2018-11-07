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
    /// Logique d'interaction pour VueVulnerabilites.xaml
    /// </summary>
    public partial class VueVulnerabilites : Window
    {
        List<Vulnerabilite> listeVuln;
        int current = 0;
        public VueVulnerabilites()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulnerabiliteDAO vulnDAO = new VulnerabiliteDAO();
            listeVuln = vulnDAO.GetListeNouvelles();
            chargerVulnerabilite(0);
        }

        private void chargerVulnerabilite(int n)
        {
            if (n < 0 || n >= listeVuln.Count) return;

            lblDate.Content = listeVuln[n].date;
            txtDescription.Text = listeVuln[n].description;
            lblLien.Content = listeVuln[n].lien;
            lblTitre.Content = listeVuln[n].titre;

            lblNumero.Content = "Numéro: " + n.ToString();
            current = n;
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            chargerVulnerabilite(0);
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            chargerVulnerabilite(listeVuln.Count - 1);
        }

        private void btnPrecedent_Click(object sender, RoutedEventArgs e)
        {
            if (current <= 0) return;
            chargerVulnerabilite(--current);
        }

        private void btnSuivant_Click(object sender, RoutedEventArgs e)
        {
            if (current >= listeVuln.Capacity - 1) return;
            chargerVulnerabilite(++current);
        }
    }
}
