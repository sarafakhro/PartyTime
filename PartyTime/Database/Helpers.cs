using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PartyTime.Database
{
    public class Helpers
    {
        private SqlConnection sql;
        private SqlCommand cmd;
        private SqlDataAdapter sda;
        private DataTable dt;


        //This function will check if logged user is admin or not
        public bool checkUserType()
        {
            bool user = false;
            string loggedUser = System.Web.HttpContext.Current.Session["user"].ToString();
            SqlConnection connection = new SqlConnection(Database.connectionString.con);
            connection.Open();
            String query = "SELECT username, userType FROM Users WHERE (username = '" + loggedUser + "');";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sds = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sds.SelectCommand = cmd;
            int i = 0;
            sds.Fill(ds, "loggedUser");
            if (ds.Tables[i].Rows.Count > 0)
            {
                if (ds.Tables[i].Rows[i]["userType"].ToString() == "U")
                {
                    // If you login and you are user
                    user = true;
                }
            }
            connection.Close();
            return user;
        }


        //This function will get party type name from the database.
        public DataTable getPartyDropData()
        {
            sql = new SqlConnection(connectionString.con);
            cmd = new SqlCommand("sp_getPartyType", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        //This function will get decoration suggestions name from the database.
        public DataTable getdecorationSuggestionsDropData()
        {
            sql = new SqlConnection(connectionString.con);
            cmd = new SqlCommand("sp_getDecorSugges", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        //This function will get food type from the database.
        public DataTable getFoodTypeDropData()
        {
            sql = new SqlConnection(connectionString.con);
            cmd = new SqlCommand("sp_getFoodType", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}