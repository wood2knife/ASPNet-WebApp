<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudentPage.aspx.cs" Inherits="WebApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="css/bootstrap.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row g-3">
            <div class="col-md-3">
                <asp:Label ID="RecordBookLabel" runat="server" Font-Size="Large" Text="Record Book" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="RecordBookTextBox" runat="server" Font-Size="Large" CssClass="form-control mb-3"></asp:TextBox>
                <asp:Label ID="GroupNumberLabel" runat="server" Font-Size="Large" Text="Group Number" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="GroupNumberDropDownList" runat="server" Font-Size="Large" CssClass="form-control mb-3"></asp:DropDownList> 
            </div>
            <div class="col-md-3">
                <asp:Label ID="StudentSurnameLabel" runat="server" Font-Size="Large" Text="Student Surname" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="StudentSurnameTextBox" runat="server" Font-Size="Large" CssClass="form-control mb-3"></asp:TextBox>
                <asp:Label ID="StudentNameLabel" runat="server" Font-Size="Large" Text="Student Name" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="StudentNameTextBox" runat="server" Font-Size="Large" CssClass="form-control mb-3"></asp:TextBox>
                <asp:Label ID="StudentOtchestvoLabel" runat="server" Font-Size="Large" Text="Student Otchestvo" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="StudentOtchestvoTextBox" runat="server" Font-Size="Large" CssClass="form-control mb-3"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label ID="ExamLabel" runat="server" Font-Size="Large" Text="Exam" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="ExamDropDownList" runat="server" Font-Size="Large" CssClass="form-control mb-3"></asp:DropDownList> 
                <asp:Label ID="DateOfExamLabel" runat="server" Font-Size="Large" Text="Date Of Exam" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="DateOfExamTextBox" runat="server" Font-Size="Large" CssClass="form-control mb-3" TextMode="Date"></asp:TextBox>
                <asp:Label ID="MarkLabel" runat="server" Font-Size="Large" Text="Mark" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="MarkTextBox" runat="server" Font-Size="Large" CssClass="form-control mb-3"></asp:TextBox>
            </div>
        </div>
        <div class="col-3">
            <asp:Button ID="AddDataButton" runat="server" Font-Size="Large" OnClick="AddData_Click" Text="Ok" Class="btn btn-primary btn-block" />
        </div>
    </form>
</body>
</html>
