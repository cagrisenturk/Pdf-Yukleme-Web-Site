using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace YazLab3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        VeriTabanı veriTabanı;
        protected void Page_Load(object sender, EventArgs e)
        {
            veriTabanı = new VeriTabanı();
            Label1.Text = Kullanici.Ad.ToUpper() + " Hoş Geldiniz";
            VeriGetir();
        }


        protected void ButtonYukle_Click1(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)//Kullanıcı fileupload ile bir dosya seçmiş ise işlemleri gerçekleştir.
            {
                if (FileUpload1.PostedFile.ContentType == "application/pdf") //Sadece jpeg dosyalarını yüklenmesine izin veriyoruz.
                {
                    FileUpload1.SaveAs("C:\\Users\\csent\\Desktop\\c#\\YazLab3\\YazLab3\\pdfler\\" + FileUpload1.FileName);
                    Pdf pdf = new Pdf(FileUpload1.FileName, "C:\\Users\\csent\\Desktop\\c#\\YazLab3\\YazLab3\\pdfler\\" + FileUpload1.FileName);
                     
                    pdf.PdfParcala(pdf);
                    veriTabanı.PdfsEkle(pdf, out string neden);
                    LabelBilgi.Text = neden+veriTabanı.MaxBul();
                    
                    veriTabanı.KullaniciPdfEkle();
                    
                    for (int i = 0; i < pdf.Yazarlar.Count; i++)
                    {
                        veriTabanı.YazarEkle(pdf.Yazarlar[i]);
                        veriTabanı.YazarPdfEkle(pdf.Yazarlar[i]);
                    }
                    for (int i = 0; i < pdf.AnahtarKelime.Count; i++)
                    {
                        veriTabanı.AnahtarKelimePdf(pdf.AnahtarKelime[i]);
                    }
                    VeriGetir();
                }
                
                    
                else
                    LabelBilgi.Text = "Sadece pdf uzantılı dosyalar yüklenebilir.";
            }
            else
                LabelBilgi.Text = "Lütfen bir dosya seçiniz.";
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

                    MySqlCommand komut = new MySqlCommand("select adı_pdfs from pdfs where id_pdfs IN(select id_pdfs from kullanici_pdf where id_kullanici =" + Kullanici.Id + ")", baglan);
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

        protected void ButtonYazarAra_Click(object sender, EventArgs e)
        {
            
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;

                    MySqlCommand komut = new MySqlCommand("select pdfs.adı_pdfs from pdfs, yazar_pdf,kullanici_pdf where  yazar_pdf.no_yazar = "+TextBoxYazarNo.Text+" and pdfs.id_pdfs = yazar_pdf.id_pdfs and kullanici_pdf.id_kullanici="+Kullanici.Id+" and yazar_pdf.id_pdfs=kullanici_pdf.id_pdfs", baglan);
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

        protected void ButtonYazarAraAd_Click(object sender, EventArgs e)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;

                    MySqlCommand komut = new MySqlCommand("select pdfs.adı_pdfs from pdfs,yazar_pdf,yazar,kullanici_pdf where   pdfs.id_pdfs=yazar_pdf.id_pdfs and yazar.ad_yazar='" + TextBoxYazarAd.Text+"' and yazar.no_yazar=yazar_pdf.no_yazar  and kullanici_pdf.id_kullanici="+Kullanici.Id+" and yazar_pdf.id_pdfs=kullanici_pdf.id_pdfs", baglan);
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

                    MySqlCommand komut = new MySqlCommand("select pdfs.adı_pdfs from pdfs,yazar_pdf,yazar,kullanici_pdf where   pdfs.id_pdfs=yazar_pdf.id_pdfs and yazar.soyad_yazar='" + TextBoxYazarSoyad.Text + "' and yazar.no_yazar=yazar_pdf.no_yazar  and kullanici_pdf.id_kullanici=" + Kullanici.Id + " and yazar_pdf.id_pdfs=kullanici_pdf.id_pdfs", baglan);
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

                    MySqlCommand komut = new MySqlCommand("SELECT  pdfs.adı_pdfs FROM pdfs,kullanici_pdf where pdfs.ders_adi_pdfs='"+TextBoxDersAdi.Text+"' and kullanici_pdf.id_kullanici="+Kullanici.Id+" and pdfs.id_pdfs=kullanici_pdf.id_pdfs", baglan);
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

                    MySqlCommand komut = new MySqlCommand("SELECT  pdfs.adı_pdfs FROM pdfs, kullanici_pdf where pdfs.baslik_pdfs = '"+TextBoxProjeAdi.Text+" ' and kullanici_pdf.id_kullanici = "+Kullanici.Id+" and pdfs.id_pdfs = kullanici_pdf.id_pdfs", baglan);
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

                    MySqlCommand komut = new MySqlCommand("select adı_pdfs from pdfs,anahtar_kelime_pdf,kullanici_pdf where anahtar_kelime_pdf.anahtar_kelime='"+TextBoxAnahtarKelime.Text+"' and pdfs.id_pdfs=anahtar_kelime_pdf.id_pdfs and kullanici_pdf.id_kullanici="+Kullanici.Id+" and kullanici_pdf.id_pdfs=pdfs.id_pdfs", baglan);
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
                    MySqlCommand komut = new MySqlCommand("SELECT pdfs.adı_pdfs FROM pdfs,kullanici_pdf where pdfs.donem_pdfs='"+TextBoxDonem.Text+"' and kullanici_pdf.id_kullanici="+Kullanici.Id+" and kullanici_pdf.id_pdfs=pdfs.id_pdfs", baglan);
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
                    MySqlCommand komut = new MySqlCommand("select adı_pdfs from pdfs where donem_pdfs='" + DonemTextBox.Text +"' and ders_adi_pdfs='"+DersAdiTextBox.Text+"' and  id_pdfs IN(select id_pdfs from kullanici_pdf where   id_kullanici IN (select id_kullanici from kullanici where id_kullanici="+Kullanici.Id+"))", baglan);
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
            string dosyaYolu = "C:\\Users\\csent\\Desktop\\c#\\YazLab3\\YazLab3\\pdfler\\" + GridView1.Rows[index].Cells[1].Text;
            WebClient user = new WebClient();
            byte[] fileBuffer = user.DownloadData(dosyaYolu);
            if (fileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-legth", fileBuffer.Length.ToString());
                Response.BinaryWrite(fileBuffer);
            }
        }
    }
}