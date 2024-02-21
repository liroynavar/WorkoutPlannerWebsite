using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace MyProject
{
    public partial class ShowUsersData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dataTable = new DataTable();

                using (OleDbConnection con1 = new OleDbConnection())
                {
                    con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb");
                    con1.Open();
                    string sqlstring1 = "SELECT * FROM Plans";
                    OleDbCommand cmd = new OleDbCommand(sqlstring1, con1);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

                    adapter.Fill(dataTable);
                    dataorg.DataSource = dataTable;
                    dataorg.DataBind();
                }

            }

        }
        protected void delBtn1_Click(object sender, EventArgs e)
        {
            OleDbConnection Con1 = new OleDbConnection();
            Button delBtn = (Button)sender;
            string[] arguments = delBtn.CommandArgument.Split(';');
            string UserID = arguments[0];
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb");

            string query = "DELETE * FROM Plans WHERE UserID = '" + UserID +"'";
            OleDbCommand cmd2 = new OleDbCommand(query, Con1);

            Con1.Open();
            cmd2.ExecuteNonQuery();
            Response.Redirect("ShowUsersData.aspx");
        }
    }
}
