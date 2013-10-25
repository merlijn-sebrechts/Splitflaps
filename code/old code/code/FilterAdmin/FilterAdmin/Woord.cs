using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterAdmin {
    public struct Woord {
        private string word;

        public string Word {
            get { return word; }
            set { word = value; }
        }

        public Woord(string woord) {
            this.word = woord;
        }

        public override string ToString() {
            return this.word;
        }
    }
}
