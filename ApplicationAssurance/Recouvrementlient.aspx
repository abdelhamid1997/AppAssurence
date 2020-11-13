<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Recouvrementlient.aspx.cs" Inherits="ApplicationAssurance.Recouvrementlient" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleEtatAvenant.css" rel="stylesheet" />
    <style>
        .main{
           position: relative;
           width:100%;
           height:100vh;
           color:#fff;
           background:linear-gradient(-45deg, #ee7752, #23d56a, #23a6d5, #23d5ab);
           background-size:400% 400%;
/*           animation:change 10s ease-in-out infinite;
*/        }
/*        @keyframes change
        {
            0%
            {
                background-position: 0 50%;
            }
            50%
            {
                background-position: 100% 50%;
            }
            100%
            {
                background-position: 0 50%;
            }

        }
*/        .dvHead {
            position: relative;
            width: 100%;
            padding-top: 1rem;
            padding-bottom: 0.5rem;
            margin-bottom: 2rem;
        }
        .entredate
        {
            margin-left:35%;
            margin-bottom: 1rem;
        }
        .recousearch
        {
            margin-left:30%;
        }
        .txtDate {
          margin-top: 0.5rem;
          height: 2rem;
          width: 20%;
          font-weight: 500;
                  }
        .DropSearch {
           font-weight: 500;
           justify-content: center;
           width: 13%;
           border:1px solid black;
           border-radius:3px;
           padding:0.3rem;
           outline:none;
           transition:0.5s ease all;
}
        .DropSearch:hover
        {
             background-color:#0c52f6;
          color:white;
        }
          .btnSearch{
              padding:0.3rem 0.3rem 0.3rem 0.3rem;
          
           font-weight:700;
           border-radius:5px 5px 5px 5px;
       }
          .searchtxt
          {
               margin-top: 0.5rem;
                height: 2rem;
               width: 20%;
             font-weight: 500;
            
          }
          .dvGrid
          {
              margin-top:4rem;
          }
        
          .GridViewAv 
          {
           position:absolute;
           background-color: #4fadf1;   
           border-bottom: 2px solid #ffff;

          }
              .GridViewAv th {
        border-bottom: 2px solid #ffff;
        border-right: 2px solid #ffff;
        text-align: center;
        padding: 0.5rem 0.5rem;
        font-size: 20px;
        background-color: #2635a9;
  
              }
              #GridView1 tr.moseover:hover
              {
                  background-color:#A1DCF2;
              }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
      <div class="dvHead">
  <div class="entredate">
    <asp:TextBox ID="date1" runat="server" TextMode="Date"  CssClass="txtDate "></asp:TextBox>
    <asp:TextBox ID="date2" runat="server" TextMode="Date"  CssClass="txtDate "></asp:TextBox>
      </div>
    <div class="recousearch">
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="DropSearch ">
        <asp:ListItem>Auto</asp:ListItem>
        <asp:ListItem>HorsAuto</asp:ListItem>
        <asp:ListItem>Assistance</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="DropSearch ">
        <asp:ListItem>Cin</asp:ListItem>
        <asp:ListItem>Nom</asp:ListItem>
        <asp:ListItem>Num Attestation</asp:ListItem>
    </asp:DropDownList>
        <asp:TextBox ID="recherchertxt" runat="server" CssClass="searchtxt"></asp:TextBox>
    <asp:Button ID="rechercherbtn" runat="server" Text="Rechercher"   CssClass="btn-primary btnSearch" OnClick="rechercherbtn_Click"/>
        </div>
          
        </div>

     <div class="dvGrid">
    <asp:GridView ID="GridView1" RowStyle-CssClass="moseover" ClientIDMode="Static" CssClass="GridViewAv" runat="server" AutoPostBack="true" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" AllowPaging="True" EnableSortingAndPagingCallbacks="True" PageSize="6"  >
      <%--  <Columns>
            <asp:HyperLinkField  DataNavigateUrlFields="id_affaire" DataNavigateUrlFormatString="~/AffectationRenouvellement.aspx?id_affaire={0}" DataTextField="id_affaire" HeaderText="Action" NavigateUrl="~/AffectationRenouvellement.aspx" Target="_blank"  >
            <ControlStyle BorderStyle="None" CssClass="action"  />
            <ItemStyle HorizontalAlign="Center" />
            </asp:HyperLinkField>
        </Columns>--%>
</asp:GridView>
        </div>
          </div>
</asp:Content>
