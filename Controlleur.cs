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
        private VuePokeAPI vuePokeAPI;
        private VueVulnerabilites vueVulnerabilites;

        public Controlleur(FenetrePrincipale fp)
        {
            fp = fenetrePrincipale;
            vueCrypto = new VueCrypto();
            vuePokeAPI = new VuePokeAPI();
            vueVulnerabilites = new VueVulnerabilites();
        }

        public void ShowCrypto()
        {
            vueCrypto.Show();
        }

        public void ShowPokeAPI()
        {
            vuePokeAPI.Show();
        }

        public void ShowVulnerabilites()
        {
            vueVulnerabilites.Show();
        }
    }
}
