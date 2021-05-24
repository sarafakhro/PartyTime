using PartyTime.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PartyTime.Admin
{
    public partial class Administration : System.Web.UI.Page
    {
        private Helpers helpers;
        private SqlConnection sql;
        private SqlCommand cmd;
        private SqlDataAdapter sda;
        private DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            wlcLabel.Text = "Welcome back:" + Session["user"];
            helpers = new Helpers();
            if (!IsPostBack)
            {
                filldecorationSuggestionsDrop();
            }
            addDecotdBtn.ServerClick += addDecotdBtn_ServerClick; 
        }

        private void addDecotdBtn_ServerClick(object sender, EventArgs e)
        {
            if (checkEmpty())
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "emptyFields()", true);
            }
            else
            {
                //Add to the datbase
                sql = new SqlConnection(Database.connectionString.con);
                sql.Open(); // Open the connection to the database
                string procedureName = "sp_addDecorData"; //Stored Procedure name
                cmd = new SqlCommand(procedureName, sql);  //creating  SqlCommand  object
                cmd.CommandType = CommandType.StoredProcedure;  //here we declaring command type as stored Procedure
                HttpPostedFile postedFile = fileUploader.PostedFile;
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);
                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                    //adding paramerters to  SqlCommand below  
                    cmd.Parameters.AddWithValue("@DecorName", decorationSuggestionsDrop.SelectedItem.Text); //decorationSuggestion  
                    cmd.Parameters.AddWithValue("@ImageName", imageName.Value); //Image name
                    cmd.Parameters.AddWithValue("@DecorImage", bytes);  //Image  
                    cmd.ExecuteNonQuery(); //executing the sqlcommand
                    sql.Close(); // Close the connection to the database
                    imageName.Value = ""; // Clear the fields
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "doneAdminInput()", true);
                }
                else
                {
                    //Wrong image extenstion
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "wrongExtesnion()", true);
                }
            }
        }

        private bool checkEmpty()
        {
            if (imageName.Value == "" || fileUploader.Value == "")
            {
                return true;
            }
            return false;
        }

        /**
         * This function will fill decorationsuggestionsDrop with data from the database. 
         */
        public void filldecorationSuggestionsDrop()
        {
            decorationSuggestionsDrop.DataSource = helpers.getdecorationSuggestionsDropData();
            decorationSuggestionsDrop.DataTextField = "name";
            decorationSuggestionsDrop.DataValueField = "id";
            decorationSuggestionsDrop.DataBind();
        }
    }
}