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
        CtrlSeisme ctrl;

        public VueSeisme(CtrlSeisme ctrlSeisme)
        {
            InitializeComponent();
            ctrl = ctrlSeisme;
        }

        private void actionCharger(object sender, RoutedEventArgs e)
        {
            ctrl.chargerSeisme(txtLieu.Text);
        }
    }
}
