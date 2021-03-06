﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace ApplicationAssurance
{
    public partial class EtatPayClient : System.Web.UI.Page
    {
        ADO d = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["SelecteValue"] = DropDownList1.SelectedValue;

            d.CONNECTER();
            SqlDataSource SqlDataSource5 = new SqlDataSource();
            SqlDataSource5.ID = "SqlDataSource5";
            this.Page.Controls.Add(SqlDataSource5);
            SqlDataSource5.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
            SqlDataSource5.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, numAttestation,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,montant,Affectation from wAutoRecouv" ;
            GridView1.DataSource = SqlDataSource5;
            GridView1.DataBind();
            d.con.Close();
            d.CONNECTER();
            
        }

        private void calculateSum()
        {
            Int64 grandtotal = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {

                grandtotal = grandtotal + Convert.ToInt64(row.Cells[8].Text);
                GridView1.FooterRow.Cells[2].Text = " Total";
                GridView1.FooterRow.Cells[8].Text = grandtotal.ToString();
            }
        }
        public void filtreDate()
        {
            d.CONNECTER();
            d.cmd = new SqlCommand("fitredate", d.con);
            d.cmd.CommandType = CommandType.StoredProcedure;
            d.cmd.Connection = d.con;
            d.cmd.Parameters.AddWithValue("@date1", date1.Text);
            d.cmd.Parameters.AddWithValue("@date2", date2.Text);
            d.dap = new SqlDataAdapter(d.cmd);
            d.dt = new DataTable();
            d.dap.Fill(d.dt);
            d.cmd.ExecuteNonQuery();
            GridView1.DataSource = d.dt;
            GridView1.DataBind();
            d.DECONNECTER();
        }
        public void filtreDateHorsauto()
        {
            d.CONNECTER();
            d.cmd = new SqlCommand("fitredateHorsauto", d.con);
            d.cmd.CommandType = CommandType.StoredProcedure;
            d.cmd.Connection = d.con;
            d.cmd.Parameters.AddWithValue("@date1", date1.Text);
            d.cmd.Parameters.AddWithValue("@date2", date2.Text);
            d.dap = new SqlDataAdapter(d.cmd);
            d.dt = new DataTable();
            d.dap.Fill(d.dt);
            d.cmd.ExecuteNonQuery();
            GridView1.DataSource = d.dt;
            GridView1.DataBind();
            d.DECONNECTER();
        }
        public void filtreDateAssistance()
        {
            d.CONNECTER();
            d.cmd = new SqlCommand("fitredateAssistance", d.con);
            d.cmd.CommandType = CommandType.StoredProcedure;
            d.cmd.Connection = d.con;
            d.cmd.Parameters.AddWithValue("@date1", date1.Text);
            d.cmd.Parameters.AddWithValue("@date2", date2.Text);
            d.dap = new SqlDataAdapter(d.cmd);
            d.dt = new DataTable();
            d.dap.Fill(d.dt);
            d.cmd.ExecuteNonQuery();
            GridView1.DataSource = d.dt;
            GridView1.DataBind();
            d.DECONNECTER();
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
                SqlDataSource1.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, numAttestation,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,montant,Affectation from wAutoRecouv   ";
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
                SqlDataSource2.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, brancheRD,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,montant,Affectation from vwHorsAutoRecouv  ";
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
                SqlDataSource3.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, typeAssistance,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,montant,Affectation from vwAssistanceRecouv  ";
                GridView1.DataSource = SqlDataSource3;
                GridView1.DataBind();
                d.con.Close();
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rechercherbtn_Click(object sender, EventArgs e)
        {
     

            if (DropDownList1.SelectedValue == "Auto")
            {

                d.CONNECTER();
                SqlDataSource SqlDataSource5 = new SqlDataSource();
                SqlDataSource5.ID = "SqlDataSource5";
                this.Page.Controls.Add(SqlDataSource5);
                SqlDataSource5.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
                SqlDataSource5.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, numAttestation,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,montant,Affectation from wAutoRecouv where Affectation='Non Affecter' and compagnie = '" + recherchertxt.Text + "'";
                GridView1.DataSource = SqlDataSource5;
                GridView1.DataBind();

                d.con.Close();
                d.CONNECTER();


            }
            else if (DropDownList1.SelectedValue == "HorsAuto")
            {


                d.CONNECTER();
                SqlDataSource SqlDataSource2 = new SqlDataSource();
                SqlDataSource2.ID = "SqlDataSource2";
                this.Page.Controls.Add(SqlDataSource2);
                SqlDataSource2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
                SqlDataSource2.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, brancheRD,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,montant,Affectation from vwHorsAutoRecouv where Affectation='Non Affecter' and compagnie = '" + recherchertxt.Text + "'";
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
                SqlDataSource3.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, typeAssistance,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,montant,Affectation from vwAssistanceRecouv where Affectation='Non Affecter' and compagnie = '" + recherchertxt.Text + "'";
                GridView1.DataSource = SqlDataSource3;
                GridView1.DataBind();
                d.con.Close();


            }
        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#eed952");
                    row.ToolTip = string.Empty;
                    GridViewRow gr = GridView1.SelectedRow;
                    Response.Redirect("~/AffichagePayClient.aspx?id_affaire=" + gr.Cells[0].Text);



                }
                
            }

        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            calculateSum();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void date2_TextChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Auto")
            {
                filtreDate();
            }
            else if (DropDownList1.SelectedValue == "HorsAuto")
            {
                filtreDateHorsauto();
            }
            else if (DropDownList1.SelectedValue == "Assistance")
            {
                filtreDateAssistance();
            }

        }
    }
}