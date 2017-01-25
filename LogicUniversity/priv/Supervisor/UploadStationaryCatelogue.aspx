<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadStationaryCatelogue.aspx.cs" Inherits="UploadStationaryCatelogue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:FileUpload id="FileUploadControl" runat="server" />
    <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
    <br /><br />
    <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
         <br />
         <br />
         <asp:Button ID="bt_ViewData" runat="server" Text="View Data" OnClick="bt_ViewData_Click" />
         <asp:Button ID="bt_ClearData" runat="server" OnClick="Button3_Click" Text="Clear Old Info" />
         <br />
         <br />
         <asp:GridView ID="GridView1" runat="server">
         </asp:GridView>
         <br />
         <asp:Button ID="bt_UpdateSC" runat="server" Text="Update Stationary Catelogue" OnClick="bt_UpdateSC_Click" />
         <br />
         <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    </div>
    </form>
</body>
</html>
