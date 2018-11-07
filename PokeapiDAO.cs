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

            //string completeurl = baseurl + requesturl;
            //console.writeline(completeurl);

            //httpwebrequest request = httpwebrequest.createhttp(completeurl);
            //request.method = "get";
            //request.useragent = "mozilla/5.0 doogiepim/1.0.4.2 applewebkit/537.36 (khtml, like gecko) chrome/51.0.2704.84 safari/537.36";
            //webresponse reponse = request.getresponse();
            //streamreader lecteurliste = new streamreader(reponse.getresponsestream());

            //string feed = lecteurListe.ReadToEnd();

            // File.WriteAllText("pokeapi.json", feed);

            string feed = File.ReadAllText("..\\pokeapi.json");

            JavaScriptSerializer serial = new JavaScriptSerializer();
            dynamic objet = serial.Deserialize<dynamic>(feed);
            string nombre = objet["count"].ToString();
            Console.WriteLine(nombre + " Pokémon reçus");

            dynamic[] results = objet["results"];
            Pokemon tempokemon;
            int count = 1;
            foreach (dynamic proutbanane in results)
            {
                tempokemon = new Pokemon();
                tempokemon.nom = proutbanane["name"];
                
                tempokemon.numero = count++;
                if (count == 803) count = 10001;
                //tempokemon.hauteur = proutbanane["heigth"];
                listePokemon.Add(tempokemon);
            }
            return listePokemon;
        }

        public Pokemon GetPokemonDetails(int n)
        {
            Pokemon tempPokemon = new Pokemon();


            string completeurl = baseURL + requestURL + n.ToString();
            Console.WriteLine(completeurl);

            HttpWebRequest request = HttpWebRequest.CreateHttp(completeurl);
            request.Method = "get";
            request.UserAgent = "mozilla/5.0 doogiepim/1.0.4.2 applewebkit/537.36 (khtml, like gecko) chrome/51.0.2704.84 safari/537.36";
            WebResponse reponse = request.GetResponse();
            StreamReader lecteurliste = new StreamReader(reponse.GetResponseStream());

            string feed = lecteurliste.ReadToEnd();

            //File.WriteAllText("pokeapi.json", feed);

            //string feed = File.ReadAllText("..\\pokeapi.json");

            JavaScriptSerializer serial = new JavaScriptSerializer();
            dynamic objet = serial.Deserialize<dynamic>(feed);

  
            Pokemon tempokemon;
            
            

            return tempPokemon;
        }
    }
}
