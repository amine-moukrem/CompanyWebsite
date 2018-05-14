using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    private string productID, name;
    private Image productImage;
    private string productDescription;
    private int quantity;
    private double productPrice;

    public Product()
    {

    }

    public Product(int quant, string prodId, string prodName, double prodPrice, string prodDesc)
    {
        quantity = quant;
        productID = prodId;
        name = prodName;
        productDescription = prodDesc;
        productPrice = prodPrice;
    }

    // Product ID
    public string ProductId
    {
        get { return productID; }
        set { productID = value; }
    }

    // Name of product
    public string ProductName
    {
        get { return name; }
        set { name = value; }
    }
    
    // List of product images
    public Image ProductImage
    {
        get { return productImage; }
        set { productImage = value; }
    }

    // Description of product
    public string ProductDescription
    {
        get { return productDescription; }
        set { productDescription = value; }
    }

    // Number of instances of this product
    public int ProductQuantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    // Price of product
    public double ProductPrice
    {
        get { return productPrice; }
        set { productPrice = value; }
    }
}