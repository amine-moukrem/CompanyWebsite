using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_MyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.Cookies["UserSettings"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                LoggedInLabel.Text = "Successfully logged in as: " + Request.Cookies["UserSettings"]["User"] + ".";
            }
        } catch (NullReferenceException)
        {
            Response.Redirect("Login.aspx");
        }

        // Creates data table to fill with SQL data
        DataTable table = new DataTable();
        table.Columns.Add("Total");

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString);
        String query = "Select [Order].OrderDate, total from IST411.[Order] order by OrderDate DESC";
        // Select [Order].OrderDate, total, [Order].OrderId, ProductId, Quantity, PricePer from IST411.[Order], ist411.OrderItem where [Order].OrderId = ist411.OrderItem.OrderId
        SqlCommand command = new SqlCommand(query, con);

        con.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        adapter.Fill(table);

        // Assigns data from table to grid
        PastOrdersGrid.DataSource = table;
        PastOrdersGrid.DataBind();
        con.Close();
        adapter.Dispose();
    }

    // Removes current user data cookie and redirects to the login page
    protected void LogoutBttn_Click(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Cookies.Remove("UserSettings");
        Response.Cookies["UserSettings"].Expires = DateTime.Now.AddDays(-10);
        Response.Cookies["UserSettings"].Value = null;
        Response.Redirect("Login.aspx");
    }
}