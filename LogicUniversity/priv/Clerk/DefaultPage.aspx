<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultPage.aspx.cs" Inherits="DefaultPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Welcome to Defalt Page"></asp:Label>
        <br />
        <br />
        <asp:Button ID="bt_makeAjustment" runat="server" OnClick="bt_makeAjustment_Click" Text="Make an Adjustment Voucher" />
    </div>
    </form>
</body>
</html>
