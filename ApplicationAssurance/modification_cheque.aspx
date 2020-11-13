<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modification_cheque.aspx.cs" Inherits="ApplicationAssurance.modification_cheque" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body{
            background-color:aliceblue;
            overflow-x:hidden;
        }
        .body{
           padding-top:40px;
           padding-bottom:20px;
           background-color:white;
           border-radius:15px;
           box-shadow:1px 1px 10px gray;
           margin-left:15%;
           margin-right:15%;
        }
        .body div{
            position:relative;
            padding-top:15px;
            padding-bottom:30px;
            top: 0px;
        }
        h1{
          text-align:center;
          color:#1CE036;
          font-size:40px;
        }
        #Nom_Prenom_Lab,#IdAffaire_Lab,#GSM_Lab,#Montant_cheque_Lab,#Banque_Lab,#Date_remise,#Statut_Lab,#statutFuture_Lab{
            position:absolute;
            left:30%;
            color:#1F8DA1 ;
        }
        lab1,lab2,lab3,lab4,lab5,lab6,lab7,lab8,lab9{
            position:absolute;
            left:0%;
        }
        .d1,.d2,.d3,.d4,.d5,.d6,.d7,.d8,.d9{
            position:relative;
            left:300px;
            font-weight:bold;
            font-family:Arial;
            font-size:20px;
        }
        .group_Buttons{
            position:absolute;left:0%;
            text-align:center;
            padding-top:10px;
            width:100%;
        }
        #btn1,#btn2,#btn3,#btn4,#btn5{
            
            background-color:white;
            margin-left:10px;
            height:50px;
            width:150px;
            color:deepskyblue;
            font-weight:bold;
            border-radius:15px;
            transition-duration:0.5s;
            border-width:2px ;
            border-color:deepskyblue;
            font-size:17px;
        }
        #table1{
            position:absolute;
            left:10%;
            width:80%;
            top: 15px;
        }
        #btn1:hover,#btn2:hover,#btn3:hover,#btn4:hover{
            background-color:deepskyblue;
            color:white;
            border-color:white;
        }
        #btn5:hover{
            background-color:#1CE036;
            color:white;
            border-color:white;
        }
        #TextBox_Style{
            background-color:aliceblue;
            outline:none;
            border-radius:15px;
            text-align:center;
        }
        .btn_Retour_style{
            position:absolute;
           background-color:white;
            margin-left:10px;
            height:50px;
            width:150px;
            color:deepskyblue;
            font-weight:bold;
            border-radius:15px;
            transition-duration:0.5s;
            border-width:2px ;
            border-color:deepskyblue;
            font-size:17px; 
        }
        .btn_Retour_style:hover{
            background-color:#1CE036;
            color:white;
            border-color:white;
        }
    </style>
</head>
<body runat="server">
   
    <form id="form1" runat="server">
        <h1><asp:Label ID="numchequeLAB" runat="server" Text="Label"></asp:Label></h1>
        <asp:Button ID="btn_Retour" CssClass="btn_Retour_style" runat="server" Text="Retour" OnClick="btn_Retour_Click"/>
        <div runat="server" class="body">
            <div class="d1">
                <asp:Label ID="lab1" runat="server" Text="Nom Complet:"></asp:Label>
                <asp:Label ID="Nom_Prenom_Lab" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="d2">
                <asp:Label ID="lab2" runat="server" Text="Id Affaire:"></asp:Label>
                <asp:Label ID="IdAffaire_Lab" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="d3">
                <asp:Label ID="lab3" runat="server" Text="Gsm:"></asp:Label>
                <asp:Label ID="GSM_Lab" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="d4">
                <asp:Label ID="lab4" runat="server" Text="Montant cheque:"></asp:Label>
                <asp:Label ID="Montant_cheque_Lab" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="d5">
                <asp:Label ID="lab5" runat="server" Text="La Banque:"></asp:Label>
                <asp:Label ID="Banque_Lab" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="d6">
                <asp:Label ID="lab6" runat="server" Text="La Date de remise actuel:"></asp:Label>
                <asp:Label ID="Date_remise" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="d7">
                <asp:Label ID="lab7" runat="server" Text="Le statut:"></asp:Label>
                <asp:Label ID="Statut_Lab" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="d8">
                <asp:Label ID="lab8" runat="server" Text="Le statut future"></asp:Label>
                <asp:Label ID="statutFuture_Lab" runat="server" Text=""></asp:Label>
            </div>
            <div runat="server" class="d9" >
                <asp:Label ID="lab9" runat="server" Text="la date de remise future:"></asp:Label>
                <asp:TextBox ID="TextBox_dateR" CssClass="TextBox_Style" runat="server"></asp:TextBox>
            </div>
        <div class="group_Buttons" runat="server">
            <asp:Table runat="server" ID="table1">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <div class="d8btn" runat="server">
                            <asp:Button ID="btn1" runat="server" Text="A remettre" OnClick="btn1_click" />
                        </div>
                    </asp:TableCell>
                    <asp:TableCell>
                        <div class="d9btn">
                            <asp:Button ID="btn2" runat="server" Text="A remplacer"  />
                        </div>
                    </asp:TableCell>
                    <asp:TableCell>
                        <div class="d10btn">
                            <asp:Button ID="btn3" runat="server" Text="Remis" OnClick="btn3_click"/>
                        </div>
                    </asp:TableCell>
                    <asp:TableCell>
                        <div class="d11btn">
                            <asp:Button ID="btn4" runat="server" Text="Rejeter" OnClick="btn4_click" />

                        </div>
                    </asp:TableCell>
                    <asp:TableCell>
                        <div class="d12btn">
                            <asp:Button ID="btn5" runat="server" OnClick="btn5_click" Text="Valider" />
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            </div>
            </div>
    </form>
</body>
</html>
