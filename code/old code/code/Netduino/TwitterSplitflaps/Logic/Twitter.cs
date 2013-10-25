using System;
using Microsoft.SPOT;
using TwitterSplitflaps.Datalayer;
using System.Collections;

namespace TwitterSplitflaps.Logic
{
    class Twitter
    {
        TwitterConnection twitterConnection;

        public Twitter()
        {

            // Get query from SD and make new TwitterConnection with it
            twitterConnection = new TwitterConnection("%23Philip");
        }

        public Tweet GetLatestTweet()
        {
            return twitterConnection.GetLatestTweet();
        }

        public ArrayList GetLatestTweetsSince(string sinceID)
        {
            return twitterConnection.GetLatestTweetsSince(sinceID);
        }
    }
}
