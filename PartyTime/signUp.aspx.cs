using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PartyTime
{
    public partial class signUp : System.Web.UI.Page
    {
        private bool emailExist = false;
        private bool userNameExist = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            signUpBtm.ServerClick += signUpBtm_ServerClick;
        }

        private void signUpBtm_ServerClick(object sender, EventArgs e)
        {
            if (checkEmpty())
            {
                // ingen har skrivit nått 
                return;

            }
            else
            {
                SqlConnection con = new SqlConnection(Database.connectionString.con);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [Users] ";
                cmd.Connection = con;
                SqlDataReader sqlReader = cmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    if (sqlReader[1].ToString() ==userName.Value)
                    {
                        userNameExist = true;
                        break;
                    }
                    if (sqlReader[3].ToString() == email.Value)
                    {
                        emailExist = true;
                        break;

                    }

                }
                if (userNameExist)
                {
                    //userName exist 

                }
                else if (emailExist)
                {
                    // email exist 
                }
                else
                {
                    SqlConnection sqlConnection1 = new SqlConnection(Database.connectionString.con);
                    sqlConnection1.Open();
                    string procedureName = "sp_Users_addAccount";
                    SqlCommand cmd1 = new SqlCommand(procedureName,sqlConnection1);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@username", userName.Value.ToString());
                    cmd1.Parameters.AddWithValue("@password",pass.Value.ToString());
                    cmd1.Parameters.AddWithValue("@Email", email.Value.ToString());
                    cmd1.Parameters.AddWithValue("@userType","U");
                    cmd1.ExecuteNonQuery();
                    sqlConnection1.Close();
                    Session["user"] = userName.Value.ToString();
                    clear();
                    Response.Redirect("logIn.aspx");


                }

            }
        }
        private void clear()
        {
            userName.Value = email.Value = pass.Value = "";

        }
        private bool checkEmpty()
        {
            if (userName.Value== "" || email.Value=="" || pass.Value=="")
            {
                return true;
            }
            return false;
        }
    }
}