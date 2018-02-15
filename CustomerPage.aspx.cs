using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public class Customer : MasterPage.Person
    {
        private int nOrders;
        private string fOrderDate;

        public Customer(int numOrders, string firstOrderDate)
        {
            nOrders = numOrders;
            fOrderDate = firstOrderDate;
        }

        public int NumberOfOrders
        {
            get { return nOrders; }
            set { nOrders = value; }
        }

        public string FirstOrderDate
        {
            get { return fOrderDate; }
            set { fOrderDate = value; }
        }
    }


    public void DoneClick(object sender, EventArgs e)
    {
        string forderdate = Request["fOrderDateBox"];
        string bday = Request["bdaybox"];
        int numOrders = Int32.Parse(numOrdersBox.Text);


        Customer cust1 = new Customer(numOrders, forderdate);
        
        cust1.PersNumber++;
        cust1.FirstName = custFNameBox.Text;
        cust1.LastName = custLNameBox.Text;
        cust1.DateOfBirth = bday;
        cust1.PhoneNumsList.Add(phoneBox.Text);
        cust1.AddressesList.Add(addressBox.Text);
        cust1.NumberOfOrders = Int32.Parse(numOrdersBox.Text);
        cust1.FirstOrderDate = forderdate;

        custformdiv.Attributes.Add("style", "display:none");
        custresults.Attributes.Add("style", "display:block");
    }
}