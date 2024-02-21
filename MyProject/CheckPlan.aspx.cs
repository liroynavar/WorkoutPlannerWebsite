using MyProject.ServiceReference1;
using System;
using System.Web.UI;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace MyProject
{
    public partial class CheckPlan : Page
    {
        protected void ChkBtn_Click(object sender, EventArgs e)
        {
            // Instantiate the service client using the reference name you provided
            WebServiceSoapClient serviceClient = new WebServiceSoapClient();

            // Retrieve the current user's username from the session
            string username = Session["username"] as string;

            // Retrieve the user's ID from the UsersInfo database
            int userID = GetUserID(username);

            if (userID != -1)
            {
                // Retrieve the exercises for the user from the Plans database
                string exercises = GetExercisesForUser(userID);

                if (!string.IsNullOrEmpty(exercises))
                {
                    // Get the muscles for the exercises
                    string muscleString = GetMuscleFromExercises(exercises);

                    // Check if all muscles are present
                    bool allMusclesPresent = serviceClient.CheckMuscles(muscleString);

                    // Display the result
                    if (allMusclesPresent)
                    {
                        Response.Write("Yes");
                    }
                    else
                    {
                        Response.Write("No");
                    }
                }
                else
                {
                    Response.Write("No exercises found for the user.");
                }
            }
            else
            {
                Response.Write("User not found.");
            }

            // Close the service client
            serviceClient.Close();
        }

        // Method to retrieve the user's ID from the UsersInfo database
        public int GetUserID(string username)
        {
            int myID = -1;

            using (OleDbConnection connection = new OleDbConnection())
            {
                connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb");
                connection.Open();

                string query = "SELECT MyID FROM UsersInfo WHERE MyUName = @Username";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            myID = Convert.ToInt32(reader["MyID"]);
                        }
                    }
                }
            }

            return myID;
        }

        // Method to retrieve the exercises for the user from the Plans database
        public string GetExercisesForUser(int userID)
        {
            string exercises = string.Empty;

            using (OleDbConnection con1 = new OleDbConnection())
            {
                con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb");
                con1.Open();
                string sqlstring1 = "SELECT Exercises FROM Plans WHERE UserID = @UserID";

                using (OleDbCommand cmd = new OleDbCommand(sqlstring1, con1))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            exercises += reader["Exercises"].ToString() + ",";
                        }
                    }
                }
            }

            return exercises;
        }

        // Method to retrieve the muscles for the exercises
        public string GetMuscleFromExercises(string exercises)
        {
            // Split the exercises string by commas
            string[] exerciseArray = exercises.Split(',');

            // List to store the muscles
            List<string> muscles = new List<string>();

            // Construct the connection string for the ExercisesInfo database
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("") + "\\Database1.accdb";

            // Connect to the ExercisesInfo database
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                // Loop through each exercise
                foreach (string exercise in exerciseArray)
                {
                    // Query to retrieve the Muscle field for the exercise
                    string query = "SELECT Muscle FROM ExercisesInfo WHERE ExerciseName = @ExerciseName";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ExerciseName", exercise.Trim());

                        // Execute the query and retrieve the Muscle field
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string muscle = reader.GetString(0);
                                muscles.Add(muscle);
                            }
                        }
                    }
                }
            }

            // Concatenate the muscles into a single string
            string muscleString = string.Join(", ", muscles);

            return muscleString;
        }
    }
}
