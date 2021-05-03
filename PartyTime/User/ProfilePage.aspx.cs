using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PartyTime.User
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            saveBtn.ServerClick += saveBtn_ServerClick;
            resetBtn.ServerClick += resetBtn_ServerClick;
            if (Session["user"] != null)
            {
                if (!IsPostBack)
                {
                    loggedUser.Text = "Welcome back:" + Session["user"].ToString();
                    getProfileInfo();
                }
            }

        }
        //it will reset the fields
        private void resetBtn_ServerClick(object sender, EventArgs e)
        {
            username.Value = email.Value = password.Value = "";
        }
        // It will save new values into the database
        private void saveBtn_ServerClick(object sender, EventArgs e)
        {
            if (checkEmpty())
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "emptyFields()", true);
            }
            else
            {
                //Save the new values into the database.
                using (var con = new SqlConnection(Database.connectionString.con))
                {
                    string currentUsername = Session["user"].ToString();

                    con.Open();
                    SqlCommand sqlCmd = new SqlCommand("sp_editUsers", con);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@username", username.Value.Trim());
                    sqlCmd.Parameters.AddWithValue("@password", password.Value.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", email.Value.Trim());
                    sqlCmd.Parameters.AddWithValue("@oldUsername", currentUsername);
                    sqlCmd.ExecuteNonQuery();
                    sqlCmd.Dispose();
                    saveBtn.Visible = false;
                    resetBtn.Visible = false;
                    Session["user"] = username.Value.Trim();
                    infoLabel.Text = "Your info has been updated!";
                    infoLabel.ForeColor = System.Drawing.Color.Green;

                }
            }
        }
        //It will fill the fields with values from the database.
        private void getProfileInfo()
        {
            String query = "select * from Users where (username = '" + Session["user"].ToString() + "');";
            using (SqlConnection sql = new SqlConnection(Database.connectionString.con))
            {
                using (SqlCommand cmd = new SqlCommand(query, sql))
                {
                    sql.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        username.Value = sdr["username"].ToString();
                        password.Value = sdr["password"].ToString();
                        email.Value = sdr["Email"].ToString();

                    }
                    sql.Close();
                }
            }
        }
        //Check if the fields is empty.
        private bool checkEmpty()
        {
            if (username.Value == "" || email.Value == "" || password.Value == "")
            {
                return true;
            }
            return false;
        }
    }
}