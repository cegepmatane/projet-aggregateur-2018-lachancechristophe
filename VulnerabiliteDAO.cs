using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Xml;

namespace TP2_ProjetAgregateur
{
    class VulnerabiliteDAO
    {
        string baseURL = "http://nvd.nist.gov/";
        string requestURL = "feeds/xml/cve/misc/nvd-rss-analyzed.xml";

        public List<Vulnerabilite> GetListeNouvelles()
        {
            Console.WriteLine("VulnerabiliteDAO.GetListeNouvelles()");

            //string completeURL = baseURL + requestURL;
            //Console.WriteLine(completeURL);

            //HttpWebRequest request = HttpWebRequest.CreateHttp(completeURL);
            //request.Method = "get";
            //request.UserAgent = "mozilla/5.0 doogiepim/1.0.4.2 applewebkit/537.36 (khtml, like gecko) chrome/51.0.2704.84 safari/537.36";
            //WebResponse reponse = request.GetResponse();

            //StreamReader lecteurliste = new StreamReader(reponse.GetResponseStream());
            //string feed = lecteurliste.ReadToEnd();

            string feed = File.ReadAllText("nvd-rss-analyzed.xml");

            XmlDocument documentXML = new XmlDocument();
            documentXML.LoadXml(feed);

            List<Vulnerabilite> listeVulnerabilites = new List<Vulnerabilite>();

            Vulnerabilite temp_vuln;
            foreach (XmlNode xmlNode in documentXML.DocumentElement.ChildNodes)
            {
                if (xmlNode.Name == "channel") continue;
                temp_vuln = new Vulnerabilite();

                temp_vuln.titre = xmlNode.ChildNodes[0].InnerText;
                temp_vuln.lien = xmlNode.ChildNodes[1].InnerText;
                temp_vuln.description = xmlNode.ChildNodes[2].InnerText;
                temp_vuln.date = xmlNode.ChildNodes[3].InnerText;

                listeVulnerabilites.Add(temp_vuln);
            }

            return listeVulnerabilites;
        }
    }
}
