<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AffectationAnnulation.aspx.cs" Inherits="ApplicationAssurance.AffectationAnnulation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="Content/bootstrap.min.css" rel="stylesheet" runat="server" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.5.1.min.js"></script>
    <style type="text/css">
        body{
            padding:1rem;
            background-color:royalblue;
            
        }
        .btnV{
            padding:0.5rem;
            font-weight:500;
            border-radius:3px;
            border:none;
        }
        .Partition{
            display:grid;
            grid-template-columns:1fr 1fr;
        }
        .body1{
            width:100%;
            margin:auto;
        }
        .body{
        margin:auto;
        width:100%;
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
        
        .form-control{
           background-color:white;
           width:80%;
           height:auto;
           margin:0 auto 2rem auto; 
           border-radius:5px;
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
        .modal-body-montant
        {
          display:none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Partition">
            <div class="body">
                   <div class="form-control">
                   <div class="modal-content">
                       <div class="modal-header">
                           Annulation
                       </div>
                       <div class="modal-body">

                           <div class="form-group">
                           <label >Id Client</label>
                           <asp:TextBox ID="idclienttxt" runat="server"></asp:TextBox>
                           </div>
                           <div class="form-group">
                           <label>Compagnie</label>
                           <asp:TextBox ID="compagnietxt" runat="server"></asp:TextBox>
                           </div>
                           <div class="form-group">
                          <label>CIN ou RC</label>
                          <asp:TextBox ID="cintxt" runat="server"></asp:TextBox>
                      </div>     
                           <div class="form-group">
                          <label>Nom Prénom</label>
                          <asp:TextBox ID="nomtxt" runat="server"></asp:TextBox>
                      </div>     
                           <div class="form-group">
                         <label>Souscripteur</label>         
                          <asp:TextBox ID="soustxt" runat="server"></asp:TextBox>
                      </div>     
                           <div class="form-group">
                          <label>Type Affaire</label>
                             <asp:DropDownList ID="droptypeAff" runat="server" CssClass="drop">
                              <asp:ListItem>R</asp:ListItem>
                              <asp:ListItem>NR</asp:ListItem>
                               </asp:DropDownList>
                     </div>      
                           <div class="form-group">
                          <label>Affectation</label>
                          <asp:TextBox ID="Affectxt" runat="server"></asp:TextBox>
                           </div>    
                           <div class="form-group">
                          <label>Nature d'Operation</label>
                          <asp:TextBox ID="naturetxt" runat="server"></asp:TextBox>
                           </div>                                                
                           <div class="form-group">
                          <label>Date Operation</label> 
                          <asp:TextBox ID="dateopetxt" runat="server" TextMode="DateTime"></asp:TextBox>
                        </div>
                           <div class="form-group">
                          <label>Date Debut</label>
                          <asp:TextBox ID="datedebuttxt" runat="server" TextMode="DateTime"></asp:TextBox>
                           </div>
                           <div class="form-group">
                          <label>Date fin</label>
                          <asp:TextBox ID="datefintxt" runat="server" TextMode="DateTime"></asp:TextBox>
                           </div>
                           <div class="form-group">
                          <label>num Police</label>
                          <asp:TextBox ID="numpolicetxt" runat="server"></asp:TextBox>
                          </div>

                           <div class="form-group">
                         <label id="numattestlbl" runat="server">Num Attestation</label>
                        <asp:TextBox ID="numattestxt" runat="server" ></asp:TextBox>
                               </div>
                        <div class="form-group">
                        <label id="brancherdlbl" runat="server">BrancheRD</label>
                         <asp:DropDownList ID="dropbrancherd" runat="server" CssClass="drop">
                              <asp:ListItem>MRP</asp:ListItem>
                              <asp:ListItem>MRH</asp:ListItem>
                              <asp:ListItem>TRSP</asp:ListItem>
                           <asp:ListItem>AT</asp:ListItem>
                            <asp:ListItem>VIE</asp:ListItem>
                               </asp:DropDownList>
                            </div>
                        <div class="form-group">
                        <label id="typelbl" runat="server">Type Assistance</label>
                             <asp:DropDownList ID="droptypeAssistace" runat="server" CssClass="drop">
                              <asp:ListItem>ISAAF</asp:ListItem>
                              <asp:ListItem>VISA_EUROPE</asp:ListItem>
                              <asp:ListItem>VISA_MONDE</asp:ListItem>
                           <asp:ListItem>ETUDIANT</asp:ListItem>
                            
                               </asp:DropDownList>   
                          </div>                           
                      </div> 
                       <div class="modal-footer">

                       </div>
                  </div>
               </div>          
     </div>
        <div class="body1">
            <div class="form-control">
                <div class="modal-content">
                    <div class="modal-header">
                       Annulation
                    </div>
                    <div class="modal-body-montant">
                        <div class="form-group">
                        <label>Prime NET</label>
                        <asp:TextBox ID="primenettxt" runat="server" Text="0"></asp:TextBox>
                           </div>
                           <div class="form-group">
                        <label>TVA</label>
                        <asp:TextBox ID="tvatxt" runat="server" Text="0"></asp:TextBox>
                            </div>         
                           <div class="form-group">
                        <label>taxeEvrc</label>
                        <asp:TextBox ID="taxeevrctxt" runat="server" Text="0"></asp:TextBox>
                           </div>
                           <div class="form-group">
                        <label>TaxeEvga</label>
                        <asp:TextBox ID="taxeevga" runat="server" Text="0"></asp:TextBox>
                         
                           </div>
                           <div class="form-group">
                        <label>Accessoire</label>
                        <asp:TextBox ID="accessoiretxt" runat="server" Text="0"></asp:TextBox>
                           </div>
                          <div class="form-group">
                        <label>net a payez</label>
                        <asp:TextBox ID="netapayertxt" runat="server" Text="0"></asp:TextBox>
                           </div>
                           <div class="form-group">
                        <label>taxe1</label>
                        <asp:TextBox ID="taxe1txt" runat="server" Text="0"></asp:TextBox>
                           </div>
                             <div class="form-group">
                        <label>taxe1</label>
                        <asp:TextBox ID="taxe2txt" runat="server" Text="0"></asp:TextBox>
                           </div>
                         
                    </div>
                      <div class="form-group">
                        <label>Montant d'annulation</label>
                        <asp:TextBox ID="montanttxt" runat="server" Text="0"></asp:TextBox>
                           </div>
                    <div class="modal-footer">
             <asp:Button ID="ButtonEnregistrer" CssClass="btn-success btnV" runat="server" Text="Enregistrer" OnClick="ButtonEnregistrer_Click" />       
                    </div>
                </div>
            </div>
        </div>

        </div>
      
    </form>
</body>
</html>
