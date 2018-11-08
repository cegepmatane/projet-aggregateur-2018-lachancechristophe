using System;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Globalization;

namespace TP2_ProjetAgregateur
{
    class CryptomonnaieDAO
    {

        /*
		     "GLYPH": {
      "Id": "4530",
      "Url": "/coins/glyph/overview",
      "ImageUrl": "/media/19725/glyph.png",
      "Name": "GLYPH",
      "Symbol": "GLYPH",
      "CoinName": "GlyphCoin",
      "FullName": "GlyphCoin (GLYPH)",
      "Algorithm": "X11",
      "ProofType": "PoW/PoS",
      "FullyPremined": "0",
      "TotalCoinSupply": "7000000",
      "BuiltOn": "N/A",
      "SmartContractAddress": "N/A",
      "PreMinedValue": "N/A",
      "TotalCoinsFreeFloat": "N/A",
      "SortOrder": "126",
      "Sponsored": false
    },

			 */
        public List<Cryptomonnaie> listerMonnaies()
        {
            Console.WriteLine("CryptoMonnaieDAO.listerMonnaies()");
            //string url = "https://min-api.cryptocompare.com/data/all/coinlist";
            //HttpWebRequest requeteListeMonnaies = (HttpWebRequest)WebRequest.Create(url);
            //WebResponse reponse = requeteListeMonnaies.GetResponse();
            //StreamReader lecteurListeMonnaies = new StreamReader(reponse.GetResponseStream());
            //string json = lecteurListeMonnaies.ReadToEnd();
            //Console.WriteLine(json);

            string json = File.ReadAllText("../crypto.json");

            JavaScriptSerializer parseur = new JavaScriptSerializer();
            dynamic objet = parseur.Deserialize<dynamic>(json);
            var lesMonnaies = objet["Data"];
            int count = 0;
            List<Cryptomonnaie> listeCryptomonnaie = new List<Cryptomonnaie>();
            foreach (dynamic itemMonnaie in lesMonnaies)
            {
                if (count >= 15) break;
                //Console.WriteLine(itemMonnaie.ToString());
                // Donne : [AXIS, System.Collections.Generic.Dictionary`2[System.String, System.Object]]
                // Même si on a [truc1, truc2] c'est pas un tableau, c'est un cle => valeur, acces avec .Key & .Value
                var monnaie = itemMonnaie.Value;
                var symbole = monnaie["Symbol"];
                var nom = monnaie["CoinName"];
                var algorithme = monnaie["Algorithm"];
                String nombre = monnaie["TotalCoinSupply"];

                var illustration = "NoImage";
                try
                {
                    illustration = monnaie["ImageUrl"];

                    string filename = Path.GetFileName(illustration);

                    if (!File.Exists("images\\crypto\\" + filename))
                        using (WebClient client = new WebClient())
                            client.DownloadFile(new Uri("https://www.cryptocompare.com/"+illustration), "images\\crypto\\" + filename);

                    illustration = filename;
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("NoImage");
                }

                Cryptomonnaie cryptomonnaie = new Cryptomonnaie();
                cryptomonnaie.symbole = symbole;
                cryptomonnaie.nom = nom;
                cryptomonnaie.algorithme = algorithme;
                cryptomonnaie.illustration = illustration == "NoImage" ? "Non" : illustration;

                nombre = nombre.TrimEnd(' ');
                nombre = nombre.Replace(".", ",");
                if (nombre.Split(',').Length > 2) nombre = nombre.Replace(",", "");
                nombre = nombre.Replace(" ", String.Empty);

                if (nombre == "N/A") nombre = "0";
                double t_nombre;
                if (double.TryParse(nombre, out t_nombre))
                    cryptomonnaie.nombre = t_nombre;
                else
                { //Condition speciale tres conne pour un edge case.
                    nombre = nombre.Remove(0, 1);
                    cryptomonnaie.nombre = double.Parse(nombre);
                }
                if (cryptomonnaie.nombre == 0) continue;
                //Console.WriteLine("Monnaie " + symbole + " : " + cryptomonnaie.nom + "(" + cryptomonnaie.nombre + ")");
                listeCryptomonnaie.Add(cryptomonnaie);
                count++;
            }

            return listeCryptomonnaie;
        }

    }
}
