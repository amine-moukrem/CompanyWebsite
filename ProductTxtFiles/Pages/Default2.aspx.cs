using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string[] authors = new String[] { "Hanselman, Scott", "Evjen, Bill", "haack, Phil", "Viewira, Robert", "Spaanjars, Imar" };

        var result = from author in authors
                     where author.Contains("S")
                     orderby author
                     select author;

        foreach (var author in result) {
            Label1.Text += author + "<br />";
        }

        IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve", Age = 15 } ,
            new Student() { StudentID = 3, StudentName = "Bill", Age = 25 } ,
            new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron", Age = 19 }
        };

        var orderByResult = from s in studentList
                            orderby s.StudentName
                            select s;

        foreach (var s in orderByResult) {
            Label1.Text += s.StudentName + " " + s.StudentID + " " + s.Age + "<br />";
        }

        var filteredResult = studentList.Where(s => s.Age > 12 && s.Age < 20);

        Label1.Text += "<br /> Under 20: <br />";
         foreach (var s in filteredResult) {
            Label1.Text += s.StudentName + " " + s.StudentID + " " + s.Age + "<br />";
        }

        var sumOfage = studentList.Sum(s => s.Age);
        Label1.Text += "<br /> " + sumOfage;
    }
}


public class Student
{

    public Student()
    {

    }

    public int StudentID { get; set; }

    public string StudentName { get; set; }

    public int Age { get; set; }
}