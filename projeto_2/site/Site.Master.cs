using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace site
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnLogout.Visible = Session["autenticado"] != null;

        }

        protected void logout(object sender, EventArgs e)
        {
            Session.Clear();
            FormsAuthentication.SignOut();
        }
    }
}