using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ApplicationAssurance
{
    public partial class EtatProduction : System.Web.UI.Page
    {
        ADO d = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            d.CONNECTER();
            
             FillGridToday();
            TextBoxDate1.Enabled = false;
            TextBoxDate2.Enabled = false;

        }
            //Fill Grid
            void FillGridToday()
            {
                if(d.dt.Rows != null)
                {
                d.dt.Clear();
                 }
                float Total = 0;
                float cheque = 0;
                float espece = 0;
                d.cmd.CommandText = "select id_affaire,nom_RS,prenom_FJ,numPolice,numAttestation,montant,Branche,Compagnie,convert(varchar, DateDebut) as DateDebut,convert(varchar, DateFin) as DateFin from AffaireAutoClient";
                d.cmd.Connection = d.con;
                d.dr = d.cmd.ExecuteReader();
                d.dt.Load(d.dr);
                GridViewEtatPro.DataSource = d.dt;
                GridViewEtatPro.DataBind();
                d.CONNECTER();

            if(d.dt.Rows.Count == 0)
            {
                tblEtat.Visible = false;
            }
            else
            {
                tblEtat.Visible = true;
            }
                foreach (GridViewRow row in GridViewEtatPro.Rows)
                {
                    d.dr.Close();
                    Total += float.Parse(row.Cells[5].Text);
                    d.cmd.CommandText = "select montantPayer from PaiementModeMontant where id_aff = '" + int.Parse(row.Cells[0].Text) + "' and MoyenRéglement = 'cheque'";
                    d.cmd.Connection = d.con;
                    d.dr = d.cmd.ExecuteReader();
                    while (d.dr.Read())
                    {
                        cheque += float.Parse(d.dr[0].ToString());
                    }
                    d.dr.Close();
                    d.cmd.CommandText = "select montantPayer from PaiementModeMontant where id_aff = '" + int.Parse(row.Cells[0].Text) + "' and MoyenRéglement = 'espece'";
                    d.cmd.Connection = d.con;
                    d.dr = d.cmd.ExecuteReader();
                    while (d.dr.Read())
                    {
                        espece += float.Parse(d.dr[0].ToString());
                    }


                }
                lblespece.Text = espece.ToString();
                lblcheque.Text = cheque.ToString();
                lblTot.Text = Total.ToString();

            }

            protected void CheckBoxToday_CheckedChanged(object sender, EventArgs e)
            {
            }


        void FillGridPeriod()
        {
            if (d.dt.Rows != null)
            {
                d.dt.Clear();
            }
            float Total = 0;
            float cheque = 0;
            float espece = 0;
            d.cmd.CommandText = "select id_affaire,nom_RS,prenom_FJ,numPolice,numAttestation,montant,Branche,Compagnie,convert(varchar, DateDebut) as DateDebut,convert(varchar, DateFin) as DateFin from AffaireAutoClient  where DateOperation >= '" +DateTime.Parse( TextBoxDate1.Text) + "' and DateOperation <= '"+DateTime.Parse( TextBoxDate2.Text)+"'";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            GridViewEtatPro.DataSource = d.dt;
            GridViewEtatPro.DataBind();
            d.CONNECTER();

            if (d.dt.Rows.Count == 0)
            {
                tblEtat.Visible = false;
            }
            else
            {
                tblEtat.Visible = true;
            }
            foreach (GridViewRow row in GridViewEtatPro.Rows)
            {
                d.dr.Close();
                Total += float.Parse(row.Cells[5].Text);
                d.cmd.CommandText = "select montantPayer from PaiementModeMontant where id_aff = '" + int.Parse(row.Cells[0].Text) + "' and MoyenRéglement = 'cheque'";
                d.cmd.Connection = d.con;
                d.dr = d.cmd.ExecuteReader();
                while (d.dr.Read())
                {
                    cheque += float.Parse(d.dr[0].ToString());
                }
                d.dr.Close();
                d.cmd.CommandText = "select montantPayer from PaiementModeMontant where id_aff = '" + int.Parse(row.Cells[0].Text) + "' and MoyenRéglement = 'espece'";
                d.cmd.Connection = d.con;
                d.dr = d.cmd.ExecuteReader();
                while (d.dr.Read())
                {
                    espece += float.Parse(d.dr[0].ToString());
                }


            }
            lblespece.Text = espece.ToString();
            lblcheque.Text = cheque.ToString();
            lblTot.Text = Total.ToString();

        }


        //Fill GridTodayBranch and Compagnie
        void FillGridTodayBranchCompagnie () 
        {
            if (d.dt.Rows != null)
            {
                d.dt.Clear();
            }
            float Total = 0;
            float cheque = 0;
            float espece = 0;
            d.cmd.CommandText = "select id_affaire,nom_RS,prenom_FJ,numPolice,numAttestation,montant,Branche,Compagnie,convert(varchar, DateDebut) as DateDebut,convert(varchar, DateFin) as DateFin from AffaireAutoClient  where DateOperation = '" + DateTime.Today + "' and Compagnie = '"+DropDownListCompagnie.SelectedValue+"' and Branche = '"+DropDownListBranch.SelectedValue+"'";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            GridViewEtatPro.DataSource = d.dt;
            GridViewEtatPro.DataBind();
            d.CONNECTER();

            if (d.dt.Rows.Count == 0)
            {
                tblEtat.Visible = false;
            }
            else
            {
                tblEtat.Visible = true;
            }
            foreach (GridViewRow row in GridViewEtatPro.Rows)
            {
                d.dr.Close();
                Total += float.Parse(row.Cells[5].Text);
                d.cmd.CommandText = "select montantPayer from PaiementModeMontant where id_aff = '" + int.Parse(row.Cells[0].Text) + "' and MoyenRéglement = 'cheque'";
                d.cmd.Connection = d.con;
                d.dr = d.cmd.ExecuteReader();
                while (d.dr.Read())
                {
                    cheque += float.Parse(d.dr[0].ToString());
                }
                d.dr.Close();
                d.cmd.CommandText = "select montantPayer from PaiementModeMontant where id_aff = '" + int.Parse(row.Cells[0].Text) + "' and MoyenRéglement = 'espece'";
                d.cmd.Connection = d.con;
                d.dr = d.cmd.ExecuteReader();
                while (d.dr.Read())
                {
                    espece += float.Parse(d.dr[0].ToString());
                }


            }
            lblespece.Text = espece.ToString();
            lblcheque.Text = cheque.ToString();
            lblTot.Text = Total.ToString();

        }
        protected void refrech_Click(object sender, EventArgs e)
        {
            if(CheckBoxToday.Checked == true)
            {
                d.dr.Close();
                TextBoxDate1.Enabled = false;
                TextBoxDate2.Enabled = false;
                if (CheckBoxTous.Checked == true)
                {
                   
                    FillGridToday();
                    d.DECONNECTER();

                }              
                 else
                {
                    FillGridTodayBranchCompagnie();
                    d.DECONNECTER();
                }
                
            }
            else
            {
                TextBoxDate1.Enabled = true;
                TextBoxDate2.Enabled = true;
                if (TextBoxDate1.Text != "" && TextBoxDate2.Text != "")
                {
                    if (DateTime.Parse(TextBoxDate2.Text) > DateTime.Parse(TextBoxDate1.Text))
                    {
                        d.dr.Close();
                        FillGridPeriod();
                    }
                    else
                    {
                        Response.Write("<script>alert('la premiere date doit etre inferieure a la deuxieme')</script>");
                    }

                }
            }
           
        }
    }
}