using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterSplitflaps.Datalayer.Ethernet;
using SplitflapsFrontend.Overkoepelend;

namespace SplitflapsFrontend.Datalayer
{
    class TwitterController
    {

        #region Members

        private List<Tweet> tweets;

        #endregion

        #region Properties

        public string Query
        {
            get
            {
                return TwitterConnection.Query.Substring(3);
            }
            set
            {
                // Set the query in TwitterConnection
                TwitterConnection.Query = value;

                // Get new tweets for new query
                tweets = TwitterConnection.GetLatestTweets(15);
            }
        }

        public Tweet CurrentTweet
        {
            get
            {
                return tweets[0];
            }
        }

        #endregion


        public TwitterController()
        {
            // Set Query
            TwitterConnection.Query = "use-it";

            // Check for internet
            // TODO

            // Get tweets
            tweets = TwitterConnection.GetLatestTweets(15);
        }

        internal void NextTweet()
        {
            // Remove showed tweet IF we have more
            tweets.RemoveAt(0);
            
            // Get new tweets since last "cached" tweet
            // TODO: Run this in another thread?
            tweets.AddRange(TwitterConnection.GetLatestTweetsSince(tweets[tweets.Count - 1].ID));
        }
    }
}
