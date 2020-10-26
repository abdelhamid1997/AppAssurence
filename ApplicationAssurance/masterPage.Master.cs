using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationAssurance
{
    public partial class masterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dvRec.Visible = false;
            dvProd.Visible = false;
            dvAvenant.Visible = false;
            dvAffectRem.Visible = false;
        }
        protected void btnProd_Click(object sender, EventArgs e)
        {
            dvRec.Visible = true;
            dvProd.Visible = true;
            dvAvenant.Visible = true;
            dvAffectRem.Visible = true;
        }
    }
}