using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Pages_ViewCart : System.Web.UI.Page
{
    HttpCookieCollection cookieColl;
    string products = string.Empty;
    string keyWord;
    Cart myCart = new Cart();

    protected void Page_Load(object sender, EventArgs e)
    {
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

    protected void checkoutBttn_Click(object sender, EventArgs e)
    {
        myCart.ParseCartFromCookie(products);
        if (myCart.TotalPrice() <= 0)
        {
            cartTotalLabel.Text += " (Cart is empty)";
        }
        else
        {
            try
            {
                if (Request.Cookies["UserSettings"]["User"] != null)
                {
                    Response.Redirect("Checkout.aspx");
                }
            }
            catch (NullReferenceException)
            {
                Response.Redirect("CustomerPage.aspx");
            }
        }
    }
}