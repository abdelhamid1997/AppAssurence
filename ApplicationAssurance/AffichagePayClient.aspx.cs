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
    
    public partial class AffichagePayClient : System.Web.UI.Page
    {
        ADO d = new ADO();

        public void Auto()
        {
            d.CONNECTER();
            SqlCommand cmd = new SqlCommand("select * from wAutoRecouv where id_affaire ='" + Request.QueryString["id_affaire"].ToString() + "'", d.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                idafflbl.Text = dr[0].ToString();
                nomlbl.Text = dr[2].ToString() + " " + dr[3].ToString();
                attestlbl.Text = dr[6].ToString();
                branchelbl.Text = dr[12].ToString();
                compagnielbl.Text = dr[13].ToString();
                periodelbl.Text = "Du " + DateTime.Parse( dr[9].ToString()).ToShortDateString() + "  au " + DateTime.Parse( dr[10].ToString()).ToShortDateString();
                montantlbl.Text = dr[16].ToString() + " DH";
                payerlbl.Text = "";
                restlbl.Text = "";
                nomlbl1.Text = dr[2].ToString() + " " + dr[3].ToString();


                dr.Close();
            }
        }
        public void HorsAuto()
        {
            d.CONNECTER();
            SqlCommand cmd = new SqlCommand("select * from vwHorsAutoRecouv where id_affaire ='" + Request.QueryString["id_affaire"].ToString() + "'", d.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                idafflbl.Text = dr[0].ToString();
                nomlbl.Text = dr[2].ToString() + " " + dr[3].ToString();
                attestlbl.Text = dr[6].ToString();
                branchelbl.Text = dr[12].ToString();
                compagnielbl.Text = dr[13].ToString();
                periodelbl.Text = "Du" + DateTime.Parse(dr[9].ToString()).ToShortDateString() + "  au" + DateTime.Parse(dr[10].ToString()).ToShortDateString();
                montantlbl.Text = dr[16].ToString() + " DH";
                payerlbl.Text = "";
                restlbl.Text = "";
                nomlbl1.Text = dr[2].ToString() + " " + dr[3].ToString();
                Label6.Text = "Type Assistance";

                dr.Close();
            }
            d.DECONNECTER();
        }
        public void Assistance()
        {
            d.CONNECTER();
            SqlCommand cmd = new SqlCommand("select * from vwAssistanceRecouv where id_affaire ='" + Request.QueryString["id_affaire"].ToString() + "'", d.con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                idafflbl.Text = dr[0].ToString();
                nomlbl.Text = dr[2].ToString() + " " + dr[3].ToString();
                attestlbl.Text = dr[6].ToString();
                branchelbl.Text = dr[12].ToString();
                compagnielbl.Text = dr[13].ToString();
                periodelbl.Text = "Du" + DateTime.Parse(dr[9].ToString()).ToShortDateString() + "  au" + DateTime.Parse(dr[10].ToString()).ToShortDateString();
                montantlbl.Text = dr[16].ToString() + " DH";
                payerlbl.Text = "";
                restlbl.Text = "";
                nomlbl1.Text = dr[2].ToString() + " " + dr[3].ToString();
                Label6.Text = "Type Assistance";

                dr.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SelecteValue"].ToString() == "Auto")
            {
                if (!Page.IsPostBack)
                {
                    Auto();
                }
            }
            else if (Session["SelecteValue"].ToString() == "HorsAuto")
            {
                if (!Page.IsPostBack)
                {
                    HorsAuto();
                }
            }
            else if (Session["SelecteValue"].ToString() == "Assistance")
            {
                if (!Page.IsPostBack)
                {
                    Assistance();
                }

            }

        }

    }
}