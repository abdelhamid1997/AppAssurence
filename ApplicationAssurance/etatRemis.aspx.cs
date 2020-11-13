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
   
    public partial class etatRemis : System.Web.UI.Page
    {
        ADO d = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
             d.CONNECTER();
             SqlDataSource SqlDataSource1 = new SqlDataSource();
             SqlDataSource1.ID = "SqlDataSource1";
             this.Page.Controls.Add(SqlDataSource1);
             SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
             SqlDataSource1.SelectCommand = "select id_affaire, (nom_RS +' '+ prenom_FJ) as NomComplet,Gsm,reference,Banque,Montant_cheque,convert(varchar,Date_Remise )as dateRemise,Statut,id_paiment from vwcheque   order by Date_Remise asc";
             GridView1.DataSource = SqlDataSource1;
             GridView1.DataBind();
             //d.con.Close();
            total.Visible = false;
            filtrage_Stat.Visible = true;
           
        }

        //FillGrid Period 
        public void fillGridPeriod()
        {
            //d.CONNECTER();
            if (d.dt.Rows != null)
            {
                d.dt.Clear();
            }
            decimal Total = 0;
            decimal cheque = 0;
            d.cmd.CommandText = "select id_affaire, (nom_RS +' '+ prenom_FJ) as NomComplet,Gsm,reference,Banque,Montant_cheque,convert(varchar,Date_Remise ) as dateRemise,Statut,id_paiment from vwcheque where Date_Remise >= '" + DateTime.Parse(date1.Text).ToShortDateString()+ "' and Date_Remise <='" + DateTime.Parse(date2.Text).ToShortDateString() + "' and statut='" + DropDownList1.SelectedValue + "' order by Date_Remise asc ";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            GridView1.DataSource = d.dt;
            GridView1.DataBind();
            d.dr.Close();
            d.CONNECTER();

            if (d.dt.Rows.Count == 0)
            {
                total.Visible = false;
            }
            else
            {
                total.Visible = true;
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                d.dr.Close();
                Total += decimal.Parse(row.Cells[6].Text);
                d.cmd.CommandText = "select c.Montant_cheque from cheque c,IdentifiantPaiement Id,PaimentClient PC where PC.id_pai=Id.Id_paiment and Id.Id_paiment=c.id_paiment and PC.id_aff = '" + int.Parse(row.Cells[1].Text) + "' ";
                d.cmd.Connection = d.con;
                d.dr = d.cmd.ExecuteReader();
                while (d.dr.Read())
                {
                    cheque += decimal.Parse(d.dr[0].ToString());
                }
                montantTotal_Lab.Text = (Total+"DH").ToString();
                d.dr.Close();

            }
        }
        
        //boutton rechercher
        protected void Recherche_Btn_Click(object sender, EventArgs e)
        {
            montantTotal_Lab.Text = "";
            if(date1.Text !="" && date2.Text != "")
            {
                fillGridPeriod();
                lbldate.InnerText = "";
                if(GridView1.Rows.Count != '0') { 
                total.Visible = true;
                }
                else
                {
                    total.Visible = false;
                }
                filtrage_Stat.Visible = true;
               
            }
            else
            {
                lbldate.InnerText = "ereur de remplisage des données!!!!";
                d.dt.Clear();
                GridView1.DataSource = d.dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            d.CONNECTER();
            d.cmd.CommandText = "select id_affaire, (nom_RS +' '+ prenom_FJ) as NomComplet,Gsm,reference,Banque,Montant_cheque,convert(varchar,Date_Remise ) as dateRemise,Statut,id_paiment from vwcheque where Statut = '"+DropDownList1.SelectedValue+ "'  order by Date_Remise asc";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            GridView1.DataSource = d.dt;
            GridView1.DataBind();
        }
    }
}