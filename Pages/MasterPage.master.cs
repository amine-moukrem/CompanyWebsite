using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Hides root node of breadcrumb if currently on home page
        SiteMapPath1.Visible = (SiteMap.CurrentNode != SiteMap.RootNode); 
    }
}