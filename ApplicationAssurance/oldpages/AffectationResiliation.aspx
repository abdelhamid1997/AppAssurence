<%@ Page Title="" Language="C#" MasterPageFile="~/Avenant.Master" AutoEventWireup="true" CodeBehind="AffectationResiliation.aspx.cs" Inherits="Avenent.AffectationResiliation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Résiliation"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div  style="margin-bottom:2rem ; text-align:center;" >
    <table border="1" class="auto-style1" >
           <tr>
            <td class="auto-style3">
                <asp:Label ID="Label3" runat="server" Text="Id Client"></asp:Label>

            </td>
            <td class="auto-style4"> 
                <asp:TextBox ID="idclienttxt" runat="server"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td class="auto-style3">
                <asp:Label ID="Label4" runat="server" Text="Compagnie"></asp:Label>

            </td>
            <td class="auto-style4"> 
                <asp:TextBox ID="compagnietxt" runat="server"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td class="auto-style2">
                <asp:Label ID="Label5" runat="server" Text="CIN ou RC"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="cintxt" runat="server"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td class="auto-style2">
                <asp:Label ID="Label6" runat="server" Text="Nom Prénom"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="nomtxt" runat="server"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td class="auto-style2">
                <asp:Label ID="Label7" runat="server" Text="Souscrpteure"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="soustxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label24" runat="server" Text="Type Affaire"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="typeAff" runat="server"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td class="auto-style2">
                <asp:Label ID="Label8" runat="server" Text="Affectation"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="Affectxt" runat="server"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td class="auto-style2">
                <asp:Label ID="Label9" runat="server" Text="Nature Opération"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="naturetxt" runat="server"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td class="auto-style2">
                <asp:Label ID="Label10" runat="server" Text="Date Operation"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="dateopetxt" runat="server"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td class="auto-style2">
                <asp:Label ID="Label11" runat="server" Text="Date debut "></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="datedebuttxt" runat="server"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td class="auto-style2">
                <asp:Label ID="Label12" runat="server" Text="Date Fin"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="datefintxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label13" runat="server" Text="Num Police"></asp:Label>

            </td>
            <td class="auto-style4"> 
                <asp:TextBox ID="numpolicetxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        
         <tr >
            
            <td class="auto-style2">
                <asp:Label ID="Label14" runat="server" Text="Num Attestation"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="BrancheRD"></asp:Label>
                  <asp:Label ID="Label23" runat="server" Text="Type Assitance"></asp:Label>
                
            </td>
            <td> 
                <asp:TextBox ID="numattestxt" runat="server" ></asp:TextBox>
                  <asp:TextBox ID="brancherdtxt" runat="server"></asp:TextBox>
                <asp:TextBox ID="typeassitxt" runat="server"></asp:TextBox>
            </td>
               
        </tr>
       
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label15" runat="server" Text="montant"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="montanttxt" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label16" runat="server" Text="Prime Nette"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="primenettxt" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label17" runat="server" Text="Taxe TVA"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="tvatxt" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label18" runat="server" Text="Taxe EvRc"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="taxeevrctxt" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label19" runat="server" Text="Taxe EvGa"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="taxeevga" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label20" runat="server" Text="Accessoire"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="accessoiretxt" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label21" runat="server" Text="Net a Payer"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="netapayertxt" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                <asp:Label ID="Label22" runat="server" Text="Taxe1"></asp:Label>

            </td>
            <td> 
                <asp:TextBox ID="taxe1txt" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
       </div>
    <div style="text-align:center">
    <asp:Button ID="Button1" runat="server" Text="Enregistrer" Width="256px" Height="31px" OnClick="Button1_Click"  />
        </div>
</asp:Content>
