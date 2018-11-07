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
    /// Logique d'interaction pour VueSeisme.xaml
    /// </summary>
    public partial class VueSeisme : Window
    {
        public VueSeisme()
        {
            InitializeComponent();
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            SeismeDAO seismeDAO = new SeismeDAO();

            List<Seisme> listeSeismes = seismeDAO.listerSeismes("Stella");

            dataGrid.ItemsSource = listeSeismes;
        }
    }
}
