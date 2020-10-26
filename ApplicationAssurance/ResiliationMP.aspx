<%@ Page Title="" Language="C#" MasterPageFile="~/Avenant.Master" AutoEventWireup="true" CodeBehind="ResiliationMP.aspx.cs" Inherits="Avenent.ResiliationMP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleEtatAvenant.css" rel="stylesheet" />
            <style>

      .textbx{
         width:80%;
     }
     .lblTitle{
         margin-top:0.4rem;
         font-weight:500;
     }
     .dvHead{
         position:relative;
         width:100%;
         padding-top:1rem;
         padding-bottom:0.5rem;
         background-color:rgba(167, 167, 167, 0.25);
         margin-bottom:2rem;
     }
     .headp{
         position:relative;
         width:100%;
         padding:1rem;
         background-color:#5f9dea;
         width:50%;
         border-radius:5px;
         margin:2rem auto;
         display :grid;
         grid-template-columns:0.5fr 3fr 1fr;
         grid-column-gap:2rem;
     }
     .drop{
           border:1px solid black;
           border-radius:3px;
           padding:0.3rem;
           outline:none;
           transition:0.5s ease all;
           font-weight:500;
     }
       .drop:hover{
          background-color:#0c52f6;
          color:white;
       }
       .btnSearch{
           border:none;
           font-weight:500;
           border-radius:0px 5px 5px 0px;
       }
       .dvGrid{
           position:relative;
           margin-right:6%;
       }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="dvHead">
    <div class="headp">
    <asp:DropDownList ID="DropDownList1" 
        runat="server" CssClass="drop" AutoPostBack="true" 
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>Auto</asp:ListItem>
        <asp:ListItem>HorsAuto</asp:ListItem>
        <asp:ListItem>Assistance</asp:ListItem>
</asp:DropDownList>
 <div id="RecherchZone" class="input-group mb-0 searchdvRec" >    
<asp:TextBox ID="TextBox1" CssClass="form-control textbx" runat="server" ></asp:TextBox>
<asp:Button ID="Button1" CssClass="btn-primary btnSearch" runat="server" Text="Rechercher" OnClick="Button1_Click" />
 </div>
    <asp:Label ID="Label1" CssClass="lblTitle" runat="server" Text="Résiliation"></asp:Label>
   </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dvGrid">
    <asp:GridView ID="GridView1" CssClass="GridViewAv" runat="server" AllowPaging="True" EnableSortingAndPagingCallbacks="True" PageSize="6">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="id_affaire" DataNavigateUrlFormatString="~/AffectationResiliation1.aspx?id_affaire={0}" DataTextField="id_affaire" HeaderText="Action" NavigateUrl="~/AffectationResiliation1.aspx" Target="_blank" />
        </Columns>
</asp:GridView>
        </div>
</asp:Content>

