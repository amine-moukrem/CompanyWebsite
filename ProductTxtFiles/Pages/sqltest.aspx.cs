using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Pages_sqltest : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString);


    protected void Page_Load(object sender, EventArgs e)
    {
        Select();
    }

    public void Select() {
        string cmdStr = "SELECT * FROM [IST411].[PERSON] WHERE FirstName = @Name";
        using (SqlCommand command = new SqlCommand(cmdStr, connection)) {
            command.Parameters.AddWithValue("@Name", "Nick");
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                Console.WriteLine(reader["FirstName"].ToString(), reader["LastName"].ToString());
            }
            connection.Close();
        }
    }

    public void Update() {
        string cmdStr = "SELECT * FROM [IST411].[PERSON] WHERE FirstName = @Name";
        using (SqlCommand command = new SqlCommand(cmdStr, connection))
        {
            command.Parameters.AddWithValue("@Name", "Nick");
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

     
}