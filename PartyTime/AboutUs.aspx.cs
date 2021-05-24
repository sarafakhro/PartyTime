using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PartyTime
{
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if there is an logged in user, logged_User get it's
            //value later, save in server
            if(Session["user"] != null)
            {
                //show these buttons
                //hide from the beginning
                dashBtn.Style.Add("display", "block");
                logOutBtn.Style.Add("display", "block");
                //and hide these buttons
                logInBtn.Visible = false;
                signUpBtn.Visible = false;
            }
            //else vice versa
            else
            {
                dashBtn.Style.Add("display", "none");
                logOutBtn.Style.Add("display", "none");
                logInBtn.Visible = true;
                signUpBtn.Visible = true;
            }
            //connect buttons with functions
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
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('You will be logged out')", true);
            //reset session, when you want to log out, clean everything beacause we don't want any data left
            Session.Abandon();
        }

        /**
         * Redirect the user to Sign up page.
         */
        private void signUpBtn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("signUp.aspx");
        }

        /**
         * Redirect the user to Log in page.
         */
        private void logInBtn_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("logIn.aspx");
        }
    }
}