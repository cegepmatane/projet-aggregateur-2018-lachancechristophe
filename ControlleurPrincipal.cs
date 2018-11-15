using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ProjetAgregateur
{
    class ControlleurPrincipal
    {
        private FenetrePrincipale fenetrePrincipale;

        private CtrlPokemon ctrlPokemon;
        private CtrlCrypto ctrlCrypto;
        private CtrlSeisme ctrlSeisme;
        private CtrlSlack ctrlSlack;
        private CtrlVulnerabilite ctrlVulnerabilite;
        

        public ControlleurPrincipal(FenetrePrincipale fp)
        {
            fenetrePrincipale = fp;

            ctrlPokemon = new CtrlPokemon();
            ctrlCrypto = new CtrlCrypto();
            ctrlSeisme = new CtrlSeisme();
            ctrlVulnerabilite = new CtrlVulnerabilite();
            ctrlSlack = new CtrlSlack();
        }

        public void ShowCrypto()
        {
            ctrlCrypto.afficherFenetre();
        }

        public void ShowPokeAPI()
        {
            ctrlPokemon.afficherFenetre();
        }

        public void ShowVulnerabilites()
        {
            ctrlVulnerabilite.afficherFenetre();
        }

        public void ShowSeisme()
        {
            ctrlSeisme.afficherFenetre();
        }

        public void ShowSlack()
        {
            ctrlSlack.afficherFenetre();
        }
    }
}
