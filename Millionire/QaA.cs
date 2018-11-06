using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionire { 
    class QaA {
        public string otazka { get; set; }
        public string odpoved1 { get; set; }
        public string odpoved2 { get; set; }
        public string odpoved3 { get; set; }

        //Správně
        public string odpoved4 { get; set; }
        public int obtiznost { get; set; }


        public QaA(string otazka, string odpoved1, string odpoved2, string odpoved3, string odpoved4, int obtiznost) {
            this.otazka = otazka;
            this.odpoved1 = odpoved1;
            this.odpoved2 = odpoved2;
            this.odpoved3 = odpoved3;
            this.odpoved4 = odpoved4;
            this.obtiznost = obtiznost;
        }
    }


}
