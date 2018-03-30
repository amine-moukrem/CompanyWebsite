using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ProductPage : System.Web.UI.Page
{
    string Product, Title, Description;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Product = Request.QueryString["Product"];
            GetPathToFile("title", Product);
            GetPathToFile("description", Product);
        }
        catch (Exception ex)
        {
            Product = "1001";
            GetPathToFile("title", Product);
            GetPathToFile("description", Product);
        }

        GetContentFiles();
    }

    public void GetContentFiles()
    {
        int key = 1;
        LoadImages(key);
        ItemTitle.Text = GetPathToFile("title", Product);
        ProdDescLabel.Text = "\u2022 " + GetPathToFile("description", Product);
    }

    // When thumbnail of image is clicked, sets main image to image clicked
    public void ProductImage_OnClick(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            try
            {
                Product = Request.QueryString["Product"];
                GetContentFiles();
                ChangeMainImage(sender);
            }
            catch (Exception ex)
            {
                Product = "1001";
                GetContentFiles();
                ChangeMainImage(sender);
            }
        }

        //MainImgUpdate.Update();
    }

    // Sets images of thumbnails and initial main image
    public void LoadImages(int key)
    {
        MainImage.ImageUrl = "../images/" + Product + "/1.JPG";
        Thumbnail1.ImageUrl = "../images/" + Product + "/1.JPG";
        Thumbnail2.ImageUrl = "../images/" + Product + "/2.JPG";
        Thumbnail3.ImageUrl = "../images/" + Product + "/3.JPG";
        Thumbnail4.ImageUrl = "../images/" + Product + "/4.JPG";
    }

    // Changes main image of a product page
    public void ChangeMainImage(object sender)
    {
        ImageButton btn = (ImageButton)sender;
        string sent = btn.ID;
        int key = Int32.Parse(Regex.Match(sent, "\\d+").Value);
        MainImage.ImageUrl = "../images/" + Product + "/" + key + ".JPG";
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

    public void AddToCart()
    {

    }
}