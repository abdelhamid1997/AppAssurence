<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="SaisieAff.aspx.cs" Inherits="ApplicationAssurance.SaisieAff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="Content/bootstrap.min.css" rel="stylesheet" runat="server" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.5.1.min.js"></script>
   <style>

       .body{
           padding:2rem;
       }
       
       body{                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
           background-color:#cbdef8;
           align-content:center;
       }
       .header{
           position:absolute;           
       }
       .header h1 {
            font-size:100px;
            opacity:0.5;
       }
       
       .form-control{
           background-color:white;
           width:70%;
           height:auto;
           margin:0 auto 2rem auto; 
           border-radius:3px;
           box-shadow:5px 5px 10px #808080;
           
       }
        
       .modal-content{
        border:none;
       }
       .form-group label{
           margin-right:2rem;
           margin-top:0.2rem;
           position:absolute;
           font-weight:500;
       }
       .form-group input[type=text] , input[type=datetime]{
           width:50%;
           padding:0.3rem;
           border:1px solid black;
           border-radius:3px;
           outline:none;
           margin-left:15rem;
           font-weight:500;

       }
       input[type=checkbox]{
           margin-left:15rem;
           height:2rem;
       }
       .form-group input[type=text]:focus{
          border:2px solid #0c52f6;
           
       }
       .drop{
           margin-left:15rem;
           border:1px solid black;
           border-radius:3px;
           padding:0.3rem;
           outline:none;
           transition:0.5s ease all;
           width:40%;
       }
       .drop:hover{
          background-color:#0c52f6;
          color:white;
       }
       .dropSearch{
           outline:none;
           font-weight:500;
           transition:0.5s ease-in-out;
           width:10%;
       }
       .dropSearch:hover{
           background-color:#0c52f6;
           color:white;
          
       }
       .btn-success{
           border:none;
           padding:0.3rem 1rem;
           border-radius:3px;
       }
       .search{
           box-shadow:none;
           width:40%;
           outline:none;
       }
       .btnRech{
           border-radius:3px;
           font-weight:500;
           transition:0.5s ease all;
       }
       .dv-taxeAuto{
           width:40%;
           margin:auto;
           background-color:white;
           border-radius:10px;
       }
      .table{
           border-collapse: collapse;
           border-radius: 0.2em;
           overflow: hidden;
           box-shadow:6px 6px 15px #808080;
           font-weight:500;
      }
      .table input[type=text]{
          width:90%;
          border:none;
          outline:none;
      }
      .validAff{
          position:absolute;
          top:92%;
          padding:1rem 2rem;
          font-weight:500;
      }
      .dv-search{
          position:relative;
          width:60%;
          margin-left:auto;
      }
      .ERRlbl{
          font-weight:500;
          font-size:20px;
          margin:1.2rem 0 0 12rem;
          color:red;
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
          animation:ErrorShowHide 5s;
      }
      @keyframes ErrorShowHide{
          from{opacity:1;}
          to{opacity:0}
      }
      
      .closebtn 
      {
             margin-left: 15px;
             color: white;
             font-weight: bold;
             float: right;
             font-size: 22px;
             line-height: 20px;
             cursor: pointer;
             transition: 0.3s;
      }

        .closebtn:hover 
        {
             color: black;
        }
        .btnvalider{

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
        .none{            
            display:none;
        }
        
        .rightShow{
            margin-left:0.2rem;
            width:30px;
            height:30px;
            display:inline;
        }
        .wrongShow{
            margin-left:0.2rem;
            width:25px;
            height:25px;
            display:inline;
        }

       
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="body">
        
      <div class="header">
      <%------alertfail------%>
      </div>      
        <div class="alert" id="alertdvfail" runat="server">
    <span class="closebtn"  onclick="this.parentElement.style.display='none';">&times;</span> 
    <strong>Danger!</strong> Merci de remplire tous les champs correctement
     </div>
        <%--------alertSucces--------%>
        <div class="alertS" id="AlertdvSucces" runat="server">
    <span class="closebtn"  onclick="this.parentElement.style.display='none';">&times;</span> 
    <strong>Succes!</strong> 
     </div>
        <%------------alertFailMoney-------------%>
        <%--<div class="alert" id="AlertfailMoney" runat="server">
    <span class="closebtn"  onclick="this.parentElement.style.display='none';">&times;</span> 
    <strong>Danger!</strong>Entrez le montant de cette affaire s'ils vous plait
     </div>--%>
            <div class=" form-control">
                
                <div class="modal-content">
                    <div class="modal-header">
                         <h3>SAISIE CLIENT</h3>
                       <label class="ERRlbl" id="ErrorSearch" runat ="server"></label>
                        <div class=" bg-transparent text-dark p-3 dv-search">
                    <div class="input-group mb-0">                                              
                        <asp:DropDownList ID="DropDownListRecherchPar" CssClass="dropSearch" runat="server">
                            <asp:ListItem>ID</asp:ListItem>
                            <asp:ListItem>CIN</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="TextBoxRecherch" CssClass="form-control search" placeholder="Rechercher"  runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:Button ID="ButtonRecherchBTN" CssClass="btn-outline-primary btnRech" runat="server" Text="Rechercher" OnClick="ButtonRecherchBTNAuto_Click"  />
                        </div>
                    </div>
                </div>
                    </div>

                    <div class="modal-body">

                        <div class="form-group">
                            <label>ID-Client :</label>
                            <asp:TextBox ID="TextBoxId" runat="server"></asp:TextBox>
                        </div>
                         <div class="form-group">
                             <label>CIN Client :</label>
                             <asp:TextBox ID="TextBoxCIN" runat="server"></asp:TextBox>
                        </div>

                         <div class="form-group">
                              <label>Nom ou Rasion social :</label>
                             <asp:TextBox ID="TextBoxNomRS" runat="server"></asp:TextBox>
                        </div>
                         <div class="form-group">
                              <label>Prenom ou Form juridique :</label>
                             <asp:TextBox ID="TextBoxPrenomFJ" runat="server"></asp:TextBox>
                        </div>
                         <div class="form-group">
                              <label>GSM :</label>
                             <asp:TextBox ID="TextBoxGSM" runat="server" placeholder="+212/ 06 00 00 00 00 " AutoPostBack="true" OnTextChanged="TextBoxGSM_TextChanged"></asp:TextBox><img runat="server" id="GsmRight" class="none" src="img/RightIcon.png" /><img runat="server" id="GsmWrong" class="none" src="img/WrongIcon.png" />
                        </div>
                         <div class="form-group">
                             <label>Date Naissance:</label>
                             <asp:TextBox ID="TextBoxDateN" runat="server" placeholder="jj/mm/yyyy " TextMode="DateTime"></asp:TextBox>
                        </div>
                         <div class="form-group">
                             <label>Email :</label>
                             <asp:TextBox ID="TextBoxEmail" runat="server" AutoPostBack="true" OnTextChanged="TextBoxEmail_TextChanged"></asp:TextBox><img runat="server" id="EmailRight" class="none" src="img/RightIcon.png" /><img runat="server" id="EmailWrong" class="none" src="img/WrongIcon.png" />
                        </div>
                         <div class="form-group">
                             <label>Ville:</label>
                             <asp:TextBox ID="TextBoxVille" runat="server"></asp:TextBox>
                        </div>
                         <div class="form-group">
                             <label>Adress :</label>
                             <asp:TextBox ID="TextBoxAdress" runat="server"></asp:TextBox>
                        </div>
                         
                        <div class="form-group">
                             <label>Activiter :</label>
                            <asp:DropDownList ID="DropDownListActivite" CssClass="drop" runat="server">
                                <asp:ListItem>Professeur</asp:ListItem>
                                <asp:ListItem>Docteur</asp:ListItem>
                                <asp:ListItem>Formateur</asp:ListItem>
                             </asp:DropDownList>
                        </div>
                        <div class="form-group">
                             <label>Profile :</label>
                            <asp:DropDownList ID="DropDownListProfil" CssClass="drop" runat="server">
                                <asp:ListItem>Parrain</asp:ListItem>
                                <asp:ListItem>Demarcheur</asp:ListItem>
                                <asp:ListItem>VIP</asp:ListItem>
                                <asp:ListItem>Ordinaire</asp:ListItem>
                                <asp:ListItem>Complexe</asp:ListItem>
                             </asp:DropDownList>
                        </div>
                        <div class="form-group">
                             <label>Type de person :</label>
                            <asp:DropDownList ID="DropDownListTypePerson" CssClass="drop" runat="server">
                                <asp:ListItem>PP</asp:ListItem>
                                <asp:ListItem>PM</asp:ListItem>
                             </asp:DropDownList>
                        </div> 
                        <div class="form-group">
                            <label class="condlbl">le client est le conducteur :</label>
                             <asp:CheckBox ID="checkboxConducteur" AutoPostBack="true" Checked="true" runat="server" OnCheckedChanged="checkboxConducteur_CheckedChanged"  />
                        </div>
                        <div id="ConducteurArea" runat="server">
                            <div class="form-group">
                             <label>Nom Conducteur :</label>
                             <asp:TextBox ID="TextBoxNomConduct" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                             <label>Prenom Conducteur :</label>
                             <asp:TextBox ID="TextBoxPrenomConduct" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         <div class=" form-control">
                <div class="modal-content">
                    <div class="modal-header">
                         <h3>SAISIE AFFAIRE</h3>
                        <asp:DropDownList ID="DropDownListChoix" CssClass="drop" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListChoix_SelectedIndexChanged">
                            <asp:ListItem Value="Auto">Auto</asp:ListItem>
                            <asp:ListItem Value="Hors_Auto">Hors_Auto</asp:ListItem>
                            <asp:ListItem Value ="Assistance">Assistance</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="modal-body">
                         <div id="AutoArea" runat="server">

                        <div class="form-group">
                            <label>Numero Attestation :</label>
                            <asp:TextBox ID="TextBoxNumAtt" runat="server"></asp:TextBox>
                        </div>         
                             <div class="form-group">
                              <label>Num Permis :</label>
                             <asp:TextBox ID="TextBoxNumP" placeholder="Du Conducteur" runat="server" AutoPostBack="true" OnTextChanged="TextBoxNumP_TextChanged"></asp:TextBox><img runat="server" id="PermisRight" class="none" src="img/RightIcon.png" /><img runat="server" id="PermisWrong" class="none" src="img/WrongIcon.png" />
                        </div>
                        <div class="form-group">
                             <label>Flotte:</label>
                             <asp:DropDownList ID="DropDownListFlotte" CssClass="drop" runat="server">
                                 <asp:ListItem>NON</asp:ListItem>
                                 <asp:ListItem>OUI</asp:ListItem>            
                             </asp:DropDownList>
                        </div>
                         </div>
                        <div id="HorsAutoArea" runat="server">
                            <div class="form-group">
                             <label>BrancheRD:</label>
                             <asp:DropDownList ID="DropDownListBranchRD" CssClass="drop" runat="server">
                                 <asp:ListItem>MRH</asp:ListItem>
                                 <asp:ListItem>MRP</asp:ListItem>
                                 <asp:ListItem>TRSP</asp:ListItem>
                                 <asp:ListItem>AT</asp:ListItem>
                                 <asp:ListItem>VIE</asp:ListItem>
                             </asp:DropDownList>
                        </div>
                        </div>
                        <div id="AssistanceArea" runat="server">
                            <div class="form-group">
                             <label>TypeAssistance:</label>
                             <asp:DropDownList ID="DropDownListTypeAssistance" CssClass="drop" runat="server">
                                 <asp:ListItem>ISAAF</asp:ListItem>
                                 <asp:ListItem>VISA_EUROPE</asp:ListItem>
                                 <asp:ListItem>VISA_MONDE</asp:ListItem>
                                 <asp:ListItem>ETUDIANT</asp:ListItem>                            
                             </asp:DropDownList>
                        </div>
                        </div>
                         <div class="form-group">
                             <label>Nom de Compangie:</label>
                             <asp:DropDownList ID="DropDownListNomCompanie" CssClass="drop" runat="server">
                                 <asp:ListItem>SAHAM</asp:ListItem>
                                 <asp:ListItem>AXA</asp:ListItem>
                                  <asp:ListItem>RMA</asp:ListItem>
                             </asp:DropDownList>
                        </div>
                         <div class="form-group">
                             <label>Type de Contrat :</label>
                             <asp:DropDownList ID="DropDownListTypeContrat" CssClass="drop" runat="server">
                                 <asp:ListItem>R</asp:ListItem>
                                 <asp:ListItem>NR</asp:ListItem>
                             </asp:DropDownList>
                        </div>                        
                         <div class="form-group">
                              <label>Numero de Police :</label>
                             <asp:TextBox ID="TextBoxNumPolice" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                             <label>Date d'Operation :</label>
                             <asp:TextBox ID="TextBoxDateOperation" placeholder="jj/mm/yyyy" runat="server" TextMode="DateTime"></asp:TextBox>
                        </div>
                         <div class="form-group">
                             <label>Date de début :</label>
                             <asp:TextBox ID="TextBoxDateDebut" placeholder="jj/mm/yyyy" runat="server" TextMode="DateTime"></asp:TextBox>
                        </div>
                         <div class="form-group">
                             <label>Date de fin :</label>
                             <asp:TextBox ID="TextBoxDateFin" placeholder="jj/mm/yyyy" runat="server" TextMode="DateTime"></asp:TextBox>
                        </div>
                        <div class="form-group">
                              <label>Le souscripteur :</label>
                             <asp:TextBox ID="TextBoxSouscripteur" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
    <%--         -----------------------VEHICULE-----------------%>
      <div id="VehiculeArea" class=" form-control" runat="server">
        <div class="modal-content">
                    <div class="modal-header">
                         <h3>VEHICULE</h3>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label>Immatriculation :</label>
                            <asp:TextBox ID="TextBoxImmatriculation" runat="server" AutoPostBack="true" OnTextChanged="TextBoxImmatriculation_TextChanged"></asp:TextBox><img runat="server" id="ImmaRight" class="none" src="img/RightIcon.png" /><img runat="server" id="ImmaWrong" class="none" src="img/WrongIcon.png" />
                        </div>

                         <div class="form-group">
                            <label>Marque :</label>
                            <asp:TextBox ID="TextBoxMarque" runat="server"></asp:TextBox>
                        </div>

                         <div class="form-group">
                              <label>Usage:</label>
                             <asp:DropDownList ID="DropDownListUsage" CssClass="drop" runat="server">
                                 <asp:ListItem>AUTO</asp:ListItem>
                                 <asp:ListItem>CYCLO</asp:ListItem>
                                 <asp:ListItem>COMMERCE</asp:ListItem>
                                 <asp:ListItem>DIVERS</asp:ListItem>
                                 <asp:ListItem>PROVISOIRE</asp:ListItem>
                                 <asp:ListItem>CARTE VERTE</asp:ListItem>
                              </asp:DropDownList>
                        </div>

                         <div class="form-group">
                            <label>Date MEC :</label>
                            <asp:TextBox ID="TextBoxDateMec" placeholder="jj/mm/yyyy" runat="server"></asp:TextBox>
                        </div>
                   
                    </div>
                </div>
            </div>
        </div>

       <%-- -------------------TaxeArea-----------------------%>
        <div class="dv-taxeAuto">
        <asp:Table ID="TableTaxeAuto" CssClass="table table-bordered" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ColumnSpan="2" CssClass="text-center"><h3>de prime à payer en Dirhams</h3><p>Du ...... au</p></asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>Net à payer  </asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBoxNetApayer" runat="server" AutoPostBack="true" Text="0" ></asp:TextBox> </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Prime nette</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBoxPrimeNette" runat="server" AutoPostBack="true" Text="0" OnTextChanged="TextBoxPrimeNette_TextChanged" ></asp:TextBox> </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>TVA</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBoxTVA" runat="server" AutoPostBack="true" Text="0"  OnTextChanged="TextBoxTVA_TextChanged"></asp:TextBox> </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>TaxeEvGa</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBoxEvGa" runat="server" AutoPostBack="true" Text="0" OnTextChanged="TextBoxEvGa_TextChanged" ></asp:TextBox> </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Taxe EvRC</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBoxEvRc" runat="server" AutoPostBack="true" Text="0" OnTextChanged="TextBoxEvRc_TextChanged"></asp:TextBox> </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Accessoire</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBoxAccessoire" runat="server" AutoPostBack="true" Text="0" OnTextChanged="TextBoxAccessoire_TextChanged" ></asp:TextBox> </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Taxe1</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBoxTAXE1" runat="server" AutoPostBack="true" Text="0" OnTextChanged="TextBoxTAXE1_TextChanged" ></asp:TextBox> </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Taxe2</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBoxTAXE2" runat="server" AutoPostBack="true" Text="0" OnTextChanged="TextBoxTAXE2_TextChanged" ></asp:TextBox> </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>Montant</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="TextBoxMontant" Enabled="false" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableFooterRow>
                <asp:TableCell ColumnSpan="2">TEXT</asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
        </div>
       <asp:Button ID="btnValider" CssClass=" btn-success btnvalider" Text="Valider" runat="server" OnClick="btnValider_Click"/>
</asp:Content>
