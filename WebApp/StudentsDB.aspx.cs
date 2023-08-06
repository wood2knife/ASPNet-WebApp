using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApp.Core;

namespace WebApp
{
    public partial class StudentsDB : System.Web.UI.Page
    {

        private UserSession _curl;
        private void Display()
        {
            switch(_curl.Role)
            {
                case "admin":
                    AddStudentButton.Visible = true;
                    break;
                case "lecturer":
                    AddStudentButton.Visible = true;
                    break;
                case "student":
                    AddStudentButton.Visible = false;
                    break; 
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _curl = UserSession.Current;
            try
            {
                Display();
                string getStudentsInfo = @"
                    SELECT StudentTable.RecordBook, StudentTable.Fam, StudentTable.Name,
                    StudentTable.Otchestvo, ExamTable.Exam, ExamTable.DateOfExam,
                    ExamTable.Mark FROM ExamTable INNER JOIN StudentTable ON ExamTable.ExamID=StudentTable.StudentID";
                DataTable dataTableStudents = DB.GetDataFromDB(getStudentsInfo);
                parentRepeater.DataSource = dataTableStudents;
                parentRepeater.DataBind();
            }
            catch (Exception)
            {
            }
        }
        protected void AddStudent_Click(object sender, EventArgs e)
        {
            string url = "AddStudentPage.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=900,height=600,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

        }
        protected void LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            _curl = null;
        }
    }
}