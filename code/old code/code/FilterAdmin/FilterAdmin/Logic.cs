using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FilterAdmin {
    class Logic {
        DataLayer dl;

        public Logic() {
            dl = new DataLayer();
        }

        public DataLayer GetLayer() {
            return dl;
        }

        public void SetLayer(DataLayer dl) {
            this.dl = dl;
        }

        public void SetFolder(string folder) {
            dl.SetPath(folder);
        }

        public List<Woord> GetWoorden() {
            return dl.GetWoorden();
        }

        public string GetHashtag() {
            return dl.GetHashtag();
        }

        public void SetHashtag(string hashtag){

            // URL encode the number sign #
            if (hashtag.StartsWith("#")) hashtag = "%23" + hashtag.Substring(1, hashtag.Length);
            else hashtag = "%23" + hashtag;

            Dictionary<String, String> config = new Dictionary<String, String>();
            config.Add("hashtag", hashtag);
            dl.WriteConfig(config);
        }

        public void SetWoorden(List<Woord> woorden) {
            dl.WriteFile(woorden);
        }
    }
}
