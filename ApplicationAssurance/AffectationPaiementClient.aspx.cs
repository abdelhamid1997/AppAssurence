using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.DynamicData;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace ApplicationAssurance
{
    public partial class AffectationPaiementClient : System.Web.UI.Page
    {
        ADO d = new ADO();
        string idCl = "0";
        decimal MontAff;
        public int idP = 0;
        public int idAff;
        string Ref = "Null";
        protected void Page_Load(object sender, EventArgs e)
        {
            

           if(AutreArea.Visible == true)
            {
                if (DropDownListModePaiement.SelectedValue == "Reliquat")
                {
                    reliquatArea.Visible = true;
                    NonReliquat.Visible = false;
                    lblPPR.InnerText = "";
                    
                }
                else if (DropDownListModePaiement.SelectedValue == "PPR")
                {
                    lblPPR.InnerText = "Cliquer sur le button valider pour payer avec PPR";
                    NonReliquat.Visible = false;
                    reliquatArea.Visible = false;
                }
                else
                {
                    reliquatArea.Visible = false;
                    NonReliquat.Visible = true;
                    lblPPR.InnerText = "";
                }
            }
           
            if (EspeceArea.Visible == true)
            {
                ButtonEspèce.Style.Add("background-color", "#0c52f6");
                ButtonEspèce.Style.Add("color", "white");
            }
            ChequeArea.Visible = false;
            AutreArea.Visible = false;
            reliquatArea.Visible = false;
            VirementArea.Visible = false;
            QueryString();
            d.CONNECTER();            
                d.cmd = new SqlCommand("select montantCredit from credit where idAff ='" + idAff + "'", d.con);
                d.dr = d.cmd.ExecuteReader();
                if (d.dr.Read())
                {
                    MontAff = decimal.Parse(d.dr[0].ToString());
                }
            
            d.dr.Close();
            if (!Page.IsPostBack)
            {
                RestEsp.Text = MontAff.ToString();
                RestCheque.Text = MontAff.ToString();
                RestAutre.Text = MontAff.ToString();
                RestVirement.Text = MontAff.ToString();
            }
            FillGrid();

        }
        //Querytring 
           public void QueryString()
            {
            d.CONNECTER();
           
            d.cmd = new SqlCommand("select * from VWAffaireClient where id_affaire ='" + Request.QueryString["id_affaire"].ToString() + "'", d.con);
            d.dr = d.cmd.ExecuteReader();
            if (d.dr.Read())
            {
                idAff = int.Parse(d.dr[0].ToString());
                idCl = d.dr[1].ToString();
            }
            d.dr.Close();
            d.DECONNECTER();
           }
        //FillGrid
        void FillGrid()
        {
            d.dr.Close();
            d.CONNECTER();
            if (d.dt.Rows != null)
            {
                d.dt.Clear();
            }
            d.cmd.CommandText = "select * from Reliquat";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            GridView1.DataSource = d.dt;
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                ReliquatNonExist.InnerText = "Vous n'avez pas de reliquat";
            }
            else
            {
                ReliquatNonExist.InnerText = "";
            }

            //d.cmd.CommandText = "select * from VWAffaireClient where id_affaire = '" + idAff + "'";
            //d.cmd.Connection = d.con;
            //d.dr = d.cmd.ExecuteReader();
            //if (d.dr.Read())
            //{
            //    idCl = d.dr[1].ToString();
            //    d.dr.Close();
            //    d.cmd.CommandText = "select * from Reliquat where id_client = '"+idCl+"'";
            //    d.cmd.Connection = d.con;
            //    d.dr = d.cmd.ExecuteReader();
            //    d.dt.Load(d.dr);
            //    GridView1.DataSource = d.dt;
            //    GridView1.DataBind();
            //    if(GridView1.Rows.Count == 0)
            //    {                  
            //            ReliquatNonExist.InnerText = "ce client n'a pas de reliquat";
            //    }
            //    else
            //    {
            //        ReliquatNonExist.InnerText = "";
            //    }
            //}
        }


        protected void ButtonEspèce_Click(object sender, EventArgs e)
        {
            ButtonEspèce.Style.Add("background-color", "#0c52f6");
            ButtonEspèce.Style.Add("color", "white");

            ButtonChéque.Style.Add("background-color", "white");
            ButtonChéque.Style.Add("color", "#0c52f6");

            ButtonAutre.Style.Add("background-color", "white");
            ButtonAutre.Style.Add("color", "#0c52f6");

            ButtonVirement.Style.Add("background-color", "white");
            ButtonVirement.Style.Add("color", "#0c52f6");
            
            EspeceArea.Visible = true;
            ChequeArea.Visible = false;
            AutreArea.Visible = false;
            VirementArea.Visible = false;
            alertdvfail.Attributes.Add("class", "alterdvfail");
            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");

        }

        protected void ButtonChéque_Click(object sender, EventArgs e)
        {
            ButtonChéque.Style.Add("background-color", "#0c52f6");
            ButtonChéque.Style.Add("color", "white");

            ButtonEspèce.Style.Add("background-color", "white");
            ButtonEspèce.Style.Add("color", "#0c52f6");

            ButtonAutre.Style.Add("background-color", "white");
            ButtonAutre.Style.Add("color", "#0c52f6");

            ButtonVirement.Style.Add("background-color", "white");
            ButtonVirement.Style.Add("color", "#0c52f6");

            EspeceArea.Visible = false;
            ChequeArea.Visible = true;
            AutreArea.Visible = false;
            VirementArea.Visible = false;
            alertdvfail.Attributes.Add("class", "alterdvfail");
            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            

        }

        protected void ButtonAutre_Click(object sender, EventArgs e)
        {
            ButtonAutre.Style.Add("background-color", "#0c52f6");
            ButtonAutre.Style.Add("color", "white");

            ButtonChéque.Style.Add("background-color", "white");
            ButtonChéque.Style.Add("color", "#0c52f6");

            ButtonEspèce.Style.Add("background-color", "white");
            ButtonEspèce.Style.Add("color", "#0c52f6");

            ButtonVirement.Style.Add("background-color", "white");
            ButtonVirement.Style.Add("color", "#0c52f6");

            EspeceArea.Visible = false;
            ChequeArea.Visible = false;
            AutreArea.Visible = true;
            VirementArea.Visible = false;
            alertdvfail.Attributes.Add("class", "alterdvfail");
            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            if (DropDownListModePaiement.SelectedValue == "Reliquat")
            {
                reliquatArea.Visible = true;
                NonReliquat.Visible = false;
                lblPPR.InnerText = "";               
            }
            else if (DropDownListModePaiement.SelectedValue == "PPR")
            {
                lblPPR.InnerText = "Cliquer sur le button valider pour payer avec PPR";
                NonReliquat.Visible = false;
                reliquatArea.Visible = false;
            }
            else
            {
                reliquatArea.Visible = false;
                NonReliquat.Visible = true;
                lblPPR.InnerText = "";
            }

        }

        //Insert into IdentifiantP
    
        public bool InsertIdentifiantPaiement()
        {
            d.dr.Close();
            bool oky = false;
            if (EspeceArea.Visible == true) {
                d.cmd.CommandText = "insert into IdentifiantPaiement (MoyenRéglement) values ('Espèce')";
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                oky = true;
                
            }
            else if(ChequeArea.Visible == true)
            {
                d.cmd.CommandText = "insert into IdentifiantPaiement (MoyenRéglement) values ('Chéque')";
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                oky = true;
                Ref = TextBoxRef.Text;
            }
            else if(VirementArea.Visible == true)
            {
                d.cmd.CommandText = "insert into IdentifiantPaiement (MoyenRéglement) values ('Virement')";
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                oky = true;
                Ref = textboxRéfVirement.Text;
            }
            else
            {
                d.cmd.CommandText = "insert into IdentifiantPaiement (MoyenRéglement) values ('"+DropDownListModePaiement.SelectedValue+"')";
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                oky = true;
            }            
            return oky;
        }
        //InsertInsertEspece
        
        public bool InsertPaiementClient()
          {
            bool ret = false;
             if (InsertIdentifiantPaiement() == true)
             {
            
                d.cmd = new SqlCommand("select TOP 1 *  from IdentifiantPaiement order by Id_paiment desc ", d.con);
                d.dr = d.cmd.ExecuteReader();
                if (d.dr.Read())
                {
                    
                    idP = int.Parse(d.dr[0].ToString());
                    d.dr.Close();
                    d.cmd.CommandText = "insert into PaimentClient values ('" + idAff + "','" + idP + "','"+Ref+"')";
                    d.cmd.Connection = d.con;
                    d.cmd.ExecuteNonQuery();

                }

                ret = true;
             }
            else
            {
                ret = false;
            }
            return ret;
        }
         
        //InsertEspèce
           
          public string InsertEspèce()
          {
            string oky;
            d.cmd.CommandType = CommandType.StoredProcedure;
            d.cmd.CommandText = "InsertEspéce";
            d.cmd.Parameters.Add("@idP", SqlDbType.Int).Value = idP;
            d.cmd.Parameters.Add("@dateP", SqlDbType.Date).Value = DateTime.Parse(TextBoxDatePaiementEspece.Text);
            d.cmd.Parameters.Add("@MontantPayer", SqlDbType.Decimal).Value = decimal.Parse(TextBoxEspece.Text);
            SqlParameter ok = new SqlParameter("@ok", SqlDbType.Int);
            ok.Direction = ParameterDirection.Output;
            d.cmd.Parameters.Add(ok);
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            oky = ok.Value.ToString();
            return oky;
          }
        string ModeP;
        //InsertReliquat
         public string InsertReliquat()
         {
            d.CONNECTER();
            d.cmd.Parameters.Clear();
            string okyR = "0";
            decimal MontantReliquat;
            string Reference;
            if (ModeP == "Chéque")
            {
                 MontantReliquat = decimal.Parse(TextBoxCheque.Text) - decimal.Parse(MontAff.ToString());
                 Reference = TextBoxRef.Text;
            }
            else
            {
                 MontantReliquat = decimal.Parse(textboxVirement.Text) - decimal.Parse(MontAff.ToString());
                Reference = textboxRéfVirement.Text;
            }            
            d.cmd.CommandType = CommandType.StoredProcedure;
            d.cmd.CommandText = "InsertReliquat";
            d.cmd.Parameters.Add("@idAff", SqlDbType.Int).Value = idAff ;
            d.cmd.Parameters.Add("@montantReliquat", SqlDbType.Decimal).Value = MontantReliquat;                         
            d.cmd.Parameters.Add("@reference", SqlDbType.VarChar).Value =Reference;
            d.cmd.Parameters.Add("@idClient", SqlDbType.VarChar).Value = idCl;
            d.cmd.Parameters.Add("@ModeP", SqlDbType.VarChar).Value = ModeP;
            SqlParameter ok = new SqlParameter("@ok", SqlDbType.Int);
            ok.Direction = ParameterDirection.Output;
            d.cmd.Parameters.Add(ok);
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            okyR = ok.Value.ToString();
            return okyR;
         }
        //InsertPPR
           public string InsertPPR()
           {
            d.CONNECTER();
            d.cmd.Parameters.Clear();
            string oky = "0";
            d.cmd.CommandType = CommandType.StoredProcedure;
            d.cmd.CommandText = "InsertPPR";
            d.cmd.Parameters.Add("@idP", SqlDbType.Int).Value = idP;
            d.cmd.Parameters.Add("@MontantPPR", SqlDbType.Decimal).Value = MontAff;
            SqlParameter ok = new SqlParameter("@ok",SqlDbType.Int);
            ok.Direction = ParameterDirection.Output;
            d.cmd.Parameters.Add(ok);
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            oky = ok.Value.ToString();
            MontAff = 0;            
            return oky;
           }

        //InsertChèque

        public string BanqueCh;
        public decimal MontantCh;
        public string DateCh;
          public string InsertChèque()
          {
            d.CONNECTER();
            d.cmd.Parameters.Clear();
            string oky = "0";
            d.cmd.CommandType = CommandType.StoredProcedure;
            d.cmd.CommandText = "InsertChèque";
            d.cmd.Parameters.Add("@idP", SqlDbType.Int).Value = idP;
            d.cmd.Parameters.Add("@Banque", SqlDbType.VarChar).Value = BanqueCh;
            d.cmd.Parameters.Add("@MontantCheque", SqlDbType.Decimal).Value = MontantCh;
            d.cmd.Parameters.Add("@dateRemise", SqlDbType.Date).Value = DateCh;
            SqlParameter ok = new SqlParameter("@ok", SqlDbType.Int);
            ok.Direction = ParameterDirection.Output;
            d.cmd.Parameters.Add(ok);
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            oky = ok.Value.ToString();           
            return oky;
          }

        public decimal MontantV;
        public string DateV;
        //InsertVirement
         public string InsertVirement()
        {
            d.CONNECTER();
            d.cmd.Parameters.Clear();
            string oky = "0";
            d.cmd.CommandType = CommandType.StoredProcedure;
            d.cmd.CommandText = "InsertVirement";
            d.cmd.Parameters.Add("@idPaiement", SqlDbType.Int).Value = idP;
            d.cmd.Parameters.Add("@MontantVirement", SqlDbType.Decimal).Value = MontantV;
            d.cmd.Parameters.Add("@DateVirement", SqlDbType.Date).Value = DateV;
            SqlParameter ok = new SqlParameter("@ok",SqlDbType.Int);
            ok.Direction = ParameterDirection.Output;
            d.cmd.Parameters.Add(ok);
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            oky = ok.Value.ToString();
            return oky;
        }

        //UpdateCredit 
        public void UpdateCredit()
        {
            d.CONNECTER();
            d.cmd.Parameters.Clear();
            d.cmd.CommandType = CommandType.StoredProcedure;
            d.cmd.CommandText = "UpdateCredit";
            d.cmd.Parameters.Add("@idAff", SqlDbType.Int).Value = idAff;
            d.cmd.Parameters.Add("@MontantCredit", SqlDbType.Decimal).Value = decimal.Parse(RestAutre.Text);
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
        }
        //Insert MONTANT PP

        public string InsertPP()
        {
            d.CONNECTER();
            string oky = "0";
            d.cmd.Parameters.Clear();
            d.cmd.CommandType = CommandType.StoredProcedure;
            d.cmd.CommandText = "InsertPP";
            d.cmd.Parameters.Add("@idAff", SqlDbType.Int).Value = idAff;           
                decimal a = decimal.Parse(RestAutre.Text);
                string b = "-" + a.ToString();
                d.cmd.Parameters.Add("@MontantPP", SqlDbType.Decimal).Value = decimal.Parse(b);           
            SqlParameter ok = new SqlParameter("@ok",SqlDbType.Int);
            ok.Direction = ParameterDirection.Output;
            d.cmd.Parameters.Add(ok);
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();
            oky = ok.Value.ToString();
            return oky;
        }
        protected void btnValiderEspèce_Click(object sender, EventArgs e)
        {
            d.CONNECTER();
            if (decimal.Parse(RestEsp.Text) == 0)
            {
                alertdvfail.InnerText = "Cette affaire déja payé";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            else
            {
                if (TextBoxEspece.Text != "" && TextBoxDatePaiementEspece.Text != "")
                {
                    if (decimal.Parse(TextBoxEspece.Text) <= decimal.Parse(RestEsp.Text))
                    {
                        if (InsertPaiementClient() == true)
                        {
                            if (InsertEspèce() == "1")
                            {
                                if (Page.IsPostBack)
                                {
                                    decimal a, b, c;
                                    a = decimal.Parse(TextBoxEspece.Text);
                                    b = decimal.Parse(RestEsp.Text);
                                    c = b - a;
                                    RestEsp.Text = c.ToString();
                                    RestCheque.Text = c.ToString();
                                    RestAutre.Text = c.ToString();
                                    RestVirement.Text = c.ToString();
                                    AlertdvSucces.InnerText = "Succès";
                                    AlertdvSucces.Attributes.Add("class", "Error alertS");
                                    alertdvfail.Attributes.Add("class", "alterdvfail");
                                    if (decimal.Parse(RestEsp.Text) == 0)
                                    {
                                        d.cmd = new SqlCommand("update affaire set Affectation = 'Affecter' where id_affaire = '"+idAff+"'", d.con);
                                        d.cmd.ExecuteNonQuery();
                                    }
                                    UpdateCredit();
                                }
                                

                            }
                            else
                            {
                                alertdvfail.InnerText = "Error de Paiement";
                                alertdvfail.Attributes.Add("class", "Error alert");
                                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                            }
                        }
                        
                    }
                    else
                    {
                        alertdvfail.InnerText = "le montant espece est superieur que le montant doit payé";
                        alertdvfail.Attributes.Add("class", "Error alert");
                        AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                    }
                    TextBoxEspece.Text = "";
                    TextBoxDatePaiementEspece.Text = "";
                    d.DECONNECTER();

                }
                else
                {
                    alertdvfail.InnerText = "Merci de remplire tous les champs";
                    alertdvfail.Attributes.Add("class", "Error alert");
                    AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                }
            }
            d.cmd.CommandText = "delete from Reliquat where montantReliquat = '" + 0 + "'";
            d.cmd.ExecuteNonQuery();
            
        }

        protected void TextBoxEspece_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex("^\\d+([,]\\d+)?$");
           

            if(r.IsMatch(TextBoxEspece.Text))
            {
                if (string.IsNullOrEmpty(TextBoxEspece.Text))
                {
                    TextBoxEspece.Text = "0";
                }
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            else
            {
               
                TextBoxEspece.Text = "0";
                alertdvfail.InnerText = "ce champ n'accepte que les Nombres et les Virgules (,)(0-9)";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            EspeceArea.Visible = true;
        }

        protected void TextBoxDatePaiementEspece_TextChanged(object sender, EventArgs e)
        {
            Regex date = new Regex("^\\d{2}/\\d{2}/\\d{4}$");
            if (date.IsMatch(TextBoxDatePaiementEspece.Text))
            {
                if (string.IsNullOrEmpty(TextBoxDatePaiementEspece.Text))
                {
                    TextBoxDatePaiementEspece.Text = "";
                }
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            else
            {
                TextBoxDatePaiementEspece.Text = "";
                alertdvfail.InnerText = "le syntax du date  et incorrect !!";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            EspeceArea.Visible = true;
        }

        protected void TextBoxCheque_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex("^\\d+([,]\\d+)?$");
            
                if (r.IsMatch(TextBoxCheque.Text))
                {
                    if (string.IsNullOrEmpty(TextBoxCheque.Text))
                    {
                        TextBoxCheque.Text = "0";
                    }
                    alertdvfail.Attributes.Add("class", "alterdvfail");
                    AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                }
                else
                {

                    TextBoxCheque.Text = "0";
                    alertdvfail.InnerText = "ce champ n'accepte que les Nombres et les Virgules (,)(0-9)";
                    alertdvfail.Attributes.Add("class", "Error alert");
                    AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                }
            ChequeArea.Visible = true;
            
        }

        protected void TextBoxDateRemise_TextChanged(object sender, EventArgs e)
        {
            Regex date = new Regex("^\\d{2}/\\d{2}/\\d{4}$");
            if (date.IsMatch(TextBoxDateRemise.Text))
            {
                if (string.IsNullOrEmpty(TextBoxDateRemise.Text))
                {
                    TextBoxDateRemise.Text = "";
                }
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            else
            {
                TextBoxDateRemise.Text = "";
                alertdvfail.InnerText = "le syntax du date  et incorrect !!";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            ChequeArea.Visible = true;
        }

        protected void btnValiderChéque_Click(object sender, EventArgs e)
        {
            d.CONNECTER();
           

            if (decimal.Parse(RestEsp.Text) == 0)
            {
                alertdvfail.InnerText = "Cette affaire déja payé";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            else {
                
                if (TextBoxCheque.Text != "" && TextBoxDateRemise.Text != "" && TextBoxRef.Text != "")
                {
                    Ref = TextBoxRef.Text;
                    ModeP = "Chéque";
                    BanqueCh = dropBanque.SelectedValue;
                    MontantCh = decimal.Parse(TextBoxCheque.Text);
                    DateCh = TextBoxDateRemise.Text;
                    if (InsertPaiementClient() == true)
                    {
                        if (InsertChèque() == "1")
                        {
                            if (decimal.Parse(RestCheque.Text) < decimal.Parse(TextBoxCheque.Text))
                            {
                                if (InsertReliquat() == "1")
                                {
                                    AlertdvSucces.InnerText = " bien payé,le reste de sold vous allez le trouver dans le reliquat";
                                    AlertdvSucces.Attributes.Add("class", "Error alertS");
                                    alertdvfail.Attributes.Add("class", "alterdvfail");
                                    MontAff = 0;
                                    RestEsp.Text = MontAff.ToString();
                                    RestCheque.Text = MontAff.ToString();
                                    RestVirement.Text = MontAff.ToString();
                                    RestAutre.Text = MontAff.ToString();
                                    if (decimal.Parse(RestVirement.Text) == 0)
                                    {
                                        d.cmd = new SqlCommand("update affaire set Affectation = 'Affecter' where id_affaire = '" + idAff + "'", d.con);
                                        d.cmd.ExecuteNonQuery();
                                    }
                                    UpdateCredit();
                                }
                                else
                                {
                                    alertdvfail.InnerText = "Error Reliquat";
                                    alertdvfail.Attributes.Add("class", "Error alert");
                                    AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                                }
                            }
                            else
                            {
                                AlertdvSucces.InnerText = "Payé avec succès";
                                AlertdvSucces.Attributes.Add("class", "Error alertS");
                                alertdvfail.Attributes.Add("class", "alterdvfail");
                                if (Page.IsPostBack)
                                {
                                    decimal a, b, c;
                                    a = decimal.Parse(TextBoxCheque.Text);
                                    b = decimal.Parse(RestCheque.Text);
                                    c = b - a;
                                    RestEsp.Text = c.ToString();
                                    RestCheque.Text = c.ToString();
                                    RestAutre.Text = c.ToString();
                                    RestVirement.Text = c.ToString();
                                    if(decimal.Parse(RestCheque.Text) == 0)
                                    {
                                        d.cmd = new SqlCommand("update affaire set Affectation = 'Affecter' where id_affaire = '" + idAff + "' ", d.con);
                                        d.cmd.ExecuteNonQuery();
                                    }
                                    UpdateCredit();
                                }
                            }
                        }
                        else
                        {
                            alertdvfail.InnerText = "Error de Paiement";
                            alertdvfail.Attributes.Add("class", "Error alert");
                            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                        }

                    }
                }
                else
                {
                    alertdvfail.InnerText = "Merci de remplire tous les champs";
                    alertdvfail.Attributes.Add("class", "Error alert");
                    AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                }               
            }
            ChequeArea.Visible = true;
        }

        protected void DropDownListModePaiement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownListModePaiement.SelectedValue == "Reliquat")
            {
                reliquatArea.Visible = true;
                NonReliquat.Visible = false;
                lblPPR.InnerText = "";
            }
            else if (DropDownListModePaiement.SelectedValue =="PPR")
            {
                lblPPR.InnerText = "Cliquer sur le button valider pour payer avec PPR";
                NonReliquat.Visible = false;
                reliquatArea.Visible = false;
            }
            else
            {
                reliquatArea.Visible = false;
                NonReliquat.Visible = true;
                lblPPR.InnerText = "";
            }
            AutreArea.Visible = true;
        }
        //UpdateReliquat
        public string UpdateReliquat()
        {
            d.CONNECTER();
            d.cmd.Parameters.Clear();
            int idAffR = int.Parse(GridView1.SelectedRow.Cells[1].Text);
            string oky = "0";
            decimal MontantRe;
            if (MontantCh > decimal.Parse(RestAutre.Text))
            {
                MontantRe = MontantCh - decimal.Parse(RestAutre.Text);
                d.cmd.CommandType = CommandType.StoredProcedure;
                d.cmd.CommandText = "UpdateReliquat";
                d.cmd.Parameters.Add("@idAff", SqlDbType.Int).Value = idAffR;
                d.cmd.Parameters.Add("@MontantReliquat", SqlDbType.Decimal).Value = MontantRe;
                SqlParameter ok = new SqlParameter("@ok", SqlDbType.Int);
                ok.Direction = ParameterDirection.Output;
                d.cmd.Parameters.Add(ok);
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                oky = ok.Value.ToString();
            }
            else
            {
                MontantRe = decimal.Parse(RestAutre.Text) - MontantCh;
                MontAff = MontantRe;
                RestEsp.Text = MontAff.ToString();
                RestCheque.Text = MontAff.ToString();
                RestAutre.Text = MontAff.ToString();
                RestVirement.Text = MontAff.ToString();
                oky = "1";
                d.cmd = new SqlCommand("delete from Reliquat where idAff  ='" + idAffR + "'", d.con);
                d.cmd.ExecuteNonQuery();
            }   
           
            return oky;

        }

        protected void ButtonValiderAutre_Click(object sender, EventArgs e)
        {
            d.CONNECTER();
           
            if (decimal.Parse(RestAutre.Text) == 0)
            {
                alertdvfail.InnerText = "Cette affaire déja payé";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                AutreArea.Visible = true;
            }
            else
            {
                
                if (InsertPaiementClient() == true)
                {
                    if (DropDownListModePaiement.SelectedValue == "PPR")
                    {
                        if (InsertPPR() == "1")
                        {
                            AlertdvSucces.InnerText = "Payé avec succès";
                            AlertdvSucces.Attributes.Add("class", "Error alertS");
                            alertdvfail.Attributes.Add("class", "alterdvfail");
                            if (Page.IsPostBack)
                            {
                                RestEsp.Text = MontAff.ToString();
                                RestCheque.Text = MontAff.ToString();
                                RestAutre.Text = MontAff.ToString();
                                RestVirement.Text = MontAff.ToString();
                                if (decimal.Parse(RestAutre.Text) == 0)
                                {
                                    d.cmd = new SqlCommand("update affaire set Affectation = 'Affecter' where id_affaire = '" + idAff + "' ", d.con);
                                    d.cmd.ExecuteNonQuery();
                                }
                                UpdateCredit();
                            }
                        }
                        else
                        {
                            alertdvfail.InnerText = "Error de Paiement";
                            alertdvfail.Attributes.Add("class", "Error alert");
                            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                        }
                    }
                    else if (DropDownListModePaiement.SelectedValue == "Reliquat")
                    {
                        try {
                            BanqueCh = DropDownListBanqueReliquat.SelectedValue;
                            DateCh = DateTime.Now.ToShortDateString();
                            MontantCh = decimal.Parse(GridView1.SelectedRow.Cells[2].Text);
                            DateV = DateTime.Now.ToShortDateString();
                            MontantV = decimal.Parse(GridView1.SelectedRow.Cells[2].Text);
                            Ref = GridView1.SelectedRow.Cells[3].Text;
                            reliquatArea.Visible = true;
                            if (decimal.Parse(RestAutre.Text) < MontantCh)
                            {
                                if (GridView1.SelectedRow.Cells[5].Text == "Virement")
                                {
                                    if (InsertVirement() == "1")
                                    {
                                        if (UpdateReliquat() == "1")
                                        {
                                            MontAff = 0;
                                            RestEsp.Text = MontAff.ToString();
                                            RestCheque.Text = MontAff.ToString();
                                            RestAutre.Text = MontAff.ToString();
                                            RestVirement.Text = MontAff.ToString();
                                            if (decimal.Parse(RestAutre.Text) == 0)
                                            {
                                                d.cmd = new SqlCommand("update affaire set Affectation = 'Affecter' where id_affaire = '" + idAff + "' ", d.con);
                                                d.cmd.ExecuteNonQuery();
                                            }
                                            AlertdvSucces.InnerText = "Payé avec succès par reliquat Virement";
                                            AlertdvSucces.Attributes.Add("class", "Error alertS");
                                            alertdvfail.Attributes.Add("class", "alterdvfail");
                                        }
                                        else
                                        {
                                            alertdvfail.InnerText = "Error RELIQUAT";
                                            alertdvfail.Attributes.Add("class", "Error alert");
                                            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                                        }
                                    }
                                    else
                                    {
                                        alertdvfail.InnerText = "Error Virement";
                                        alertdvfail.Attributes.Add("class", "Error alert");
                                        AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                                    }


                                }
                                else
                                {

                                    if (InsertChèque() == "1")
                                    {
                                        if (UpdateReliquat() == "1")
                                        {
                                            MontAff = 0;
                                            RestEsp.Text = MontAff.ToString();
                                            RestCheque.Text = MontAff.ToString();
                                            RestAutre.Text = MontAff.ToString();
                                            RestVirement.Text = MontAff.ToString();
                                            if (decimal.Parse(RestAutre.Text) == 0)
                                            {
                                                d.cmd = new SqlCommand("update affaire set Affectation = 'Affecter' where id_affaire = '" + idAff + "' ", d.con);
                                                d.cmd.ExecuteNonQuery();
                                            }
                                            AlertdvSucces.InnerText = "Payé avec succès par reliquat chéque";
                                            AlertdvSucces.Attributes.Add("class", "Error alertS");
                                            alertdvfail.Attributes.Add("class", "alterdvfail");
                                        }
                                        else
                                        {
                                            alertdvfail.InnerText = "Error RELIQUAT";
                                            alertdvfail.Attributes.Add("class", "Error alert");
                                            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                                        }

                                    }
                                    else
                                    {
                                        alertdvfail.InnerText = "Error de Paiement";
                                        alertdvfail.Attributes.Add("class", "Error alert");
                                        AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                                    }

                                }
                            }
                            else
                            {
                                if (GridView1.SelectedRow.Cells[5].Text == "Virement")
                                {
                                    if (InsertVirement() == "1")
                                    {
                                        if (UpdateReliquat() == "1")
                                        {
                                            if (decimal.Parse(RestAutre.Text) == 0)
                                            {
                                                d.cmd = new SqlCommand("update affaire set Affectation = 'Affecter' where id_affaire = '" + idAff + "' ", d.con);
                                                d.cmd.ExecuteNonQuery();
                                            }
                                            UpdateCredit();
                                            AlertdvSucces.InnerText = "Payé avec succès par reliquat Virement";
                                            AlertdvSucces.Attributes.Add("class", "Error alertS");
                                            alertdvfail.Attributes.Add("class", "alterdvfail");
                                        }
                                        else
                                        {
                                            alertdvfail.InnerText = "Error RELIQUAT";
                                            alertdvfail.Attributes.Add("class", "Error alert");
                                            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                                        }


                                    }
                                    else
                                    {
                                        alertdvfail.InnerText = "Error de Paiement";
                                        alertdvfail.Attributes.Add("class", "Error alert");
                                        AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                                    }
                                }
                                else
                                {
                                    if (InsertChèque() == "1")
                                    {
                                        if (UpdateReliquat() == "1")
                                        {
                                            if (decimal.Parse(RestAutre.Text) == 0)
                                            {
                                                d.cmd = new SqlCommand("update affaire set Affectation = 'Affecter' where id_affaire = '" + idAff + "' ", d.con);
                                                d.cmd.ExecuteNonQuery();
                                            }
                                            UpdateCredit();
                                            AlertdvSucces.InnerText = "Payé avec succès par reliquat chéque";
                                            AlertdvSucces.Attributes.Add("class", "Error alertS");
                                            alertdvfail.Attributes.Add("class", "alterdvfail");
                                        }
                                        else
                                        {
                                            alertdvfail.InnerText = "Error RELIQUAT";
                                            alertdvfail.Attributes.Add("class", "Error alert");
                                            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                                        }

                                    }
                                    else
                                    {
                                        alertdvfail.InnerText = "Error de Paiement";
                                        alertdvfail.Attributes.Add("class", "Error alert");
                                        AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                                    }
                                }
                            }
                        }
                        catch (Exception a)
                        {
                            if (a.Message.StartsWith("L'index était hors limites. Il ne doit pas être négatif et doit être inférieur à la taille de la collection"))
                            {
                                alertdvfail.InnerText = "Vous n'avez pas de reliquat";
                                alertdvfail.Attributes.Add("class", "Error alert");
                                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                            }
                        }
                    }
                    else
                    {
                        if (TextBoxDatePaiementAutre.Text != "")
                        {

                            if (InsertPP() == "1")
                            {
                                AlertdvSucces.InnerText = "Montant PP bien enregistré";
                                AlertdvSucces.Attributes.Add("class", "Error alertS");
                                alertdvfail.Attributes.Add("class", "alterdvfail");
                                MontAff = 0;
                                RestEsp.Text = MontAff.ToString();
                                RestCheque.Text = MontAff.ToString();
                                RestAutre.Text = MontAff.ToString();
                                RestVirement.Text = MontAff.ToString();
                                if (decimal.Parse(RestAutre.Text) == 0)
                                {
                                    d.cmd = new SqlCommand("update affaire set Affectation = 'Affecter' where id_affaire = '" + idAff + "' ", d.con);
                                    d.cmd.ExecuteNonQuery();
                                }
                                UpdateCredit();
                            } else
                            {
                                alertdvfail.InnerText = "Error de Paiement";
                                alertdvfail.Attributes.Add("class", "Error alert");
                                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                            }
                        }
                        else
                        {
                            alertdvfail.InnerText = "Merci de remplire la date";
                            alertdvfail.Attributes.Add("class", "Error alert");
                            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                        }
                    }
                }
                else
                {
                    alertdvfail.InnerText = "Error de Paiement";
                    alertdvfail.Attributes.Add("class", "Error alert");
                    AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                }
               
            }
            AutreArea.Visible = true;
            if(GridView1.Rows.Count == 0)
            {
                DropDownListBanqueReliquat.Visible = true;
            }
        }

        protected void ButtonVirement_Click(object sender, EventArgs e)
        {
            ButtonVirement.Style.Add("background-color", "#0c52f6");
            ButtonVirement.Style.Add("color", "white");

            ButtonChéque.Style.Add("background-color", "white");
            ButtonChéque.Style.Add("color", "#0c52f6");

            ButtonAutre.Style.Add("background-color", "white");
            ButtonAutre.Style.Add("color", "#0c52f6");

            ButtonEspèce.Style.Add("background-color", "white");
            ButtonEspèce.Style.Add("color", "#0c52f6");

            EspeceArea.Visible = false;
            ChequeArea.Visible = false;
            AutreArea.Visible = false;
            VirementArea.Visible = true;
            alertdvfail.Attributes.Add("class", "alterdvfail");
            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
        }

        protected void textboxVirement_TextChanged(object sender, EventArgs e)
        {
            Regex r = new Regex("^\\d+([,]\\d+)?$");

            if (r.IsMatch(textboxVirement.Text))
            {
                if (string.IsNullOrEmpty(textboxVirement.Text))
                {
                    textboxVirement.Text = "0";
                }
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            else
            {

                textboxVirement.Text = "0";
                alertdvfail.InnerText = "ce champ n'accepte que les Nombres et les Virgules (,)(0-9)";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            VirementArea.Visible = true;
        }

        protected void textboxDateVirement_TextChanged(object sender, EventArgs e)
        {
            Regex date = new Regex("^\\d{2}/\\d{2}/\\d{4}$");
            if (date.IsMatch(textboxDateVirement.Text))
            {
                if (string.IsNullOrEmpty(textboxDateVirement.Text))
                {
                    textboxDateVirement.Text = "";
                }
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            else
            {
                textboxDateVirement.Text = "";
                alertdvfail.InnerText = "le syntax du date  et incorrect !!";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            VirementArea.Visible = true;
        }

        protected void ButtonValiderVirement_Click(object sender, EventArgs e)
        {
            
            
            if(decimal.Parse(RestVirement.Text) == 0)
            {
                alertdvfail.InnerText = "Cette affaire déja payé";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            else
            {
                if(textboxVirement.Text != "" && textboxDateVirement.Text !="" && textboxRéfVirement.Text != "")
                {
                    MontantV = decimal.Parse(textboxVirement.Text);
                    DateV = textboxDateVirement.Text;
                    Ref = textboxRéfVirement.Text;
                    ModeP = "Virement";
                    if (InsertPaiementClient() == true)
                        {
                            if (InsertVirement() == "1")
                            {
                                if(decimal.Parse(RestVirement.Text) < decimal.Parse(textboxVirement.Text))
                                {
                                    if (InsertReliquat() == "1")
                                    {
                                        AlertdvSucces.InnerText = " bien payé,le reste de sold vous allez le trouver dans le reliquat";
                                        AlertdvSucces.Attributes.Add("class", "Error alertS");
                                        alertdvfail.Attributes.Add("class", "alterdvfail");
                                        MontAff = 0;
                                        RestEsp.Text = MontAff.ToString();
                                        RestCheque.Text = MontAff.ToString();
                                        RestVirement.Text = MontAff.ToString();
                                        RestAutre.Text = MontAff.ToString();
                                    if (decimal.Parse(RestVirement.Text) == 0)
                                    {
                                        d.cmd = new SqlCommand("update affaire set Affectation = 'Affecter' where id_affaire = '" + idAff + "'", d.con);
                                        d.cmd.ExecuteNonQuery();
                                    }
                                        UpdateCredit();
                                }
                                    else
                                    {
                                        alertdvfail.InnerText = "Error Reliquat";
                                        alertdvfail.Attributes.Add("class", "Error alert");
                                        AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                                    }
                                }
                                else
                                {
                                    AlertdvSucces.InnerText = "Payé avec succès";
                                    AlertdvSucces.Attributes.Add("class", "Error alertS");
                                    alertdvfail.Attributes.Add("class", "alterdvfail");
                                    if (Page.IsPostBack)
                                    {
                                        decimal a, b, c;
                                        a = decimal.Parse(textboxVirement.Text);
                                        b = decimal.Parse(RestVirement.Text);
                                        c = b - a;
                                        RestEsp.Text = c.ToString();
                                        RestCheque.Text = c.ToString();
                                        RestAutre.Text = c.ToString();
                                        RestVirement.Text = c.ToString();
                                        AlertdvSucces.InnerText = "Succès";
                                        AlertdvSucces.Attributes.Add("class", "Error alertS");
                                        alertdvfail.Attributes.Add("class", "alterdvfail");
                                        if (decimal.Parse(RestVirement.Text) == 0)
                                        {
                                            d.cmd = new SqlCommand("update affaire set Affectation = 'Affecter' where id_affaire = '" + idAff + "'", d.con);
                                            d.cmd.ExecuteNonQuery();
                                        }
                                        UpdateCredit();
                                    }
                                }
                                
                            }
                            else
                            {
                                alertdvfail.InnerText = "Error de Paiement";
                                alertdvfail.Attributes.Add("class", "Error alert");
                                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                            }
                        }
                }
                else
                {
                    alertdvfail.InnerText = "Merci de remplire tous les champs";
                    alertdvfail.Attributes.Add("class", "Error alert");
                    AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                }
            }
            VirementArea.Visible = true;
        }
        public decimal montantRe;
        public string RefReliquat;
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            MontantCh = montantRe;
            Ref = RefReliquat;
            if (GridView1.SelectedRow.Cells[5].Text == "Virement")
            {
                DropDownListBanqueReliquat.Visible = false;

            }
            else
            {              
                DropDownListBanqueReliquat.Visible = true;
                
            }
            AutreArea.Visible = true;
            reliquatArea.Visible = true;
        }

        protected void DropDownListBanqueReliquat_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutreArea.Visible = true;
            reliquatArea.Visible = true;
        }
    }
}