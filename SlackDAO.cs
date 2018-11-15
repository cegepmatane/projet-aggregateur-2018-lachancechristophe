using System;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using System.Collections.Generic;

namespace TP2_ProjetAgregateur
{
    class Salon
    {
        public string id { get; set; }
        public string nom { get; set; }
    }

    class SlackDAO
    {
        public List<Salon> listerSalons()
        {
            Console.WriteLine("SalonDAO.listerSalons()");
            string json = "";
            
            string url = "https://slack.com/api/channels.list?token=" + SlackSecret.token + "&pretty=1";
            WebRequest requetesSalons = WebRequest.Create(url);
            WebResponse reponse = requetesSalons.GetResponse();
            StreamReader lecteur = new StreamReader(reponse.GetResponseStream());
            json = lecteur.ReadToEnd();

            JavaScriptSerializer parseur = new JavaScriptSerializer();
            dynamic objet = parseur.Deserialize<dynamic>(json);
            var lesSalons = objet["channels"];

            List<Salon> listeSalons = new List<Salon>();
            foreach (dynamic salon in lesSalons)
            {
                Salon tempSalon = new Salon();
                tempSalon.id = salon["id"];
                tempSalon.nom = salon["name"];
                listeSalons.Add(tempSalon);
            }

            return listeSalons;
        }

        public List<string> listerMessagesParSalon(string salon)
        {
            Console.WriteLine("SalonDAO.listerMessagesParSalon()");
            string json = "";
            string url = "https://slack.com/api/channels.history?token=" + SlackSecret.token + "&channel=" + salon;
            WebRequest requetesSalons = WebRequest.Create(url);
            WebResponse reponse = requetesSalons.GetResponse();
            StreamReader lecteur = new StreamReader(reponse.GetResponseStream());
            json = lecteur.ReadToEnd();

            JavaScriptSerializer parseur = new JavaScriptSerializer();
            dynamic objet = parseur.Deserialize<dynamic>(json);
            var lesMessages = objet["messages"];
            List<string> listeMessages = new List<string>();
            foreach (dynamic message in lesMessages)
                listeMessages.Add(message["text"]);
            
            return listeMessages;
        }
    }
}
