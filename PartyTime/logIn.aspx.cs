using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PartyTime
{
    public partial class logIn : System.Web.UI.Page
    {
        private string userToken;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                userToken = Session["user"].ToString();

            }
            logInBtm.ServerClick += logInBtm_ServerClick;
        }

        private void logInBtm_ServerClick(object sender, EventArgs e)
        {
            string epost = email.Value;
            string password = pass.Value;
            string both = epost + password;
            SqlConnection con = new SqlConnection(Database.connectionString.con);
            con.Open();
            String query = "SELECT Email,password, username, userType FROM Users WHERE (Email = '" + epost + "') AND (password = '" + password + "');";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sda.SelectCommand = cmd;
            int i = 0;
            sda.Fill(ds, "Password");
            if (ds.Tables[i].Rows.Count > 0)

            {
                if (userToken == null)
                {
                    Session["user"] = ds.Tables[i].Rows[i]["userName"].ToString();
                }
                if (ds.Tables[i].Rows[i]["UserType"].ToString() == "U")
                {
                    //if you login and you're user.
                }
                else
                {
                    //if you login and you're admin.
                }

            }
            else if (both == "")
            {
                //empty fields
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "emptyFields()", true);
                clear();

            }
            else
            {
                //wrong user or password.
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "wrongEmail_Pass()", true);
                clear();
            }
            con.Close();

        }



        private void clear()
        {
            email.Value = pass.Value = "";
        }
    }

   
}
