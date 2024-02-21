using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace MyProject
{
    public partial class WorkoutPlan : System.Web.UI.Page
    {
        string TName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve data from the UserInfo table
                OleDbConnection con1 = new OleDbConnection();
                con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb");
                con1.Open();
                string sqlstring = "SELECT MyID FROM UsersInfo";
                OleDbCommand cmd = new OleDbCommand(sqlstring, con1);
                OleDbDataReader reader = cmd.ExecuteReader();

                con1.Close();
            }
            if (!IsPostBack)
            {
                DataTable dataTable = new DataTable();

                using (OleDbConnection con1 = new OleDbConnection())
                {
                    con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb");
                    con1.Open();
                    string sqlstring1 = "SELECT * FROM PlansInfo WHERE TName= '"+Session["username"].ToString()+"'";
                    OleDbCommand cmd = new OleDbCommand(sqlstring1, con1);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

                    adapter.Fill(dataTable);
                    dataorg.DataSource = dataTable;
                    dataorg.DataBind();
                }

                // Store the retrieved data in the session for later use
                Session["WorkoutData"] = dataTable;
            }
        }


        protected void delBtn_Click(object sender, EventArgs e)
        {
            OleDbConnection Con1 = new OleDbConnection();
            Button delBtn = (Button)sender;
            string[] arguments = delBtn.CommandArgument.Split(';');
            string ExName = arguments[0];
            TName = arguments[1];
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb");

            string query = "DELETE * FROM PlansInfo WHERE ExName = '" + ExName + "'  AND TName = '" + TName + "'";
            OleDbCommand cmd2 = new OleDbCommand(query, Con1);

            Con1.Open();
            cmd2.ExecuteNonQuery();
            Response.Redirect("WorkoutPlan.aspx");
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the TrainerName value from the session
                string trainerName = Session["username"].ToString();

                // Retrieve the selected ID from the search bar
                string selectedUserID = searchBox.Text;

                // Retrieve the stored data from the session
                DataTable dataTable = (DataTable)Session["WorkoutData"];

                // Retrieve the Exercises value from the dataorg DataList
                string exercisesString = "";
                foreach (DataRow row in dataTable.Rows)
                {
                    exercisesString += row["ExName"].ToString() + ",";
                }
                exercisesString = exercisesString.TrimEnd(',');

                // Insert the data into the Plans table
                using (OleDbConnection con1 = new OleDbConnection())
                {
                    con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\Database1.accdb";
                    con1.Open();

                    if (!string.IsNullOrEmpty(trainerName) && !string.IsNullOrEmpty(selectedUserID))
                    {
                        string sqlstring = "INSERT INTO Plans (TrainerName, Exercises, UserID) VALUES (@p1, @p2, @p3)";
                        using (OleDbCommand cmd = new OleDbCommand(sqlstring, con1))
                        {
                            cmd.Parameters.AddWithValue("@p1", trainerName);
                            cmd.Parameters.AddWithValue("@p2", exercisesString);
                            cmd.Parameters.AddWithValue("@p3", selectedUserID);
                            cmd.ExecuteNonQuery();
                        }

                        Response.Write("Data inserted successfully!");
                    }
                    else
                    {
                        Response.Write("Trainer name or selected user ID is missing or empty.");
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

