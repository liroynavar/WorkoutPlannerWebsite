using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyProject
{
    public partial class SignUp : System.Web.UI.Page
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

                string sqlstring = String.Format(" INSERT INTO UsersInfo (MyFName, MyLName, MyWeight, MyBodyFat, MyHeight, MyAge, MyUName, MyPass) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", MyFName.Text, LName.Text, Weight.Text, BodyFat.Text, Height.Text, Age.Text, UName.Text, Pass.Text);

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