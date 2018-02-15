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
        //SiteMapPath1.Visible = (SiteMap.CurrentNode != SiteMap.RootNode); // Hides root node of breadcrumb if currently on home page
    }

    public class Person
    {
        private int pNumber;
        private String fName, lName, dOfBirth;
        private ArrayList phoneNumsList = new ArrayList();
        private ArrayList addressesList = new ArrayList();

        public Person()
        {
            pNumber = 0;
            fName = " ";
            lName = " ";
            dOfBirth = " ";
        }

        public Person(int personNumber, String firstName, String lastName, String dateOfBirth)
        {
            pNumber = personNumber;
            fName = firstName;
            lName = lastName;
            dOfBirth = dateOfBirth;
        }

        public int PersNumber
        {
            get { return pNumber; }
            set { pNumber = value; }
        }

        public String FirstName
        {
            get { return fName;  }
            set { fName = value;  }
        }

        public String LastName
        {
            get { return lName; }
            set { lName = value; }
        }

        public String DateOfBirth
        {
            get { return dOfBirth; }
            set { dOfBirth = value; }
        }

        public ArrayList PhoneNumsList
        {
            get { return phoneNumsList; }
            set { phoneNumsList.Add(value); }
        }
        public ArrayList AddressesList
        {
            get { return addressesList; }
            set { addressesList.Add(value); }
        }
    }
}
