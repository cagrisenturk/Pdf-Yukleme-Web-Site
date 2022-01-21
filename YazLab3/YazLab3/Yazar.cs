using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YazLab3
{
    public class Yazar
    {
        private string ad;
        private string soyad;
        private int ogrenciNo;
        private string ogrenimTuru;

        public Yazar(string ad, string soyad, int ogrenciNo, string ogrenimTuru)
        {
            this.ad = ad;
            this.soyad = soyad;
            this.ogrenciNo = ogrenciNo;
            this.ogrenimTuru = ogrenimTuru;
        }

        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public int OgrenciNo { get => ogrenciNo; set => ogrenciNo = value; }
        public string OgrenimTuru { get => ogrenimTuru; set => ogrenimTuru = value; }
    }
}