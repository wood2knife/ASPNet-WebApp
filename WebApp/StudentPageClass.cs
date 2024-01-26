using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApp.Core;

namespace WebApp
{
    public class StudentPageClass
    {
        public int PageNumber;
        public int PageSize;
        public int TotalRows;
        public int AmountOfPages;
        public DataTable Students = new DataTable();

        private string mainSql = @"
SELECT 
StudentTable.StudentID,
StudentTable.RecordBook, 
StudentTable.Fam, 
StudentTable.Name,
StudentTable.Otchestvo, 
ExamTable.Exam, 
ExamTable.DateOfExam,
ExamTable.Mark 
FROM ExamTable 
INNER JOIN StudentTable 
ON ExamTable.ExamID=StudentTable.StudentID
%ORDER%
%OFFSET%
";

        private string amoutOfStudents = @"
SELECT 
COUNT(*)
FROM ExamTable 
INNER JOIN StudentTable 
ON ExamTable.ExamID=StudentTable.StudentID
";

        public StudentPageClass() 
        {
            PageNumber = 1;
            PageSize= 10;
        }
        public void getData(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            string sql = mainSql
                .Replace("%ORDER%", "ORDER BY StudentTable.RecordBook")
                .Replace("%OFFSET%", $@"
OFFSET {PageNumber - 1} * {PageSize} ROWS
FETCH NEXT {PageSize} ROWS ONLY ");
            Students = DB.GetDataFromDB(sql);
            TotalRows = DB.ExecScalar(amoutOfStudents);
            AmountOfPages = TotalRows / PageSize + 1;
        }

        public bool deleteStudentInfo(int studentId)
        {
            var deleteStudentSql = $@"
delete from StudentTable
where StudentID = {studentId};";
            var execSql = DB.ExecScalar(deleteStudentSql);
            if (execSql != -1)
                return true;
            else
                return false;
        }
    }
}