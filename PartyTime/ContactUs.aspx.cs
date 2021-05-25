using PartyTime.Database;
using System;
using System.Net.Mail;
using System.Web.UI;

namespace PartyTime
{
    public partial class ContactUs : System.Web.UI.Page
    {
        private Helpers helpers;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if there is a user
            if(Session["user"] != null)
            {
                //hide buttons
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
                logOutBtn.Visible = true;
                signUpBtn.Visible = true;
            }
            logInBtn.ServerClick += logInBtn_ServerClick;
            signUpBtn.ServerClick += signUpBtn_ServerClick;
            logOutBtn.ServerClick += logOutBtn_ServerClick;
            dashBtn.ServerClick += dashBtn_ServerClick;
            send_btn.ServerClick += Send_btn_ServerClick;
        }

        /**
         * Send button
         * User can click on the send-button.
         */
        private void Send_btn_ServerClick(object sender, EventArgs e)
        {
            if (checkempty())
            {
                //empty fields
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "emptyFields()", true);
            }
            else
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                //e-mailaddress and password for partytime
                smtp.Credentials = new System.Net.NetworkCredential("partytimemau21@gmail.com", "Party2021");
                smtp.EnableSsl = true;
                MailMessage msg = new MailMessage();
                msg.Subject = "Meddelande från en Användare!";
                msg.Body = " Meddelande från:" + "\n" + name.Value + "\n\nPhone: " + "\n" + phone.Value + "\n\nE-post: " + "\n" + email.Value + "\n" + " \n " +
                   "Meddelande:" + "\n" + message.Value + "\n\n";
                msg.From = new MailAddress(email.Value);
                msg.To.Add("partytimemau21@gmail.com"); // Party Time e-post som ska få meddelandena
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "sendMessage()", true);
                smtp.Send(msg);
                clear();
            }
        }

        /**
         * Check if inlogged user admin or user and redirect to the right panel.
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

        /**
         * This function will check if the user has written any text in the fields. 
         */
        private bool checkempty()
        {
            //if all fields are empty
            if(name.Value == "" || phone.Value == "" || email.Value == "" || message.Value == "")
            {
                //empty fields
                return true;
            }
            return false;
        }

        /**
         * This function clear up after the user write and the user are done.
         */
        private void clear()
        {
            name.Value = phone.Value = email.Value = message.Value = "";
        }
    }
}