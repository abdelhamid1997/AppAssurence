using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ApplicationAssurance;



namespace ApplicationAssurance
{
    public partial class modification_cheque : System.Web.UI.Page
    {
        ADO d = new ADO();

        protected void Page_Load(object sender, EventArgs e)
        {

            statutFuture_Lab.Visible = true;
            lab8.Visible = true;
            if (!Page.IsPostBack)
            {
                infos();
            }
            lab9.Visible = false;
            TextBox_dateR.Visible = false;
        }
        
        private void infos()
        {
            d.CONNECTER();
            SqlCommand cmd = new SqlCommand("select * from vwcheque where id_paiment ='" + Request.QueryString["id_paiment"].ToString() + "'", d.con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            IdAffaire_Lab.Text = dr[0].ToString();
            Session["IDP"] = dr[1].ToString();
            Nom_Prenom_Lab.Text = (dr[2] + " " + dr[3]).ToString();
            GSM_Lab.Text = dr[4].ToString();
            numchequeLAB.Text = dr[6].ToString();
            Banque_Lab.Text = dr[5].ToString();
            Montant_cheque_Lab.Text = dr[7].ToString();
            Date_remise.Text = DateTime.Parse(dr[8].ToString()).ToShortDateString();
            Statut_Lab.Text = dr[9].ToString();
            dr.Close();

        }
        /////////////// les bouttons////////////
        protected void btn1_click(object sender, EventArgs e)
        {

            statutFuture_Lab.Text = "à remettre";
            lab9.Visible = true;
            TextBox_dateR.Visible = true;

        }
        protected void btn3_click(object sender, EventArgs e)
        {

            statutFuture_Lab.Text = "Remis";

        }
        protected void btn4_click(object sender, EventArgs e)
        {

            statutFuture_Lab.Text = "Rejeter";

        }


        /*private void modification_statut()
        {
            int id_pai = 0;

            d.CONNECTER();

            SqlCommand cmd = new SqlCommand("select id_paiment from cheque where Num_cheque ='" + numchequeLAB.Text + "'", d.con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            id_pai = int.Parse(dr.ToString());


            dr.Close();
        }*/
        private void update_statut()
        {
            
            d.CONNECTER();
          
                d.cmd = new SqlCommand("Update cheque set Statut ='" + statutFuture_Lab.Text + "' where id_paiment ='" +int.Parse(Session["IDP"].ToString()) + "' ", d.con);
                d.cmd.ExecuteNonQuery();
           


        }
        private void update_dateR()
        {
            
            d.CONNECTER();
           
                d.cmd = new SqlCommand("Update cheque set Statut ='" + statutFuture_Lab.Text + "',Date_Remise='" + DateTime.Parse(TextBox_dateR.Text) + "' where id_paiment ='" +int.Parse(Session["IDP"].ToString()) + "' ", d.con);               
                d.cmd.ExecuteNonQuery();
         
           
        }
        protected void btn5_click(object sender, EventArgs e)
        {
            //int id_pai = 0;

            //d.CONNECTER();

            //SqlCommand cmd = new SqlCommand("select id_paiment from cheque where Num_cheque ='" + numchequeLAB.Text + "'", d.con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //dr.Read();

            //    id_pai = int.Parse(dr.ToString());


            //dr.Close();

            if (statutFuture_Lab.Text != "")
            {
                if (statutFuture_Lab.Text != "à remettre")
                {
                    update_statut();
                    Response.Write("<script> alert('succée!!') </script>");
                }
                else
                {
                    if (TextBox_dateR.Text != "" && DateTime.Parse(TextBox_dateR.Text) > DateTime.Parse(Date_remise.Text))
                    {
                        update_dateR();
                        Response.Write("<script> alert('succée!!') </script>");
                        
                    }
                    else
                    {
                        Response.Write("<script> alert('la date de remis future est null ou inferieure a la date premmiere!!') </script>");
                        
                    }
                }
            }
            else
            {
                Response.Write("<script> alert('imposible de mettre une modification sur le cheque car le statut future est null.') </script>");
            }
        }

        protected void btn_Retour_Click(object sender, EventArgs e)
        {
            Response.Redirect("etatRemis.aspx");
        }
    }
}