using System.Net;
using System.IO;
using System;
using System.Text;
using System.Xml.XPath;
using System.Collections.Generic;
using System.Xml;

namespace TP2_ProjetAgregateur
{
    class SeismeDAO
    {
        public static string URL_SEISME = "http://soda.demo.socrata.com/resource/6yvf-kk3n.xml?source=pr&$where=region%20like%20%27%25";
        public static string URL_FIN = "%25%27";

        public List<Seisme> listerSeismes(string lieu)
        {
            List<Seisme> listeSeismes = new List<Seisme>();

            if (!File.Exists(lieu + ".xml"))
            {
                Console.WriteLine("SeismeDAO.listerSeismes(" + lieu + ")");
                string url = URL_SEISME + lieu + URL_FIN;
                Console.WriteLine(url);
                WebRequest requeteSeismes = WebRequest.Create(url);
                WebResponse reponse = requeteSeismes.GetResponse();
                StreamReader lecteur = new StreamReader(reponse.GetResponseStream());
                string feed = lecteur.ReadToEnd();

                File.WriteAllText(lieu + ".xml", feed);
            }

            string xml = File.ReadAllText(lieu + ".xml");
            XmlDocument documentXML = new XmlDocument();
            documentXML.LoadXml(xml);

            foreach (XmlNode xmlNode in documentXML.DocumentElement.ChildNodes[0].ChildNodes)
            {
                if (xmlNode.Name != "row") continue;

                Seisme seisme = new Seisme();
                seisme.id = xmlNode.ChildNodes[1].InnerText;
                seisme.magnitude = xmlNode.ChildNodes[2].InnerText;
                seisme.profondeur = xmlNode.ChildNodes[3].InnerText;
                seisme.region = xmlNode.ChildNodes[5].InnerText;
              
                listeSeismes.Add(seisme);
            }

            return listeSeismes;
        }
    }
}
