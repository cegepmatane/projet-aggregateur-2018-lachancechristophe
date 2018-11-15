using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TP2_ProjetAgregateur
{
    public class CtrlPokemon
    {
        VuePokemon vue;
        PokeapiDAO DAO;

        int current = 0;
        List<Pokemon> listePokemon;
        List<BitmapImage> imagePokemon;

        public CtrlPokemon()
        {
            vue = new VuePokemon(this);
            DAO = new PokeapiDAO();
            listePokemon = new List<Pokemon>();
            imagePokemon = new List<BitmapImage>();

            for (int i = 1; i <= 10; i++)
            {
                listePokemon.Add(DAO.GetPokemonDetails(i));
                imagePokemon.Add(new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\pokemon\\" + i.ToString() + ".png")));
            }
            chargerPokemon(0);
        }

        public void afficherFenetre()
        {
            vue.Show();
        }

        public void chargerPokemon(int n)
        {
            if (n < 0 || n > 10) return;

            vue.lblNom.Content = listePokemon[n].nom;
            vue.lblHauteur.Content = "Hauteur: " + listePokemon[n].hauteur;
            vue.lblNumero.Content = "Numéro: " + listePokemon[n].numero;

            vue.imgFace.Source = imagePokemon[n];
            vue.lstAttaques.Items.Clear();
            foreach (string a in listePokemon[n].attaques)
                vue.lstAttaques.Items.Add(a);
            current = n;
        }

        public void premierPkmn()
        {
            chargerPokemon(0);
        }

        public void dernierPkmn()
        {
            chargerPokemon(listePokemon.Count - 1);
        }

        public void prochainPkmn()
        {
            if (current >= listePokemon.Count - 1) return;
            chargerPokemon(++current);
        }

        public void precedentPkmn()
        {
            if (current <= 0) return;
            chargerPokemon(--current);
        }
    }
}
