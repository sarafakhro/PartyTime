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
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader sqlReader;
        protected void Page_Load(object sender, EventArgs e)
        {
            signUpBtm.ServerClick += signUpBtm_ServerClick;
        }

        /**
         * This function will run when u click on the butten 
         * This function will create an account for the user
         */
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
                con = new SqlConnection(Database.connectionString.con);
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "select * from [Users] ";
                cmd.Connection = con;
                sqlReader = cmd.ExecuteReader();
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
                    con = new SqlConnection(Database.connectionString.con); // Init the connenction.
                    con.Open(); // Open the connection to the database.
                    string procedureName = "sp_Users_addAccount"; //Stored Procedure name.
                    cmd = new SqlCommand(procedureName,con); //Creating  SqlCommand  object.
                    cmd.CommandType = System.Data.CommandType.StoredProcedure; //Here we declaring command type as stored Procedure.
                    //Adding paramerters to  SqlCommand below  
                    cmd.Parameters.AddWithValue("@userName", userName.Value.ToString()); //Username. 
                    cmd.Parameters.AddWithValue("@passWord",pass.Value.ToString()); //Password.  
                    cmd.Parameters.AddWithValue("@eMail", email.Value.ToString()); //Email.
                    cmd.Parameters.AddWithValue("@userType","U");  //Usertype.
                    cmd.ExecuteNonQuery(); //Executing the sqlcommand.
                    con.Close(); // Close the connection to the database.
                    Session["user"] = userName.Value.ToString(); // Saving username into the servere as a session called ["user"].
                    clear(); //Clear the fields.
                    Response.Redirect("logIn.aspx"); //Redirect to this site.
                }
            }
        }

        /**
        * This fuction will reset the field 
        */
        private void clear()
        {
            userName.Value = email.Value = pass.Value = "";
        }

        /**
        * This function will check if the fields are empty
        */
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