using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ApplicationAssurance;

namespace Avenent
{
    public partial class ChangGarantie : System.Web.UI.Page
    {
        ADO d = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["SelecteValue"] = DropDownList1.SelectedValue;
            d.CONNECTER();
            SqlDataSource SqlDataSource4 = new SqlDataSource();
            SqlDataSource4.ID = "SqlDataSource4";
            this.Page.Controls.Add(SqlDataSource4);
            SqlDataSource4.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
            SqlDataSource4.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, numAttestation,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from vwAuto  ";
            GridView1.DataSource = SqlDataSource4;
            GridView1.DataBind();
            d.con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (DropDownList1.SelectedValue == "Auto")
            {
                d.CONNECTER();
                SqlDataSource SqlDataSource5 = new SqlDataSource();
                SqlDataSource5.ID = "SqlDataSource5";
                this.Page.Controls.Add(SqlDataSource5);
                SqlDataSource5.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
                SqlDataSource5.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, numAttestation,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from vwAuto where numPolice = '" + TextBox1.Text + "' or numAttestation='" + TextBox1.Text + "' or cin_rc='" + TextBox1.Text + "' or id_client='" + TextBox1.Text + "'";
                GridView1.DataSource = SqlDataSource5;
                GridView1.DataBind();
                d.con.Close();
            }
            else if (DropDownList1.SelectedValue == "HorsAuto")
            {
                d.CONNECTER();
                SqlDataSource SqlDataSource2 = new SqlDataSource();
                SqlDataSource2.ID = "SqlDataSource2";
                this.Page.Controls.Add(SqlDataSource2);
                SqlDataSource2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
                SqlDataSource2.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, brancheRD,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from vwHorsAuto where numPolice = '" + TextBox1.Text + "' or id_client='" + TextBox1.Text + "' or cin_rc='" + TextBox1.Text + "' ";
                GridView1.DataSource = SqlDataSource2;
                GridView1.DataBind();
                d.con.Close();
            }
            else if (DropDownList1.SelectedValue == "Assistance")
            {
                d.CONNECTER();
                SqlDataSource SqlDataSource3 = new SqlDataSource();
                SqlDataSource3.ID = "SqlDataSource3";
                this.Page.Controls.Add(SqlDataSource3);
                SqlDataSource3.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
                SqlDataSource3.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, typeAssistance,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from vwAssistance where numPolice = '" + TextBox1.Text + "' or id_client='" + TextBox1.Text + "' or cin_rc='" + TextBox1.Text + "' ";
                GridView1.DataSource = SqlDataSource3;
                GridView1.DataBind();
                d.con.Close();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelecteValue"] = DropDownList1.SelectedValue;

            if (DropDownList1.SelectedValue == "Auto")
            {
                d.CONNECTER();
                SqlDataSource SqlDataSource1 = new SqlDataSource();
                SqlDataSource1.ID = "SqlDataSource1";
                this.Page.Controls.Add(SqlDataSource1);
                SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
                SqlDataSource1.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, numAttestation,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from vwAuto   ";
                GridView1.DataSource = SqlDataSource1;
                GridView1.DataBind();
                d.con.Close();
            }
            else if (DropDownList1.SelectedValue == "HorsAuto")
            {
                d.CONNECTER();
                SqlDataSource SqlDataSource2 = new SqlDataSource();
                SqlDataSource2.ID = "SqlDataSource2";
                this.Page.Controls.Add(SqlDataSource2);
                SqlDataSource2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
                SqlDataSource2.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, brancheRD,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from vwHorsAuto  ";
                GridView1.DataSource = SqlDataSource2;
                GridView1.DataBind();
                d.con.Close();
            }
            else if (DropDownList1.SelectedValue == "Assistance")
            {
                d.CONNECTER();
                SqlDataSource SqlDataSource3 = new SqlDataSource();
                SqlDataSource3.ID = "SqlDataSource3";
                this.Page.Controls.Add(SqlDataSource3);
                SqlDataSource3.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
                SqlDataSource3.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, typeAssistance,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from vwAssistance  ";
                GridView1.DataSource = SqlDataSource3;
                GridView1.DataBind();
                d.con.Close();
            }
        }
    }
}