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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected bool IsUserInTDatabase(string username)
        {
            bool userExists = false;

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb");

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Replace "trainersinfo" with the actual table name in your database
                string query = "SELECT COUNT(*) FROM TrainersInfo WHERE TUName = @TUName";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TUName", username);
                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            userExists = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception or log the error
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return userExists;
        }
    }
}
