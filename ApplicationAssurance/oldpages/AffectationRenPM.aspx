<%@ Page Title="" Language="C#" MasterPageFile="~/Avenant.Master" AutoEventWireup="true" CodeBehind="AffectationRenPM.aspx.cs" Inherits="Avenent.AffectationRenPM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .body{
        width:100%;
        padding:2rem;
    }
        
        .form-control{
           background-color:white;
           width:80%;
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
           color:red;
            
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
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Renouvellement"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    
               <div class="body">
                   <div class="form-control">
                   <div class="modal-content">
                       <div class="modal-header">
                           TEXT
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
                         <label>soustraction</label>         
                          <asp:TextBox ID="soustxt" runat="server"></asp:TextBox>
                      </div>     
                           <div class="form-group">
                          <label>type Affaire</label>
                          <asp:TextBox ID="typeAff" runat="server"></asp:TextBox>
                     </div>      
                           <div class="form-group">
                          <label>Affectation</label>
                          <asp:TextBox ID="Affectxt" runat="server"></asp:TextBox>
                           </div>    
                           <div class="form-group">
                          <label>Nature Affaire</label>
                          <asp:TextBox ID="naturetxt" runat="server"></asp:TextBox>
                           </div>          
                           <div class="form-group">
                          <label>Type Affaire</label>
                          <asp:TextBox ID="typeAfftxt" runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="numattestxt" runat="server" OnTextChanged="TextBox13_TextChanged"></asp:TextBox>
                               </div>
                        <div class="form-group">
                        <label id="brancherdlbl" runat="server">BrancheRD</label>
                        <asp:TextBox ID="brancherdtxt" runat="server"></asp:TextBox>
                            </div>
                        <div class="form-group">
                        <label id="typelbl" runat="server">Type Assistance</label>
                        <asp:TextBox ID="typeassitxt" runat="server"></asp:TextBox>
                           
                           </div>
                           <div class="form-group">
                        <label>Prime NET</label>
                        <asp:TextBox ID="primenettxt" runat="server"></asp:TextBox>
                           </div>
                           <div class="form-group">
                        <label>TVA</label>
                        <asp:TextBox ID="tvatxt" runat="server"></asp:TextBox>
                            </div>         
                           <div class="form-group">
                        <label>taxeEvrc</label>
                        <asp:TextBox ID="taxeevrctxt" runat="server"></asp:TextBox>
                           </div>
                           <div class="form-group">
                        <label>TaxeEvga</label>
                        <asp:TextBox ID="taxeevga" runat="server"></asp:TextBox>
                         
                           </div>
                           <div class="form-group">
                        <label>Accessoire</label>
                        <asp:TextBox ID="accessoiretxt" runat="server"></asp:TextBox>
                           </div>
                          <div class="form-group">
                        <label>net a payez</label>
                        <asp:TextBox ID="netapayertxt" runat="server"></asp:TextBox>
                           </div>
                           <div class="form-group">
                        <label>taxe1</label>
                        <asp:TextBox ID="taxe1txt" runat="server"></asp:TextBox>
                           </div>
                           <div class="form-group">
                        <label>montant</label>
                        <asp:TextBox ID="montanttxt" runat="server"></asp:TextBox>
                           </div>
                      </div> 
                       <div class="modal-footer">

                       </div>
                  </div>
               </div>
               
                
     </div>
    <div style="text-align:center">
    <asp:Button ID="Button1" runat="server" Text="Enregistrer" Width="256px" Height="31px" OnClick="Button1_Click"  />
        </div>
</asp:Content>
