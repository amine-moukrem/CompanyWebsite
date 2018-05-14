using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeePage : System.Web.UI.Page
{                                           
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void AddPhoneNumToListBox(object sender, EventArgs e)
    {
        // checks if value entered is all numbers and 10 chars long
        Boolean checkNums = true; 

        if (empPhoneBox.Text.Length != 10)
        {
            checkNums = false;
        }

        else
        {
            // Checks if all chars in textbox are numbers
            for (int i = 0; i < 10; i++)
            {
                if (!Char.IsNumber(empPhoneBox.Text[i]))
                {
                    checkNums = false;
                }
            }
        }

        try
        {
            if (checkNums)
            {
                phoneNumsListBox.Items.Add(new ListItem(empPhoneBox.Text));
                empPhoneBox.Text = "";
            }
        }
        catch (NullReferenceException)
        {

        }
    }

    /*
     * Adds addresses to ListBox from addressBox, clears addressBox
     */
    public void AddAddressToListBox(object sender, EventArgs e)
    {
        if (StreetAddressBox.Text.Length > 1 && CityBox.Text.Length > 1 && StateBox.Text.Length > 1 && ZipBox.Text.Length > 1)
        {
            string address = StreetAddressBox.Text + ", " + CityBox.Text + ", " + StateBox.Text + ", " + ZipBox.Text;
            addressesListBox.Items.Add(new ListItem(address));
            StreetAddressBox.Text = "";
            CityBox.Text = "";
            StateBox.Text = "";
            ZipBox.Text = "";
        }
    }

    /*
     * Sets text of labels in results form
     */
    public void EmpToDisplay(Employee emp)
    {
        fnameDisplayLabel.Text = emp.FirstName + " ";
        lnameDisplayLabel.Text = emp.LastName;
        //dobDisplay.Text = emp.DateOfBirth;

        for (int a = 0; a < phoneNumsListBox.Items.Count; a++) {
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

        EmpNumDisplay.Text = emp.EmpNum;
        HireDateDisplay.Text = emp.HDate;

    }

    /*
     * Creates instance of Employee, adds values to it from site
     */
    public void DoneClick(object sender, EventArgs e)
    {
        Employee emp1 = new Employee("", "");
        emp1.FirstName = empFNameBox.Text;
        emp1.LastName = empLNameBox.Text;
        //emp1.DateOfBirth = bdaybox.Value.ToString();
        emp1.EmpNum = empNumBox.Text;
        emp1.HDate= hireDateBox.Value.ToString();

        for (int a = 0; a < phoneNumsListBox.Items.Count; a++)
            emp1.PhoneNumsList.Add(phoneNumsListBox.Items[a].ToString());

        for (int a = 0; a < addressesListBox.Items.Count; a++)
            emp1.AddressesList.Add(addressesListBox.Items[a].ToString());

        formdiv.Attributes.Add("style", "display:none");
        empresults.Attributes.Add("style", "display:block");

        empresults.Visible = true;

        EmpToDisplay(emp1);
    }
}