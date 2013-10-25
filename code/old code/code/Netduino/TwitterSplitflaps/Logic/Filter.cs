using System;
using Microsoft.SPOT;
using System.IO;
using TwitterSplitflaps.Overkoepelend;
using TwitterSplitflaps.Datalayer.SD;
using System.Collections;
using System.Text;


namespace TwitterSplitflaps.Logic{

    class Filter
    {
    
        private ArrayList slechteWoorden;
        private char[] illegalCharacters = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '²', '³', '&', '|', '"', '\'', '(', '§', '!', '{', '}', ')', '°', '\\', '?', ',', '.', ';', '=', '+', '~', '^', '[', ']', '¨', '*', '$', '%', '´', '*', '-', '_', 'µ', '`', 'µ', '÷', 'þ' };
        private Hashtable translateCharacters;

        public Filter()
        {
            translateCharacters = new Hashtable();

            // Translation characters that can be mapped to characters found on splitflap
            translateCharacters.Add('à', 'a');
            translateCharacters.Add('á', 'a');
            translateCharacters.Add('â', 'a');
            translateCharacters.Add('ã', 'a');
            translateCharacters.Add('ä', 'a');
            translateCharacters.Add('è', 'e');
            translateCharacters.Add('é', 'e');
            translateCharacters.Add('ê', 'e');
            translateCharacters.Add('ë', 'e');
            translateCharacters.Add('ý', 'y');
            translateCharacters.Add('ÿ', 'y');
            translateCharacters.Add('ç', 'c');
            translateCharacters.Add('ù', 'u');
            translateCharacters.Add('ú', 'u');
            translateCharacters.Add('û', 'u');
            translateCharacters.Add('ü', 'u');
            translateCharacters.Add('ì', 'i');
            translateCharacters.Add('í', 'i');
            translateCharacters.Add('î', 'i');
            translateCharacters.Add('ï', 'i');
            translateCharacters.Add('ò', 'o');
            translateCharacters.Add('ó', 'o');
            translateCharacters.Add('ô', 'o');
            translateCharacters.Add('õ', 'o');
            translateCharacters.Add('ö', 'o');
            translateCharacters.Add('ø', 'o');
            translateCharacters.Add('ñ', 'o');
            translateCharacters.Add('@', ':');
            translateCharacters.Add('#', '/');
        }

        /// <summary>
        /// Reads filter list from SD
        /// </summary>
        public void ReadFilterList() {
            // Get filter list
            slechteWoorden = SD.GetFilterList();
        }

        /// <summary>
        /// Filters a tweet both on illegal characters and bad words
        /// </summary>
        /// <param name="tweet">Tweet that needs to be filtered</param>
        /// <returns>Filtered tweet or null if illegal tweet</returns>
        public Tweet FilterTweet(Tweet tweet) {
            if (tweet == null) return null;
            else if (FilterWords(tweet)) return FilterChars(tweet);
            return null;
        }

        /// <summary>
        /// Filters a tweet on bad words
        /// </summary>
        /// <param name="tweet">Tweet that needs to be filtered on bad words</param>
        /// <returns>Filtered tweet or null if illegal tweet</returns>
        private bool FilterWords(Tweet tweet)
        {
            foreach (string woord in slechteWoorden)
            {
                foreach (string tweetWoord in tweet.Text.Split(' '))
                {
                    if (tweetWoord.ToLower() == woord.ToLower())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Filters a tweet on illegal characters
        /// </summary>
        /// <param name="tweet">Tweet that needs to be filtered on illegal characters/param>
        /// <returns>Filtered tweet</returns>
        private Tweet FilterChars(Tweet tweet) {
           
            StringBuilder newText = new StringBuilder();
            bool appended = false;

            foreach (char w in tweet.Text.ToCharArray())
            {

                // Check if we can translate the character
                foreach (DictionaryEntry pair in translateCharacters)
                {
                
                    if (w.ToLower() == (char)pair.Key)
                    {
                        newText.Append(pair.Value);
                        appended = true;
                        break;
                    }
                }

                // Check if we were able to map the character to another character, else check if illegal
                if (!appended)
                {
                    
                    foreach (char c in illegalCharacters)
                    {
                        if (w.ToLower() == c)
                        {
                            appended = true;
                            newText.Append(" ");
                            break;
                        }
                    }
                }

                if (!appended) newText.Append(w);
                appended = false;
            }

            tweet.Text = newText.ToString().ToUpper();
            return tweet;
        }
    }
}
