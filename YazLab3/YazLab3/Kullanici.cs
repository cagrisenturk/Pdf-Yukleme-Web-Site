using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YazLab3
{
    public class Kullanici
    {
        static int id;
        static string ad;
        private string sifre;

        public Kullanici(string ad, string sifre)
        {
            this.sifre = sifre;
        }

        public static int Id { get => id; set => id = value; }
        public static string Ad { get => ad; set => ad = value; }
        public string Sifre { get => sifre; set => sifre = value; }
    }
}