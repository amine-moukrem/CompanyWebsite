using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Address
{
    private string stAddress, city, state, zip;
    private int addressID;

    public Address()
    {
        stAddress = " ";
        city = " ";
        state = " ";
        zip = " ";
    }

    public int AddressID
    {
        get { return addressID; }
        set { addressID = value; }
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

    public string ZipCode 
    {
        get { return zip; }
        set { zip = value; }
    }
}