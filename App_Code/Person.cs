using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Person
/// </summary>
public class Person
{
    Random rand = new Random();
    private int pNumber;
    private String fName, lName;
    private DateTime dOfBirth;
    private List<string> _PhoneNumsList = new List<string>();
    private List<string> _AddressesList = new List<string>();

    private List<Address> addresslist = new List<Address>();
    private List<PhoneNums> phonenumslist = new List<PhoneNums>();

    public Person()
    {
        pNumber = rand.Next(100, 900);
        fName = " ";
        lName = " ";
    }

    public Person(int personNumber, String firstName, String lastName, DateTime dateOfBirth)
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
        get { return fName; }
        set { fName = value; }
    }

    public String LastName
    {
        get { return lName; }
        set { lName = value; }
    }

    public DateTime DateOfBirth
    {
        get { return dOfBirth; }
        set { dOfBirth = value; }
    }

    public List<String> PhoneNumsList
    {
        get { return _PhoneNumsList; }
        set { _PhoneNumsList = value; }
    }

    public List<String> AddressesList
    {
        get { return _AddressesList; }
        set { _AddressesList = value; }
    }
}