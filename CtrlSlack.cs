using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ProjetAgregateur
{
    public class CtrlSlack
    {
        SlackDAO DAO;
        VueSlack vue;
        List<Salon> listeSalons;
        List<string> listeMessages;

        public CtrlSlack()
        {
            DAO = new SlackDAO();
            vue = new VueSlack(this);
        }

        public void afficherFenetre()
        {
            vue.Show();
        }

        public void listerSalons()
        {
            vue.lstSalons.Items.Clear();
            listeSalons = DAO.listerSalons();
            foreach ( Salon s in listeSalons)
            {
                vue.lstSalons.Items.Add(s.id + " - " + s.nom);
            }
        }

        public void chargerMessages(int n)
        {
            vue.lstMessages.Items.Clear();
            listeMessages = DAO.listerMessagesParSalon(listeSalons[n].id);
            listeMessages.Reverse();

            foreach (string s in listeMessages)
                vue.lstMessages.Items.Add(s);

            vue.lstMessages.SelectedIndex = vue.lstMessages.Items.Count - 1;
        }
    }
}
