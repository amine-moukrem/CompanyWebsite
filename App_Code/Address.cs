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