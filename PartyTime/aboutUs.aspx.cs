using PartyTime.Database;
using System;
using System.Web.UI;

namespace PartyTime
{
    public partial class AboutUs : System.Web.UI.Page
    {
        private Helpers helpers;
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

        /**
         * Check if inlogged user admin or user and redirect to the right panel!
         * When user click on the button "panel" - only when user is inlogged.
         */
        private void dashBtn_ServerClick(object sender, EventArgs e)
        {
            //Check if inlogged user admin or user and redirect to the right panel
            helpers = new Helpers();
            if (helpers.checkUserType())
            {
                //The logged user is not admin
                Response.Redirect("~/User/PlanningPage.aspx");
            }
            else
            {
                //The logged user is admin
                Response.Redirect("~/Admin/Administration.aspx");
            }
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