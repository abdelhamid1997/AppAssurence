<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AffectationPaiementClient.aspx.cs" Inherits="ApplicationAssurance.AffectationPaiementClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet" runat="server" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.5.1.min.js"></script>
    <title></title>
    <style>
        body{
            background-color:#e9eaed;
        }
        .form-group input[type=text] , input[type=datetime]{
           width:50%;
           padding:0.3rem;
           border:1px solid black;
           border-radius:3px;
           outline:none;
           margin-left:15rem;
           font-weight:500;
           border:0.2px solid grey; 

       }
        .form-group label{
           margin-right:2rem;
           margin-top:0.2rem;
           position:absolute;
           font-weight:500;
       }
        .drop{
           margin-left:15rem;
           border:1px solid black;
           border-radius:3px;
           padding:0.3rem;
           outline:none;
           transition:0.5s ease all;
           width:40%;
            border:0.2px solid grey; 
       }
        .radiobtn{
            margin:5rem;
            border:1px solid black;
           border-radius:3px;
           padding:0.3rem;
           outline:none;
           transition:0.5s ease all;
           width:40%;
            border:0.2px solid grey; 
        }
        .radiobtn:hover{
            background-color:#0c52f6;
            color:white;
        }
       .drop:hover{
          background-color:#0c52f6;
          color:white;
       }
        .dvEspece{
            margin:6rem auto;
            width:60%;
        }
        .modal-content{
         font-weight:500;
         box-shadow:7px 7px 15px gray;
        }
        .modal-body{
          
        }
        .modal-header{
            background-color:#0c52f6;
            color:white;
        }
        .modal-footer{
           
        }
        .Restlbl{
            position:relative;
            
        }
        .montantRest{
            position:relative;
        }
        .dvMontantAff{
            position:relative;
            left:75%;
            display:grid;
            grid-template-columns:1fr 1fr;
            width:30%;
            font-size:18px;
        }
        #MenuPaiement{
            font-weight:600;
            width:40%;
            margin:2rem auto;
            display:grid;
            grid-template-columns:1fr 1fr 1fr 1fr;
        }
        .BtnMenu{
            text-align:center;
            padding:0.5rem;
            border-radius:40px;
            width:80%;
            background-color:white;
            box-shadow:7px 7px 15px grey;
            cursor:pointer;
            border:none;
            outline:none;
            font-weight:600;
        }
        .dvChéque{
             margin:6rem auto;
             width:60%;
        }
        .dvVirement{
            margin:6rem auto;
             width:60%;
        }
        .dvAutre{
            margin:6rem auto;
            width:60%;
        }
        .btnV{
            font-weight:500;
            border:none;
            padding:0.5rem;
            border-radius:5px;
        }
        .alertS {
          position:fixed;
          padding: 20px;
          width:20%;
          background-color: #088f1f;
          color: white;
          z-index:1;
          top:0;
          left:80%;
          opacity:0;
          display:block;
         }
        .alterdvfail{
            display:none;
        }
        .AlertdvSucces{
            display:none;
        }
        .alert {
      position:fixed;
      padding: 20px;
      width:20%;
      background-color: #f44336;
      color: white;
      z-index:1;
      top:0;
      left:80%;
      opacity:0;
      display:block;
         }
      .Error{
          animation:ErrorShowHide 7s;
      }
      @keyframes ErrorShowHide{
          from{opacity:1;}
          to{opacity:0}
      }
      .GridViewReliquat {
         position:relative;
         background-color: #b3d7f1;     
         border: none;
         margin:auto;
       }

    .GridViewReliquat td {
        padding: 0.5rem 0.5rem;
        border: none;
        border-right: 2px solid #ffff;
        font-weight: bold;
    }

    .GridViewReliquat tr {
        border-right: 2px solid #207ec3;
    }

    .GridViewReliquat th {
        border: none;
        border-bottom: 2px solid #ffff;
        border-right: 2px solid #ffff;
        text-align: center;
        padding: 0.5rem 0.5rem;
        font-size: 15px;
        background-color: #4fadf1;
    }

    table.GridViewReliquat {
      border-radius: 5px;
      border-right: 3px solid transparent;
    }
   .dvGrid{
     position:relative;
     width:100%;
     margin:auto,
   }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div class="alert" id="alertdvfail" runat="server">
    <span class="closebtn"  onclick="this.parentElement.style.display='none';">&times;</span> 
    <strong>Danger!</strong> Merci de remplire tous les champs correctement
     </div>
        <%--------alertSucces--------%>
        <div class="alertS" id="AlertdvSucces" runat="server">
    <span class="closebtn"  onclick="this.parentElement.style.display='none';">&times;</span> 
    <strong>Succes!</strong> 
     </div>
            <div id="MenuPaiement">
                <asp:Button  ID="ButtonEspèce" CssClass="BtnMenu" runat="server" Text="Espèce" OnClick="ButtonEspèce_Click"/>
                <asp:Button  ID="ButtonChéque" CssClass="BtnMenu" runat="server" Text="Chéque" OnClick="ButtonChéque_Click"/>
                <asp:Button  ID="ButtonVirement" CssClass="BtnMenu" runat="server" Text="Virement" OnClick="ButtonVirement_Click" />
                <asp:Button  ID="ButtonAutre" CssClass="BtnMenu" runat="server" Text="Autre" OnClick="ButtonAutre_Click"/>
            </div>
          <div id="EspeceArea" class="dvEspece" runat="server">              
                <div class="modal-content">
                    <div class="modal-header">
                       <h5 style="position:absolute;">ESPECE</h5>
                        <div class="dvMontantAff">
                        <asp:Label CssClass="Restlbl" runat="server">Montant reste :</asp:Label>
                        <asp:Label  ID="RestEsp" CssClass="montantRest" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                          <label>Espèce :</label>
                          <asp:TextBox ID="TextBoxEspece" runat="server" Text="0" AutoPostBack="true" OnTextChanged="TextBoxEspece_TextChanged"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Date de Paiement :</label>
                            <asp:TextBox ID="TextBoxDatePaiementEspece" placeholder="jj/mm/yyyy" runat="server" TextMode="DateTime" AutoPostBack="true" OnTextChanged="TextBoxDatePaiementEspece_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnValiderEspèce" CssClass="btn-success btnV" Text="Valider" runat="server" OnClick="btnValiderEspèce_Click" />
                    </div>
                </div>
            
          </div>
          <div id="ChequeArea" class="dvChéque" runat="server">              
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 style="position:absolute;">CHÉQUE</h5>
                        <div class="dvMontantAff">
                        <asp:Label CssClass="Restlbl" runat="server">Montant reste :</asp:Label>
                        <asp:Label  ID="RestCheque" CssClass="montantRest" runat="server"></asp:Label>
                      </div>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                          <label>Montant Chéque :</label>
                          <asp:TextBox ID="TextBoxCheque" runat="server" AutoPostBack="true" OnTextChanged="TextBoxCheque_TextChanged"></asp:TextBox>
                        </div>
                        <div class="form-group">
                          <label>Numero de  Chéque :</label>
                          <asp:TextBox ID="TextBoxRef" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                          <label>La banque :</label>
                          <asp:DropDownList ID="dropBanque" CssClass="drop" runat="server">
                              <asp:ListItem Value="BMCE">BMCE</asp:ListItem>
                              <asp:ListItem Value="CIH">CIH</asp:ListItem>
                          </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Date de Remise :</label>
                            <asp:TextBox ID="TextBoxDateRemise" placeholder="jj/mm/yyyy" runat="server" TextMode="DateTime" AutoPostBack="true" OnTextChanged="TextBoxDateRemise_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnValiderChéque" runat="server" CssClass="btn-success btnV" Text="Valider" OnClick="btnValiderChéque_Click"/>
                    </div>
                </div>
            
          </div>
            <div id="VirementArea" class="dvVirement" runat="server">
                <div class="modal-content">
                    <div class="modal-header">
                         <h5 style="position:absolute;">VIREMENT</h5>
                        <div class="dvMontantAff">
                        <asp:Label CssClass="Restlbl" runat="server">Montant reste :</asp:Label>
                        <asp:Label  ID="RestVirement" CssClass="montantRest" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                        <label>Montant de virement :</label>
                        <asp:TextBox ID="textboxVirement" runat="server" AutoPostBack="true" OnTextChanged="textboxVirement_TextChanged"></asp:TextBox>
                        </div> 
                        <div class="form-group">
                            <label>Référence :</label>
                            <asp:TextBox ID="textboxRéfVirement" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Date de Virement :</label>
                            <asp:TextBox ID="textboxDateVirement" runat="server" AutoPostBack="true" TextMode="DateTime" OnTextChanged="textboxDateVirement_TextChanged"></asp:TextBox>
                        </div>
                        
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="ButtonValiderVirement" CssClass="btn-success btnV" Text="Valider" OnClick="ButtonValiderVirement_Click" runat="server" />
                    </div>
                </div>
            </div>

              <div id="AutreArea" class="dvAutre" runat="server">              
                <div class="modal-content">
                    <div class="modal-header">
                       <h5 style="position:absolute;">AUTRE</h5>
                        <div class="dvMontantAff">
                        <asp:Label CssClass="Restlbl" runat="server">Montant reste :</asp:Label>
                        <asp:Label  ID="RestAutre" CssClass="montantRest" runat="server"></asp:Label>
                     </div>
                </div>
                    <div class="modal-body">
                        <div class="form-group">
                          <label>Mode Paiement</label>
                          <asp:DropDownList ID="DropDownListModePaiement" AutoPostBack="true" CssClass="drop" runat="server" OnSelectedIndexChanged="DropDownListModePaiement_SelectedIndexChanged">
                              <asp:ListItem Value="PPR">PPR</asp:ListItem>
                              <asp:ListItem Value="PP">PP</asp:ListItem>
                              <asp:ListItem Value="Reliquat">Reliquat</asp:ListItem>                       
                          </asp:DropDownList>
                            <h6 style="position:relative;left:35%;font-size:18px;">
                            <label id="lblPPR" runat="server"></label>
                            </h6>
                        </div>
                        <div id="NonReliquat" runat="server">
                       
                        <div class="form-group">
                            <label>Date de Paiement:</label>
                            <asp:TextBox ID="TextBoxDatePaiementAutre" placeholder="jj/mm/yyyy" runat="server" TextMode="DateTime"></asp:TextBox>
                        </div>
                        
                       </div>
                        <div id="reliquatArea" class=".dvGrid" runat="server">
                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="#DCDCDC" />
                                <Columns>
                                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Select" ShowHeader="True" Text="Affecter" />
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#0c52f6" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#000065" />
                            </asp:GridView>
                            <div>
                                <asp:DropDownList ID="DropDownListBanqueReliquat" Visible="false" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="DropDownListBanqueReliquat_SelectedIndexChanged" >
                                    <asp:ListItem Value="BMCE">BMCE</asp:ListItem>
                                    <asp:ListItem Value="CIH">CIH</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <h6 style="position:relative;left:40%; font-size:18px;"><label id="ReliquatNonExist" runat="server"></label></h6>
                        </div>
                        </div>
                    <div class="modal-footer">
                         
                          <h5 id="lbl5" runat="server" style="position:absolute;left:5%">cliquer sur le button valider pour  affecter le montant perte</h5>
                       
                         <asp:Button ID="ButtonValiderAutre" runat="server" CssClass="btn-success btnV" Text="Valider" OnClick="ButtonValiderAutre_Click"/>
                       
                    </div>
                </div>
            
          </div>
            <asp:HyperLink ID="HyperLinkReturnPageRec" NavigateUrl="~/Recouvrementlient.aspx" runat="server">Retoure</asp:HyperLink>
        </div>
        
    </form>
</body>
</html>
