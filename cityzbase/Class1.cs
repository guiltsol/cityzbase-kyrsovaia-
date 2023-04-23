using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cityzbase
{
    public class Cityz
    {
        private string contry;
        private string cityname;
        private double nasel;
        private double plos;
        private string stol;
        private double obzp;
        public Cityz(string c, string ci, double n, double p, string st,double z)
        {
            contry = c;
            cityname = ci;
            nasel = n;
            plos = p;
            stol = st;
            obzp = z;
        }
        public string Info()
        {
            string s = contry + " " + cityname + " " + nasel + " " + plos + " " + stol + " " + obzp;
            return s;
        }
    }
}
