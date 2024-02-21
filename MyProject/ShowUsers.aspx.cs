using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace MyProject
{
    public partial class ShowUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dataTable = new DataTable();

                using (OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb")))
                {
                    con1.Open();
                    string sqlstring1 = "SELECT * FROM UsersInfo";
                    OleDbCommand cmd = new OleDbCommand(sqlstring1, con1);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

                    adapter.Fill(dataTable);
                    dataorg1.DataSource = dataTable;
                    dataorg1.DataBind();
                }
            }
        }

        protected void delBtn1_Click(object sender, EventArgs e)
        {
            Button delBtn = (Button)sender;
            string MyID = delBtn.CommandArgument;

            using (OleDbConnection con1 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb")))
            {
                string query = "DELETE FROM UsersInfo WHERE MyID = ?";
                OleDbCommand cmd2 = new OleDbCommand(query, con1);
                cmd2.Parameters.AddWithValue("MyIDParam", MyID);

                con1.Open();
                cmd2.ExecuteNonQuery();
            }

            Response.Redirect("ShowUsers.aspx");
        }
    }
}