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
    public partial class forgotPassword : System.Web.UI.Page
    {
        private string userPassword;

        /**
         * This method must start with a big letter.
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            getBtn.ServerClick += getBtn_ServerClick;
        }

        /**
         * This method connect to sql database to get the password for the e-mail
         * based on if the user write a right e-mailaddress.
         */
        private void getBtn_ServerClick(object sender, EventArgs e)
        {
            //if the user writes any e-mailaddress
            if (email.Value != "")
            {
                string epost = email.Value;
                SqlConnection sqlConnection = new SqlConnection(Database.connectionString.con);
                sqlConnection.Open();
                //variablename in string
                string query = "select Email,password from Users where (Email = '" + epost + "')";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                DataSet dataSet = new DataSet();
                sqlDataAdapter.SelectCommand = sqlCommand;
                int i = 0;
                sqlDataAdapter.Fill(dataSet, "password");
                if (dataSet.Tables[i].Rows.Count > 0)
                {
                    userPassword = dataSet.Tables[i].Rows[i]["password"].ToString();
                    passwordLabel.Text = "Your password:" + userPassword;
                    passwordLabel.ForeColor = System.Drawing.Color.Green;
                    getBtn.Visible = false;
                    logInBtn.Visible = true;
                }
                else
                {
                    //wrong email
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "wrongEmail()", true);
                    email.Value = "";
                }
            }
            else
            {
                //emptyfields
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "emptyFields()", true);
            }
        }
    }
}