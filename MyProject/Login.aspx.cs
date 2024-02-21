using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace MyProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UName.Text;
            string password = Pass.Text;
            OleDbConnection conn = new OleDbConnection();

            try
            {
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\Database1.accdb";
                conn.Open();

                // Check the UsersInfo table
                OleDbCommand cmdUsers = new OleDbCommand("SELECT * FROM UsersInfo WHERE MyUName=@username AND MyPass=@password", conn);
                cmdUsers.Parameters.AddWithValue("@MyUName", username);
                cmdUsers.Parameters.AddWithValue("@MyPass", password);
                OleDbDataReader readerUsers = cmdUsers.ExecuteReader();

                // Check the TrainersInfo table
                OleDbCommand cmdTrainers = new OleDbCommand("SELECT * FROM TrainersInfo WHERE TUName=@username AND TPass=@password", conn);
                cmdTrainers.Parameters.AddWithValue("@TFName", username);
                cmdTrainers.Parameters.AddWithValue("@TPass", password);
                OleDbDataReader readerTrainers = cmdTrainers.ExecuteReader();

                if (readerUsers.HasRows || readerTrainers.HasRows)
                {
                    // Login successful
                    Session["username"] = username;
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    // Login failed
                    Response.Write("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
