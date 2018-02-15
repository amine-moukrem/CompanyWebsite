using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeePage : System.Web.UI.Page
{
    MasterPage.Person p = new MasterPage.Person();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public class Employee : MasterPage.Person
    {
        private int empNum;
        private String hDate;

        public Employee(int employeeNum, String hireDate)
        {
            empNum = employeeNum;
            hDate = hireDate;
        }
    }
}