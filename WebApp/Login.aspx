<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="css/bootstrap.css" />
    <title></title>
</head>
<body>
        <form id="form1" runat="server">
            <div class="position-absolute top-50 start-50 translate-middle">
                <table>
                    <tr>
                        <td colspan="8" style="text-align: center">
                            <asp:Label ID="LoginHeader" runat="server" Font-Size="X-Large" Text="Login"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="8">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="LoginLabel" runat="server" Font-Size="Large" Text="UserName"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td colspan="4">
                            <asp:TextBox ID="LoginTextBox" runat="server" Font-Size="Large" CssClass="form-control mb-3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="PasswordLabel" runat="server" Font-Size="Large" Text="Password"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td colspan="4">
                            <asp:TextBox ID="PasswordTextBox" runat="server" Font-Size="Large" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="6">&nbsp;</td>
                        <td colspan="2" style="padding-left:175px;">
                            <asp:Button ID="LoginButton" runat="server" Font-Size="Large" OnClick="Login_Click" Text="Log In" Class="btn btn-primary btn-block" />
                        </td>
                    </tr>
                </table>
            </div>
        </form>
</body>
</html>
