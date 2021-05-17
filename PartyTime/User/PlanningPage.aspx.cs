using PartyTime.Database;
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
    public partial class PlanningPage : System.Web.UI.Page
    {
        private Helpers helpers; 
        private SqlConnection sql;
        private SqlCommand cmd;
        private SqlDataAdapter sda;
        private DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            wlcLabel.Text = "Welcome back: " + Session["user"];
            helpers = new Helpers();
            if (!IsPostBack)
            {
                fillPartyTypeDrop();
                filldecorationSuggestionsDrop();
                fillFoodTypeDrop();
            }
            doneBtn.ServerClick += doneBtn_ServerClick;
        }
        // This function will save user input to the database
        private void doneBtn_ServerClick(object sender, EventArgs e)
        {
            //If child and andult number are empty
            if (checkEmpty())
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "emptyFields()", true);
            }
            else
            {
                //Add to the datbase
                sql = new SqlConnection(Database.connectionString.con);
                sql.Open(); // Open the connection to the database
                string procedureName = "sp_UserInput_addData"; //Stored Procedure name
                cmd = new SqlCommand(procedureName, sql);  //creating  SqlCommand  object
                cmd.CommandType = CommandType.StoredProcedure;  //here we declaring command type as stored Procedure
                //adding paramerters to  SqlCommand below  
                cmd.Parameters.AddWithValue("@partyType", partyTypeDrop1.SelectedItem.Text); //partyType 
                cmd.Parameters.AddWithValue("@decorationSuggestion", decorationSuggestionsDrop1.SelectedItem.Text); //decorationSuggestion  
                cmd.Parameters.AddWithValue("@foodType", foodTypeDrop1.SelectedItem.Text);  //foodType  
                cmd.Parameters.AddWithValue("@childNumber", childNumber.Value); //childNumber  
                cmd.Parameters.AddWithValue("@adulNumber", adulNumber.Value); //adulNumber  
                cmd.Parameters.AddWithValue("@userName", Session["user"].ToString()); //userNamer  
                cmd.ExecuteNonQuery(); //executing the sqlcommand
                sql.Close(); // Close the connection to the database
                clear(); // Clear the fields
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "doneInput()", true);

            }
        }
        //This function will fill PartyTypeDrop with data from the database. 
        public void fillPartyTypeDrop()
        {
            partyTypeDrop1.DataSource = helpers.getPartyDropData();
            partyTypeDrop1.DataTextField = "name";
            partyTypeDrop1.DataValueField = "id";
            partyTypeDrop1.DataBind();
        }


        //This function will fill decorationsuggestionsDrop with data from the database. 
        public void filldecorationSuggestionsDrop()
        {
            decorationSuggestionsDrop1.DataSource = helpers.getdecorationSuggestionsDropData();
            decorationSuggestionsDrop1.DataTextField = "name";
            decorationSuggestionsDrop1.DataValueField = "id";
            decorationSuggestionsDrop1.DataBind();
        }


        //This function will fill  foodTypeDrop with data from the database. 
        public void fillFoodTypeDrop()
        {
            foodTypeDrop1.DataSource = helpers.getFoodTypeDropData();
            foodTypeDrop1.DataTextField = "name";
            foodTypeDrop1.DataValueField = "id";
            foodTypeDrop1.DataBind();
        }

        private bool checkEmpty()
        {
            if (childNumber.Value == "" || adulNumber.Value == "")
            {
                return true;
            }
            return false;
        }

        private void clear()
        {
            childNumber.Value = adulNumber.Value = "";
        }
    }
}