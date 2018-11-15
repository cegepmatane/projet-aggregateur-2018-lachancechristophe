using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ProjetAgregateur
{
    public class CtrlVulnerabilite
    {
        List<Vulnerabilite> listeVulnerabilite;
        int current = 0;
        VueVulnerabilites vue;
        VulnerabiliteDAO DAO;

        public CtrlVulnerabilite()
        {
            VulnerabiliteDAO vulnDAO = new VulnerabiliteDAO();
            vue = new VueVulnerabilites(this);
            listeVulnerabilite = vulnDAO.GetListeNouvelles();
            chargerVulnerabilite(0);
        }

        public void afficherFenetre()
        {
            vue.Show();
        }

        private void chargerVulnerabilite(int n)
        {
            if (n < 0 || n >= listeVulnerabilite.Count) return;

            vue.lblDate.Content = listeVulnerabilite[n].date;
            vue.txtDescription.Text = listeVulnerabilite[n].description;
            vue.lblLien.Content = listeVulnerabilite[n].lien;
            vue.lblTitre.Content = listeVulnerabilite[n].titre;

            vue.lblNumero.Content = "Numéro: " + n.ToString();
            current = n;
        }

        public void premiereVulnerabilite()
        {
            chargerVulnerabilite(0);
        }

        public void derniereVulnerabilite()
        {
            chargerVulnerabilite(listeVulnerabilite.Count - 1);
        }

        public void prochaineVulnerabilite()
        {
            if (current >= listeVulnerabilite.Count - 1) return;
            chargerVulnerabilite(++current);
        }

        public void precedenteVulnerabilite()
        {
            if (current <= 0) return;
            chargerVulnerabilite(--current);
        }
    }
}
