using PartyTime.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PartyTime
{
    public partial class index : System.Web.UI.Page
    {
        private Helpers helpers;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] != null)
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

               logInBtn.Visible = true;
               signUpBtn.Visible = true;
             }


            logInBtn.ServerClick += logInBtn_ServerClick;
            signUpBtn.ServerClick += signUpBtn_ServerClick;
            logOutBtn.ServerClick += logOutBtn_ServerClick;
            dashBtn.ServerClick += dashBtn_ServerClick;
            planBtn.ServerClick += planBtn_ServerClick;
        }

        private void planBtn_ServerClick(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                //Open the dash
                Response.Redirect("~/User/PlanningPage.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "mustLogin()", true);
            }
        }

        private void dashBtn_ServerClick(object sender, EventArgs e)
        {
            //Check if inlogged user admin or user and redirect to the right panel!
            helpers = new Helpers();
            if (helpers.checkUserType())
            {
                //The logged user is not admin!
                Response.Redirect("~/User/PlanningPage.aspx");
            }
            else
            {
                //The logged user is admin!
                Response.Redirect("~/Admin/adminstration.aspx");

            }
        }

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