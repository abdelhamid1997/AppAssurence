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
    public partial class AffectationRenouvellement : System.Web.UI.Page
    {
        ADO d = new ADO();

        SqlConnection cnx = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Assurancedb;Integrated Security=True");

        public void Auto()
        {
            cnx.Open();
            SqlCommand cmd = new SqlCommand("select * from vwAuto where id_affaire ='" + Request.QueryString["id_affaire"].ToString() + "'", cnx);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            idclienttxt.Text = dr[1].ToString();
            compagnietxt.Text = dr[13].ToString();
            cintxt.Text = dr[4].ToString();
            nomtxt.Text = dr[2].ToString() + " " + dr[3].ToString();
            soustxt.Text = dr[7].ToString();
            Affectxt.Text = dr[14].ToString();
            naturetxt.Text = dr[11].ToString();
            dateopetxt.Text = DateTime.Parse(dr[8].ToString()).ToShortDateString();
            datedebuttxt.Text = DateTime.Parse(dr[9].ToString()).ToShortDateString();
            datefintxt.Text = DateTime.Parse(dr[10].ToString()).ToShortDateString();
            numpolicetxt.Text = dr[5].ToString();
            numattestxt.Text = dr[6].ToString();
           droptypeAff.SelectedValue = dr[15].ToString();

            dropbrancherd.Visible = false;
            droptypeAssistace.Visible = false;
            brancherdlbl.Visible = false;
            typelbl.Visible = false;

            idclienttxt.Enabled = false;
            compagnietxt.Enabled = false;
            cintxt.Enabled = false;
            nomtxt.Enabled = false;
            soustxt.Enabled = false;
            Affectxt.Enabled = false;
            naturetxt.Enabled = false;

            dr.Close();
        }

        public void HorsAuto()
        {
            cnx.Open();
            SqlCommand cmd = new SqlCommand("select * from vwHorsAuto where id_affaire ='" + Request.QueryString["id_affaire"].ToString() + "'", cnx);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();


            idclienttxt.Text = dr[1].ToString();
            compagnietxt.Text = dr[13].ToString();
            cintxt.Text = dr[4].ToString();
            nomtxt.Text = dr[2].ToString() + " " + dr[3].ToString();
            soustxt.Text = dr[7].ToString();
            Affectxt.Text = dr[14].ToString();
            naturetxt.Text = dr[11].ToString();
            dateopetxt.Text = DateTime.Parse(dr[8].ToString()).ToShortDateString();
            datedebuttxt.Text = DateTime.Parse(dr[9].ToString()).ToShortDateString();
            datefintxt.Text = DateTime.Parse(dr[10].ToString()).ToShortDateString();
            numpolicetxt.Text = dr[5].ToString();
           dropbrancherd.SelectedValue = dr[6].ToString();


            idclienttxt.Enabled = false;
            compagnietxt.Enabled = false;
            cintxt.Enabled = false;
            nomtxt.Enabled = false;
            soustxt.Enabled = false;
            Affectxt.Enabled = false;
            naturetxt.Enabled = false;

            numattestxt.Visible = false;
            numattestlbl.Visible = false;
            droptypeAssistace.Visible = false;
            typelbl.Visible = false;

            dr.Close();



        }

        public void Assistance()
        {
            cnx.Open();
            SqlCommand cmd = new SqlCommand("select * from vwAssistance where id_affaire ='" + Request.QueryString["id_affaire"].ToString() + "'", cnx);
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();


            idclienttxt.Text = dr[1].ToString();
            compagnietxt.Text = dr[11].ToString();
            cintxt.Text = dr[4].ToString();
            nomtxt.Text = dr[2].ToString() + " " + dr[3].ToString();
            soustxt.Text = dr[7].ToString();
            Affectxt.Text = dr[12].ToString();
            naturetxt.Text = dr[13].ToString();
            dateopetxt.Text = DateTime.Parse(dr[8].ToString()).ToShortDateString();
            datedebuttxt.Text = DateTime.Parse(dr[9].ToString()).ToShortDateString();
            datefintxt.Text = DateTime.Parse(dr[10].ToString()).ToShortDateString();
            numpolicetxt.Text = dr[5].ToString();
            droptypeAssistace.SelectedValue = dr[6].ToString();


            idclienttxt.Enabled = false;
            compagnietxt.Enabled = false;
            cintxt.Enabled = false;
            nomtxt.Enabled = false;
            soustxt.Enabled = false;
            Affectxt.Enabled = false;
            naturetxt.Enabled = false;




            numattestxt.Visible = false;
            numattestlbl.Visible = false;
            dropbrancherd.Visible = false;
            brancherdlbl.Visible = false;

            dr.Close();
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
        //Method Attestation
        public int NumAtt()
        {
            d.CONNECTER();
            int cpt;
            d.cmd.CommandText = "select Count(numAttestation) from affaireAuto where numAttestation = '" + numattestxt.Text + "'";
            d.cmd.Connection = d.con;
            cpt = (int)d.cmd.ExecuteScalar();
            return cpt;

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
          
            if (Session["SelecteValue"].ToString() == "Auto" && NumAtt() == 0)
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("insert into affaire (id_client,souscripteur,dateOperation,datedebut,datefin,numPolice,natureOperation,branche,Compagnie,TypeAff,Affectation) values('" + idclienttxt.Text + "','" + soustxt.Text + "','" + DateTime.Parse(dateopetxt.Text) + "','" + DateTime.Parse(datedebuttxt.Text) + "','" + DateTime.Parse(datefintxt.Text) + "','" + numpolicetxt.Text + "','" + naturetxt.Text + "','Auto','" + compagnietxt.Text + "','" +droptypeAff.SelectedValue + "','" + Affectxt.Text + "') ", cnx);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("select TOP 1 * from affaire order by id_affaire desc", cnx);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int ida;
                    ida = Convert.ToInt32(dr[0].ToString());
                    cmd = new SqlCommand("insert into affaireAuto values('" + numattestxt.Text + "','0','" + ida + "')", cnx);
                    dr.Close();
                    cmd.ExecuteNonQuery();
                    //decimal var = 50;
                    //SqlCommand cmd1 = new SqlCommand("insert into montant values('" + ida + "','" + montanttxt.Text + "','" + primenettxt.Text + "','" + tvatxt.Text + "','" + taxeevrctxt.Text + "','" + taxeevga.Text + "','" + accessoiretxt.Text + "','" + taxe1txt.Text + "','"+var+"','" + netapayertxt.Text + "')", cnx);
                    //cmd1.ExecuteNonQuery();
                    AddMoney();
                    Response.Write("<script>alert('Les information sont bien enregistrer')</script>");
                    Response.Write("<script>window.close()</script>");
                }
                else
                {
                    Response.Write("<script>alert('Les information ne sont pas enregistrer')</script>");

                }






            }
            else if (Session["SelecteValue"].ToString() == "HorsAuto")
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("insert into affaire (id_client,souscripteur,dateOperation,datedebut,datefin,numPolice,natureOperation,branche,Compagnie,TypeAff,Affectation) values('" + idclienttxt.Text + "','" + soustxt.Text + "','" + DateTime.Parse(dateopetxt.Text) + "','" + DateTime.Parse(datedebuttxt.Text) + "','" + DateTime.Parse(datefintxt.Text) + "','" + numpolicetxt.Text + "','" + naturetxt.Text + "','Auto','" + compagnietxt.Text + "','" + droptypeAff.SelectedValue + "','" + Affectxt.Text + "') ", cnx);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("select TOP 1 * from affaire order by id_affaire desc", cnx);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int ida;
                    ida = Convert.ToInt32(dr[0].ToString());
                    cmd = new SqlCommand("insert into affaireHorsAuto values('" + dropbrancherd.SelectedValue + "','" + ida + "')", cnx);
                    dr.Close();
                    //decimal var = 50;
                    cmd.ExecuteNonQuery();
                    //SqlCommand cmd1 = new SqlCommand("insert into montant values('" + ida + "','" + montanttxt.Text + "','" + primenettxt.Text + "','" + tvatxt.Text + "','" + taxeevrctxt.Text + "','" + taxeevga.Text + "','" + accessoiretxt.Text + "','" + taxe1txt.Text + "','" + var +"','" + netapayertxt.Text + "')", cnx);
                    //cmd1.ExecuteNonQuery();
                    AddMoney();
                    Response.Write("<script>alert('Les information sont bien enregistrer')</script>");
                    Response.Write("<script>window.close()</script>");
                }
                else
                {
                    Response.Write("<script>alert('Les information ne sont pas enregistrer')</script>");

                }






            }
            else if (Session["SelecteValue"].ToString() == "Assistance")
            {

                SqlCommand cmd = new SqlCommand("insert into affaire (id_client,souscripteur,dateOperation,datedebut,datefin,numPolice,natureOperation,branche,Compagnie,TypeAff,Affectation) values('" + idclienttxt.Text + "','" + soustxt.Text + "','" + DateTime.Parse(dateopetxt.Text) + "','" + DateTime.Parse(datedebuttxt.Text) + "','" + DateTime.Parse(datefintxt.Text) + "','" + numpolicetxt.Text + "','" + naturetxt.Text + "','Auto','" + compagnietxt.Text + "','" + droptypeAff.SelectedValue+ "','" + Affectxt.Text + "') ", cnx);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("select TOP 1 * from affaire order by id_affaire desc", cnx);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int ida;
                    ida = Convert.ToInt32(dr[0].ToString());
                    cmd = new SqlCommand("insert into AffAssistance values('" + droptypeAssistace.SelectedValue+ "','" + ida + "')", cnx);
                    dr.Close();
                    cmd.ExecuteNonQuery();
                    //SqlCommand cmd1 = new SqlCommand("insert into montant values('" + ida + "','" + montanttxt.Text + "','" + primenettxt.Text + "','" + tvatxt.Text + "','" + taxeevrctxt.Text + "','" + taxeevga.Text + "','" + accessoiretxt.Text + "','" + taxe1txt.Text + "',' ','" + netapayertxt.Text + "')", cnx);
                    //cmd1.ExecuteNonQuery();
                    AddMoney();
                    Response.Write("<script>alert('Les information sont bien enregistrer')</script>");
                    Response.Write("<script>window.close()</script>");
                }
                else
                {
                    Response.Write("<script>alert('Les information ne sont pas enregistrer')</script>");

                }






            }
            cnx.Close();
        }
    }
}