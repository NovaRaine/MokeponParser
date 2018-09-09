using System;
using System.IO;

namespace MokeponStatsParser
{
    internal class Parser
    {
        public Parser()
        {
            
        }

        public bool Run()
        {
            var settingsParser = new SettingsParser();
            var filePath = settingsParser.FilePath;

            if (string.IsNullOrEmpty(filePath)) return false;

            var input = ReadCSV(filePath);

            if (string.IsNullOrEmpty(input)) return false;

            var res = HandleCSV(input, settingsParser.Output);

            return res;
        }

        private bool HandleCSV(string input, string output)
        {
            var csvHandler = new CsvHandler();
            return csvHandler.HandleInput(input, output);
        }

        private string ReadCSV(string filePath)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(filePath))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    return line;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return "";
            }
        }
    }
}