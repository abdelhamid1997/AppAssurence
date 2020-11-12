<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="EtatPayClient.aspx.cs" Inherits="ApplicationAssurance.EtatPayClient"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleEtatAvenant.css" rel="stylesheet" />
        <style>
        .main{
           position: relative;
           width:100%;
           height:100vh;
           color:#fff;
           background:linear-gradient(-45deg, #ee7752, #eed952, #b5b4ae, #b5b08f); 
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
        .detail
        {
            
            margin-top:15%;
            margin-left:25%;
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
            
              .table1
              {
                 
                   border-collapse: collapse;
                   margin: 25px 0;
                   min-width: 500px;
                   border-radius: 5px 5px 0 0;
                   overflow: hidden;
                   box-shadow: 0 0 40px rgba(0, 0, 0, 0.15);
                   padding:2.5rem;
                   font-size:1.2rem;
              }
             
              
              
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <div class="main">

    <div class="dvHead">
  <div class="entredate">
    <asp:TextBox ID="date1" runat="server" TextMode="Date"  CssClass="txtDate "></asp:TextBox>
    <asp:TextBox ID="date2" runat="server" TextMode="Date"  CssClass="txtDate " OnTextChanged="date2_TextChanged"></asp:TextBox>
      </div>
    <div class="recousearch">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" CssClass="DropSearch " OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>Auto</asp:ListItem>
        <asp:ListItem>HorsAuto</asp:ListItem>
        <asp:ListItem>Assistance</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" CssClass="DropSearch " OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" >
      
        <asp:ListItem>Compagnie</asp:ListItem>
      
    </asp:DropDownList>
        <asp:TextBox ID="recherchertxt" runat="server" CssClass="searchtxt"></asp:TextBox>
    <asp:Button ID="rechercherbtn" runat="server" Text="Rechercher"   CssClass="btn-primary btnSearch" OnClick="rechercherbtn_Click"/>
        </div>
         
        </div>
     <div class="dvGrid">
         <asp:GridView ID="GridView1"  ClientIDMode="Static" CssClass="GridViewAv"  runat="server" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True" AllowPaging="True"  OnDataBound="GridView1_DataBound" PageSize="6" OnPageIndexChanging="GridView1_PageIndexChanging">
             <FooterStyle BackColor="#3333CC" Font-Bold="True" Font-Size="Medium" ForeColor="White" />

         </asp:GridView>
         
     </div>
            
</div>
</asp:Content>

