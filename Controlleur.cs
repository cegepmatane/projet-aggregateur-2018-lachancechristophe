using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ProjetAgregateur
{
    class Controlleur
    {
        private FenetrePrincipale fenetrePrincipale;
        private VueCrypto vueCrypto;
        private VuePokemon vuePokemon;
        private VueVulnerabilites vueVulnerabilites;
        private VueSeisme vueSeisme;
        private VueSlack vueSlack;

        public Controlleur(FenetrePrincipale fp)
        {
            fenetrePrincipale = fp;
            vueCrypto = new VueCrypto();
            vuePokemon = new VuePokemon();
            vueVulnerabilites = new VueVulnerabilites();
            vueSeisme = new VueSeisme();
            vueSlack = new VueSlack();
        }

        public void ShowCrypto()
        {
            vueCrypto.Show();
        }

        public void ShowPokeAPI()
        {
            vuePokemon.Show();
        }

        public void ShowVulnerabilites()
        {
            vueVulnerabilites.Show();
        }

        public void ShowSeisme()
        {
            vueSeisme.Show();
        }

        public void ShowSlack()
        {
            vueSlack.Show();
        }
    }
}
