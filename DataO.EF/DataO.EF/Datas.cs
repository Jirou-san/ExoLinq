using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Xml;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace DataO.EF
{
    public sealed class Datas
    {
        public string XmlPath { get; set; }
        private int WomanCount { get; set; }
        
        public Datas(string _xmlPath)
        {
            XmlPath = _xmlPath;
        }
        public List<string> FilesNameM(string path, string partialname)
        {
            
            string[] listeOfFiles = Directory.GetFiles(path);
            /*var query = from l1 in listeOfFiles
                        where l1.ToString().Contains("m")
                        select l1;*/
            var fluentQuery = listeOfFiles.Where(e => e.ToString().Contains(partialname)).Select(e => e).ToList();

            return fluentQuery;
        }

        public IEnumerable<XElement> getXmlData()
        {
            XElement xml = XElement.Load(XmlPath);
            IEnumerable<XElement> Employees = xml.Elements("Employee");

            return Employees;

        }
        public string getWomenData()
        {
            string answer = "";
            var fluentQuery = this.getXmlData().Where(e => e.Element("Sex").Value.ToString().ToUpper() == "FEMALE").Select(e => e.Element("Name").Value);

            answer = "Voici la liste des femmes:" + Environment.NewLine;
            foreach (var item in fluentQuery)
            {
                WomanCount++;
                answer += item.ToString() + "\r\n";
            }
            answer += "Voici leur nombre: " + WomanCount + Environment.NewLine;
            return answer;
        }
        public string getEmployeeCity()
        {
            string answer = "";
            var fluentQuery = this.getXmlData().Where(e => e.Element("Address").Element("City").Value == "Alta").Select(e => e.Element("Name").Value);
            answer = "Voici la liste des personnes habitant à Alta:" + Environment.NewLine;
            foreach (var item in fluentQuery)
            {
                WomanCount++;
                answer += item.ToString() + "\r\n";
            }
            return answer;
        }
        public void addElementToXml()
        {
            XElement xml = XElement.Load(XmlPath);
            xml.Add(" ");
            xml.Save(XmlPath);
        }
    }
}
