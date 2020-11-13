<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="etatRemis.aspx.cs" Inherits="ApplicationAssurance.etatRemis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
        .body{
            overflow-x:hidden;
        }
        .Date2{
            position:relative;
            left:40%;
            padding-top:15px;
        }
        .Date1 {
            position: relative;
            left: 37.5%;
            padding-top: 15px;
        }
        .styleTextB{
            background-color:aliceblue;
            outline:none;
            border-radius:15px;
            text-align:center;
        }
        .styleLabel{
            color:cadetblue;
            font-weight:bolder;
        }
        .btnRechercher{
            position:relative;
            left:44%;
            padding-top:15px;
        }
        .recherche_Btn{
            background-color:#0BF03A;
            color:white;
            font-weight:bolder;
            border-width:1px;
            border-color:white;
            transition-duration:0.5s;
            border-radius:5px;
        }
        .recherche_Btn:hover{
            background-color:white;
            color:#0BF03A;
            border-width:1px;
            border-color:#0BF03A;
        }
        .gridview{
            position:absolute;
            left:20%;
            top:40%;
            
        }
        .filtrage_statut{
            position:absolute;
            left:71.75%;
            top:36.75%;
        }
        .Total{
            position:absolute;
            left:57%;
            font-size:25px;
        }
        .styleLabTotal{
            
            color:#0BF03A;
        }
        .styleMontantTot{
            color:#126FC8;
            font-weight:bolder;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="body" runat="server">
        
        <h1>Etat de remise cheques</h1>
        <div class="Date1">
            <asp:Label ID="Label1" Cssclass="styleLabel" runat="server" Text="Date du"></asp:Label>
            <asp:TextBox ID="date1" CssClass="styleTextB"  runat="server"></asp:TextBox>
        </div>
        <div class="Date2">
            <asp:Label ID="Label2" Cssclass="styleLabel" runat="server" Text="Au"></asp:Label>
            <asp:TextBox ID="date2" CssClass="styleTextB" runat="server"></asp:TextBox>
            <label id="lbldate" runat="server"></label>
        </div>
        <div class="btnRechercher">
            <asp:Button ID="Recherche_Btn" CssClass="recherche_Btn" runat="server" Text="Rechercher" OnClick="Recherche_Btn_Click"/>
        </div>
         <div runat="server" id="filtrage_Stat" class="filtrage_statut">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>à remettre</asp:ListItem>
                <asp:ListItem>A remplacer</asp:ListItem>
                <asp:ListItem>Remis</asp:ListItem>
                <asp:ListItem>Rejeter</asp:ListItem>
             </asp:DropDownList>
        </div>
    <div class="gridview">
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:HyperLinkField HeaderText="modification" NavigateUrl="~/modification_cheque.aspx" Text="modifier ici" DataNavigateUrlFields="id_paiment" DataNavigateUrlFormatString="~/modification_cheque.aspx?id_paiment={0}" DataTextField="id_paiment" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <div id="total" class="Total" runat="server">
            <asp:Label ID="labelTotal" CssClass="styleLabTotal" runat="server" Text="Total:"></asp:Label>
            <asp:Label ID="montantTotal_Lab" CssClass="styleMontantTot" runat="server"></asp:Label>
        </div>
    </div>
    </div>
   
</asp:Content>
