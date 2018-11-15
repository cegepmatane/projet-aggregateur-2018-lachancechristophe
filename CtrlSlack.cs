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
            vue.textBlock.Text = DAO.listerSalons();
        }
    }
}
