using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionire {
    class HighScore_items {
        public int score { get; set; }
        public string nick { get; set; }

        public HighScore_items(int score, string nick) {
            this.score = score;
            this.nick = nick;
        }
    }


}
