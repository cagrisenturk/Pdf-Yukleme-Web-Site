using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
namespace YazLab3
{
    public class Pdf
    {
        private string adı;
        private string dosyaYolu;
        private string dersAdi;
        private string ozet;
        private string donem;
        private string baslik;
        private int id;
        private Danisman danisman=new Danisman();
        private Juri juri1Id=new Juri();
        private Juri juri2Id=new Juri();
        private Juri juri3Id=new Juri();
        private List<string> anahtarKelime=new List<string>();
        private List<Yazar> yazarlar = new List<Yazar>();

        public Pdf(string adı, string dosyaYolu)
        {
            this.dosyaYolu = dosyaYolu;
            this.adı = adı;
        }

        public string Adı { get => adı; set => adı = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string DersAdi { get => dersAdi; set => dersAdi = value; }
        public string Ozet { get => ozet; set => ozet = value; }
        public string Donem { get => donem; set => donem = value; }
        public string Baslik { get => baslik; set => baslik = value; }
        public int Id { get => id; set => id = value; }
        
        public List<string> AnahtarKelime { get => anahtarKelime; set => anahtarKelime = value; }
        public List<Yazar> Yazarlar { get => yazarlar; set => yazarlar = value; }
        public Danisman Danisman { get => danisman; set => danisman = value; }
        public Juri Juri1Id { get => juri1Id; set => juri1Id = value; }
        public Juri Juri2Id { get => juri2Id; set => juri2Id = value; }
        public Juri Juri3Id { get => juri3Id; set => juri3Id = value; }

        public void PdfParcala(Pdf pdf)
        {
            try
            {
                StringBuilder text = new StringBuilder();
                using (PdfReader reader = new PdfReader(dosyaYolu))
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, 2));
                }
                string sayfa = text.ToString();
                int baslangic, yıl;
                string  danisman="", unvan = "" ;
                List<string> ögrenciler = new List<string>();
                List<string> ögrencilerAd = new List<string>();
                List<string> ögrencilerSoyAd = new List<string>();
                List<string> jüriler = new List<string>();
                List<string> jürilerAd = new List<string>();
                List<string> jürilerSoyAd = new List<string>();
                List<string> unvanlar = new List<string>();
                List<int> numaralar = new List<int>();
                List<string> ogrenimTuru = new List<string>();
                List<string> anahtarKelime = new List<string>();
                if (sayfa.Contains("BİTİRME PROJESİ"))
                {
                    baslangic = sayfa.IndexOf("BİTİRME PROJESİ") + 15;
                    //Console.WriteLine(sayfa.IndexOf("LİSANS TEZİ"));
                    pdf.dersAdi = "BİTİRME PROJESİ";


                    //sayfa = sayfa.Substring(0, sayfa.IndexOf("\n \n"));
                }
                else
                {
                    baslangic = sayfa.IndexOf("ARAŞTIRMA PROBLEMLERİ") + 21;
                    pdf.dersAdi = "ARAŞTIRMA PROBLEMLERİ";  
                }
                sayfa = sayfa.Remove(0, baslangic).Trim();
                baslangic = sayfa.IndexOf("\n");
                pdf.baslik = sayfa.Substring(0, baslangic);
                sayfa = sayfa.Remove(0, baslangic + 1);
                if (!(sayfa.IndexOf("\n") < 2))
                {
                    baslangic = sayfa.IndexOf("\n");
                    pdf.baslik += sayfa.Substring(0, baslangic);
                    sayfa = sayfa.Remove(0, baslangic).Trim();
                }
                else
                {
                    sayfa = sayfa.Trim();
                }   
                while (!(sayfa.IndexOf("\n") < 2))
                {
                    baslangic = sayfa.IndexOf("\n");
                    ögrenciler.Add(sayfa.Substring(0, baslangic-1));
                    sayfa = sayfa.Remove(0, baslangic + 1);
                }

                sayfa = sayfa.Trim();


                for (int i = 0; i < 3; i++)
                {
                    unvan = sayfa.Substring(0, sayfa.IndexOf(".") + 1);
                    sayfa = sayfa.Remove(0, sayfa.IndexOf(".") + 1).Trim();
                    unvan += sayfa.Substring(0, sayfa.IndexOf(".") + 1);
                    sayfa = sayfa.Remove(0, sayfa.IndexOf(".") + 1).Trim();
                    if (sayfa.IndexOf("Üyesi") < 1)
                    {
                        unvan += " Üyesi";
                        sayfa = sayfa.Remove(0, 5).Trim();
                    }
                    unvanlar.Add(unvan);
                    baslangic = sayfa.IndexOf("\n");
                    jüriler.Add(sayfa.Substring(0, baslangic));
                    if (i == 0)
                    {
                        danisman = sayfa.Substring(0, baslangic);
                    }
                    sayfa = sayfa.Remove(0, baslangic + 1);
                    baslangic = sayfa.IndexOf("\n");
                    sayfa = sayfa.Remove(0, baslangic + 1);
                    baslangic = sayfa.IndexOf("\n");
                    sayfa = sayfa.Remove(0, baslangic + 1);
                }
                for (int i = 0; i < 3; i++)
                {
                    string juriAd = "";
                    string juriSoyAd = "";
                    while (!(jüriler[i].IndexOf(" ") == -1))
                    {
                        baslangic = jüriler[i].IndexOf(" ");
                        if (Convert.ToChar(jüriler[i].Substring(1, 1)) >= 'A' && Convert.ToChar(jüriler[i].Substring(1, 1)) <= 'Z')
                        {
                            juriSoyAd += jüriler[i].Substring(0, baslangic + 1);
                        }
                        else
                        {
                            juriAd += jüriler[i].Substring(0, baslangic + 1);
                        }
                        jüriler[i] = jüriler[i].Remove(0, baslangic + 1);
                    }
                    jürilerAd.Add(juriAd);
                    jürilerSoyAd.Add(juriSoyAd);
                    if (i==0)
                    {
                        pdf.danisman.Ad = jürilerAd[i];
                        pdf.danisman.Soyad = jürilerSoyAd[i];
                        pdf.danisman.Unvan = unvanlar[i];
                        pdf.juri1Id.Ad = jürilerAd[i];
                        pdf.juri1Id.Soyad = jürilerSoyAd[i];
                        pdf.juri1Id.Unvan = unvanlar[i];
                    }
                    if (i == 1)
                    {
                        pdf.juri2Id.Ad = jürilerAd[i];
                        pdf.juri2Id.Soyad = jürilerSoyAd[i];
                        pdf.juri2Id.Unvan = unvanlar[i];
                    }
                    if (i==2)
                    {
                        pdf.juri3Id.Ad = jürilerAd[i];
                        pdf.juri3Id.Soyad = jürilerSoyAd[i];
                        pdf.juri3Id.Unvan = unvanlar[i];
                    }
                }
                baslangic = sayfa.IndexOf(".");
                if (sayfa.Substring(baslangic + 1, 2) == "06" || sayfa.Substring(baslangic + 1, 2) == "05")
                {
                    yıl = Convert.ToInt32(sayfa.Substring(baslangic + 4, 4));
                    pdf.donem = yıl - 1 + "-" + yıl + " Bahar";
                }
                else if (sayfa.Substring(baslangic + 1, 2) == "01")
                {
                    yıl = Convert.ToInt32(sayfa.Substring(baslangic + 4, 4));
                    pdf.donem = yıl - 1 + "-" + yıl + " Güz";
                }
                else if (sayfa.Substring(baslangic + 1, 2) == "12")
                {
                    yıl = Convert.ToInt32(sayfa.Substring(baslangic + 4, 4));
                    pdf.donem = yıl + "-" + yıl + 1 + " Güz";
                }
                text.Clear();
                using (PdfReader reader = new PdfReader(dosyaYolu))
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, 4));
                }
                sayfa = text.ToString();
                baslangic = sayfa.IndexOf("Öğrenci No:");
                sayfa = sayfa.Remove(0, baslangic);

                while (!(sayfa.IndexOf("Öğrenci No:") == -1))
                {
                    baslangic = sayfa.IndexOf("Öğrenci No:");
                    sayfa = sayfa.Remove(0, baslangic + 12);
                    numaralar.Add(Convert.ToInt32(sayfa.Substring(0, 9)));
                    if ((sayfa.Substring(5, 1)) == "1")
                    {
                        ogrenimTuru.Add("1. Öğretim");
                    }
                    else
                    {
                        ogrenimTuru.Add("2. Öğretim");
                    }

                }
                for (int i = 0; i < ögrenciler.Count; i++)
                {
                    baslangic = ögrenciler[i].LastIndexOf(" ");
                    ögrencilerAd.Add(ögrenciler[i].Substring(0, baslangic));
                    ögrenciler[i] = ögrenciler[i].Remove(0, baslangic + 1);
                    ögrencilerSoyAd.Add(ögrenciler[i]);
                }
                for (int i = 0; i < ögrenciler.Count; i++)
                {
                    Yazar yazar = new Yazar(ögrencilerAd[i], ögrencilerSoyAd[i], numaralar[i], ogrenimTuru[i]);
                    pdf.yazarlar.Add(yazar);
                }
                text.Clear();
                using (PdfReader reader = new PdfReader(dosyaYolu))
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, 10));
                }
                sayfa = text.ToString();
                baslangic = sayfa.IndexOf("ÖZET");
                sayfa = sayfa.Remove(0, baslangic + 6);
                baslangic = sayfa.IndexOf("Anahtar kelimeler");
                pdf.ozet = sayfa.Substring(0, baslangic - 2);
                sayfa = sayfa.Remove(0, baslangic + 19);
                baslangic = sayfa.IndexOf(".");
                sayfa = sayfa.Remove(baslangic + 1);

                while (!(sayfa.IndexOf(".") == 0))
                {
                    if (!(sayfa.IndexOf("\n") == -1))
                    {
                        sayfa = sayfa.Remove(sayfa.IndexOf("\n"), 1);
                    }

                    if (sayfa.IndexOf(",") == -1)
                    {
                        anahtarKelime.Add(sayfa.Substring(0, sayfa.IndexOf(".")).ToUpper());
                        break;

                    }
                    anahtarKelime.Add(sayfa.Substring(0, sayfa.IndexOf(",")).ToUpper());
                    sayfa = sayfa.Remove(0, sayfa.IndexOf(",") + 2);
                }
                for (int i = 0; i < anahtarKelime.Count; i++)
                {
                   pdf.anahtarKelime.Add(anahtarKelime[i]);
                }


            }
            catch (Exception hata)
            {
                Console.WriteLine(hata);
                throw;
            }
        }
        public void adSoyadParcala(Pdf pdf)
        {
            //pdf.juri1Id.Ad
        }
    }
    }
