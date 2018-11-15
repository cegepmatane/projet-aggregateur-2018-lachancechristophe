using System;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;

namespace TP2_ProjetAgregateur
{
    class SlackDAO
    {
        public string listerSalons()
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
            foreach (dynamic salon in lesSalons)
            {
                var id = salon["id"];
                var nom = salon["name"];
                Console.WriteLine(id + " : " + nom);
            }

            return json;
        }

        public string listerMessagesParSalon(string salon)
        {
            Console.WriteLine("SalonDAO.listerMessagesParSalon()");
            string json = "";
            string url = "https://slack.com/api/channels.list? " + SlackSecret.token + "&pretty=1";
            WebRequest requetesMessages = WebRequest.Create(url);
            WebResponse reponse = requetesMessages.GetResponse();
            StreamReader lecteur = new StreamReader(reponse.GetResponseStream());
            json = lecteur.ReadToEnd();

            JavaScriptSerializer parseur = new JavaScriptSerializer();
            dynamic objet = parseur.Deserialize<dynamic>(json);
            var lesMessages = objet["messages"];
            foreach (dynamic message in lesMessages)
            {
                var type = message["type"];
                var texte = message["text"];
                Console.WriteLine(type + " : " + texte);
            }

            return json;
        }
    }
}
