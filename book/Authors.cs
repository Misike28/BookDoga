using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book
{
    internal class Authors
    {
        public Guid ID { get; set; }
        public string Vezeteknev;
        public string Keresztnev;

        public string vezeteknev
        {
            get => vezeteknev;
            set
            {
                if (value.Length < 3 || value.Length > 32) throw new ArgumentException("A vezetéknév hossza 3 és 32 karakter között legyen");
            }
        }
        public string keresztnev
        {
            get => keresztnev;
            set
            {
                if (value.Length < 3 || value.Length > 32) throw new ArgumentException("A keresztnév hossza 3 és 32 karakter között legyen");
            }
        }


        public Authors(string nev)
        {
            string[] v = nev.Split(' ');
            ID = Guid.NewGuid();
            vezeteknev = v[0];
            keresztnev = v[1];

        }
    }
}
