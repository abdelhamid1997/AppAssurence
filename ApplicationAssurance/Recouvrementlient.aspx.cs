using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
<<<<<<< HEAD
=======
using System.Configuration;
>>>>>>> 3d8aa206723ebe39f5078df8b5d028b4746044f6
using System.Drawing;
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
<<<<<<< HEAD
            SqlDataSource4.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, numAttestation,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,montant,Affectation from wAutoRecouv where Affectation = 'Non Affecter' ";
=======
            SqlDataSource4.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, numAttestation,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,montant,Affectation from wAutoRecouv where Affectation='Non Affecter' ";
>>>>>>> 3d8aa206723ebe39f5078df8b5d028b4746044f6
            GridView1.DataSource = SqlDataSource4;
            GridView1.DataBind();
            d.con.Close();
        }

<<<<<<< HEAD
        public void filtrDate()
        {
            d.CONNECTER();
            d.cmd = new SqlCommand("fitredate", d.con);
            d.cmd.Connection = d.con;
            d.cmd.CommandType = CommandType.StoredProcedure;
            d.cmd.Parameters.AddWithValue("@date1", date1.Text);
            d.cmd.Parameters.AddWithValue("@date2", date2.Text);
            d.dap = new SqlDataAdapter(d.cmd);
            d.dt = new DataTable();
            d.dap.Fill(d.dt);
            d.cmd.ExecuteNonQuery();
            GridView1.DataSource = d.dt;
            d.DECONNECTER();
=======
        //public void filtrDate()
        //{
        //    d.CONNECTER();
        //    d.cmd = new SqlCommand("fitredate", d.con);
        //    d.cmd.Connection = d.con;
        //    d.cmd.CommandType = CommandType.StoredProcedure;
        //    d.cmd.Parameters.AddWithValue("@date1", date1.Text);
        //    d.cmd.Parameters.AddWithValue("@date2", date2.Text);
        //    d.dap = new SqlDataAdapter(d.cmd);
        //    d.dt = new DataTable();
        //    d.dap.Fill(d.dt);
        //    d.cmd.ExecuteNonQuery();
        //    GridView1.DataSource = d.dt;
        //    d.DECONNECTER();
        //}




        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click ici pour select la ligne";
            }

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    GridViewRow gr = GridView1.SelectedRow;
                    Response.Redirect("~/AffectationRenouvellement.aspx?id_affaire="+gr.Cells[0].Text);

                }

            }
        }

       

        protected void rechercherbtn_Click(object sender, EventArgs e)
        {
     
            if (DropDownList1.SelectedValue == "Auto" )
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
                SqlDataSource2.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, brancheRD,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from vwHorsAutoRecouv where Affectation='Non Affecter' and compagnie = '" + recherchertxt.Text + "'";
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
                SqlDataSource3.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, typeAssistance,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from vwAssistanceRecouv where Affectation='Non Affecter' and compagnie = '" + recherchertxt.Text + "'";
                GridView1.DataSource = SqlDataSource3;
                GridView1.DataBind();
                d.con.Close();

              
            }
>>>>>>> 3d8aa206723ebe39f5078df8b5d028b4746044f6
        }


       

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Auto")
            {
                d.CONNECTER();
                SqlDataSource SqlDataSource1 = new SqlDataSource();
                SqlDataSource1.ID = "SqlDataSource1";
                this.Page.Controls.Add(SqlDataSource1);
                SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
                SqlDataSource1.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, numAttestation,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from wAutoRecouv   ";
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
                SqlDataSource2.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, brancheRD,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from vwHorsAutoRecouv  ";
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
                SqlDataSource3.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, typeAssistance,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from vwAssistanceRecouv  ";
                GridView1.DataSource = SqlDataSource3;
                GridView1.DataBind();
                d.con.Close();
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {

        }

<<<<<<< HEAD
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click ici pour select la ligne";
            }

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");

                    row.ToolTip = string.Empty;
                    GridViewRow gr = GridView1.SelectedRow;
                    Response.Redirect("~/AffectationPaiementClient.aspx?id_affaire="+gr.Cells[0].Text);

                }

            }
        }

       

        protected void rechercherbtn_Click(object sender, EventArgs e)
        {
            //if ( date1.Text != "" || date2.Text != "" || recherchertxt.Text != "" || DropDownList1.SelectedValue == "Auto")
            //{
            //    d.CONNECTER();
            //    d.cmd = new SqlCommand("fitredate", d.con);
            //    d.cmd.Connection = d.con;
            //    d.cmd.CommandType = CommandType.StoredProcedure;
            //    d.cmd.Parameters.AddWithValue("@date1", date1.Text);
            //    d.cmd.Parameters.AddWithValue("@date2", date2.Text);
            //    d.dap = new SqlDataAdapter(d.cmd);
            //    d.dt = new DataTable();
            //    d.dap.Fill(d.dt);
            //    d.cmd.ExecuteNonQuery();
            //    GridView1.DataSource = d.dt;
            //    GridView1.DataBind();
            //    d.DECONNECTER();


            //}
            if (date1.Text != "" || date2.Text != "" || DropDownList1.SelectedValue == "Auto" )
            {
                filtrDate();
                d.CONNECTER();
                SqlDataSource SqlDataSource5 = new SqlDataSource();
                SqlDataSource5.ID = "SqlDataSource5";
                this.Page.Controls.Add(SqlDataSource5);
                SqlDataSource5.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
                SqlDataSource5.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, numAttestation,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,montant,Affectation from wAutoRecouv where numPolice = '" + recherchertxt.Text + "'";
                GridView1.DataSource = SqlDataSource5;
                GridView1.DataBind();
                d.con.Close();
                d.CONNECTER();

        
            }
            else if (date1.Text != "" || date2.Text != "" || DropDownList1.SelectedValue == "HorsAuto")
            {
                filtrDate();

                d.CONNECTER();
                SqlDataSource SqlDataSource2 = new SqlDataSource();
                SqlDataSource2.ID = "SqlDataSource2";
                this.Page.Controls.Add(SqlDataSource2);
                SqlDataSource2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
                SqlDataSource2.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, brancheRD,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from vwHorsAuto where numPolice = '" + recherchertxt.Text + "' or id_client='" + recherchertxt.Text + "' or cin_rc='" + recherchertxt.Text + "' ";
                GridView1.DataSource = SqlDataSource2;
                GridView1.DataBind();
                d.con.Close();

              
            }
            else if (date1.Text != "" || date2.Text != "" || DropDownList1.SelectedValue == "Assistance")
            {
                filtrDate();

                d.CONNECTER();
                SqlDataSource SqlDataSource3 = new SqlDataSource();
                SqlDataSource3.ID = "SqlDataSource3";
                this.Page.Controls.Add(SqlDataSource3);
                SqlDataSource3.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AssurancedbConnectionString"].ConnectionString;
                SqlDataSource3.SelectCommand = "select id_affaire , id_client ,( nom_RS +' '+ prenom_FJ) as NomComplet , numPolice, typeAssistance,convert(varchar, dateOperation) as DateOperation ,convert(varchar, dateFin) as Date_Fin,Compagnie,Affectation from vwAssistance where numPolice = '" + recherchertxt.Text + "' or id_client='" + recherchertxt.Text + "' or cin_rc='" + recherchertxt.Text + "' ";
                GridView1.DataSource = SqlDataSource3;
                GridView1.DataBind();
                d.con.Close();

              
            }
=======
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
>>>>>>> 3d8aa206723ebe39f5078df8b5d028b4746044f6
        }
    }
}