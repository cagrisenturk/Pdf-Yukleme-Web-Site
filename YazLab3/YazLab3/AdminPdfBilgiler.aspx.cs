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
    public partial class AdminPdfBilgiler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mysqlBaglantisi = "SERVER=localhost;DATABASE=website;UID=root;PWD=1234";
            using (var baglan = new MySqlConnection(mysqlBaglantisi))
            {
                try
                {
                    baglan.Open();
                    MySqlDataReader oku;
                    MySqlCommand komut = new MySqlCommand("SELECT * FROM pdfs,yazar_pdf,yazar where    yazar_pdf.id_pdfs=pdfs.id_pdfs and yazar.no_yazar=yazar_pdf.no_yazar ", baglan);
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
            string dosyaYolu = "C:\\Users\\csent\\Desktop\\c#\\YazLab3\\YazLab3\\pdfler\\" + GridView1.Rows[index].Cells[7].Text;
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