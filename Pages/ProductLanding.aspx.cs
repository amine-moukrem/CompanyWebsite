using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ProductLanding : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Product1.ImageUrl = "../images/1001/1.JPG";
        Product2.ImageUrl = "../images/1002/1.JPG";
        Product3.ImageUrl = "../images/1003/1.JPG";
    }
}