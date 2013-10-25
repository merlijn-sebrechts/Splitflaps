using System;
using Microsoft.SPOT;

namespace TwitterSplitflaps.Overkoepelend
{
    class Tweet
    {

        private string id;
        private string text;
        private string user;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
