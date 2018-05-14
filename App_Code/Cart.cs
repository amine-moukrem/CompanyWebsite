using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cart
/// </summary>
public class Cart
{
    private int quantity;
    private string paymentMethod;
    private List<Product> CartProducts;
    private double totalPrice;

    public Cart()
    {
        CartProducts = new List<Product>();
    }

    // Total price of items in cart
    public double TotalPrice()
    {
        double total = 0;
        for (int i = 0; i < CartProductList.Count; i++)
        {
            total += CartProductList[i].ProductPrice * CartProductList[i].ProductQuantity;
        }
        return total;
    }

    // Number of products in cart
    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public string PaymentMethod
    {
        get { return paymentMethod; }
        set { paymentMethod = value; }
    }

    public List<Product> CartProductList
    {
        get { return CartProducts; }
    }

    // Total cost of current products in cart
    public double TotalOrder(double price)
    {
        for (int i = 0; i < CartProducts.Count; i++)
        {
            price += CartProducts[i].ProductPrice;
        }
        return price;
    }
    
    // Checks if product cookie already exists
    public Boolean CheckForCookie()
    {
        if (HttpContext.Current.Request.Cookies["productCookie"] != null)
        {
            return true;
        }
        return false;
    }

    // Fills cart object using a cookie
    public Cart ParseCartFromCookie(string cookieString)
    {
        Cart myCart = new Cart();

        string[] splitProducts = cookieString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

    
        for (int i = 0; i < splitProducts.Length; i++)
        {
            if (!string.IsNullOrEmpty(cookieString))
            {
                List<string> parts = splitProducts[i].Split('|').Select(p => p.Trim()).ToList();
                CartProducts.Add(new Product(int.Parse(parts[0]), parts[1], parts[2], double.Parse(parts[3]), parts[4]));
            }
        }
    
        return myCart;
    }

    // Gets string of product cookie and removes the selected product from it
    public void RemoveProductFromCart(string productStr)
    {
        string cookieString;
        cookieString = HttpContext.Current.Request.Cookies["productCookie"]["products"];

        string[] splitProducts = cookieString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < splitProducts.Length; i++)
        {
            if (!string.IsNullOrEmpty(cookieString) && splitProducts[i].Contains(productStr))
            {
                List<string> temp = new List<string>();
                temp = splitProducts.OfType<string>().ToList();
                temp.RemoveAt(i);
                splitProducts = temp.ToArray();
            }
        }
        cookieString = string.Join(",", splitProducts);
        HttpContext.Current.Response.Cookies["productCookie"]["products"] = cookieString;
        HttpContext.Current.Response.Cookies["productCookie"].Expires = DateTime.Now.AddDays(1);
        HttpContext.Current.Response.Cookies.Add(HttpContext.Current.Response.Cookies["productCookie"]);
    }
}
