using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book
{
    internal class Book
    {

        private List<Authors> Szerzok = [];

        public long ISBN;
        public string Cim;
        public int Kiadas;
        public string Nyelv;
        public int Keszlet;
        public int Ar;

        public long isbn
        {
            get => isbn;
            set
            {
                if (value < 1000000000 || value > 9999999999) throw new Exception("Az ISBN ID pontosan 10 karakter hosszú legyen!");
                isbn = value;
            }
        }
        public string cim
        {
            get => cim;
            set
            {
                if (value.Length < 3 || value.Length > 64) throw new Exception("A cím hossza legyen 3 és 64 között!");
                cim = value;    
            }
        }
        public int kiadas
        {
            get => kiadas;
            set
            {
                if (value < 2007 || value > DateTime.Now.Year) throw new Exception("A kiadás éve 2007 és most között legyen!");
                kiadas = value;
            }
        }
        public string nyelv
        {
            get => nyelv;
            set {
                if (value != "magyar" || value != "angol" || value != "német") throw new Exception("A könyv nyelve magyar, angol vagy német legyen!");
                nyelv = value;
            }
        }
        public int keszlet
        {
            get => keszlet;
            set
            {
                if (value < 0) throw new Exception("A készlet nem lehet kissebb mint nulla!");
                keszlet = value;
            }
        }
        public int ar
        {
            get => ar;
            set
            {
                if (ar % 100 != 0) throw new Exception("az ár kerek százas szám legyen!");
                if (ar < 1000 || ar > 10000) throw new Exception("Az ár 1000 és 10000 között legyen!");
            }
        }

        public void Szerzorogzites(params string[] authors)
        {
           foreach (var szerzo in authors)
            {
                Szerzok.Add(new Authors(szerzo));
            }
        }   
        public string szerzoklistaja =>
            string.Join('\n', this.Szerzok);

        public override string ToString()
        {
            if (Szerzok.Count == 1)
            {
                return $"[{ISBN}]. {Cim}, {Nyelv} nyelven. Megjelent {Kiadas}-ban/ben. {Keszlet} db van raktáron, {Ar}Ft. Szerző:{Szerzok}";
            }
            else if(keszlet == 0)
            {
                return $"[{ISBN}]. {Cim}, {Nyelv} nyelven. Megjelent {Kiadas}-ban/ben. Beszerzés alatt áll, {Ar}Ft. Szerzők:{Szerzok}";
            }
            else if (Szerzok.Count == 1 && keszlet == 0)
            {
                return $"[{ISBN}]. {Cim}, {Nyelv} nyelven. Megjelent {Kiadas}-ban/ben. Beszerzés alatt áll, {Ar}Ft. Szerző:{Szerzok}";

            }
            else
            {
                return $"[{ISBN}]. {Cim}, {Nyelv} nyelven. Megjelent {Kiadas}-ban/ben. {Keszlet} van raktáron, {Ar}Ft. Szerzők:{Szerzok}";
            }

        }


        public Book(long iSBN, string cim, int kiadas, string nyelv, int keszlet, int ar, params string[] szerzok)
        {
            ISBN = iSBN;
            Cim = cim;
            Kiadas = kiadas;
            Nyelv = nyelv;
            Keszlet = keszlet;
            Ar = ar;
            foreach(var szerzo in szerzok)
            {
                this.Szerzok.Add(new Authors(szerzo));
            }
        }

      


    }
}
