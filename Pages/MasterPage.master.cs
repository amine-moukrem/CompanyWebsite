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
        SiteMapPath1.Visible = (SiteMap.CurrentNode != SiteMap.RootNode); // Hides root node of breadcrumb if currently on home page
    }

    /**
     * TO DO: Populate address and phonenum classes, use them instead of List<string>
     */
    public class Address
    {
        private string stAddress, city, state, zip;

        public Address()
        {
            stAddress = " ";
            city = " ";
            state = " ";
            zip = " ";
        }

        public string StreetAddress
        {
            get { return stAddress; }
            set { stAddress = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { zip = value; }
        }

    }

    public class PhoneNums
    {
        private string phonenum;

        public string PhoneNum
        {
            get { return phonenum; }
            set { phonenum = value; }
        }
    }

    
}