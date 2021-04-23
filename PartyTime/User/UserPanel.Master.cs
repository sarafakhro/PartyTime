using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PartyTime.User
{
    public partial class UserPanel : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            logOutBtn.Click += logOutBtn_Click;
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            //delete session --> userName from the server
            Session.Abandon();
            //back one steg to reach index
            Response.Redirect("../index.aspx");
        }
    }
}