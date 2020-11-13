<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AffichagePayClient.aspx.cs" Inherits="ApplicationAssurance.AffichagePayClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script>
  function printpage() {

   var getpanel = document.getElementById("<%= Panel1.ClientID%>");
   var MainWindow = window.open('', '', 'height=500,width=800');
   MainWindow.document.write('<html><head>');
   MainWindow.document.write('</head><body>');
   MainWindow.document.write(getpanel.innerHTML);
   MainWindow.document.write('</body></html>');
   MainWindow.document.close();
   setTimeout(function () {
    MainWindow.print();
   }, 500);
   return false;

  }
     </script>
    <style>
 body{
   
 }
.box
{
   position: absolute;
 left: 0;
 top: 0;
 bottom: 0;
 right: 0;
 z-index: 1;
 background: rgb(101, 154, 235);


opacity: .7;
}
                    .table1{

                     position: absolute;
                     z-index: 2;
                     left: 30%;
                     top: 40%;
                     transform: translate(-50%,-50%);
                     width: 35%; 
                     border-collapse: collapse;
                     border-spacing: 0;
                     box-shadow: 0 2px 15px rgba(64,64,64,.7);
                     border-radius: 12px 12px 0 0;
                     overflow: hidden;
                     text-align:left;
                    }
                    td , th{
                     padding: 15px 20px;
                     text-align: center;
                     font-size:15px ;
 

                    }
                   
                    th{
                     background-color:#33a6b0;
                     color: #fafafa;
                     font-family: 'Open Sans',Sans-serif;
                     font-weight: 200;
                     text-transform: uppercase;

                    }
                    tr{
                     width: 100%;
                     background-color: #fafafa;
                     font-family: 'Montserrat', sans-serif;
                    }
                    tr:nth-child(even){
                     background-color: #eeeeee;
                    }

.item{
margin-top:30%;
 margin-left:50%;
  width:150px;
  height:60px;
  text-align:center;
  cursor:pointer;
  border:2px solid #00acee;
  border-radius:10px;
  box-sizing:border-box;
  overflow:hidden;

 
  font-size:15px;
  font-weight:600;
  text-transform:uppercase;
  line-height:50px;
   
}


      

    </style>
</head>
<body>
       <form id="form1" runat="server" class="box">
             <asp:Panel ID="Panel1" runat="server">
       
        
          
            <table class="table1" runat="server">
                <tr>
                <th>Client : </th>
                <th><asp:Label ID="nomlbl1" runat="server" Text="Label"></asp:Label></th>
                
              </tr>
                <tr>
                   
                    <td><asp:Label ID="Label2" runat="server" Text="ID Affaire :"></asp:Label></td>
                    <td><asp:Label ID="idafflbl" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                
                    <td><asp:Label ID="Label4" runat="server" Text="Nom Prénom :"></asp:Label></td>
                    <td><asp:Label ID="nomlbl" runat="server" Text="Label"></asp:Label></td>
</tr>
                    <tr>
                
                    <td><asp:Label ID="Label6" runat="server" Text="Attestation :"></asp:Label></td>
                    <td><asp:Label ID="attestlbl" runat="server" Text="Label"></asp:Label></td>
                </tr>
                    <tr>
                
                    <td><asp:Label ID="Label8" runat="server" Text="Branche :"></asp:Label></td>
                    <td><asp:Label ID="branchelbl" runat="server" Text="Label"></asp:Label></td>
                </tr>
                    <tr>
                
                    <td><asp:Label ID="Label10" runat="server" Text="Compagnie :"></asp:Label></td>
                    <td><asp:Label ID="compagnielbl" runat="server" Text="Label"></asp:Label></td>
                </tr>
                    <tr>
                
                    <td><asp:Label ID="Label12" runat="server" Text="Periode :"></asp:Label></td>
                    <td><asp:Label ID="periodelbl" runat="server" Text="Label"></asp:Label></td>
                </tr>
                    <tr>
                
                    <td class="auto-style1"><asp:Label ID="Label14" runat="server" Text="Montant :"></asp:Label></td>
                    <td class="auto-style1"><asp:Label ID="montantlbl" runat="server" Text="Label"></asp:Label></td>
                </tr>
                    <tr>
                
                    <td><asp:Label ID="Label16" runat="server" Text="Payer :"></asp:Label></td>
                    <td><asp:Label ID="payerlbl" runat="server" Text="Label"></asp:Label></td>
                </tr>
                 <tr>
                
                    <td><asp:Label ID="Label18" runat="server" Text="Rest :"></asp:Label></td>
                    <td><asp:Label ID="restlbl" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                 
                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Button ID="Button1" runat="server" CssClass="item" Text="Imprimer l'état" OnClientClick="return printpage();" />
    </form>
</body>
</html>
