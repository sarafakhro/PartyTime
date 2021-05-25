using PartyTime.Database;
using System;
using System.Web.UI;

namespace PartyTime
{
    public partial class Index : System.Web.UI.Page
    {
        //database connection
        private Helpers helpers;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if there is a user
            if (Session["user"] != null)
            {
                dashBtn.Style.Add("display", "block");
                logOutBtn.Style.Add("display", "block");
                logInBtn.Visible = false;
                signUpBtn.Visible = false;
            }
            else
            {
                //else vice versa
               dashBtn.Style.Add("display", "none");
               logOutBtn.Style.Add("display", "none");
               logInBtn.Visible = true;
               signUpBtn.Visible = true;
             }
            //connect buttons with functions
            //make it possible for the user to click on the buttons
            logInBtn.ServerClick += logInBtn_ServerClick;
            signUpBtn.ServerClick += signUpBtn_ServerClick;
            logOutBtn.ServerClick += logOutBtn_ServerClick;
            dashBtn.ServerClick += dashBtn_ServerClick;
            planBtn.ServerClick += planBtn_ServerClick;
        }

        /**
         * This method will make it possible for the user to begin planning
         * if the user is logged in.
         */
        private void planBtn_ServerClick(object sender, EventArgs e)
        {
            //if there is a user
            if (Session["user"] != null)
            {
                //open the dash to PlanningPage
                Response.Redirect("~/User/PlanningPage.aspx");
            }
            //error message that tell the user you must be logged in to continue
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "mustLogin()", true);
            }
        }

        /*
         * This method check if the user is admin or user and
         * redirect to the right side
         */
        private void dashBtn_ServerClick(object sender, EventArgs e)
        {
            //check if inlogged user admin or user and redirect to the right panel
            helpers = new Helpers();
            if (helpers.checkUserType())
            {
                //the logged user is not admin
                Response.Redirect("~/User/PlanningPage.aspx");
            }
            else
            {
                //the logged user is admin
                Response.Redirect("~/Admin/adminstration.aspx");

            }
        }

        /**
         * This method will show an error message when the user log out
         * and delete the name from the server.
         * Username must be deleted from the server so the user can be logged out. 
         * Username must be null. 
         */
        private void logOutBtn_ServerClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "logOut()", true);
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