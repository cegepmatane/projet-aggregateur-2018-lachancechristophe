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
        public VueSlack()
        {
            InitializeComponent();
        }

        private void textBlock_Loaded(object sender, RoutedEventArgs e)
        {
            string output;

            SlackDAO slackDAO = new SlackDAO();
            textBlock.Text = slackDAO.listerSalons();
        }
    }
}
