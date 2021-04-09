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
                // Empty fields
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "emptyFields()", true);
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
                    //Username exist 
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "usernameExist()", true);

                }
                else if (emailExist)
                {
                    // Email exist 
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "emailExist()", true);
                }
                else
                {
                    SqlConnection sqlConnection1 = new SqlConnection(Database.connectionString.con); // Init the connenction.
                    sqlConnection1.Open(); // Open the connection to the database.
                    string procedureName = "sp_Users_addAccount"; //Stored Procedure name.
                    SqlCommand cmd1 = new SqlCommand(procedureName,sqlConnection1); //Creating  SqlCommand  object.
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure; //Here we declaring command type as stored Procedure.
                    //Adding paramerters to  SqlCommand below  
                    cmd1.Parameters.AddWithValue("@username", userName.Value.ToString()); //Username. 
                    cmd1.Parameters.AddWithValue("@password",pass.Value.ToString()); //Password.  
                    cmd1.Parameters.AddWithValue("@Email", email.Value.ToString()); //Email.
                    cmd1.Parameters.AddWithValue("@userType","U");  //Usertype.
                    cmd1.ExecuteNonQuery(); //Executing the sqlcommand.
                    sqlConnection1.Close(); // Close the connection to the database.
                    Session["user"] = userName.Value.ToString(); // Saving username into the servere as a session called ["user"].
                    clear(); //Clear the fields.
                    Response.Redirect("logIn.aspx"); //Redirect to this site.
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