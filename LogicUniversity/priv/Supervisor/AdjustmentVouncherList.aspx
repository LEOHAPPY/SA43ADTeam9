<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdjustmentVouncherList.aspx.cs" Inherits="AdjustmentVouncherList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Current Adjustments</h2>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="requestBy" HeaderText="requestBy" SortExpression="requestBy" />
                <asp:BoundField DataField="requestDate" HeaderText="requestDate" SortExpression="requestDate" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ADT9DB1ConnectionString %>" SelectCommand="SELECT [id], [requestBy], [remark], [requestDate] FROM [transactionList] WHERE (([status] = @status) AND ([type] = @type)) ORDER BY [requestDate]">
            <SelectParameters>
                <asp:Parameter DefaultValue="submitted" Name="status" Type="String" />
                <asp:Parameter DefaultValue="iav" Name="type" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <hr />
        <h2>Adjustments History</h2>
        <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" DataKeyNames="id" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="requestBy" HeaderText="requestBy" SortExpression="requestBy" />
                <asp:BoundField DataField="requestDate" HeaderText="requestDate" SortExpression="requestDate" />
                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                <asp:BoundField DataField="remark" HeaderText="remark" SortExpression="remark" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ADT9DB1ConnectionString %>" SelectCommand="SELECT [id], [requestDate], [requestBy], [remark],[status] FROM [transactionList] WHERE (([type] = @type) AND (([status] = @status1) OR [status]=@status2)) ORDER BY [requestDate]">
            <SelectParameters>
                <asp:Parameter DefaultValue="iav" Name="type" Type="String" />
                <asp:Parameter DefaultValue="approved" Name="status1" Type="String" />
                <asp:Parameter DefaultValue="rejected" Name="status2" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

    </form>
</body>
</html>
