using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace TP2_ProjetAgregateur
{
    class PokeapiDAO
    {
        string baseURL = "https://pokeapi.co/api/v2/";
        string requestURL = "pokemon/";

        public List<Pokemon> GetPokemon()
        {
            Console.WriteLine("PokeapiDAO.GetPokemon()");

            List<Pokemon> listePokemon = new List<Pokemon>();

            if (!File.Exists("..\\pokeapi.json"))
            {
                string completeURL = baseURL + requestURL;
                Console.WriteLine(completeURL);

                HttpWebRequest request = HttpWebRequest.CreateHttp(completeURL);
                request.Method = "get";
                request.UserAgent = "mozilla/5.0 doogiepim/1.0.4.2 applewebkit/537.36 (khtml, like gecko) chrome/51.0.2704.84 safari/537.36";
                WebResponse reponse = request.GetResponse();
                StreamReader lecteurliste = new StreamReader(reponse.GetResponseStream());

                File.WriteAllText("pokeapi.json", lecteurliste.ReadToEnd());
            }
            string feed = File.ReadAllText("..\\pokeapi.json");

            JavaScriptSerializer serial = new JavaScriptSerializer();
            dynamic objet = serial.Deserialize<dynamic>(feed);
            string nombre = objet["count"].ToString();
            Console.WriteLine(nombre + " Pokémon reçus");

            dynamic[] results = objet["results"];
            Pokemon tempokemon;
            int count = 1;
            foreach (dynamic tempObject in results)
            {
                tempokemon = new Pokemon();
                tempokemon.nom = tempObject["name"];
                
                tempokemon.numero = count++;
                if (count == 803) count = 10001;
                listePokemon.Add(tempokemon);
            }
            return listePokemon;
        }

        public Pokemon GetPokemonDetails(int n)
        {
            Pokemon tempPokemon = new Pokemon();


            string completeurl = baseURL + requestURL + n.ToString();
            Console.WriteLine(completeurl);

            if (!File.Exists(n.ToString() + ".json"))
            {
                HttpWebRequest request = HttpWebRequest.CreateHttp(completeurl);
                request.Method = "get";
                request.UserAgent = "mozilla/5.0 doogiepim/1.0.4.2 applewebkit/537.36 (khtml, like gecko) chrome/51.0.2704.84 safari/537.36";
                WebResponse reponse = request.GetResponse();
                StreamReader lecteurliste = new StreamReader(reponse.GetResponseStream());
                
                File.WriteAllText(n.ToString() + ".json", lecteurliste.ReadToEnd());
            }
            string feed = File.ReadAllText(n.ToString() + ".json");

            JavaScriptSerializer serial = new JavaScriptSerializer();
            dynamic objet = serial.Deserialize<dynamic>(feed);

            Pokemon tempokemon = new Pokemon();

            tempPokemon.nom = objet["name"];
            tempPokemon.numero = objet["id"];
            tempPokemon.hauteur = objet["height"];

            List<string> abilities = new List<string>();
            foreach (dynamic duo in objet["moves"])
                abilities.Add(duo["move"]["name"].Replace('-', ' '));
            
            tempPokemon.attaques = abilities;

            tempPokemon.illustration = objet["sprites"]["front_default"];

            string filename = Path.GetFileName(tempPokemon.illustration);

            if (!File.Exists("images\\pokemon\\" + filename))
                using (WebClient client = new WebClient())
                    client.DownloadFile(new Uri(tempPokemon.illustration), "images\\pokemon\\" + filename);

            return tempPokemon;
        }
    }
}
