<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsDB.aspx.cs" Inherits="WebApp.StudentsDB" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="css/bootstrap.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="d-grid gap-2 d-md-flex justify-content-md-end mt-4">
                <asp:Button ID="AddStudentButton" runat="server" OnClick="AddStudent_Click" Text="Add Student" class="btn btn-primary me-md-2" />
                <asp:Button ID="LogoutButton" runat="server" OnClick="LogOut_Click" Text="Log out" class="btn btn-outline-secondary me-md-4" />
            </div>
            <div>
                <h2 style="text-align: center">Students List</h2>
            </div>
            <asp:Repeater ID="parentRepeater" runat="server">
                <HeaderTemplate>
                    <table class="table table-hover table-bordered table-light" style="text-align: center">
                        <tr class="table-primary">
                            <th>Student Record Book</th>
                            <th>Student Surname</th>
                            <th>Student Name</th>
                            <th>Student Otchestvo</th>
                            <th>Exam Name</th>
                            <th>Date</th>
                            <th>Mark</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblStudentID" runat="server" Text='<%# Eval("RecordBook") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblStudentFam" runat="server" Text='<%# Eval("Fam") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblStudentName" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblStudentOtchestvo" runat="server" Text='<%# Eval("Otchestvo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblExamName" runat="server" Text='<%# Eval("Exam") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblExamDate" runat="server" Text='<%# Convert.ToDateTime(Eval("DateOfExam")).ToString("dd/MM/yyyy") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblExamMark" runat="server" Text='<%# Eval("Mark") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
