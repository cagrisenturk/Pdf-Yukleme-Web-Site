<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPdfBilgiler.aspx.cs" Inherits="YazLab3.AdminPdfBilgiler" %>

  <!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    <link

    href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    
    <title>Home</title>
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

</html>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <table class="w-100">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center">
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
    </table>
    </form>
    </body>
</html>
