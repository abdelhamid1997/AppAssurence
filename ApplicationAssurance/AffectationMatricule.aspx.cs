using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services.Description;
using System.Security.Principal;
using ApplicationAssurance;

namespace ApplicationAssurance
{
    public partial class AffectationMatricule : System.Web.UI.Page
    {
        ADO d = new ADO();


        public void remplir()
        {
            d.CONNECTER();
            SqlCommand cmd = new SqlCommand("select * from vwChangImma where id_affaire ='" + Request.QueryString["id_affaire"].ToString() + "'", d.con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            idclienttxt.Text = dr[1].ToString();
            nomtxt.Text = dr[2].ToString() + " " + dr[3].ToString();
            cintxt.Text = dr[4].ToString();
           soustxt.Text = dr[6].ToString();
            compagnietxt.Text = dr[7].ToString();
            Affectxt.Text = dr[8].ToString();
            droptypeAff.SelectedValue = dr[9].ToString();
            naturetxt.Text = dr[10].ToString();
            dateopetxt.Text = DateTime.Parse( dr[11].ToString()).ToShortDateString();
            datefintxt.Text = DateTime.Parse(dr[12].ToString()).ToShortDateString();
            datedebuttxt.Text = DateTime.Parse(dr[13].ToString()).ToShortDateString();
            numpolicetxt.Text = dr[5].ToString();
            textImmatriculation.Text = dr[14].ToString();
            textMarque.Text= dr[15].ToString();
            textUsage.Text = dr[16].ToString();
            textDateMec.Text = DateTime.Parse(dr[17].ToString()).ToShortDateString();



            idclienttxt.Enabled = false;
            nomtxt.Enabled = false;
            cintxt.Enabled = false;
            soustxt.Enabled = false;
            compagnietxt.Enabled = false; ;
            Affectxt.Enabled = false;
            droptypeAff.Enabled = false;
            naturetxt.Enabled = false;



            dr.Close();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                remplir();
            }
        }
 

        //MethodMoney
        public string AddMoney()
        {
            string ret = "0";
            d.cmd.Parameters.Clear();

            d.cmd = new SqlCommand("select TOP 1 * from affaire order by id_affaire desc", d.con);
            d.dr = d.cmd.ExecuteReader();
            int ida;
            if (d.dr.Read())
            {
                ida = Convert.ToInt32(d.dr[0].ToString());
                d.dr.Close();
                d.cmd.CommandType = CommandType.StoredProcedure;
                d.cmd.CommandText = "INSERTMoney";
                d.cmd.Parameters.Add("@idAff", SqlDbType.Int).Value = ida;
                d.cmd.Parameters.Add("@Montant", SqlDbType.Decimal).Value = decimal.Parse(montanttxt.Text);
                d.cmd.Parameters.Add("@Primenette", SqlDbType.Decimal).Value = decimal.Parse(primenettxt.Text);
                d.cmd.Parameters.Add("@taxeEvRc", SqlDbType.Decimal).Value = decimal.Parse(taxeevrctxt.Text);
                d.cmd.Parameters.Add("@taxeEvGa", SqlDbType.Decimal).Value = decimal.Parse(taxeevga.Text);
                d.cmd.Parameters.Add("@accessoire", SqlDbType.Decimal).Value = decimal.Parse(accessoiretxt.Text);
                d.cmd.Parameters.Add("@TVA", SqlDbType.Decimal).Value = decimal.Parse(tvatxt.Text);
                d.cmd.Parameters.Add("@taxe1", SqlDbType.Decimal).Value = decimal.Parse(taxe1txt.Text);
                d.cmd.Parameters.Add("@taxe2", SqlDbType.Decimal).Value = decimal.Parse(taxe2txt.Text);
                SqlParameter ok = new SqlParameter("@OK", SqlDbType.Int);
                ok.Direction = ParameterDirection.Output;
                d.cmd.Parameters.Add(ok);
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                ret = ok.Value.ToString();
            }
            return ret;
        }
        protected void ButtonEnregistrer_Click(object sender, EventArgs e)
        {
            d.CONNECTER();
            SqlCommand cmd = new SqlCommand("insert into affaire (id_client,souscripteur,dateOperation,datedebut,datefin,numPolice,natureOperation,branche,Compagnie,TypeAff,Affectation) values('" + idclienttxt.Text + "','" + soustxt.Text + "','" + DateTime.Parse(dateopetxt.Text) + "','" + DateTime.Parse(datedebuttxt.Text) + "','" + DateTime.Parse(datefintxt.Text) + "','" + numpolicetxt.Text + "','" + naturetxt.Text + "','Auto','" + compagnietxt.Text + "','" + droptypeAff.SelectedValue+ "','" + Affectxt.Text + "') ", d.con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("select TOP 1 * from affaire order by id_affaire desc", d.con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int ida;
                ida = Convert.ToInt32(dr[0].ToString());
                cmd = new SqlCommand("insert into vehicule values('" +textImmatriculation.Text + "','" + ida + "','" + textMarque.Text + "','" + textUsage.Text + "','" + textDateMec.Text + "')", d.con);
                cmd = new SqlCommand("insert into affaireAuto values('" + numattestxt.Text + "','0','" + ida + "')", d.con);

                dr.Close();
                cmd.ExecuteNonQuery();
                AddMoney();
                Response.Write("<script>alert('Les information sont bien enregistrer')</script>");
                Response.Write("<script>window.close()</script>");
            }
        }
    }
}