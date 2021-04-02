using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
            send_btn.ServerClick += Send_btn_ServerClick;

        }

        private void Send_btn_ServerClick(object sender, EventArgs e)
        {
            if (checkempty())
            {
                //empty fields
            }
            else
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("partytimemau21@gmail.com", "Party2021"); // Email och lösenord för Party Time
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
        private bool checkempty()
        {
            //om alla fälten är toma
            if(name.Value == "" || phone.Value == "" || email.Value == "" || message.Value == "")
            {
                //empty fields
                return true;
            }
            return false;
        }
        private void clear()
        {
            //clear funktionen är bara till att ta bort efter man har skrivit och gjort vad man behöver
            name.Value = phone.Value = email.Value = message.Value = "";
        }

    }
}