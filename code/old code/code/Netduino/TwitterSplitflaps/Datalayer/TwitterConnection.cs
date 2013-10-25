using System;
using Microsoft.SPOT;
using System.Net;
using System.IO;
using System.Collections;
using System.Text;

namespace TwitterSplitflaps.Datalayer
{
    class TwitterConnection
    {
        private string searchURL = "http://search.twitter.com/search.json?q=";

        public TwitterConnection(string query)
        {
            // Query doesn't start with a # or %23
            //if (!query.StartsWith("#") || query.StartsWith("%23")) query = query.Insert(0, "%23");


            // URL encode, just to be sure
            //query = HttpUtility.UrlEncode(query);
            
            // Set the searchURL to the new searchURL with the hashtag query
            searchURL = string.Concat(searchURL, query);
        }

        /// <summary>
        /// Gets the latest tweets since a specified ID
        /// </summary>
        /// <param name="sinceID">ID which represents a Tweet ID</param>
        /// <returns>Arraylist containg tweets since a specified ID</returns>
        public ArrayList GetLatestTweetsSince(string sinceID)
        {
            // Perform the WebRequest and parse it
            return ParseResponse(PerformGetRequest(searchURL + "since_id=" + sinceID));
        }

        /// <summary>
        /// Gets the latest tweets, count specified by param count
        /// </summary>
        /// <param name="count">Howmany tweets that need to be returned</param>
        /// <returns>ArrayList containing n Tweet object(s)</returns>
        public ArrayList GetLatestTweets(string count)
        {
            // Perform the WebRequest and parse it
            return ParseResponse(PerformGetRequest(searchURL + "rpp=" + count));
        }
        
        /// <summary>
        /// Gets the latest tweet.
        /// </summary>
        /// <returns>Tweet Object</returns>
        public Tweet GetLatestTweet()
        {
            // Perform the WebRequest and parse it
            return (Tweet) ParseResponse(PerformGetRequest(searchURL + "&rpp=1"))[0];
        }

        /// <summary>
        /// Parses the HTML Response into useable
        /// </summary>
        /// <param name="html">TheHTML which needs to be parsed.</param>
        /// <returns>ArrayList containing Tweet object(s)</returns>
        private ArrayList ParseResponse(string html)
        {
            // Get the index of the first result
            int resultIndex = html.IndexOf("\"results\":[{\"created_at\":");

            // Check if there is no result (no result(s) shows "results:[]" and thus index == -1)
            if (resultIndex == -1) return null;

            // Take apart the results from the full json
            html = html.Substring(resultIndex + 11);

            // ArrayList to store individual results
            ArrayList results = new ArrayList();
            // Bool to indicate wheter there are more results left in the json
            bool moreResults = true;

            // Split the individual results
            do
            {
                resultIndex = html.IndexOf("},{\"created_at\":");
                if (resultIndex == -1)
                {
                    moreResults = false;
                    results.Add(html);
                }
                else
                {
                    results.Add(html.Substring(0, resultIndex));
                    html = html.Substring(resultIndex + 2);
                }
            } while (moreResults);



            // Save the tweets in an ArrayList
            ArrayList tweets = new ArrayList();
            
            // Make new tweet object of the results and put them in the ArrayList
            foreach (string result in results) {

                // User
                int userIndex = result.IndexOf("\"from_user\":\"") + 13;
                int userEndIndex = result.IndexOf(",\"from_user_id\":");
                string user = result.Substring(userIndex, userEndIndex - userIndex - 1);

                // Text
                int textIndex = result.IndexOf("\"text\":\"") + 8;
                int textEndIndex = result.IndexOf(",\"to_user\":");
                string text = result.Substring(textIndex, textEndIndex - textIndex - 1);

                // @todo ID
                
                tweets.Add(new Tweet() {
                    Text = text,
                    User = user
                });

            } 

            // Return results
            return tweets;
        }

        /// <summary>
        /// Performs a HTTP GET WebRequest.
        /// </summary>
        /// <param name="url">The URL which needs to be requested.</param>
        /// <returns>The WebResponse of the request.</returns>
        private string PerformGetRequest(string url)
        {
            Debug.Print("IP: " + Microsoft.SPOT.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()[0].IPAddress);
        
            //using (HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(@"http://www.google.com"))
            //{
            //    request.Timeout = 15000;
            //    request.KeepAlive = false;
            //    request.ReadWriteTimeout = 5000;
            //    request.Method = "POST";
            //    request.ContentType = "application/x-www-form-urlencoded";
            //    byte[] bytes = Encoding.UTF8.GetBytes("a=3&b=4");
            //    request.ContentLength = bytes.Length;
            //    Debug.Print("request.GetRequestStream");
            //    try
            //    {
            //        using (Stream requestStream = request.GetRequestStream())
            //        {
            //            requestStream.Write(bytes, 0, bytes.Length);
            //            requestStream.Close();
            //        }
            //    }
            //    catch (WebException ex)
            //    {
            //        Debug.Print("WebException on GetRequestStream: " + ex.Message);
            //    }
            //    catch (Exception ex)
            //    {
            //        Debug.Print("Exception on GetRequestStream: " + ex.Message);
            //    }
            
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            //request.Method = "GET";
            //request.KeepAlive = false;
            //request.Timeout = 3000;
            ////request.Credentials = new NetworkCredential();
            //WebResponse response = request.GetResponse();
            //StreamReader reader = new StreamReader(response.GetResponseStream());
            //string responseString = reader.ReadToEnd();
            //reader.Close();
            //return responseString;
            return null;
        }

        private string PerformTest(string url) {
            using (HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(@"http://www.google.com"))
            {
                request.Timeout = 15000;
                request.KeepAlive = false;
                request.ReadWriteTimeout = 5000;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                byte[] bytes = Encoding.UTF8.GetBytes("a=3&b=4");
                request.ContentLength = bytes.Length;
                Debug.Print("request.GetRequestStream");
                try
                {
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                        requestStream.Close();
                    }
                }
                catch (WebException ex)
                {
                    Debug.Print("WebException on GetRequestStream: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Debug.Print("Exception on GetRequestStream: " + ex.Message);
                }

                Debug.Print("request.GetResponse");
                try
                {
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        int respSize = System.Math.Min((int)response.ContentLength, 80);
                        if (respSize != 0)
                        {
                            byte[] respData = new byte[respSize];
                            try
                            {
                                Debug.Print("request.GetResponseStream");
                                using (Stream responseStream = response.GetResponseStream())
                                {
                                    responseStream.Read(respData, 0, respData.Length);
                                    responseStream.Close();
                                }
                                string responseString = new string(Encoding.UTF8.GetChars(respData));
                                Debug.Print("Response was: " + responseString);
                            }
                            catch (WebException ex)
                            {
                                Debug.Print("WebException on GetResponseStream: " + ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Debug.Print("Exception on GetResponseStream: " + ex.Message);
                            }
                        }
                        else
                        {
                            Debug.Print("Response was empty");
                        }
                        response.Close();
                    }
                }
                catch (WebException ex)
                {
                    Debug.Print("WebException on GetResponse: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Debug.Print("Exception on GetResponse: " + ex.Message);
                }

                return null;
            }
        }
    }
}
