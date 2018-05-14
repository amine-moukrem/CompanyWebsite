using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Checkout : System.Web.UI.Page
{
    HttpCookieCollection cookieColl;
    string products = string.Empty;
    string keyWord;
    Cart myCart = new Cart();

    protected void Page_Load(object sender, EventArgs e)
    {
        postCheckout.Visible = false;
        DataTable table = new DataTable();
        DataRow row;
        cookieColl = Request.Cookies;
        table.Columns.Add("Product");
        table.Columns.Add("Price");
        table.Columns.Add("Qty");

        try
        {
            products = Request.Cookies["productCookie"]["products"];
        }
        catch (NullReferenceException)
        {

        }
        // Adds products from cookie to cart
        myCart.ParseCartFromCookie(products);

        // Gets cart info
        for (int i = 0; i < myCart.CartProductList.Count; i++)
        {
            row = table.NewRow();
            row["Product"] = myCart.CartProductList[i].ProductName;
            row["Price"] = "$" + myCart.CartProductList[i].ProductPrice * myCart.CartProductList[i].ProductQuantity
                + " ($" + myCart.CartProductList[i].ProductPrice + " each)";
            row["Qty"] = myCart.CartProductList[i].ProductQuantity;
            table.Rows.Add(row);
        }
        cartTotalLabel.Text = "Total: $" + myCart.TotalPrice();
        itemTotal.Text = "Item total: $" + myCart.TotalPrice();
        taxTotal.Text = "Tax: $" + (myCart.TotalPrice() * .06);
        finalTotal.Text = "Purchase total: $" + (myCart.TotalPrice() + (myCart.TotalPrice() * .06));
        finalTotal.Font.Bold = true;
        GridView1.DataSource = table;
        GridView1.DataBind();
    }

    // Removes product from grid and cookie
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.CompareTo("RemoveProduct") == 0)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                keyWord = row.Cells[index].Text;
                myCart.RemoveProductFromCart(keyWord);

                GridView1.DataBind();
                Response.Redirect(Request.RawUrl);
            }
            catch (NullReferenceException)
            {

            }
        }
    }

    protected void PurchaseBttn_Click(object sender, EventArgs e)
    {
        Random rand = new Random();
        int orderId = rand.Next(1, 10000);
        int personId = rand.Next(1, 10000);
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString);
        String query = "INSERT INTO ist411.[Order] (OrderId,PersonId,OrderDate,total)"
            + " VALUES (@OrderId,@PersonId,@OrderDate,@total)";
        SqlCommand command = new SqlCommand(query, con);
        con.Open();
        try
        {
            products = Request.Cookies["productCookie"]["products"];
        }
        catch (NullReferenceException)
        {

        }
        
        command.Parameters.Add("@OrderId", SqlDbType.Int);
        command.Parameters.Add("@PersonId", SqlDbType.Int);
        command.Parameters.Add("@OrderDate", SqlDbType.DateTime);
        command.Parameters.Add("@total", SqlDbType.Decimal);

        command.Parameters["@OrderId"].Value = orderId;
        command.Parameters["@PersonId"].Value = personId;
        command.Parameters["@OrderDate"].Value = DateTime.Now;
        command.Parameters["@total"].Value = (myCart.TotalPrice() + (myCart.TotalPrice() * .06));

        int result = command.ExecuteNonQuery();

        if (result < 0)
            Console.WriteLine("Couldn't insert into db.");

        // Adds products from cookie to cart
        myCart.ParseCartFromCookie(products);

        for (int i = 0; i < myCart.CartProductList.Count; i++)
        {
            query = "INSERT INTO ist411.OrderItem (OrderItemId,CustomerId,ProductId,Quantity,PricePer,OrderId)"
            + " VALUES (@OrderItemId,@CustomerId,@ProductId,@Quantity,@PricePer,@OrderId)";
            command = new SqlCommand(query, con);
            command.Parameters.Add("@OrderItemId", SqlDbType.Int);
            command.Parameters.Add("@CustomerId", SqlDbType.Int);
            command.Parameters.Add("@ProductId", SqlDbType.Int);
            command.Parameters.Add("@Quantity", SqlDbType.Int);
            command.Parameters.Add("@PricePer", SqlDbType.Decimal);
            command.Parameters.Add("@OrderId", SqlDbType.Int);

            command.Parameters["@OrderItemId"].Value = rand.Next(1, 10000);
            command.Parameters["@CustomerId"].Value = personId;
            command.Parameters["@ProductId"].Value = myCart.CartProductList[i].ProductId;
            command.Parameters["@Quantity"].Value = myCart.CartProductList[i].ProductQuantity;
            command.Parameters["@PricePer"].Value = myCart.CartProductList[i].ProductPrice;
            command.Parameters["@OrderId"].Value = orderId;

            result = command.ExecuteNonQuery();

            if (result < 0)
                Console.WriteLine("Couldn't insert into db.");
        }
        maincheckoutdiv.Attributes.Add("style", "display: none");
        postCheckout.Attributes.Add("style", "display:block");
        postCheckout.Visible = true;
    }
}