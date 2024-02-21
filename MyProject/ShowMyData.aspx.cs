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
    public partial class ShowMyData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dataTable = new DataTable();

                string username = Session["username"]?.ToString();

                if (!string.IsNullOrEmpty(username))
                {
                    using (OleDbConnection con1 = new OleDbConnection())
                    {
                        con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb");
                        con1.Open();
                        string sqlstring1 = "SELECT * FROM UsersInfo WHERE MyUName = '" + Session["username"].ToString() + "'";
                        OleDbCommand cmd = new OleDbCommand(sqlstring1, con1);
                        cmd.Parameters.AddWithValue("@username", username);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

                        adapter.Fill(dataTable);
                        dataorg2.DataSource = dataTable;
                        dataorg2.DataBind();
                    }
                }
            }
        }

        protected void delBtn1_Click(object sender, EventArgs e)
        {
            Button delBtn = (Button)sender;
            string MyID = delBtn.CommandArgument;

            using (OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb")))
            {
                string query = "DELETE FROM UsersInfo WHERE MyID = @MyIDParam";
                OleDbCommand cmd2 = new OleDbCommand(query, con1);
                cmd2.Parameters.AddWithValue("@MyIDParam", MyID);

                con1.Open();
                cmd2.ExecuteNonQuery();
            }

            Response.Redirect("ShowMyData.aspx");
        }








    }
}
