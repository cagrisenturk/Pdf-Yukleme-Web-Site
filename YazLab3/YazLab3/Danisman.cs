using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YazLab3
{
    public class Danisman
    {
        private int id;
        private string ad;
        private string soyad;
        private string unvan;

        public Danisman()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public string Unvan { get => unvan; set => unvan = value; }
    }
}