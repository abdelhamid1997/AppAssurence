using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ApplicationAssurance
{
    public class ADO
    {
       
            // Déclaration des objets sql
            public SqlConnection con = new SqlConnection();
            public SqlCommand cmd = new SqlCommand();
            public SqlDataReader dr;
            public DataTable dt = new DataTable();
            public SqlDataAdapter dap = new SqlDataAdapter();
            public DataSet ds = new DataSet();
            public SqlCommandBuilder bc;


            //Déclaration de la methode connecter 
            public void CONNECTER()
            {
                if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
                {
                    con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Assurancedb;Integrated Security=True";

                    con.Open();
                }
            }




            //Déclaration de la methode  deconnecter

            public void DECONNECTER()
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        
    }
}