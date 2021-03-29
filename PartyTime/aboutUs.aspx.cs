using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PartyTime
{
    public partial class aboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            logInBtn.ServerClick += logInBtn_ServerClick;
            signUpBtn.ServerClick += signUpBtn_ServerClick;
            logOutBtn.ServerClick += logOutBtn_ServerClick;
            dashBtn.ServerClick += dashBtn_ServerClick;
        }

        private void dashBtn_ServerClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void logOutBtn_ServerClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void signUpBtn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("signUp.aspx");
        }

        private void logInBtn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("logIn.aspx");
        }


    }
}