using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TP2_ProjetAgregateur
{
    public class CtrlCrypto
    {
        VueCrypto vue;
        CryptomonnaieDAO DAO;

        int current = 0;
        List<Cryptomonnaie> listeCrypto;
        List<BitmapImage> imageCrypto;

        public CtrlCrypto()
        {
            DAO = new CryptomonnaieDAO();
            vue = new VueCrypto(this);

            listeCrypto = DAO.listerMonnaies();
            imageCrypto = new List<BitmapImage>();

            for (int i = 0; i < 15; i++)
            {

                imageCrypto.Add(new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\crypto\\" + listeCrypto[i].illustration)));
            }
            chargerMonnaie(0);
        }

        public void afficherFenetre()
        {
            vue.Show();
        }

        public void chargerMonnaie(int n)
        {
            if (n < 0 || n > 15) return;

            vue.lblNomSymbole.Content = listeCrypto[n].symbole + " - " + listeCrypto[n].nom;
            vue.lblAlgo.Content = "Algorithme: " + listeCrypto[n].algorithme;
            vue.lblNombre.Content = "Nombre: " + listeCrypto[n].nombre.ToString();

            vue.imgIcone.Source = imageCrypto[n];

            current = n;
        }

        public void premierCrypto()
        {
            chargerMonnaie(0);
        }

        public void dernierCrypto()
        {
            chargerMonnaie(listeCrypto.Count - 1);
        }

        public void prochainCrypto()
        {
            if (current >= listeCrypto.Count - 1) return;
            chargerMonnaie(++current);
        }

        public void precedentCrypto()
        {
            if (current <= 0) return;
            chargerMonnaie(--current);
        }
    }
}
