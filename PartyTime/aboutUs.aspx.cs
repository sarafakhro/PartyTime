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
            //om det finns en en inloggad användare, logged_User får sitt
            //värde senare, sparas på servern
            if(Session["logged_User"] != null)
            {
                //då visar vi dessa knappar
                //vi har gömt dessa i början
                dashBtn.Style.Add("display", "block");
                logOutBtn.Style.Add("display", "block");

                //och göm de andra knapparna
                logInBtn.Visible = false;
                signUpBtn.Visible = false;

            }
            //annars tvärtom
            else
            {
                dashBtn.Style.Add("display", "block");
                logOutBtn.Style.Add("display", "none");

                logInBtn.Visible = true;
                signUpBtn.Visible = true;
            }



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
            //reset session, när man ska logga ut, ska det inte finnas värde kvar
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