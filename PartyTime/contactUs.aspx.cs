using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PartyTime
{
    public partial class contactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            send_btn.ServerClick += Send_btn_ServerClick;
        }

        private void Send_btn_ServerClick(object sender, EventArgs e)
        {
            sendMsg();
        }

        public void sendMsg()
        {
            if (name.Value == "" && phone.Value == "" && email.Value == "" && message.Value == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Var vänlig och fyll i alla fälten!')", true);
                return;
            }
            else
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("partytimemau21@gmail.com", "Party2021"); // Email och lösenord för fridas
                smtp.EnableSsl = true;
                MailMessage msg = new MailMessage();
                msg.Subject = "Meddelande från en Användare!";
                msg.Body = " Meddelande från:" + "\n" + name.Value + "\n\nPhone: " + "\n" + phone.Value + "\n\nE-post: " + "\n" + email.Value + "\n" + " \n " +
                   "Meddelande:" + "\n" + message.Value + "\n\n";
                msg.From = new MailAddress(email.Value);
                msg.To.Add("partytimemau21@gmail.com"); // Party time e-post som ska få meddelandena
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "alert('Meddelandet har skickats!')", true);
                smtp.Send(msg);
                clear();
            }
        }

        private void clear()
        {
            name.Value = phone.Value = email.Value = message.Value = "";
        }

        public bool checkExist()
        {
            if (name.Value == "" && phone.Value == "" && email.Value == "" && message.Value == "")
            {
                return true;
            }
            return false;
        }
    }
}