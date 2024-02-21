using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyProject
{
    public partial class TrainerSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Insert_Click(object sender, EventArgs e)
        {



            try
            {
                OleDbConnection Con1 = new OleDbConnection();

                Con1.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Server.MapPath("") + "\\Database1.accdb";

                string sqlstring = String.Format(" INSERT INTO TrainersInfo (TFName, TLName, TUName, TPass) VALUES ('{0}','{1}','{2}','{3}')", FName.Text, LName.Text, UName.Text, Pass.Text);

                Con1.Open();
                OleDbCommand cmd = new OleDbCommand(sqlstring, Con1);
                cmd.ExecuteNonQuery();
                Response.Redirect("Login.aspx");
                Con1.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}