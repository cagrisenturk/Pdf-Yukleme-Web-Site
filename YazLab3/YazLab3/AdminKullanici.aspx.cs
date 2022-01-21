using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YazLab3
{
    public partial class AdminKullanici : System.Web.UI.Page
    {
        VeriTabanı veriTabanı ;
        protected void Page_Load(object sender, EventArgs e)
        {
            veriTabanı = new VeriTabanı();
            VeriGetir();
        }

        protected void ButtonKullaniciEkle_Click(object sender, EventArgs e)
        {
            VeriTabanı veriTabanı = new VeriTabanı();
            if (!(TextBoxKullaniciAdi.Text=="" || TextBoxSifre.Text==""))
            {
                veriTabanı.KullaniciEkle(TextBoxKullaniciAdi.Text, TextBoxSifre.Text);
                LabelBilgi.Text = "Başarıyla Kaydedildi";
            }
            else
            {
                LabelBilgi.Text = "Şifre ve Kullanıcı Adı Boş Bırakılamaz";
            }
            VeriGetir();
        }
        

        protected void ButtonKullaniciSil_Click(object sender, EventArgs e)
        {
            veriTabanı.KullaniciSil(TextBoxKullaniciId.Text);
            VeriGetir();
        }
        public void VeriGetir()
        {

            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;

                    MySqlCommand komut = new MySqlCommand("select * from kullanici   ", baglan);
                    oku = komut.ExecuteReader();
                    GridView1.DataSource = oku;
                    GridView1.DataBind();
                }
                catch (Exception)
                {
                    throw;
                }


            }
        }

        protected void ButtonKullanıcıGuncelle_Click(object sender, EventArgs e)
        {
            veriTabanı.KullaniciGuncelle(TextBoxGuncelleId.Text,TextBoxGuncelleAd.Text,TextBoxGuncelleSifre.Text);
            VeriGetir();
        }
    }
}