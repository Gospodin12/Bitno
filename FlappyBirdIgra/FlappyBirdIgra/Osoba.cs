using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdIgra
{
    internal class Osoba
    {
        string ime;
        int broj_godina;
        string prezime;
        bool jelZiv;
        public Osoba(string ime,int broj_godina) 
        { 
            this.ime = ime;
            this.broj_godina = broj_godina;
        }
        public void CovekJeOStario(int k)
        {
            this.broj_godina = this.broj_godina+k;
        }
    }
}
