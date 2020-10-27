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
    public partial class Recouvrementlient : System.Web.UI.Page
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
            SqlDataSource4.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, numAttestation,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,montant from wAutoRecouv  ";
            GridView1.DataSource = SqlDataSource4;
            GridView1.DataBind();
            d.con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}