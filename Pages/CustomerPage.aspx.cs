using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerPage : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void AddPhoneNumToListBox(object sender, EventArgs e)
    {
        Boolean checkNums = true; // checks if value entered is all numbers and 10 chars long

        if (phoneBox.Text.Length != 10)
        {
            checkNums = false;
        }

        else
        {
            // Checks if all chars in string are numbers
            for (int i = 0; i < 10; i++)
            {
                if (!Char.IsNumber(phoneBox.Text[i])) 
                {
                    checkNums = false;
                }
            }
        }

        try
        {
            if (checkNums)
            {
                phoneNumsListBox.Items.Add(new ListItem(phoneBox.Text));
                phoneBox.Text = "";
            }
        }
        catch ( NullReferenceException)
        {

        }
        
    }
    /*
     * Adds addresses to ListBox from addressBox, clears addressBox
     */
    public void AddAddressToListBox(object sender, EventArgs e)
    {
        addressesListBox.Items.Add(new ListItem(addressBox.Text));
        addressBox.Text = "";
    }

    /*
     * Sets text of labels in results form
     */
    public void CustToDisplay(Customer cust)
    {
        fnameDisplayLabel.Text = cust.FirstName + " ";
        lnameDisplayLabel.Text = cust.LastName;
        //dobDisplay.Text = cust.DateOfBirth;

        for (int a = 0; a < phoneNumsListBox.Items.Count; a++)
        {
            DisplayPNums.Text += phoneNumsListBox.Items[a].ToString();
            // Adds hyphens between phone numbers
            if (a != phoneNumsListBox.Items.Count - 1)
            {
                DisplayPNums.Text += " - ";
            }
        }

        for (int a = 0; a < addressesListBox.Items.Count; a++) { 
            DisplayAddresses.Text += addressesListBox.Items[a].ToString();
            // Adds hyphens between addresses
            if (a != addressesListBox.Items.Count - 1)
            {
                DisplayAddresses.Text += " - ";
            }
        }
        NumOrdersDisplay.Text = cust.NumberOfOrders;
        FOrderDisplay.Text = cust.FirstOrderDate;
    }

    /*
     * Creates instance of Customer, adds values to it from site
     */
    public void DoneClickEmp(object sender, EventArgs e)
    {
        Customer cust1 = new Customer("", "");
        cust1.FirstName = custFNameBox.Text;
        cust1.LastName = custLNameBox.Text;
        //cust1.DateOfBirth = bdaybox.Value.ToString();
        cust1.NumberOfOrders = numOrdersBox.Text;
        cust1.FirstOrderDate = fOrderDateBox.Value.ToString();

        for (int a = 0; a < phoneNumsListBox.Items.Count; a++)
            cust1.PhoneNumsList.Add(phoneNumsListBox.Items[a].ToString());

        for (int a = 0; a < addressesListBox.Items.Count; a++)
            cust1.AddressesList.Add(addressesListBox.Items[a].ToString());

        formdiv.Attributes.Add("style", "display:none");
        custresults.Attributes.Add("style", "display:block");

        custresults.Visible = true;

        CustToDisplay(cust1);
    }
}