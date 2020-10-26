using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Avenent
{
    public partial class AffectationImmaMP : System.Web.UI.Page
    {
        SqlConnection cnx = new SqlConnection(@"Data source=DESKTOP-65ILK58\SQLEXPRESS; Initial catalog=Assurancedb; Integrated security=true");

        public void remplir()
        {
            cnx.Open();
            SqlCommand cmd = new SqlCommand("select * from vwChangImma where id_affaire ='" + Request.QueryString["id_affaire"].ToString() + "'", cnx);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            idclienttxt.Text = dr[1].ToString();
            nomtxt.Text = dr[2].ToString()+" "+dr[3].ToString();
            cintxt.Text = dr[4].ToString();
            soutxt.Text = dr[6].ToString();
            compagnietxt.Text = dr[7].ToString();
            affectationtxt.Text = dr[8].ToString();
            Typeafftxt.Text = dr[9].ToString();
            natureopetxt.Text = dr[10].ToString();
            dateopetxt.Text = dr[11].ToString();
            datefintxt.Text = dr[12].ToString();
            datedebuttxt.Text = dr[13].ToString();
            numpolictxt.Text = dr[5].ToString();
            immatxt.Text = dr[14].ToString();
            marqtxt.Text = dr[15].ToString();
            usagetxt.Text = dr[16].ToString();
            datemectxt.Text = dr[17].ToString();



            idclienttxt.Enabled = false;
            nomtxt.Enabled = false;
            cintxt.Enabled = false;
            soutxt.Enabled = false;
            compagnietxt.Enabled = false; ;
            affectationtxt.Enabled = false;
            Typeafftxt.Enabled = false;
            natureopetxt.Enabled = false;



            dr.Close();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                remplir();
            }
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
          
            SqlCommand cmd = new SqlCommand("insert into affaire (id_client,souscripteur,dateOperation,datedebut,datefin,numPolice,natureOperation,branche,Compagnie,TypeAff,Affectation) values('"+idclienttxt.Text+"','"+soutxt.Text+"','"+DateTime.Parse(dateopetxt.Text)+"','"+ DateTime.Parse(datedebuttxt.Text)+"','"+ DateTime.Parse(datefintxt.Text)+"','"+numpolictxt.Text+"','"+natureopetxt.Text+"','Auto','"+compagnietxt.Text+"','"+Typeafftxt.Text+"','"+affectationtxt.Text+"') ", cnx);     
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("select TOP 1 * from affaire order by id_affaire desc", cnx);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int ida;
                ida = Convert.ToInt32(dr[0].ToString());
                cmd = new SqlCommand("insert into vehicule values('" +immatxt.Text+ "','" + ida + "','"+marqtxt.Text+"','"+usagetxt.Text+"','"+datemectxt.Text+"')", cnx);
                dr.Close();
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("insert into montant values('"+ ida + "','"+montanttxt.Text+"','"+primenettxt.Text+"','"+tvatxt.Text+ "','" + taxeevrctxt.Text + "','" + taxeevga.Text+"','"+accessoiretxt.Text+"','"+taxe1txt.Text+"',' ','"+netapayertxt.Text+"')", cnx);
                cmd1.ExecuteNonQuery();
                Response.Write("<script>alert('Les information sont bien enregistrer')</script>");
                Response.Write("<script>window.close()</script>");
            }
            else 
                {
                Response.Write("<script>alert('Les information ne sont pas enregistrer')</script>");

            }




            cnx.Close();
         
            
        }
    }
}