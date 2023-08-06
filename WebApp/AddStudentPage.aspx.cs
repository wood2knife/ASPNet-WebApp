using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Core;
using System.Security.Policy;


namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string subjects = @"SELECT SubjectID, Subject FROM SubjectTable";
                string groups = @"SELECT DISTINCT GroupID, GroupNumber FROM StudentTable";

                var dataTableSubjects = DB.GetDataFromDB(groups);
                GroupNumberDropDownList.DataSource = dataTableSubjects;
                GroupNumberDropDownList.DataTextField = "GroupNumber";
                GroupNumberDropDownList.DataValueField = "GroupID";
                GroupNumberDropDownList.DataBind();

                var dataTableGroups = DB.GetDataFromDB(subjects);
                ExamDropDownList.DataSource = dataTableGroups;
                ExamDropDownList.DataTextField = "Subject";
                ExamDropDownList.DataValueField = "SubjectID";
                ExamDropDownList.DataBind();
            }
        }
        protected void AddData_Click(object sender, EventArgs e)
        {
            string addStudent = @"INSERT INTO StudentTable (RecordBook, GroupID, GroupNumber, Fam, Name, Otchestvo) 
                                        VALUES (@recordBook, @groupID, @groupNumber, @fam, @name, @otchestvo);
                                  INSERT INTO ExamTable (SubjectID, LecturerID, GroupID, Exam, DateOfExam, Mark) VALUES (@subjectID, @lecturerID, @groupID, @exam, @dateOfExam, @mark)";
            var dataTableInsertStudent = DB.GetDataFromDB(addStudent, new List<SqlParameter>
            {
                new SqlParameter
                {
                    Value = Int32.Parse(RecordBookTextBox.Text),
                    ParameterName= "@recordBook",
                    SqlDbType=SqlDbType.Int,
                },
                new SqlParameter
                {
                    Value = Int32.Parse(GroupNumberDropDownList.SelectedItem.Value),
                    ParameterName= "@groupID",
                    SqlDbType=SqlDbType.Int,
                },
                new SqlParameter
                {
                    Value = Int32.Parse(GroupNumberDropDownList.SelectedItem.Text),
                    ParameterName= "@groupNumber",
                    SqlDbType=SqlDbType.Int,
                },
                new SqlParameter
                {
                    Value = StudentSurnameTextBox.Text,
                    ParameterName= "@fam",
                    SqlDbType=SqlDbType.NVarChar,
                    Size=50
                },
                new SqlParameter
                {
                    Value = StudentNameTextBox.Text,
                    ParameterName= "@name",
                    SqlDbType=SqlDbType.NVarChar,
                    Size=50
                },
                new SqlParameter
                {
                    Value = StudentOtchestvoTextBox.Text,
                    ParameterName= "@otchestvo",
                    SqlDbType=SqlDbType.NVarChar,
                    Size=50
                },
                new SqlParameter
                {
                    Value = Int32.Parse(ExamDropDownList.SelectedItem.Value),
                    ParameterName= "@subjectID",
                    SqlDbType=SqlDbType.Int,
                },
                new SqlParameter
                {
                    Value = UserSession.Current.UserID,
                    ParameterName= "@lecturerID",
                    SqlDbType=SqlDbType.Int,
                },
                new SqlParameter
                {
                    Value = ExamDropDownList.SelectedItem.Text,
                    ParameterName= "@exam",
                    SqlDbType=SqlDbType.NVarChar,
                    Size=50
                },
                new SqlParameter
                {
                    Value = DateTime.Parse(DateOfExamTextBox.Text),
                    ParameterName= "@dateOfExam",
                    SqlDbType=SqlDbType.Date,
                },
                new SqlParameter
                {
                    Value = Int32.Parse(MarkTextBox.Text),
                    ParameterName= "@mark",
                    SqlDbType=SqlDbType.Int,
                }
            }) ;
            RecordBookTextBox.Text = "";
            StudentSurnameTextBox.Text = "";
            StudentNameTextBox.Text = "";
            StudentOtchestvoTextBox.Text = "";
            DateOfExamTextBox.Text = "";
            MarkTextBox.Text = "";
        }
    }
}