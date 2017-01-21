<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllProfile.aspx.cs" Inherits="priv_ViewAllProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
