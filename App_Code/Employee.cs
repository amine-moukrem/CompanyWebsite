using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Employee
/// </summary>
public class Employee : Person
{
    private string empNum;
    private string hDate;

    public Employee(string employeeNum, string hireDate)
    {
        empNum = employeeNum;
        hDate = hireDate;
    }

    public string EmpNum
    {
        get { return empNum; }
        set { empNum = value; }
    }

    public string HDate
    {
        get { return hDate; }
        set { hDate = value; }
    }
}