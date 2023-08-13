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
        private StudentPageClass CurrentPagination
        {
            get
            {
                if (Session["StudentPageClass"] == null)
                {
                    Session["StudentPageClass"] = new StudentPageClass();
                }

                return (StudentPageClass)Session["StudentPageClass"];
            }
        }
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

        public void DisplayPage()
        {
            DataTable dataTableStudents = CurrentPagination.Students;
            parentRepeater.DataSource = dataTableStudents;
            parentRepeater.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _curl = UserSession.Current;
            try
            {
                Display();
            }
            catch (Exception)
            {
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            CurrentPagination.getData(CurrentPagination.PageNumber, CurrentPagination.PageSize);
            tbPageNumber.Text = CurrentPagination.PageNumber.ToString();
            PaginationRules();
            DisplayPage();
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
            Session["StudentPageClass"] = null;
        }

        public void PaginationRules()
        {
            if (CurrentPagination.PageNumber == 1)
            {
                btnFirstPage.Enabled = false;
                btnPreviousPage.Enabled = false;
                btnNextPage.Enabled = true;
                btnLastPage.Enabled = true;
            }
            if (CurrentPagination.PageNumber == CurrentPagination.AmountOfPages)
            {
                btnFirstPage.Enabled = true;
                btnPreviousPage.Enabled = true;
                btnNextPage.Enabled = false;
                btnLastPage.Enabled = false;
            }
        }

        protected void btnFirstPage_Click(object sender, EventArgs e)
        {
            PaginationRules();

            CurrentPagination.PageNumber = 1;
        }

        protected void btnPreviousPage_Click(object sender, EventArgs e)
        {
            PaginationRules();
            if (CurrentPagination.PageNumber != 1)
                CurrentPagination.PageNumber -= 1;
        }

        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            PaginationRules();
            if (CurrentPagination.PageNumber != CurrentPagination.AmountOfPages)
                CurrentPagination.PageNumber += 1;
        }

        protected void btnLastPage_Click(object sender, EventArgs e)
        {
            PaginationRules();
            CurrentPagination.PageNumber = CurrentPagination.AmountOfPages;
        }
    }
}