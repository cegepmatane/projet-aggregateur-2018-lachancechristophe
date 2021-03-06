﻿using System;
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
        CtrlVulnerabilite ctrl;

        public VueVulnerabilites(CtrlVulnerabilite ctrlVulnerabilite)
        {
            InitializeComponent();
            ctrl = ctrlVulnerabilite;
        }

       

        private void actionPremier(object sender, RoutedEventArgs e)
        {
            ctrl.premiereVulnerabilite();
        }

        private void actionDernier(object sender, RoutedEventArgs e)
        {
            ctrl.derniereVulnerabilite();
        }

        private void actionPrecedent(object sender, RoutedEventArgs e)
        {
            ctrl.precedenteVulnerabilite();
        }

        private void actionSuivant(object sender, RoutedEventArgs e)
        {
            ctrl.prochaineVulnerabilite();
        }
    }
}
