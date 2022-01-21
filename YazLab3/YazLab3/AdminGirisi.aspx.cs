using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YazLab3
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGiris_Click(object sender, EventArgs e)
        {
            VeriTabanı veriTabanı = new VeriTabanı();
            string ad = TextBoxKullaniciAdi.Text;
            string sifre = TextBoxSifre.Text;
            string neden;
            if (veriTabanı.AdminGirisYap(ad, sifre, out neden, out int id))
            {
                LabelDurum.Text = neden;
                Response.Redirect("AdminPdf.aspx");
            }
            else
            {
                LabelDurum.Text = neden;
            }
        }
    }
}