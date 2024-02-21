using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyProject
{
    public partial class ShowExercise : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string muscle = Request.QueryString["muscle"];
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\Database1.accdb");
                con.Open();
                string sqlstring = "SELECT * FROM ExercisesInfo WHERE Muscle='" + muscle + "'";
                OleDbCommand cmd = new OleDbCommand(sqlstring, con);
                ExerciseList.DataSource = cmd.ExecuteReader();
                ExerciseList.DataBind();
                con.Close();
            }
        }

        protected void AddToBasket(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("SignUp.aspx");
            }

            OleDbConnection Con1 = new OleDbConnection();
            Button basketbtn = (Button)sender;
            string ExName = basketbtn.CommandArgument;
            Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("~/Database1.accdb");
            Con1.Open();
            string sqlstring1 = "SELECT * FROM ExercisesInfo WHERE ExerciseName = ?";
            OleDbCommand command = new OleDbCommand(sqlstring1, Con1);
            command.Parameters.AddWithValue("?", ExName);
            OleDbDataReader Dr = command.ExecuteReader();
            Dr.Read();

            if (Dr.HasRows)
            {
                string Muscle = Dr["Muscle"].ToString();
                string ExampleLink = Dr["ExampleLink"].ToString();
                SelectedItem item = new SelectedItem();
                item.NameOfEx = ExName;
                item.ExMuscle = Muscle;
                item.ExLink = ExampleLink;
                Con1.Close();

                Basket B;
                if (Session["Basket"] == null)
                {
                    B = new Basket();
                }
                else
                {
                    B = (Basket)Session["Basket"];
                }

                bool checker = true;
                foreach (SelectedItem i in B.BasketList)
                {
                    if (i.NameOfEx == item.NameOfEx)
                    {
                        checker = false;
                    }
                }

                if (checker)
                {
                    B.ADDitem(item);
                    string TName = Session["username"].ToString();
                    OleDbConnection con2 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\Database1.accdb");
                    con2.Open();
                    string sqlstring2 = "INSERT INTO PlansInfo (ExName, ExMuscle, TName) VALUES (?, ?, ?)";
                    OleDbCommand cmd2 = new OleDbCommand(sqlstring2, con2);
                    cmd2.Parameters.AddWithValue("?", item.NameOfEx);
                    cmd2.Parameters.AddWithValue("?", item.ExMuscle);
                    cmd2.Parameters.AddWithValue("?", TName);
                    cmd2.ExecuteNonQuery();
                    con2.Close();

                    Response.Write("Added Successfully!");

                    OleDbConnection con3 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\Database1.accdb");
                    con3.Open();
                    string sqlstring3 = "UPDATE ExercisesInfo SET NumberOfUse = NumberOfUse + 1 WHERE ExerciseName = ?";
                    OleDbCommand cmd3 = new OleDbCommand(sqlstring3, con3);
                    cmd3.Parameters.AddWithValue("?", item.NameOfEx);
                    cmd3.ExecuteNonQuery();
                    con3.Close();
                }
                else
                {
                    Response.Write("Item is Already in Your Basket!");
                }

                Session["Basket"] = B;
            }
        }




        protected void SelectButton_Command(object sender, EventArgs e)
        {
            string exerciseName = ((Button)sender).CommandArgument.ToString();
            Response.Write("You selected " + exerciseName);
        }

    }
}



