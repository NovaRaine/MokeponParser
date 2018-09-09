using System;
using System.Xml;

namespace MokeponStatsParser
{
    public class SettingsParser
    {
        public SettingsParser()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load("settings.xml");
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("settings.xml not found. must be in the same folder as the executable");
                return;
            }
            
            XmlNodeList nodelist = xml.SelectNodes("settings");

            foreach (XmlNode node in nodelist)
            {
                FilePath = node.SelectSingleNode("inputFilePath").InnerText;
                Output = node.SelectSingleNode("outputFilePath").InnerText;
            }
        }

        public string FilePath { get; set; }
        public string Output { get; set; }
    }
}
