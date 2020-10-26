<%@ Page Title="" Language="C#" MasterPageFile="~/Avenant.Master" AutoEventWireup="true" CodeBehind="AffectationImmaMP.aspx.cs" Inherits="Avenent.AffectationImmaMP" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 22px;
            width: 539px;
        }
        .auto-style2 {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Changement D'Immatriculation"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div  style="margin-bottom:2rem ; text-align:center;" >
    <table border="1" class="auto-style1" >
              <tr>
                <td>
                    <asp:Label runat="server" Text="Id Client"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="idclienttxt" runat="server"></asp:TextBox>
                </td>
            </tr>
          <tr>
                <td>
                    <asp:Label runat="server" Text="Nom Prénom"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="nomtxt" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label runat="server" Text="Cin"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="cintxt" runat="server"></asp:TextBox>
                </td>
            </tr>
         <tr>
                <td>
                    <asp:Label runat="server" Text="souscripteure"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="soutxt" runat="server"></asp:TextBox>
                </td>
            </tr>
       
         <tr>
                <td>
                    <asp:Label runat="server" Text="Compagnie"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="compagnietxt" runat="server"></asp:TextBox>
                </td>
            </tr>
         <tr>
                <td class="auto-style2">
                    <asp:Label runat="server" Text="affectation"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="affectationtxt" runat="server"></asp:TextBox>
                </td>
            </tr>
         <tr>
                <td>
                    <asp:Label runat="server" Text="type Affaire"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Typeafftxt" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style2">
                    <asp:Label runat="server" Text="Nature d'opération"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="natureopetxt" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label runat="server" Text="Date D'opération"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="dateopetxt" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label runat="server" Text="date fin"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="datefintxt" runat="server"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td>
                    <asp:Label runat="server" Text="date debut"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="datedebuttxt" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label runat="server" Text="NumPolice"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="numpolictxt" runat="server"></asp:TextBox>
                </td>
            </tr>
            
          <tr>
                <td>
                    <asp:Label runat="server" Text="Immatriculation" ForeColor="#66FF33"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="immatxt" runat="server"></asp:TextBox>
                </td>
            </tr>
            
              <tr>
                <td>
                    <asp:Label runat="server" Text="Marque"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="marqtxt" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>
                    <asp:Label runat="server" Text="Usage"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="usagetxt" runat="server"></asp:TextBox>
                </td>
            </tr>
         <tr>
                <td>
                    <asp:Label runat="server" Text="date mec"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="datemectxt" runat="server"></asp:TextBox>
                </td>
            </tr>
        
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label15" runat="server" Text="montant"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="montanttxt" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label16" runat="server" Text="Prime Nette"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="primenettxt" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label17" runat="server" Text="Taxe TVA"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="tvatxt" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label18" runat="server" Text="Taxe EvRc"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="taxeevrctxt" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label19" runat="server" Text="Taxe EvGa"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="taxeevga" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label20" runat="server" Text="Accessoire"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="accessoiretxt" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label21" runat="server" Text="Net a Payer"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="netapayertxt" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label22" runat="server" Text="Taxe1"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="taxe1txt" runat="server"></asp:TextBox>
            </td>
        </tr>
      </table>
        </div>
    <div style="text-align:center">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Enregistrer" Width="215px" />
        </div>
</asp:Content>