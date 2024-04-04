<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="EmpID"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="27px" Width="172px" style="margin-left: 44px"></asp:TextBox><br/>
        <asp:Label ID="Label2" runat="server" Text="EmpName"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Height="27px" Width="172px" style="margin-left: 23px"></asp:TextBox><br/>
        <asp:Label ID="Label3" runat="server" Text="EmpSalary"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Height="27px" Width="172px" style="margin-left: 22px"></asp:TextBox><br/>
        <asp:Label ID="Label4" runat="server" Text="EmpAge"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" Height="27px" Width="173px" style="margin-left: 34px"></asp:TextBox><br/>
        <asp:Button ID="Button1" runat="server" Text="Insert" Height="34px" Width="81px" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Update" Height="34px" Width="100px" style="margin-left: 39px" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Delete" Height="34px" Width="100px" style="margin-left: 39px" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="Show" Height="34px" Width="100px" style="margin-left: 39px" OnClick="Button4_Click" />
    </div>
            <asp:GridView ID="GridView1" runat="server" Height="170px" style="margin-left: 83px; margin-top: 54px" Width="308px"></asp:GridView>
        </div>
    </form>
</body>
</html>
