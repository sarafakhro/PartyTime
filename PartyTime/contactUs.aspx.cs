using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace PartyTime
{
    public partial class contactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["logged User"] != null)
            {
                dashBtn.Style.Add("display", "block");
                logOutBtn.Style.Add("display", "block");

                logInBtn.Visible = false;
                signUpBtn.Visible = false;

            }
            else
            {
                dashBtn.Style.Add("display", "none");
                logOutBtn.Style.Add("display", "none");

                logOutBtn.Visible = true;
                signUpBtn.Visible = true;
            }


            logInBtn.ServerClick += logInBtn_ServerClick;
            signUpBtn.ServerClick += signUpBtn_ServerClick;
            logOutBtn.ServerClick += LogOutBtn_ServerClick;
            dashBtn.ServerClick += DashBtn_ServerClick;

        }

        private void DashBtn_ServerClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LogOutBtn_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('You will be logged out!')", true);
            Session.Abandon();
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