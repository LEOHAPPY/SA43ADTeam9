<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VouncherDetails.aspx.cs" Inherits="VouncherDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" />
                    <asp:BoundField DataField="transactionId" HeaderText="transactionId" />
                    <asp:BoundField DataField="itemId" HeaderText="itemId" />
                    <asp:BoundField DataField="finalQty" HeaderText="adjustmentQty" />
                    <asp:BoundField DataField="remark" HeaderText="remark" />
                </Columns>
            </asp:GridView>
            <br />
            Remark:
            <div>
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>

        </div>
        <br />
        <asp:Button ID="Button_Approve" runat="server" OnClick="Button1_Click" Text="Authorise" />
        <asp:Button ID="Button_Reject" runat="server" Text="Reject" OnClick="Button2_Click" />
        <asp:Button ID="Button_Back" runat="server" OnClick="Button_Back_Click" Text="Back" />
    </form>
</body>
</html>
