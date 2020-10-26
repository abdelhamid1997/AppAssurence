<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="EtatProduction.aspx.cs" Inherits="ApplicationAssurance.EtatProduction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
    </style>
    <link href="StyleEtatAvenant.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body">
    <div class="headpage">
        <div class="todayRefrech">
       <asp:LinkButton ID="refrech" PostBackUrl="#" OnClick="refrech_Click" runat="server"><asp:Image  CssClass="RefrechImg" ImageUrl="/img/refrech.png" runat="server"/></asp:LinkButton> <h5><asp:Label runat="server">Aujourd'huit <asp:CheckBox ID="CheckBoxToday" Checked="true" CssClass="checkToday"  OnCheckedChanged="CheckBoxToday_CheckedChanged"  runat="server" /></asp:Label></h5> 
       </div>
       <div class="period">
         Period entre <asp:TextBox ID="TextBoxDate1" CssClass="txtDate" runat="server" placeholder=" jj/mm/yyyy"></asp:TextBox> et
          <asp:TextBox ID="TextBoxDate2" CssClass="txtDate" runat="server" placeholder=" jj/mm/yyyy"></asp:TextBox>
      </div>
        <div class="BranchCompagnie">
           Branch :  <asp:DropDownList ID="DropDownListBranch"  CssClass="dropdown drpcompbranch" runat="server">
               <asp:ListItem Value="Auto">Auto</asp:ListItem>
               <asp:ListItem Value="Hors_Auto">Hors_Auto</asp:ListItem>
               <asp:ListItem Value="Assistance">Assistance</asp:ListItem>
            </asp:DropDownList> 
           Compagnie :  <asp:DropDownList ID="DropDownListCompagnie" CssClass="dropdown drpcompbranch" runat="server">
               <asp:ListItem Value="SAHAM">SAHAM</asp:ListItem>
               <asp:ListItem Value="RMA">RMA</asp:ListItem>
               <asp:ListItem Value="AXA">AXA</asp:ListItem>
            </asp:DropDownList>
           <asp:Label runat="server" CssClass="allCheck">Tous :</asp:Label> <asp:CheckBox ID="CheckBoxTous" Checked="true" runat="server" />
        </div>
    <div id="RecherchZone" class="input-group mb-0 searchdv" >
        <asp:DropDownList ID="DropDownListRecherchEtat" runat="server" CssClass="DropSearch">
            <asp:ListItem Value="ID">ID</asp:ListItem>
            <asp:ListItem Value="NumAtt">Num Attestation</asp:ListItem>
            <asp:ListItem Value="NumPolice">Num Police</asp:ListItem>
            <asp:ListItem Value="NomPrenom">Nom et Prenom</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBoxRecherchEtat" CssClass="form-control txtSearch" runat="server"></asp:TextBox>
        <div class="input-group-append">
            <asp:Button ID="ButtonRecherchEtat" CssClass="btn-primary btnSearch " runat="server" Text="Rechercher" />
        </div>
    </div>
      
    </div>
     <div class="Grid">
     <asp:GridView ID="GridViewEtatPro" CssClass="GridView" runat="server">
        
     </asp:GridView>
    </div>


     <asp:Table runat="server" ID="tblEtat" CssClass="tableEtat">
         <asp:TableHeaderRow>
             <asp:TableHeaderCell><h2>Totale : </h2> </asp:TableHeaderCell>
             <asp:TableHeaderCell><h2> &nbsp<asp:Label ID="lblTot" runat="server"></asp:Label></h2></asp:TableHeaderCell>

         </asp:TableHeaderRow>
         <asp:TableRow>
         <asp:TableCell><h3>Chéque : </h3> </asp:TableCell>
             <asp:TableCell> <h3><asp:Label ID="lblcheque" runat="server"></asp:Label></h3></asp:TableCell>
         <asp:TableCell><h3>Espece : </h3> </asp:TableCell>
             <asp:TableCell> <h3> &nbsp<asp:Label ID="lblespece" runat="server"></asp:Label></h3></asp:TableCell>
             <asp:TableCell></asp:TableCell>
         </asp:TableRow>
     </asp:Table>
    
     
          
   </div>
</asp:Content>
