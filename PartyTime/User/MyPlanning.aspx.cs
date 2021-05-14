using iTextSharp.text;
using iTextSharp.text.pdf;
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
                loadGeneratedGrid();
            }
            exportBtn.ServerClick += exportBtn_ServerClick;
        }

        /**
         * This function is used to export the gridView to pdf when user click on the button
         */
        private void exportBtn_ServerClick(object sender, EventArgs e)
        {
            int columnsCount = generatedGridView.HeaderRow.Cells.Count;
            // Create the PDF table specifying the number of columns
            PdfPTable pdfTable = new PdfPTable(columnsCount);
            //Loop thru each cell in GrdiView header row
            foreach (TableCell gridViewHeaderCell in generatedGridView.HeaderRow.Cells)
            {
                //Create the Font Object for PDF document
                Font font = new Font();
                //Set the font color to GridView header row font color
                font.Color = new BaseColor(generatedGridView.HeaderStyle.ForeColor);
                //Create the PDF cell, specifying the text and font
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));
                //Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                pdfCell.BackgroundColor = new BaseColor(generatedGridView.HeaderStyle.BackColor);
                //Add the cell to PDF table
                pdfTable.AddCell(pdfCell);
            }
            //Loop thru each datarow in GrdiView
            foreach (GridViewRow gridViewRow in generatedGridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    //Loop thru each cell in GrdiView data row
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));
                        pdfCell.BackgroundColor = new BaseColor(generatedGridView.RowStyle.BackColor);
                        pdfTable.AddCell(pdfCell);
                    }
                }
            }
            // Create the PDF document specifying page size and margins
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=generatedSuggestions.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
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

        /**
         * This function is used to fill generated grid with data from the database
         */
        private void loadGeneratedGrid()
        {
            string con = Database.connectionString.con;
            using (sql = new SqlConnection(con))
            {
                sql.Open();
                cmd = new SqlCommand("sp_getGenerated", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userName", Session["user"].ToString());
                cmd.ExecuteNonQuery();
                ds = new DataSet();
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                generatedGridView.DataSource = ds;
                generatedGridView.DataBind();
            }
        }
    }
}