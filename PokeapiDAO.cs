﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace TP2_ProjetAgregateur
{
    class PokeapiDAO
    {
        string baseURL = "https://pokeapi.co/api/v2/";
        string requestURL = "pokemon/";

        public void GetPokemon()
        {
            Console.WriteLine("PokeapiDAO.GetPokemon()");

            string completeURL = baseURL + requestURL;
            Console.WriteLine(completeURL);

            HttpWebRequest request = HttpWebRequest.CreateHttp(completeURL);
            request.Method = "GET";
            //request.UserAgent = "Mozilla/5.0 doogiePIM/1.0.4.2 AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.84 Safari/537.36";
            WebResponse reponse =request.GetResponse();

            StreamReader lecteurListe = new StreamReader(reponse.GetResponseStream());

            string feed = lecteurListe.ReadToEnd();

            Console.WriteLine(feed);
        }
    }
}
