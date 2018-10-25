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

namespace TP2_ProjetAgregateur
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PokeapiDAO pd = new PokeapiDAO();
            List<Pokemon> lp = pd.GetPokemon();
            Console.ReadKey();

            foreach(Pokemon fif in lp)
            {
                Console.WriteLine(fif.numero + " - " + fif.nom);
            }
            //VulnerabiliteDAO vd = new VulnerabiliteDAO();
            //vd.GetListeNouvelles();
            //Console.ReadKey();
        }
    }
}
