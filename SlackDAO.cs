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

            string token = "xoxp-473953774023-474779142422-473751241733-5faa9c94333efbece6942434400184c4";
            string url = "https://slack.com/api/channels.list?token=" + token + "&pretty=1";
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
            string token = "token=xoxp-473953774023-473376698226-473681655141-c1f0e28aa268cc2a8f586f80c34330ff";
            string url = "https://slack.com/api/channels.list? " + token + "&pretty=1";
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
