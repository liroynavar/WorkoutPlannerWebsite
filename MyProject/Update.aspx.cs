using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MyProject
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the session contains the username
                if (Session["username"] != null)
                {
                    string username = Session["username"].ToString();
                    LoadUserData(username);
                }
            }
        }

        private void LoadUserData(string username)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection())
                {
                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\Database1.accdb";

                    string sqlstring = "SELECT MyFName, MyLName, MyUName, MyAge, MyWeight, MyHeight, MyBodyFat, MyPass FROM UsersInfo WHERE MyUName = ?";

                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = sqlstring;
                    cmd.Parameters.AddWithValue("@MyUName", username);

                    OleDbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MyFName.Text = reader["MyFName"].ToString();
                        LName.Text = reader["MyLName"].ToString();
                        UName.Text = reader["MyUName"].ToString();
                        Pass.Text = reader["MyPass"].ToString();
                        Age.Text = reader["MyAge"].ToString();
                        Weight.Text = reader["MyWeight"].ToString();
                        Height.Text = reader["MyHeight"].ToString();
                        BodyFat.Text = reader["MyBodyFat"].ToString();
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = Session["username"].ToString();

                using (OleDbConnection connection = new OleDbConnection())
                {
                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\Database1.accdb";

                    string sqlstring = "UPDATE UsersInfo SET MyFName = ?, MyLName = ?, MyWeight = ?, MyBodyFat = ?, MyHeight = ?, MyAge = ?, MyPass = ? WHERE MyUName = ?";

                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = sqlstring;
                    cmd.Parameters.AddWithValue("@MyFName", MyFName.Text);
                    cmd.Parameters.AddWithValue("@MyLName", LName.Text);
                    cmd.Parameters.AddWithValue("@MyWeight", Weight.Text);
                    cmd.Parameters.AddWithValue("@MyBodyFat", BodyFat.Text);
                    cmd.Parameters.AddWithValue("@MyHeight", Height.Text);
                    cmd.Parameters.AddWithValue("@MyAge", Age.Text);
                    cmd.Parameters.AddWithValue("@MyPass", Pass.Text);
                    cmd.Parameters.AddWithValue("@Username", username);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Redirect("HomePage.aspx");
                    }
                    else
                    {
                        // Handle case where the update did not succeed
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }





    }
}