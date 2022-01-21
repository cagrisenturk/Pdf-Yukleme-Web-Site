using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace YazLab3
{
    public class VeriTabanı
    {

        public bool AdminGirisYap(string ad, string sifre, out string neden, out int id)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            if (ad.Equals(""))
            {
                neden = "Ad Boş Bırakılmaz";
                id = 0;
                return false;
            }
            else if (sifre.Equals(""))
            {
                id = 0;
                neden = "Şifre Boş Bırakılmaz";
                return false;
            }
            else
            {
                using (var baglan = new MySqlConnection(mysqlBaglantisi))
                {
                    try
                    {
                        baglan.Open();
                        MySqlDataReader oku;
                        MySqlCommand komut = new MySqlCommand("SELECT id_admin FROM admin WHERE ad_admin ='" + ad + "' AND sifre_admin ='" + sifre + "'", baglan);
                        oku = komut.ExecuteReader();
                        if (oku.Read())
                        {
                            id = oku.GetInt32(0);
                            neden = "Giriş Başarılı";
                            return true;





                        }
                        else
                        {
                            id = 0;
                            neden = "Kullanici Adı veya Şifre Hatalı";
                            return false;
                        }

                    }
                    catch (Exception hata)
                    {
                        id = 0;
                        neden = hata.ToString();
                        return false;
                        throw;
                    }
                }
            }

        }

        public bool GirisYap(string ad, string sifre,out string neden,out int id)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            if (ad.Equals(""))
            {
                neden = "Ad Boş Bırakılmaz";
                id = 0;
                return false;
            }
            else if (sifre.Equals(""))
            {
                id = 0;
                neden = "Şifre Boş Bırakılmaz";
                return false;
            }
            else
            {
                using (var baglan = new MySqlConnection(mysqlBaglantisi))
                {
                    try
                    {
                        baglan.Open();
                        MySqlDataReader oku;
                        MySqlCommand komut = new MySqlCommand("SELECT id_kullanici FROM kullanici WHERE ad_kullanici ='" + ad + "' AND sifre_kullanici ='" + sifre + "'", baglan);
                        oku = komut.ExecuteReader();
                        if (oku.Read())
                        {
                            id = oku.GetInt32(0);
                            neden = "Giriş Başarılı";
                            return true;
                           




                        }
                        else
                        {
                            id = 0;
                            neden = "Kullanici Adı veya Şifre Hatalı";
                            return false;
                        }

                    }
                    catch (Exception hata)
                    {
                        id = 0;
                        neden = hata.ToString();
                        return false;
                        throw;
                    }
                }
            }

        }


        public void PdfEkle(Pdf pdf,out string neden)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                   
                        MySqlCommand komut = new MySqlCommand("insert into pdf (adi_pdf,yolu_pdf) values (@p1,@p2)", baglan);
                        komut.Parameters.AddWithValue("@p1", pdf.Adı);
                        komut.Parameters.AddWithValue("@p2", pdf.DosyaYolu);
                        komut.ExecuteNonQuery();
                        neden = "Başarıyla Kaydedilmiştir";
                }

                catch (Exception hata)
                {
                    neden = hata.ToString();
                    throw;
                }
            }
        }

        public int MaxBul()
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            int id=0;
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;
                    MySqlCommand komut = new MySqlCommand("SELECT MAX(id_pdfs)  FROM pdfs", baglan);
                    oku = komut.ExecuteReader();
                    if (oku.Read())
                    {
                        id = oku.GetInt32(0);
                        return id;





                    }
                    return id;
                }
                catch (Exception)
                {
                    id = 0;

                    return id;
                    throw;
                }
            }
            
        }
       
        public void AnahtarKelimePdf(string anahtar)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlCommand komut = new MySqlCommand("insert into anahtar_kelime_pdf (anahtar_kelime,id_pdfs) values (@p1,@p2)", baglan);
                    komut.Parameters.AddWithValue("@p1",anahtar);
                    komut.Parameters.AddWithValue("@p2", MaxBul());
                    komut.ExecuteNonQuery();
                }

                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void YazarEkle(Yazar yazar)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();

                    MySqlCommand komut = new MySqlCommand("insert into yazar (no_yazar,ad_yazar,soyad_yazar,ogrenim_turu_yazar) values (@p1,@p2,@p3,@p4)", baglan);
                    komut.Parameters.AddWithValue("@p1", yazar.OgrenciNo);
                    komut.Parameters.AddWithValue("@p2", yazar.Ad);
                    komut.Parameters.AddWithValue("@p3", yazar.Soyad);
                    komut.Parameters.AddWithValue("@p4", yazar.OgrenimTuru);

                    komut.ExecuteNonQuery();
                }

                catch (Exception )
                {
                   
                    throw;
                }
            }
        }
        public void KullaniciGuncelle(string id,string Ad,string sifre)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();

                    MySqlCommand komut = new MySqlCommand("UPDATE kullanici SET ad_kullanici ='"+Ad + "', sifre_kullanici='"+sifre + "' WHERE id_kullanici ='" + id + "'", baglan);
                    komut.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }


            }
        }
        
        public void KullaniciSil(string id)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();

                    MySqlCommand komut = new MySqlCommand("DELETE FROM kullanici WHERE id_kullanici = '" + id + "'", baglan);
                    komut.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }


            }
        }
        public void KullaniciEkle(string ad,string sifre)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();

                    MySqlCommand komut = new MySqlCommand("insert into kullanici (ad_kullanici,sifre_kullanici) values (@p1,@p2)", baglan);
                    komut.Parameters.AddWithValue("@p1", ad);
                    komut.Parameters.AddWithValue("@p2", sifre);

                    komut.ExecuteNonQuery();
                }

                catch (Exception)
                {

                    throw;
                }
            }
        }
        public void YazarPdfEkle(Yazar yazar)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();

                    MySqlCommand komut = new MySqlCommand("insert into yazar_pdf (no_yazar,id_pdfs) values (@p1,@p2)", baglan);
                    komut.Parameters.AddWithValue("@p1", yazar.OgrenciNo);
                    komut.Parameters.AddWithValue("@p2", MaxBul());
                    komut.ExecuteNonQuery();
                }

                catch (Exception )
                {

                    throw;
                }
            }
        }
        public void KullaniciPdfEkle()
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();

                    MySqlCommand komut = new MySqlCommand("insert into kullanici_pdf (id_kullanici,id_pdfs) values (@p1,@p2)", baglan);
                    komut.Parameters.AddWithValue("@p1", Kullanici.Id);
                    komut.Parameters.AddWithValue("@p2", MaxBul());
                    komut.ExecuteNonQuery();
                }

                catch (Exception )
                {

                    throw;
                }
            }
        }

        public string DosyaYoluBul(string baslik)
        {
            string dosyaYolu=" ";
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;

                    MySqlCommand komut = new MySqlCommand("SELECT dosya_yolu_pdfs FROM pdfs WHERE baslik_pdfs='"+baslik +"'", baglan);
                    oku = komut.ExecuteReader();
                    dosyaYolu = oku.GetString("");
                    return dosyaYolu;
                }
                catch (Exception e)
                {
                    return e.ToString();
                    throw;
                }

            }
        }

        public void PdfsEkle(Pdf pdf,out string neden)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();

                    MySqlCommand komut = new MySqlCommand("insert into pdfs (ders_adi_pdfs,ozet_pdfs,donem_pdfs,baslik_pdfs,dosya_yolu_pdfs,adı_pdfs,danısman_ad_pdfs,danısman_soyad_pdfs,danısman_unvan_pdfs,juri1_ad_pdfs,juri1_soyad_pdfs,juri1_unvan_pdfs,juri2_ad_pdfs,juri2_soyad_pdfs,juri2_unvan_pdfs,juri3_ad_pdfs,juri3_soyad_pdfs,juri3_unvan_pdfs) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18)", baglan);
                    komut.Parameters.AddWithValue("@p1", pdf.DersAdi);
                    komut.Parameters.AddWithValue("@p2", pdf.Ozet);
                    komut.Parameters.AddWithValue("@p3", pdf.Donem);
                    komut.Parameters.AddWithValue("@p4", pdf.Baslik);
                    komut.Parameters.AddWithValue("@p5", pdf.DosyaYolu);
                    komut.Parameters.AddWithValue("@p6", pdf.Adı);
                    komut.Parameters.AddWithValue("@p7", pdf.Danisman.Ad);
                    komut.Parameters.AddWithValue("@p8", pdf.Danisman.Soyad);
                    komut.Parameters.AddWithValue("@p9", pdf.Danisman.Unvan);
                    komut.Parameters.AddWithValue("@p10", pdf.Juri1Id.Ad);
                    komut.Parameters.AddWithValue("@p11", pdf.Juri1Id.Soyad);
                    komut.Parameters.AddWithValue("@p12", pdf.Juri1Id.Unvan);
                    komut.Parameters.AddWithValue("@p13", pdf.Juri2Id.Ad);
                    komut.Parameters.AddWithValue("@p14", pdf.Juri2Id.Soyad);
                    komut.Parameters.AddWithValue("@p15", pdf.Juri2Id.Unvan);
                    komut.Parameters.AddWithValue("@p16", pdf.Juri3Id.Ad);
                    komut.Parameters.AddWithValue("@p17", pdf.Juri3Id.Soyad);
                    komut.Parameters.AddWithValue("@p18", pdf.Juri3Id.Unvan);
                    komut.ExecuteNonQuery();
                    neden = "Başarıyla Kaydedilmiştir";
                }

                catch (Exception hata)
                {
                    neden = hata.ToString();
                    throw;
                }
            }
        }
    }
}