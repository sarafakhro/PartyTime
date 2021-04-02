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
        protected void Page_Load(object sender, EventArgs e)
        {
            getBtn.ServerClick += getBtn_ServerClick;
        }

        private void getBtn_ServerClick(object sender, EventArgs e)
        {
            if (email.Value != " ")
            {
                string epost = email.Value;
                SqlConnection sqlConnection = new SqlConnection(Database.connectionString.con);
                sqlConnection.Open();
                //för att vi har variabelnamn i string
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
                }
               

            }
            else
            {
                //emptyfield

            }
        }
    }
}