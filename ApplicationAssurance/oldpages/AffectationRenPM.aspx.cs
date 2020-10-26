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

namespace Avenent
{
    public partial class AffectationRenPM : System.Web.UI.Page
    {
        ADO d = new ADO();

        SqlConnection cnx = new SqlConnection(@"Data source=DESKTOP-65ILK58\SQLEXPRESS; Initial catalog=Assurancedb; Integrated security=true");

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
                dateopetxt.Text =DateTime.Parse( dr[8].ToString()).ToShortDateString();
                datedebuttxt.Text = DateTime.Parse(dr[9].ToString()).ToShortDateString();
                datefintxt.Text = DateTime.Parse(dr[10].ToString()).ToShortDateString();
                numpolicetxt.Text = dr[5].ToString();
                numattestxt.Text = dr[6].ToString();
                typeAff.Text = dr[15].ToString();

            brancherdtxt.Visible = false;
                typeassitxt.Visible = false;
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
            dateopetxt.Text = dr[8].ToString();
            datedebuttxt.Text = dr[9].ToString();
            datefintxt.Text = dr[10].ToString();
            numpolicetxt.Text = dr[5].ToString();
            brancherdtxt.Text = dr[6].ToString();


            idclienttxt.Enabled = false;
            compagnietxt.Enabled = false;
            cintxt.Enabled = false;
            nomtxt.Enabled = false;
            soustxt.Enabled = false;
            Affectxt.Enabled = false;
            naturetxt.Enabled = false;

            numattestxt.Visible = false;
            numattestlbl.Visible = false;
            typeassitxt.Visible = false;
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
            dateopetxt.Text = dr[8].ToString();
            datedebuttxt.Text = dr[9].ToString();
            datefintxt.Text = dr[10].ToString();
            numpolicetxt.Text = dr[5].ToString();
            typeassitxt.Text = dr[6].ToString();


            idclienttxt.Enabled = false;
            compagnietxt.Enabled = false;
            cintxt.Enabled = false;
            nomtxt.Enabled = false;
            soustxt.Enabled = false;
            Affectxt.Enabled = false;
            naturetxt.Enabled = false;




            numattestxt.Visible = false;
            numattestlbl.Visible = false;
            brancherdtxt.Visible = false;
            brancherdlbl.Visible = false;

            dr.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SelecteValue"].ToString() == "Auto")
            {
               
                    Auto();
                
            }
            else if(Session["SelecteValue"].ToString() == "HorsAuto")
            {
                HorsAuto();
            }
            else if (Session["SelecteValue"].ToString() == "Assistance") 
            {
                Assistance();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["SelecteValue"].ToString() == "Auto" && NumAtt() == 0 )
            {
                
                SqlCommand cmd = new SqlCommand("insert into affaire (id_client,souscripteur,dateOperation,datedebut,datefin,numPolice,natureOperation,branche,Compagnie,TypeAff,Affectation) values('" + idclienttxt.Text + "','" + soustxt.Text + "','" + DateTime.Parse(dateopetxt.Text) + "','" + DateTime.Parse(datedebuttxt.Text) + "','" + DateTime.Parse(datefintxt.Text) + "','" + numpolicetxt.Text + "','" +naturetxt.Text+ "','Auto','" + compagnietxt.Text + "','" + typeAff.Text + "','" + Affectxt.Text + "') ", cnx);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("select TOP 1 * from affaire order by id_affaire desc", cnx);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int ida;
                    ida = Convert.ToInt32(dr[0].ToString());
                    cmd = new SqlCommand("insert into affaireAuto values('" + numattestxt.Text+ "','0','" + ida +  "')", cnx);
                    dr.Close();
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand("insert into montant values('" + ida + "','" + montanttxt.Text + "','" + primenettxt.Text + "','" + tvatxt.Text + "','" + taxeevrctxt.Text + "','" + taxeevga.Text + "','" + accessoiretxt.Text + "','" + taxe1txt.Text + "',' ','" + netapayertxt.Text + "')", cnx);
                    cmd1.ExecuteNonQuery();
                    Response.Write("<script>alert('Les information sont bien enregistrer')</script>");
                    Response.Write("<script>window.close()</script>");
                }
                else
                {
                    Response.Write("<script>alert('Les information ne sont pas enregistrer')</script>");

                }




               

            }
            else if(Session["SelecteValue"].ToString() == "HorsAuto")
            {
            
                SqlCommand cmd = new SqlCommand("insert into affaire (id_client,souscripteur,dateOperation,datedebut,datefin,numPolice,natureOperation,branche,Compagnie,TypeAff,Affectation) values('" + idclienttxt.Text + "','" + soustxt.Text + "','" + DateTime.Parse(dateopetxt.Text) + "','" + DateTime.Parse(datedebuttxt.Text) + "','" + DateTime.Parse(datefintxt.Text) + "','" + numpolicetxt.Text + "','" + naturetxt.Text + "','Auto','" + compagnietxt.Text + "','" + typeAff.Text + "','" + Affectxt.Text + "') ", cnx);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("select TOP 1 * from affaire order by id_affaire desc", cnx);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int ida;
                    ida = Convert.ToInt32(dr[0].ToString());
                    cmd = new SqlCommand("insert into affaireHorsAuto values('" + brancherdtxt.Text + "','" + ida + "')", cnx);
                    dr.Close();
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand("insert into montant values('" + ida + "','" + montanttxt.Text + "','" + primenettxt.Text + "','" + tvatxt.Text + "','" + taxeevrctxt.Text + "','" + taxeevga.Text + "','" + accessoiretxt.Text + "','" + taxe1txt.Text + "',' ','" + netapayertxt.Text + "')", cnx);
                    cmd1.ExecuteNonQuery();
                    Response.Write("<script>alert('Les information sont bien enregistrer')</script>");
                    Response.Write("<script>window.close()</script>");
                }
                else
                {
                    Response.Write("<script>alert('Les information ne sont pas enregistrer')</script>");

                }




                

            }
            else if(Session["SelecteValue"].ToString() == "Assistance")
            {
              
                SqlCommand cmd = new SqlCommand("insert into affaire (id_client,souscripteur,dateOperation,datedebut,datefin,numPolice,natureOperation,branche,Compagnie,TypeAff,Affectation) values('" + idclienttxt.Text + "','" + soustxt.Text + "','" + DateTime.Parse(dateopetxt.Text) + "','" + DateTime.Parse(datedebuttxt.Text) + "','" + DateTime.Parse(datefintxt.Text) + "','" + numpolicetxt.Text + "','" + naturetxt.Text + "','Auto','" + compagnietxt.Text + "','" + typeAff.Text + "','" + Affectxt.Text + "') ", cnx);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("select TOP 1 * from affaire order by id_affaire desc", cnx);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int ida;
                    ida = Convert.ToInt32(dr[0].ToString());
                    cmd = new SqlCommand("insert into AffAssistance values('" + typeassitxt.Text + "','" + ida + "')", cnx);
                    dr.Close();
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand("insert into montant values('" + ida + "','" + montanttxt.Text + "','" + primenettxt.Text + "','" + tvatxt.Text + "','" + taxeevrctxt.Text + "','" + taxeevga.Text + "','" + accessoiretxt.Text + "','" + taxe1txt.Text + "',' ','" + netapayertxt.Text + "')", cnx);
                    cmd1.ExecuteNonQuery();
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

        protected void TextBox13_TextChanged(object sender, EventArgs e)
        {

        }
    }
}