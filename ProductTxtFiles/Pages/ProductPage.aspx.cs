using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ProductPage : System.Web.UI.Page
{
    string prodName, productStr, title, description, price;
    int quantity = 1;
    Cart myCart = new Cart();
    string cookieString;

    protected void Page_Load(object sender, EventArgs e)
    {
        /* // deletes cookie for testing
        Request.Cookies["productCookie"].Expires = DateTime.Now.AddDays(-10);
        Response.Cookies.Add(Request.Cookies["productCookie"]); */

        try
        {
            productStr = Request.QueryString["Product"];
            GetPathToFile("title", productStr);
            GetPathToFile("description", productStr);
            GetPathToFile("price", productStr);
        }
        catch (Exception ex)
        {
            productStr = "1001";
            GetPathToFile("title", productStr);
            GetPathToFile("description", productStr);
            GetPathToFile("price", productStr);
        }
        GetContentFiles();
    }

    // Gets data to be displayed on product page
    public void GetContentFiles()
    {
        int key = 1;
        LoadImages(key);
        prodName = GetPathToFile("title", productStr);
        ItemTitle.Text = prodName;
        description = "\u2022 " + GetPathToFile("description", productStr);
        ProdDescLabel.Text = description;
        price = GetPathToFile("price", productStr);
        ProdPriceLabel.Text = "$" +price;
    }

    // When thumbnail of image is clicked, sets main image to image clicked
    public void ProductImage_OnClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            try
            {
                productStr = Request.QueryString["Product"];
                GetContentFiles();
                ChangeMainImage(sender);
            }
            catch (Exception ex)
            {
                productStr = "1001";
                GetContentFiles();
                ChangeMainImage(sender);
            }
        }
    }

    // Sets images of thumbnails and initial main image
    public void LoadImages(int key)
    {
        MainImage.ImageUrl = "../images/" + productStr + "/1.JPG";
        Thumbnail1.ImageUrl = "../images/" + productStr + "/1.JPG";
        Thumbnail2.ImageUrl = "../images/" + productStr + "/2.JPG";
        Thumbnail3.ImageUrl = "../images/" + productStr + "/3.JPG";
        Thumbnail4.ImageUrl = "../images/" + productStr + "/4.JPG";
    }

    // Changes main image of a product page
    public void ChangeMainImage(object sender)
    {
        ImageButton btn = (ImageButton)sender;
        string sent = btn.ID;
        int key = Int32.Parse(Regex.Match(sent, "\\d+").Value);
        MainImage.ImageUrl = "../images/" + productStr + "/" + key + ".JPG";
    }

    // Gets info from info.txt
    public string GetPathToFile(string akey, string Product)
    {
        string text = "", temp = "";

        StreamReader reader = File.OpenText(Server.MapPath("../ProductTxtFiles/" + Product + "/info.txt"));

        while (!reader.EndOfStream)
        {
            temp = reader.ReadLine();
            if (temp.Contains(akey.ToLower()))
            {
                text = temp.Split(':')[1];
                break;
            }
        }
        return text;
    }

    // Create new cookie
    public void CreateCookie(string cookieString)
    {
        try
        {
            Request.Cookies["productCookie"]["products"] = cookieString;
            Request.Cookies["productCookie"].Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Request.Cookies["productCookie"]);
        }
        catch (NullReferenceException)
        {
            HttpCookie productCookie = new HttpCookie("productCookie");
            Response.Cookies.Add(productCookie);
            Request.Cookies["productCookie"].Values.Add("products", cookieString);
            Request.Cookies["productCookie"].Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(Request.Cookies["productCookie"]);
        }
    }

    // Adds current product properties to cookie
    public void AppendToCookieString()
    {
        cookieString += quantity.ToString() +
            "|" + productStr + "|" + prodName + "|" + price + "|" + description + ",";
    }

    // Checks if cookie string already contains a given product ID
    public Boolean ProductExistsInCookie(string productId, string productcookie)
    {
        try
        {
            if (productcookie.Contains(productId))
            {
                return true;
            }
        }
        catch (NullReferenceException)
        {
            return false;
        }
        return false;
    }

    // AddToCart button handler
    public void AddToCart(object sender, EventArgs e)
    {
        // Checks if cookie already exists
        if (HttpContext.Current.Request.Cookies["productCookie"] != null)
        {
            cookieString = Request.Cookies["productCookie"]["products"];
        }
        else
        {
            cookieString = "";
        }

        /* If cookie string is empty or the current productID
         * doesnt exist in cookie string, append to cookie string
         */
        if (cookieString == "" || !ProductExistsInCookie(productStr, cookieString))
        {
            try
            {
                AppendToCookieString();
                CreateCookie(cookieString);
            }
            catch (NullReferenceException){ }
        }

        // Else add to quantity of the item in cookie string
        else
        {
            string[] splitProducts = cookieString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < splitProducts.Length; i++)
            {
                if (!string.IsNullOrEmpty(cookieString) && splitProducts[i].Contains(productStr))
                {
                    List<string> parts = splitProducts[i].Split('|').Select(p => p.Trim()).ToList();
                    int quant = int.Parse(parts[0]);
                    quant++;
                    parts[0] = quant.ToString();
                    splitProducts[i] = string.Join("|", parts);
                }
            }
            cookieString = string.Join(",", splitProducts);
            CreateCookie(cookieString);
        }
        ProductAddedLabel.Text = "Product added to cart";
    }
}