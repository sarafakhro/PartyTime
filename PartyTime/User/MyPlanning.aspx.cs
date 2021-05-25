using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PartyTime.User
{
    public partial class MyPlanning : System.Web.UI.Page
    {
        private SqlConnection sql;
        private SqlDataReader sdr;
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter sda;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillUserGrid();
                addUsernameToReport();
            }
        }
        private void addUsernameToReport()
        {
            ReportParameter rp = new ReportParameter("Username", Session["user"].ToString());
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
        }

        /**
         * This function is used to fill user grid with data from the database
         */
        private void fillUserGrid()
        {
            string con = Database.connectionString.con;
            using (sql = new SqlConnection(con))
            {
                sql.Open();
                cmd = new SqlCommand("Select * from UserInput where userName='" + Session["user"] + "'", sql);
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows == true)
                {
                    userParamGridView.DataSource = sdr;
                    userParamGridView.DataBind();
                }
            }
        }
    }
}