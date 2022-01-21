using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YazLab3
{
    public partial class AdminPdf : System.Web.UI.Page
    {
        VeriTabanı veriTabanı;
        protected void Page_Load(object sender, EventArgs e)
        {
            veriTabanı = new VeriTabanı();
            VeriGetir();
        }

        protected void ButtonYazarAra_Click(object sender, EventArgs e)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;

                    MySqlCommand komut = new MySqlCommand("select pdfs.adı_pdfs,pdfs.ders_adi_pdfs,pdfs.donem_pdfs from pdfs, yazar_pdf where  yazar_pdf.no_yazar = " + TextBoxYazarNo.Text + " and pdfs.id_pdfs = yazar_pdf.id_pdfs", baglan);
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
        public void VeriGetir()
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;

                    MySqlCommand komut = new MySqlCommand("select adı_pdfs,pdfs.ders_adi_pdfs,pdfs.donem_pdfs from pdfs  ", baglan);
                    oku = komut.ExecuteReader();
                    GridView1.DataSource = oku;
                    GridView1.DataBind();
                    baglan.Close();
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        protected void ButtonYazarAraAd_Click(object sender, EventArgs e)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;

                    MySqlCommand komut = new MySqlCommand("select pdfs.adı_pdfs,pdfs.ders_adi_pdfs,pdfs.donem_pdfs from pdfs,yazar_pdf,yazar where   pdfs.id_pdfs=yazar_pdf.id_pdfs and yazar.ad_yazar='" + TextBoxYazarAd.Text + "' and yazar.no_yazar=yazar_pdf.no_yazar", baglan);
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

        protected void ButtonYazarAraSoyad_Click(object sender, EventArgs e)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;

                    MySqlCommand komut = new MySqlCommand("select pdfs.adı_pdfs,pdfs.ders_adi_pdfs,pdfs.donem_pdfs from pdfs,yazar_pdf,yazar where pdfs.id_pdfs=yazar_pdf.id_pdfs and yazar.soyad_yazar='" + TextBoxYazarSoyad.Text + "' and yazar.no_yazar=yazar_pdf.no_yazar", baglan);
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

        protected void ButtonDersAdıAra_Click(object sender, EventArgs e)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;

                    MySqlCommand komut = new MySqlCommand("SELECT pdfs.adı_pdfs,pdfs.ders_adi_pdfs,pdfs.donem_pdfs FROM pdfs where pdfs.ders_adi_pdfs='" + TextBoxDersAdi.Text + "'", baglan);
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

        protected void ButtonProjeAdiAra_Click(object sender, EventArgs e)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;

                    MySqlCommand komut = new MySqlCommand("SELECT pdfs.adı_pdfs,pdfs.ders_adi_pdfs,pdfs.donem_pdfs FROM pdfs where pdfs.baslik_pdfs='" + TextBoxProjeAdi.Text + " '", baglan);
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

        protected void ButtonAnahtarKelimeArama_Click(object sender, EventArgs e)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;

                    MySqlCommand komut = new MySqlCommand("(select adı_pdfs,pdfs.ders_adi_pdfs,pdfs.donem_pdfs from pdfs where   id_pdfs IN (select id_pdfs from anahtar_kelime_pdf where anahtar_kelime='" + TextBoxAnahtarKelime.Text + "'))", baglan);
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

        protected void ButtonDonemAra_Click(object sender, EventArgs e)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;
                    MySqlCommand komut = new MySqlCommand("SELECT pdfs.adı_pdfs,pdfs.ders_adi_pdfs,pdfs.donem_pdfs FROM pdfs where pdfs.donem_pdfs='" + TextBoxDonem.Text + "'", baglan);
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

        protected void ButtonSorgula_Click(object sender, EventArgs e)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;
                    MySqlCommand komut = new MySqlCommand("select adı_pdfs,ders_adi_pdfs,donem_pdfs from pdfs where donem_pdfs='" + DonemTextBox.Text + "' and ders_adi_pdfs='" + DersAdiTextBox.Text + "' and  id_pdfs IN(select id_pdfs from kullanici_pdf where   id_kullanici IN (select id_kullanici from kullanici where ad_kullanici='" + KullaniciTextBox.Text + "'))", baglan);
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

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            int index = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            //VeriGetir();
            //LabelBilgi2.Text = "*"+ veriTabanı.DosyaYoluBul(GridView1.Rows[index].Cells[1].Text) +"*";
            //LabelBilgi2.Text = "*"+GridView1.Rows[index].Cells[1].Text+"*";
            string dosyaYolu = "C:\\Users\\csent\\Desktop\\c#\\YazLab3\\YazLab3\\pdfler\\"+GridView1.Rows[index].Cells[1].Text;
            WebClient user = new WebClient();
            byte[] fileBuffer = user.DownloadData(dosyaYolu);
            if (fileBuffer!=null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-legth", fileBuffer.Length.ToString());
                Response.BinaryWrite(fileBuffer);
            }
            
        }

        
    }
}