using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Collections;

namespace FilterAdmin {
    class DataLayer {
        private List<Woord> woorden;
        private string path;
        private Dictionary<String, String> config;

        public void SetPath(string path) {
            woorden = new List<Woord>();
            this.path = path;
            ReadFile();
        }

        public void ReadFile() {
            if (path != string.Empty) {
                using (StreamReader sr = new StreamReader(path + "\\filter.txt")) {
                    string line;

                    while ((line = sr.ReadLine()) != null) {

                        woorden.Add(new Woord(line));
                    }
                }
                using (StreamReader sr = new StreamReader(path + "\\config.txt")) {
                    string line;

                    config = new Dictionary<String, String>();

                    while ((line = sr.ReadLine()) != null) {
                        String[] split = line.Split('=');
                        config.Add(split[0], split[1]);
                    }
                }
            }
        }

        public List<Woord> GetWoorden() {
            return woorden;
        }

        public string GetHashtag() {
            return config["hashtag"];
        }

        public void WriteFile(List<Woord> woorden) {
            EmptyFile("\\filter.txt");
            StreamWriter sw = new StreamWriter(path + "\\filter.txt");
            
            foreach (Woord s in woorden) {
                sw.WriteLine(s);
            }
            sw.Close();
        }

        public void WriteConfig(Dictionary<String, String> config) {
            EmptyFile("\\config.txt");
            StreamWriter sw = new StreamWriter(path + "\\config.txt");

            foreach (KeyValuePair<String, String> kv in config)
            {
                sw.WriteLine(kv.Key + "=" + kv.Value);
            }
           
            sw.Close();
        }

        public void EmptyFile(string file) {
            FileStream fileStream = File.Open(path + file, FileMode.Open);
            fileStream.SetLength(0);
            fileStream.Flush();
            fileStream.Close();
        }
    }
}
