using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Web.Services.Description;

namespace ApplicationAssurance
{
    public partial class SaisieAff : System.Web.UI.Page
    {
        ADO d = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
            ConducteurArea.Visible = false;
            HorsAutoArea.Visible = false;
            AssistanceArea.Visible = false;
            if(checkboxConducteur.Checked == false)
            {
                ConducteurArea.Visible = true;
            }
        }

        protected void checkboxConducteur_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxConducteur.Checked == false)
            {
                ConducteurArea.Visible = true;
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");

            }
            else
            {
                ConducteurArea.Visible = false;
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");

            }
        }

        protected void DropDownListChoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListChoix.SelectedValue == "Auto")
            {
                AutoArea.Visible = true;
                VehiculeArea.Visible = true;
                AssistanceArea.Visible = false;
                HorsAutoArea.Visible = false;
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");

            }
            else if (DropDownListChoix.SelectedValue == "Hors_Auto")
            {
                HorsAutoArea.Visible = true;
                VehiculeArea.Visible = false;
                AutoArea.Visible = false;
                AssistanceArea.Visible = false;
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");

            }
            else if (DropDownListChoix.SelectedValue == "Assistance")
            {
                HorsAutoArea.Visible = false;
                VehiculeArea.Visible = false;
                AutoArea.Visible = false;
                AssistanceArea.Visible = true;
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");

            }
        }

        protected void ButtonRecherchBTNAuto_Click(object sender, EventArgs e)
        {
            d.CONNECTER();
            if (DropDownListRecherchPar.SelectedValue == "ID")
            {
                d.cmd.CommandText = "select * from client  where id_client ='" + TextBoxRecherch.Text + "'";
                d.cmd.Connection = d.con;
                d.dr = d.cmd.ExecuteReader();
                
            }

            else if (DropDownListRecherchPar.SelectedValue == "CIN")
            {
                d.cmd.CommandText = "select * from client  where cin_rc ='" + TextBoxRecherch.Text + "'";
                d.cmd.Connection = d.con;
                d.dr = d.cmd.ExecuteReader();
            }
            if (d.dr.Read())
            {
                TextBoxId.Text = d.dr[0].ToString();
                TextBoxCIN.Text = d.dr[1].ToString();
                TextBoxNomRS.Text = d.dr[2].ToString();
                TextBoxPrenomFJ.Text = d.dr[3].ToString();
                TextBoxGSM.Text = d.dr[4].ToString();
                TextBoxDateN.Text = DateTime.Parse(d.dr[5].ToString()).ToShortDateString();
                TextBoxVille.Text = d.dr[6].ToString();
                TextBoxAdress.Text = d.dr[7].ToString();
                TextBoxEmail.Text = d.dr[8].ToString();
                DropDownListActivite.SelectedValue = d.dr[9].ToString();
                DropDownListProfil.SelectedValue = d.dr[10].ToString();
                DropDownListTypePerson.SelectedValue = d.dr[11].ToString();
                ErrorSearch.InnerText = null;
                alertdvfail.Attributes.Add("class", "alterdvfail");


            }
            else
            {
                ErrorSearch.InnerText = "N'existe pas";
            }
            alertdvfail.Attributes.Add("class", "alterdvfail");
            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            d.DECONNECTER();
        }

        //Procedure Stocke insert

        public string AddMoney()
        {
            string ret = "0";
            d.cmd.Parameters.Clear();

            d.cmd = new SqlCommand("select TOP 1 * from affaire order by id_affaire desc",d.con);
            d.dr = d.cmd.ExecuteReader();
            int ida = 0;
            if (d.dr.Read())
            {
                ida = Convert.ToInt32(d.dr[0].ToString());
                d.dr.Close();
                d.cmd.CommandType = CommandType.StoredProcedure;
                d.cmd.CommandText = "INSERTMoney";
                d.cmd.Parameters.Add("@idAff", SqlDbType.Int).Value = ida;
                d.cmd.Parameters.Add("@Montant", SqlDbType.Decimal).Value = decimal.Parse(TextBoxMontant.Text);
                d.cmd.Parameters.Add("@Primenette", SqlDbType.Decimal).Value = decimal.Parse(TextBoxPrimeNette.Text);
                d.cmd.Parameters.Add("@taxeEvRc", SqlDbType.Decimal).Value = decimal.Parse(TextBoxEvRc.Text);
                d.cmd.Parameters.Add("@taxeEvGa", SqlDbType.Decimal).Value = decimal.Parse(TextBoxEvGa.Text);
                d.cmd.Parameters.Add("@accessoire", SqlDbType.Decimal).Value = decimal.Parse(TextBoxAccessoire.Text);
                d.cmd.Parameters.Add("@TVA", SqlDbType.Decimal).Value = decimal.Parse(TextBoxTVA.Text);
                d.cmd.Parameters.Add("@taxe1", SqlDbType.Decimal).Value = decimal.Parse(TextBoxTAXE1.Text);
                d.cmd.Parameters.Add("@taxe2", SqlDbType.Decimal).Value = decimal.Parse(TextBoxTAXE2.Text);
                d.cmd.Parameters.Add("@Net_A_Payer", SqlDbType.Decimal).Value = decimal.Parse(TextBoxNetApayer.Text);
                SqlParameter ok = new SqlParameter("@OK", SqlDbType.Int);
                ok.Direction = ParameterDirection.Output;
                d.cmd.Parameters.Add(ok);
                d.cmd.Connection = d.con;
                d.cmd.ExecuteNonQuery();
                ret = ok.Value.ToString();
            }
            return ret;
        }

        //AddCreditSaisieAff
        public void InsertCredit()
        {
            d.CONNECTER();
            d.cmd.Parameters.Clear();

            d.cmd = new SqlCommand("select TOP 1 * from affaire order by id_affaire desc", d.con);
            d.dr = d.cmd.ExecuteReader();
            int ida = 0;
            if (d.dr.Read())
            {
                ida = Convert.ToInt32(d.dr[0].ToString());
                d.dr.Close();
            }
            d.cmd.Parameters.Clear();
            d.cmd.CommandType = CommandType.StoredProcedure;
            d.cmd.CommandText = "InsertCreditAff";
            d.cmd.Parameters.Add("@idAff",SqlDbType.Int).Value= ida;
            d.cmd.Parameters.Add("@MontantCredit", SqlDbType.Decimal).Value =decimal.Parse(TextBoxMontant.Text);
            d.cmd.Connection = d.con;
            d.cmd.ExecuteNonQuery();

        }
        



        //MethodIfClientExist
        public bool IfClientExist()
        {
            bool A = false;
            d.CONNECTER();
           
                d.cmd.CommandText = "select * from client where id_client ='" + TextBoxId.Text + "'";
                d.cmd.Connection = d.con;
                d.dr = d.cmd.ExecuteReader();
                if (d.dr.Read())
                {
                    A = true;
                }
                else
                {
                    A = false;
                }
                d.dr.Close();
            return A;

        }
        //Attestation
        public int NumAtt()
        {
            d.CONNECTER();
            int cpt;
            d.cmd.CommandText = "select Count(numAttestation) from affaireAuto where numAttestation = '" + TextBoxNumAtt.Text + "'";
            d.cmd.Connection = d.con;
            cpt = (int)d.cmd.ExecuteScalar();
            return cpt;

        }

        //NumPermis

        public int NumPermis()
        {
            d.CONNECTER();
            int nbrP;
            d.cmd.CommandText = "select Count(numPermis) from conducteur where numPermis = '" +TextBoxNumP.Text+ "'";
            d.cmd.Connection = d.con;
            nbrP = (int)d.cmd.ExecuteScalar();
            return nbrP;

        }
        //Immatriculation
        public int NbrImmatriculation()
        {
            d.CONNECTER();
            int nbrIm;
            d.cmd.CommandText = "select Count(Immatriculation) from vehicule where Immatriculation = '"+TextBoxImmatriculation.Text+"'";
            d.cmd.Connection = d.con;
            nbrIm = (int)d.cmd.ExecuteScalar();
            return nbrIm;
        }

        public bool InsertClientAff()
        {
            d.CONNECTER();
            bool result = false;
            if (DateTime.Parse(TextBoxDateOperation.Text) > DateTime.Parse(TextBoxDateDebut.Text) || DateTime.Parse(TextBoxDateDebut.Text) > DateTime.Parse(TextBoxDateFin.Text))
            {              
                result = false;

            } else
            {
                    if (IfClientExist() == false)
                    {
                        d.cmd.CommandText = "insert into client values('" + TextBoxId.Text + "','" + TextBoxCIN.Text + "','" + TextBoxNomRS.Text + "','" + TextBoxPrenomFJ.Text + "','" + TextBoxGSM.Text + "','" + DateTime.Parse(TextBoxDateN.Text)+ "','" + TextBoxVille.Text + "','" + TextBoxAdress.Text + "','" + TextBoxEmail.Text + "','" + DropDownListActivite.SelectedValue + "','" + DropDownListProfil.SelectedValue + "','" + DropDownListTypePerson.SelectedValue + "')";
                        d.cmd.Connection = d.con;
                        d.cmd.ExecuteNonQuery();

                        d.cmd.CommandText = "insert into affaire(id_client,souscripteur,dateOperation,datedebut,datefin,numPolice,natureOperation,branche,Operateur,Compagnie,typeAff,Affectation,Reglement_cabinet) values('" + TextBoxId.Text + "','" + TextBoxSouscripteur.Text + "','" + DateTime.Parse(TextBoxDateOperation.Text) + "','" + DateTime.Parse(TextBoxDateDebut.Text) + "','" + DateTime.Parse(TextBoxDateFin.Text) + "','" + TextBoxNumPolice.Text + "','Affaire nouvelle','" + DropDownListChoix.SelectedValue + "','Omar','" + DropDownListNomCompanie.SelectedValue + "','" + DropDownListTypeContrat.SelectedValue + "','Non Affecter','Non Reglée')";
                        d.cmd.Connection = d.con;
                        d.cmd.ExecuteNonQuery();

                    }
                    else
                    {
                        d.cmd.CommandText = "insert into affaire(id_client,souscripteur,dateOperation,datedebut,datefin,numPolice,natureOperation,branche,Operateur,Compagnie,typeAff,Affectation,Reglement_cabinet) values('" + TextBoxId.Text + "','" + TextBoxSouscripteur.Text + "','" + DateTime.Parse(TextBoxDateOperation.Text) + "','" + DateTime.Parse(TextBoxDateDebut.Text) + "','" + DateTime.Parse(TextBoxDateFin.Text) + "','" + TextBoxNumPolice.Text + "','Affaire nouvelle','" + DropDownListChoix.SelectedValue + "','Omar','" + DropDownListNomCompanie.SelectedValue + "','" + DropDownListTypeContrat.SelectedValue + "','Non Affecter','Non Reglée')";
                        d.cmd.Connection = d.con;
                        d.cmd.ExecuteNonQuery();


                    }
                result = true;

            }
            return result;
           
        }

        protected void btnValider_Click(object sender, EventArgs e)
        {
            int flt;




            if (DropDownListChoix.SelectedValue == "Auto")
            {
                if (DropDownListFlotte.SelectedValue == "OUI")
                {
                    flt = 1;
                }
                else
                {
                    flt = 0;
                }
                if (TextBoxMontant.Text != "0" && TextBoxMontant.Text != "" && TextBoxId.Text != "" && TextBoxCIN.Text != "" && TextBoxNomRS.Text != "" && TextBoxPrenomFJ.Text != "" && TextBoxGSM.Text != "" && TextBoxDateN.Text != "" && TextBoxVille.Text != "" && TextBoxAdress.Text != "" && TextBoxEmail.Text != "" && GsmValidation() == 1 && emailValidation() == 1 && TextBoxDateDebut.Text != "" && TextBoxDateFin.Text != "" && TextBoxDateOperation.Text != "" && TextBoxNumPolice.Text != "")
                {
                    if (NumAtt() == 0)
                    {
                        if (NumPermis() == 0)
                        {
                            if (emailValidation() == 1)
                            {

                                if (GsmValidation() == 1)
                                {
                                    if (NbrImmatriculation() == 0)
                                    {
                                        if (NumPermisValidation() == 1 && ImmatriculationValidation() == 1)
                                        {
                                            //try
                                            //{
                                            if (InsertClientAff() == true)
                                            {
                                                d.cmd.CommandText = "select TOP 1 * from affaire order by id_affaire desc";
                                                d.cmd.Connection = d.con;
                                                d.dr = d.cmd.ExecuteReader();
                                                if (d.dr.Read())
                                                {
                                                    int IdAff;
                                                    IdAff = Convert.ToInt32(d.dr[0].ToString());
                                                    d.cmd.CommandText = "insert into affaireAuto values ('" + TextBoxNumAtt.Text + "','" + flt + "','" + IdAff + "')";
                                                    d.cmd.Connection = d.con;
                                                    d.dr.Close();
                                                    d.cmd.ExecuteNonQuery();
                                                    d.cmd.CommandText = "insert into vehicule values('" + TextBoxImmatriculation.Text + "','" + IdAff + "','" + TextBoxMarque.Text + "','" + DropDownListUsage.SelectedValue + "','" + DateTime.Parse(TextBoxDateMec.Text) + "')";
                                                    d.cmd.Connection = d.con;
                                                    d.cmd.ExecuteNonQuery();
                                                    AddMoney();
                                                    InsertCredit();
                                                    d.DECONNECTER();


                                                }
                                                if (checkboxConducteur.Checked == true)
                                                {

                                                    d.CONNECTER();
                                                    d.cmd = new SqlCommand("insert into conducteur values('" + TextBoxId.Text + "','" + TextBoxNomRS.Text + "','" + TextBoxPrenomFJ.Text + "','" + TextBoxNumP.Text + "')", d.con);
                                                    d.cmd.ExecuteNonQuery();
                                                }
                                                else
                                                {
                                                    d.CONNECTER();
                                                    d.cmd = new SqlCommand("insert into conducteur values('" + TextBoxId.Text + "','" + TextBoxNomConduct.Text + "','" + TextBoxPrenomConduct.Text + "','" + TextBoxNumP.Text + "')", d.con);
                                                    d.cmd.ExecuteNonQuery();
                                                }
                                                AlertdvSucces.Attributes.Add("class", "Error alertS");
                                                alertdvfail.Attributes.Add("class", "alterdvfail");


                                            }
                                            else
                                            {
                                                alertdvfail.InnerText = "la date d'operation ou la date de debut  est superieur à la date de fin ";
                                                alertdvfail.Attributes.Add("class", "Error alert");
                                                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                                            }
                                        }
                                        else
                                        {
                                            alertdvfail.InnerText = "Num Permis ou Immatriculation et incorect !";
                                            alertdvfail.Attributes.Add("class", "Error alert");
                                            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");


                                        }
                                    }
                                    else
                                    {
                                        alertdvfail.InnerText = "ce matricule et deja exsist";
                                        alertdvfail.Attributes.Add("class", "Error alert");
                                        AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                                    }
                                }
                                else
                                {
                                    alertdvfail.InnerText = "GSM non valid  ";
                                    alertdvfail.Attributes.Add("class", "Error alert");
                                    AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                                }
                            }
                            else
                            {
                                alertdvfail.InnerText = "Email non valid";
                                alertdvfail.Attributes.Add("class", "Error alert");
                                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                            }
                        }
                        else
                        {

                            alertdvfail.InnerText = "Num Permis deja existe";
                            alertdvfail.Attributes.Add("class", "Error alert");
                            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                        }
                    }
                    else
                    {
                        alertdvfail.InnerText = "Num Attestation deja exsist";
                        alertdvfail.Attributes.Add("class", "Error alert");
                        AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                    }
                }
                else
                {
                    alertdvfail.InnerText = "Merci de remplir tous les champs";
                    alertdvfail.Attributes.Add("class", "Error alert");
                    AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                }
                   
                }



                else if (DropDownListChoix.SelectedValue == "Hors_Auto")
                {
                    if (TextBoxMontant.Text != "0" && TextBoxMontant.Text != "") {
                        //try
                        //{


                            InsertClientAff();
                            d.cmd.CommandText = "select TOP 1 * from affaire order by id_affaire desc";
                            d.cmd.Connection = d.con;
                            d.dr = d.cmd.ExecuteReader();
                            if (d.dr.Read())
                            {
                                int IdAff;
                                IdAff = Convert.ToInt32(d.dr[0].ToString());
                                d.cmd.CommandText = "insert into affaireHorsAuto values ('" + DropDownListBranchRD.SelectedValue + "','" + IdAff + "')";
                                d.cmd.Connection = d.con;
                                d.dr.Close();
                                d.cmd.ExecuteNonQuery();
                                AddMoney();
                                 AlertdvSucces.Attributes.Add("class", "Error alertS");
                                 alertdvfail.Attributes.Add("class", "alterdvfail");

                             }
                    //    }
                    //    catch
                    //    {
                    //        alertdvfail.Attributes.Add("class", "Error alert");
                    //         AlertdvSucces.Attributes.Add("class", "AlertdvSucces");

                    //}
                    }

                }
                else
                {
                    if (TextBoxMontant.Text != "0" && TextBoxMontant.Text != "") {
                        //try
                        //{
                            InsertClientAff();
                            d.cmd.CommandText = "select TOP 1 * from affaire order by id_affaire desc";
                            d.cmd.Connection = d.con;
                            d.dr = d.cmd.ExecuteReader();
                            if (d.dr.Read())
                            {
                                int IdAff;
                                IdAff = Convert.ToInt32(d.dr[0].ToString());
                                d.cmd.CommandText = "insert into AffAssistance values ('" + DropDownListTypeAssistance.SelectedValue + "','" + IdAff + "')";
                                d.cmd.Connection = d.con;
                                d.dr.Close();
                                d.cmd.ExecuteNonQuery();
                            }
                              AddMoney();
                              AlertdvSucces.Attributes.Add("class", "Error alertS");
                              alertdvfail.Attributes.Add("class", "alterdvfail");

                    //}
                    //    catch (Exception)
                    //    {
                    //        alertdvfail.Attributes.Add("class", "Error alert");
                    //       AlertdvSucces.Attributes.Add("class", "AlertdvSucces");

                    //} 
                    }

                
            }
            
           
            //}
            //alertdvfail.Attributes.Add("class", "Error alert");
            //AlertdvSucces.Attributes.Add("class","Error alertS");
        }

        protected void TextBoxPrimeNette_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBoxPrimeNette.Text))
                {
                    TextBoxPrimeNette.Text = "0";
                }
                TextBoxMontant.Text = (decimal.Parse(TextBoxPrimeNette.Text.ToString()) + decimal.Parse(TextBoxTVA.Text.ToString()) + decimal.Parse(TextBoxTAXE1.Text.ToString()) + decimal.Parse(TextBoxTAXE2.Text.ToString()) + decimal.Parse(TextBoxEvGa.Text.ToString()) + decimal.Parse(TextBoxEvRc.Text.ToString())).ToString();
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            catch (Exception)
            {
                alertdvfail.InnerText = "ce champ n'accepte que les Nombres et les Virgules (,)(0-9)";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                TextBoxPrimeNette.Text = "0";

            }


        }


        protected void TextBoxTVA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBoxTVA.Text))
                {
                    TextBoxTVA.Text = "0";
                }
                TextBoxMontant.Text = (decimal.Parse(TextBoxPrimeNette.Text.ToString()) + decimal.Parse(TextBoxAccessoire.Text.ToString()) + decimal.Parse(TextBoxTVA.Text.ToString()) + decimal.Parse(TextBoxTAXE1.Text.ToString()) + decimal.Parse(TextBoxTAXE2.Text.ToString()) + decimal.Parse(TextBoxEvGa.Text.ToString()) + decimal.Parse(TextBoxEvRc.Text.ToString())).ToString();
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
      
            }
            catch(Exception)
            {
                alertdvfail.InnerText = "ce champ n'accepte que les Nombres et les Virgules (,)(0-9)";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                TextBoxTVA.Text = "0";
            }
        }

        protected void TextBoxEvGa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBoxEvGa.Text))
                {
                    TextBoxEvGa.Text = "0";
                }
                TextBoxMontant.Text = (decimal.Parse(TextBoxPrimeNette.Text.ToString()) + decimal.Parse(TextBoxAccessoire.Text.ToString()) + decimal.Parse(TextBoxTVA.Text.ToString()) + decimal.Parse(TextBoxTAXE1.Text.ToString()) + decimal.Parse(TextBoxTAXE2.Text.ToString()) + decimal.Parse(TextBoxEvGa.Text.ToString()) + decimal.Parse(TextBoxEvRc.Text.ToString())).ToString();
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
               
            }
            catch (Exception)
            {
                alertdvfail.InnerText = "ce champ n'accepte que les Nombres et les Virgules (,)(0-9)";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                TextBoxEvGa.Text = "0";

            }
        }

        protected void TextBoxEvRc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBoxEvRc.Text))
                {
                    TextBoxEvRc.Text = "0";
                }
                TextBoxMontant.Text = (decimal.Parse(TextBoxPrimeNette.Text.ToString()) + decimal.Parse(TextBoxAccessoire.Text.ToString()) + decimal.Parse(TextBoxTVA.Text.ToString()) + decimal.Parse(TextBoxTAXE1.Text.ToString()) + decimal.Parse(TextBoxTAXE2.Text.ToString()) + decimal.Parse(TextBoxEvGa.Text.ToString()) + decimal.Parse(TextBoxEvRc.Text.ToString())).ToString();
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");

            }
            catch (Exception)
            {
                alertdvfail.InnerText = "ce champ n'accepte que les Nombres et les Virgules (,)(0-9)";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                TextBoxEvRc.Text = "0";
            }

        }

        protected void TextBoxAccessoire_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBoxAccessoire.Text))
                {
                    TextBoxAccessoire.Text = "0";
                }
                TextBoxMontant.Text = (decimal.Parse(TextBoxPrimeNette.Text.ToString()) + decimal.Parse(TextBoxAccessoire.Text.ToString()) + decimal.Parse(TextBoxTVA.Text.ToString()) + decimal.Parse(TextBoxTAXE1.Text.ToString()) + decimal.Parse(TextBoxTAXE2.Text.ToString()) + decimal.Parse(TextBoxEvGa.Text.ToString()) + decimal.Parse(TextBoxEvRc.Text.ToString())).ToString();
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            catch (Exception)
            {
                alertdvfail.InnerText = "ce champ n'accepte que les Nombres et les Virgules (,)(0-9)";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                TextBoxAccessoire.Text = "0";
            }
        }

        protected void TextBoxTAXE1_TextChanged(object sender, EventArgs e)
        {
            try
            { 
            if (string.IsNullOrEmpty(TextBoxTAXE1.Text))
            {
                TextBoxTAXE1.Text = "0";
            }
            TextBoxMontant.Text = (decimal.Parse(TextBoxPrimeNette.Text.ToString()) + decimal.Parse(TextBoxAccessoire.Text.ToString()) + decimal.Parse(TextBoxTVA.Text.ToString()) + decimal.Parse(TextBoxTAXE1.Text.ToString()) + decimal.Parse(TextBoxTAXE2.Text.ToString()) + decimal.Parse(TextBoxEvGa.Text.ToString()) + decimal.Parse(TextBoxEvRc.Text.ToString())).ToString();
            alertdvfail.Attributes.Add("class", "alterdvfail");
            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                }
                   catch (Exception)
            {
                alertdvfail.InnerText = "ce champ n'accepte que les Nombres et les Virgules (,)(0-9)";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                TextBoxTAXE1.Text = "0";
            }
        }

        protected void TextBoxTAXE2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBoxTAXE2.Text))
                {
                    TextBoxTAXE2.Text = "0";
                }
                TextBoxMontant.Text = (decimal.Parse(TextBoxPrimeNette.Text.ToString()) + decimal.Parse(TextBoxAccessoire.Text.ToString()) + decimal.Parse(TextBoxTVA.Text.ToString()) + decimal.Parse(TextBoxTAXE1.Text.ToString()) + decimal.Parse(TextBoxTAXE2.Text.ToString()) + decimal.Parse(TextBoxEvGa.Text.ToString()) + decimal.Parse(TextBoxEvRc.Text.ToString())).ToString();
                alertdvfail.Attributes.Add("class", "alterdvfail");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
            }
            catch (Exception)
            {
                alertdvfail.InnerText = "ce champ n'accepte que les Nombres et les Virgules (,)(0-9)";
                alertdvfail.Attributes.Add("class", "Error alert");
                AlertdvSucces.Attributes.Add("class", "AlertdvSucces");
                TextBoxTAXE2.Text = "0";
            }
        }

        protected void TextBoxGSM_TextChanged(object sender, EventArgs e)
        {
            GsmValidation();
            
        }

        protected void TextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            emailValidation();
        }

        protected void TextBoxNumP_TextChanged(object sender, EventArgs e)
        {
            NumPermisValidation();
        }

        protected void TextBoxImmatriculation_TextChanged(object sender, EventArgs e)
        {
            ImmatriculationValidation();
  
        }
        //Validation GSM
        public int GsmValidation()
        {
            int nb = 0;
            Regex r = new Regex("^[+]\\d{3}\\d{9}$");
            Regex r2 = new Regex("^[0]\\d{9}$");
            if (r.IsMatch(TextBoxGSM.Text) || r2.IsMatch(TextBoxGSM.Text))
            {
                GsmRight.Attributes.Add("class", "rightShow");
                GsmWrong.Attributes.Add("class", "none");
                nb = 1;

            }
            else
            {
                GsmWrong.Attributes.Add("class", "wrongShow");
                GsmRight.Attributes.Add("class", "none");
                nb = 0;
            }
            alertdvfail.Attributes.Add("class", "alterdvfail");
            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");

            return nb;

        }

        //ValidationEmail
        public int emailValidation()
        {
            int nbEmail = 0;
            Regex r = new Regex("^([a-z\\d\\._-]+)@([a-z\\d-]+)\\.([a-z]{2,8})$");
            if (r.IsMatch(TextBoxEmail.Text))
            {
                EmailRight.Attributes.Add("class", "rightShow");
                EmailWrong.Attributes.Add("class", "none");
                nbEmail = 1;
            }
            else
            {
                EmailWrong.Attributes.Add("class", "wrongShow");
                EmailRight.Attributes.Add("class", "none");
                nbEmail = 0;
            }
            alertdvfail.Attributes.Add("class", "alterdvfail");
            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");

            return nbEmail;
        }

        //ValidationNumPermis
        public int NumPermisValidation()
        {
            int nbpermi = 0;
            Regex r = new Regex("^(\\d{2,3})/(\\d{2,9})$");
            if (r.IsMatch(TextBoxNumP.Text))
            {
                PermisRight.Attributes.Add("class", "rightShow");
                PermisWrong.Attributes.Add("class", "none");
                nbpermi = 1;
            }
            else
            {
                PermisWrong.Attributes.Add("class", "wrongShow");
                PermisRight.Attributes.Add("class", "none");
                nbpermi = 0;
            }
            alertdvfail.Attributes.Add("class", "alterdvfail");
            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");

            return nbpermi;
        }

        //Validation Immatriculation
        public int ImmatriculationValidation()
        {
            int nbImma = 0;
            Regex r = new Regex("^(\\d{1,5})-([aA-zZ]{1})-(\\d{1,2})$");
            if (r.IsMatch(TextBoxImmatriculation.Text))
            {
                ImmaRight.Attributes.Add("class", "rightShow");
                ImmaWrong.Attributes.Add("class", "none");
                nbImma = 1;
            }
            else
            {
                ImmaWrong.Attributes.Add("class", "wrongShow");
                ImmaRight.Attributes.Add("class", "none");
                nbImma = 0;
            }
            alertdvfail.Attributes.Add("class", "alterdvfail");
            AlertdvSucces.Attributes.Add("class", "AlertdvSucces");

            return nbImma;
        }

    }
}