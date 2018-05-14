using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack) {
            ViewState["LoginErrors"] = 0;
        }
    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e) {
        if (checkDB(Login1.UserName, Login1.Password)) {
            Login1.Visible = false;
            HttpCookie myCookie = new HttpCookie("UserSettings");
            myCookie["User"] = Login1.UserName;
            myCookie.Expires = DateTime.Now.AddDays(1d);
            Response.Cookies.Add(myCookie);
            Response.Redirect("Account.aspx", true);
        }
        else {
            e.Authenticated = false;
        }
    }

    private Boolean checkDB(string username, string password) {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString);
        String SQLQuery = "select Username, Password FROM IST411.Person";
        SqlCommand command = new SqlCommand(SQLQuery, con);
        SqlDataReader reader;
        con.Open();
        reader = command.ExecuteReader();

        while(reader.Read()) {
            if ((username == reader["Username"].ToString()) & password == reader["Password"].ToString()) {
                return true;
            }
        }
        return false;
    }
}