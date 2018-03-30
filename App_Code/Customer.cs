using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer : Person
{
    private string nOrders;
    private string fOrderDate;

    public Customer(string numOrders, string firstOrderDate)
    {
        nOrders = numOrders;
        fOrderDate = firstOrderDate;
    }

    public string NumberOfOrders
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