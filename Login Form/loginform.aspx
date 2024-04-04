<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication2.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="EmpID"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="27px" Width="172px" style="margin-left: 44px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox><br/>
        <asp:Label ID="Label2" runat="server" Text="EmpName"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Height="27px" Width="172px" style="margin-left: 23px"></asp:TextBox><br/>
        <asp:Button ID="Button1" runat="server" Text="Login" Height="26px" OnClick="Button1_Click" style="margin-left: 66px; margin-top: 46px" Width="74px" />
    </div>
    </form>
</body>
</html>
