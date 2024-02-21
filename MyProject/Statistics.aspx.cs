using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Collections.Generic;


namespace MyProject
{
    public partial class Statistics : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("") + "\\Database1.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                int trainersCount = GetTableFieldCount(connection, "TrainersInfo");
                int usersCount = GetTableFieldCount(connection, "UsersInfo");
                int exercisesCount = GetTableFieldCount(connection, "ExercisesInfo");
                int plansCount = GetTableFieldCount(connection, "Plans");

                // Display the counts using Label controls
                lblTrainersCount.Text = "Number of Trainers: " + trainersCount;
                lblUsersCount.Text = "Number of Users: " + usersCount;
                lblExercisesCount.Text = "Number of Exercises: " + exercisesCount;
                lblPlansCount.Text = "Number of Plans: " + plansCount;

                // Retrieve top 5 exercise names based on the number of uses
                string[] topExerciseNames = GetTopExerciseNames(connection, "ExercisesInfo", 5);

                // Display the top 5 exercise names
                for (int i = 0; i < topExerciseNames.Length; i++)
                {
                    Label lblExercise = new Label();
                    lblExercise.Text = "Exercise " + (i + 1) + ": " + topExerciseNames[i] +"   ";
                    lblExercise.CssClass = "exercise-label"; // Optional CSS class for styling
                    exerciseContainer.Controls.Add(lblExercise);
                }
            }
        }

        private int GetTableFieldCount(OleDbConnection connection, string tableName)
        {
            using (OleDbCommand command = new OleDbCommand("SELECT COUNT(*) FROM " + tableName, connection))
            {
                return (int)command.ExecuteScalar();
            }
        }

private string[] GetTopExerciseNames(OleDbConnection connection, string tableName, int limit)
{
    string query = $"SELECT TOP {limit} ExerciseName FROM {tableName} ORDER BY NumberOfUse DESC";
    using (OleDbCommand command = new OleDbCommand(query, connection))
    {
        using (OleDbDataReader reader = command.ExecuteReader())
        {
            List<string> exerciseNames = new List<string>();
            while (reader.Read())
            {
                exerciseNames.Add(reader.GetString(0));
            }
            return exerciseNames.ToArray();
        }
    }
}

    }
}
