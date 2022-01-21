﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPdf.aspx.cs" Inherits="YazLab3.AdminPdf" %>

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
            height: 24px;
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
            </table>
        <table class="w-100">
            <tr>
                <td>
                    <table class="w-100">
                        <tr>
                            <td class="auto-style1">
                                <br />
                                <br />
                                <asp:TextBox ID="TextBoxYazarNo" runat="server"></asp:TextBox>
                                <asp:Button ID="ButtonYazarAra" runat="server" OnClick="ButtonYazarAra_Click" Text="Yazar No Ara" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:TextBox ID="TextBoxYazarAd" runat="server" Width="190px"></asp:TextBox>
                                <asp:Button ID="ButtonYazarAraAd" runat="server" OnClick="ButtonYazarAraAd_Click" Text="Yazar Ad Ara" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBoxYazarSoyad" runat="server"></asp:TextBox>
                                <asp:Button ID="ButtonYazarAraSoyad" runat="server" OnClick="ButtonYazarAraSoyad_Click" Text="Yazar Soyad Ara" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td> 
                    <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Right" >
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1" >Pdf Göster</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxDersAdi" runat="server"></asp:TextBox>
                    <asp:Button ID="ButtonDersAdıAra" runat="server" OnClick="ButtonDersAdıAra_Click" Text="Ders Adı Ara" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:TextBox ID="TextBoxProjeAdi" runat="server" ></asp:TextBox>
                    <asp:Button ID="ButtonProjeAdiAra" runat="server" OnClick="ButtonProjeAdiAra_Click" Text="Proje Adı Ara" />
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxAnahtarKelime" runat="server"></asp:TextBox>
                    <asp:Button ID="ButtonAnahtarKelimeArama" runat="server" OnClick="ButtonAnahtarKelimeArama_Click" Text="Anahtar Kelime Arama" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBoxDonem" runat="server"></asp:TextBox>
                    <asp:Button ID="ButtonDonemAra" runat="server" OnClick="ButtonDonemAra_Click" Text="Dönem Ara" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <p>
            &nbsp;</p>
        <table class="w-100">
            <tr>
                <td>
                    <asp:TextBox ID="DonemTextBox" runat="server"></asp:TextBox>
                    *Dönem Giriniz&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="LabelBilgi2" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="DersAdiTextBox" runat="server"></asp:TextBox>
                    *Ders Adı Giriniz&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="ButtonSorgula" runat="server" OnClick="ButtonSorgula_Click" Text="Sorgula" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="KullaniciTextBox" runat="server"></asp:TextBox>
                    *Kullanıcı Giriniz</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>

