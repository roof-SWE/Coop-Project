using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KSU_Templates
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Roles.IsUserInRole("student"))
            {
                home.Visible = false;
                contact.Visible = false;
            }
            if (Roles.IsUserInRole("admin"))
            {
                homeAdmin.Visible = true;
                ajax.Visible = true;
            }
        }
    }
}