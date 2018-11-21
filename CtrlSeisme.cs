using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ProjetAgregateur
{
    public class CtrlSeisme
    {
        SeismeDAO DAO;
        List<Seisme> listeSeismes;
        VueSeisme vue;

        public CtrlSeisme()
        {
            DAO = new SeismeDAO();
            vue = new VueSeisme(this);
        }

        public void afficherFenetre()
        {
            vue.Show();
        }

        public void chargerSeisme(string lieu)
        {
            if (vue.txtLieu.Text != "")
            {
                listeSeismes = DAO.listerSeismes(lieu);
                vue.dataGrid.ItemsSource = listeSeismes;
            }
        }
    }
}
