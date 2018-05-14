using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public void CustToDisplay(Customer cust)
    {
        fnameDisplayLabel.Text = cust.FirstName + " ";
        lnameDisplayLabel.Text = cust.LastName;
        dobDisplay.Text = cust.DateOfBirth.ToString("dd/MM/yyyy");

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
        Random rnd = new Random();
        int personID = rnd.Next(1, 10000);
        cust1.PersNumber = personID;
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

        AddPersonToDatabase(cust1);
    }

    public void AddPersonToDatabase(Customer cust1) {
        Random rnd = new Random();
        int personID = rnd.Next(1, 10000);
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SQLDbConnection"].ConnectionString);

        // Inserts Person data
        String query = "INSERT INTO ist411.Person (PersonId,FirstName,LastName,BirthDate,Username,Password)"
            + " VALUES (@PersonId,@FirstName,@LastName,@BirthDate,@Username,@Password)";

        SqlCommand command = new SqlCommand(query, con);
        command.Parameters.Add("@PersonId", SqlDbType.Int);
        command.Parameters.Add("@FirstName", SqlDbType.VarChar);
        command.Parameters.Add("@LastName", SqlDbType.VarChar);
        command.Parameters.Add("@BirthDate", SqlDbType.Date);
        command.Parameters.Add("@Username", SqlDbType.VarChar);
        command.Parameters.Add("@Password", SqlDbType.VarChar);

        command.Parameters["@PersonId"].Value = cust1.PersNumber;
        command.Parameters["@FirstName"].Value = cust1.FirstName;
        command.Parameters["@LastName"].Value = cust1.LastName;
        command.Parameters["@BirthDate"].Value = cust1.DateOfBirth;
        command.Parameters["@Username"].Value = "jhender";
        command.Parameters["@Password"].Value = "bob";

        con.Open();
        int result = command.ExecuteNonQuery();

        if (result < 0)
            Console.WriteLine("Couldn't insert into db.");

        // Insert Address data
        int addressID = rnd.Next(1, 10000);
        query = "INSERT INTO ist411.Address (AddressId,PersonId,Address1)" 
            + " VALUES (@AddressId,@PersonId,@Address1)";
        command = new SqlCommand(query, con);
        command.Parameters.Add("@AddressId", SqlDbType.Int);
        command.Parameters.Add("@PersonId", SqlDbType.Int);
        command.Parameters.Add("@Address1", SqlDbType.VarChar);

        command.Parameters["@AddressId"].Value = addressID;
        command.Parameters["@PersonId"].Value = personID;
        command.Parameters["@Address1"].Value = cust1.AddressesList[0];

        result = command.ExecuteNonQuery();

        if (result < 0)
            Console.WriteLine("Couldn't insert into db.");

        // Inserts Phone data
        int phoneID = rnd.Next(1, 10000);

        string phone = cust1.PhoneNumsList[0];
        string areaCode = phone.Substring(0, 3);
        string npa = phone.Substring(3, 3);
        string nxx = phone.Substring(6, 4);

        query = "INSERT INTO ist411.Phone (PhoneId,PersonId,AreaCode,NPA,NXX)"
            + " VALUES (@PhoneId,@PersonId,@AreaCode,@NPA,@NXX)";

        command = new SqlCommand(query, con);
        command.Parameters.Add("@PhoneId", SqlDbType.Int);
        command.Parameters.Add("@PersonId", SqlDbType.Int);
        command.Parameters.Add("@AreaCode", SqlDbType.Char);
        command.Parameters.Add("@NPA", SqlDbType.Char);
        command.Parameters.Add("@NXX", SqlDbType.Char);

        command.Parameters["@PhoneId"].Value = phoneID;
        command.Parameters["@PersonId"].Value = personID;
        command.Parameters["@AreaCode"].Value = areaCode;
        command.Parameters["@NPA"].Value = npa;
        command.Parameters["@NXX"].Value = nxx;

        result = command.ExecuteNonQuery();

        if (result < 0)
            Console.WriteLine("Couldn't insert into db.");
        con.Close();
    }
}