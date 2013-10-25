using System;
using Microsoft.SPOT;
using System.IO;
using System.Collections;

namespace TwitterSplitflaps.Datalayer.SD
{
    class SD
    {
        private const string sdDirectory = @"\SD\";
        private const string filterFileName = "filter.txt";
        private const string configFileName = "config.txt";
        private const string storedTweetFileName = "tweet.txt";

        /// <summary>
        /// Gets the list of words that needs to be filtered.
        /// </summary>
        /// <returns>An array of strings containing the words that need to be filtered.</returns>
        public static ArrayList GetFilterList() {

            ArrayList filterWords = new ArrayList();

            // SD card is inserted and file is found
            if (File.Exists(sdDirectory + filterFileName))
            {

                using (StreamReader sr = new StreamReader(sdDirectory+ filterFileName))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        filterWords.Add(line);
                    }
                }
            }

            return filterWords;
        }

        /// <summary>
        /// Gets the config.
        /// </summary>
        /// <returns>An Hashtable all config stored on the SD card.</returns>
        public static Hashtable GetConfig()
        {
            Hashtable config = new Hashtable();

            // SD card is inserted and file is found
            if (File.Exists(sdDirectory + configFileName))
            {

                using (StreamReader sr = new StreamReader(sdDirectory + configFileName))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] ab = line.Split('=');
                        config.Add(ab[0].ToString(), ab[1].ToString());
                    }
                }
            }

            return config;
        }

        /// <summary>
        /// Gets the stored tweet on the SD Card.
        /// </summary>
        /// <returns>A string with the stored tweet on the SD card. This should be the latest tweet displayed</returns>
        public static String GetStoredTweet()
        {
            string tweet = "";

            // SD card is inserted and file is found
            if (File.Exists(sdDirectory + storedTweetFileName))
            {

                using (StreamReader sr = new StreamReader(sdDirectory + storedTweetFileName))
                {
                    tweet = sr.ReadLine();
                }
            }

            return tweet;
        }

        /// <summary>
        /// Writes a string to the Tweet file on the SD card
        /// </summary>
        /// <returns>Bool which indicates whether or not the string was saved.</returns>
        public static bool WriteStoredTweet(String tweet)
        {
            // SD card is inserted and file is found
            if (Directory.Exists(sdDirectory))
            {

                using (StreamWriter sw = new StreamWriter(sdDirectory + storedTweetFileName))
                {
                    sw.WriteLine(tweet);
                    return true;
                }
            }

            return false;
        }
    }
}
