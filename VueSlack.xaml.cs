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
    /// Logique d'interaction pour VueSlack.xaml
    /// </summary>
    public partial class VueSlack : Window
    {
        CtrlSlack ctrl;
        public VueSlack(CtrlSlack ctrlSlack)
        {
            InitializeComponent();
            ctrl = ctrlSlack;
        }

        private void btnChargerSalons_Click(object sender, RoutedEventArgs e)
        {
            ctrl.listerSalons();
        }

        private void btnChargerMessages_Click(object sender, RoutedEventArgs e)
        {
            ctrl.chargerMessages(lstSalons.SelectedIndex);
        }
    }
}
