﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Avenent
{
    public partial class ChangVehiculMP : System.Web.UI.Page
    {
        SqlConnection cnx = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Assurancedb;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            cnx.Open();
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ID = "SqlDataSource1";
            this.Page.Controls.Add(SqlDataSource1);
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
            SqlDataSource1.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice  ,(Immatriculation) as matricule ,Marque,usage , convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateMec) as dateMEC,Compagnie from vwChangImma  ";
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            cnx.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            cnx.Open();
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ID = "SqlDataSource1";
            this.Page.Controls.Add(SqlDataSource1);
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
            SqlDataSource1.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice  ,(Immatriculation) as matricule,Marque,usage , convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateMec) as dateMEC,Compagnie from vwChangImma  where Immatriculation = '" + TextBox1.Text + "'";
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            cnx.Close();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}