using System;
using System.Data;
using System.Data.OleDb;

namespace MyProject
{
    public partial class ShowWorkoutPlan : System.Web.UI.Page
    {
        private int GetMyIDFromUsername()
        {
            int myID = 0;
            string username = Session["username"].ToString();
            using (OleDbConnection connection = new OleDbConnection())
            {
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb");
                connection.Open();

                string query = "SELECT MyID FROM UsersInfo WHERE MyUName = @Username";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        myID = Convert.ToInt32(reader["MyID"]);
                    }
                }
            }

            return myID;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userID = GetMyIDFromUsername().ToString();

                DataTable dataTable = new DataTable();

                using (OleDbConnection con1 = new OleDbConnection())
                {
                    con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb");
                    con1.Open();
                    string sqlstring1 = "SELECT * FROM Plans WHERE UserID= @UserID";
                    OleDbCommand cmd = new OleDbCommand(sqlstring1, con1);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

                    adapter.Fill(dataTable);
                }

                MyPlan.DataSource = dataTable;
                MyPlan.DataBind();
            }
        }
    }
}
