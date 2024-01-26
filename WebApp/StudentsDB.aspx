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
            <div class="mt-3 d-flex justify-content-between">
                <div class="">
                    <nav>
                        <ul class="pagination">
                            <asp:Button ID="btnFirstPage" runat="server" OnClick="btnFirstPage_Click" Text="First Page" class="page-link" Enabled="false" />
                            <asp:Button ID="btnPreviousPage" runat="server" OnClick="btnPreviousPage_Click" Text="Previous Page" class="page-link" Enabled="false" />
                            <asp:TextBox ID="tbPageNumber" runat="server" class="page-item disabled w-25 text-center" ReadOnly="true"></asp:TextBox>
                            <asp:Button ID="btnNextPage" runat="server" OnClick="btnNextPage_Click" Text="NextPage" class="page-link" />
                            <asp:Button ID="btnLastPage" runat="server" OnClick="btnLastPage_Click" Text="Last Page" class="page-link" />
                        </ul>
                    </nav>
                </div>
                <div class="">
                    <asp:DropDownList ID="ddlShowAmountOfStudent" autopostback="true" runat="server" onselectedindexchanged="ddlShowAmountOfStudent_SelectedIndexChanged"
                        class="btn btn-light btn-outline-dark btn-sm">
                        <asp:ListItem Text="10" Value="10"/>
                        <asp:ListItem Text="20" Value="20"/>
                        <asp:ListItem Text="30" Value="30"/>
                        <asp:ListItem Text="50" Value="50"/>
                    </asp:DropDownList>
                    <asp:Button ID="AddStudentButton" runat="server" OnClick="AddStudent_Click" Text="Add Student" class="btn btn-primary me-md-2" />
                    <asp:Button ID="LogoutButton" runat="server" OnClick="LogOut_Click" Text="Log out" class="btn btn-outline-secondary me-md-4" />
                </div>
            </div>
            <div>
                <h2 style="text-align: center">Students List</h2>
            </div>
            <asp:Repeater ID="parentRepeater" runat="server">
                <HeaderTemplate>
                    <table class="table table-hover table-bordered table-light" style="text-align: center">
                        <tr class="table-primary">
                            <th></th>
                            <th>Student Record Book</th>
                            <th>Student Surname</th>
                            <th>Student Name</th>
                            <th>Student Otchestvo</th>
                            <th>Exam</th>
                            <th>Exam Date</th>
                            <th>Mark</th>
                            <th></th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="images/editButton.png" Width="30px" OnClick="btnEdit_Click" CommandArgument='<%# Eval("StudentID") %>'/>
                        </td>
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
                        <td>
                            <asp:ImageButton ID="btnDel" runat="server" ImageUrl="images/deleteButton.png" Width="30px" OnClick="btnDel_Click" CommandArgument='<%# Eval("StudentID") %>'/>
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
