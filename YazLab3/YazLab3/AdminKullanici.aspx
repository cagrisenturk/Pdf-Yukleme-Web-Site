<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminKullanici.aspx.cs" Inherits="YazLab3.AdminKullanici" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    <link

    href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    
    <title>Home</title>
    <style type="text/css">
        .auto-style1 {
            height: 36px;
        }
        .auto-style4 {
            width: 609px;
            height: 70px;
        }
        .auto-style5 {
            height: 36px;
            width: 609px;
        }
        .auto-style8 {
            width: 756px;
            height: 70px;
        }
        .auto-style9 {
            height: 36px;
            width: 756px;
        }
        .auto-style11 {
            width: 609px;
            height: 125px;
        }
        .auto-style12 {
            width: 756px;
            height: 125px;
        }
        .auto-style13 {
            height: 125px;
        }
        .auto-style14 {
            width: 801px;
            height: 125px;
        }
        .auto-style15 {
            width: 801px;
            height: 70px;
        }
        .auto-style16 {
            height: 36px;
            width: 801px;
        }
        .auto-style17 {
            height: 70px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <nav class ="navbar navbar-expands-lg navbar-dark bg-dark">
     <div class ="container-fluid">
         <button 
         class ="navbar-toggler" 
         type ="button" 
         data-bs-toggle ="collapse"
         data-bs-target="#navbar"
         >
         <span class="navbar-toggler-icon"></span>
         </button>
         <div class="collapse navbar-collapse" id ="navbar">
             <div class ="navbar-nav">
                 <a class="nav-item nav-link" href="AdminKullanici.aspx">Kullanıcı İşlemleri</a>
                 <a class="nav-item nav-link" href="AdminPdf.aspx">Pdf İşlemleri</a>
                 <a class="nav-item nav-link" href="AdminPdfBilgiler.aspx">Pdf Bilgileri</a>
             </div>
         </div>
     </div>   
    </nav>

    
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous">    
</script>
        <table class="w-100">
            <tr>
                <td class="auto-style14">
                    <br />
                    Kullanıcı Adı:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBoxKullaniciAdi" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td class="auto-style11">
                    <br />
                    <br />
                    Silmek İstediğiniz Kullanıcının<br />
                    id:&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxKullaniciId" runat="server"></asp:TextBox>
                    <br />
                    &nbsp;&nbsp;&nbsp;
                </td>
                <td class="auto-style12">
                    <br />
                    Güncellemek İstediğiniz Kullanıcnın
                    <br />
                    id:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBoxGuncelleId" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style13">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            </tr>
            <tr>
                <td class="auto-style15">Şifre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBoxSifre" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ButtonKullaniciSil" runat="server" OnClick="ButtonKullaniciSil_Click" Text="Kullanıcı Sil" />
                </td>
                <td class="auto-style8">Kullanıcı Adı:<asp:TextBox ID="TextBoxGuncelleAd" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ButtonKullaniciEkle" runat="server" OnClick="ButtonKullaniciEkle_Click" Text="Kullanici Ekle" Width="172px" CssClass="offset-sm-0" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:Label ID="LabelBilgi" runat="server"></asp:Label>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style9">Şifre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBoxGuncelleSifre" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ButtonKullanıcıGuncelle" runat="server" OnClick="ButtonKullanıcıGuncelle_Click" Text="Kullanıcı Güncelle" Width="154px" />
                </td>
                <td class="auto-style1"></td>
            </tr>
        </table>
        <table class="w-100">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
                    &nbsp;<asp:GridView ID="GridView1" runat="server" CaptionAlign="Right" HorizontalAlign="Center">
                    </asp:GridView>
    </form>
</body>
</html>
