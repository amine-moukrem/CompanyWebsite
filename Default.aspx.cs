using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    int numpeople = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int NumPeople
    {
        get { return numpeople; }
        set { numpeople = value; }
    }
}