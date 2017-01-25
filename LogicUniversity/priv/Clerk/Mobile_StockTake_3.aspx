<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mobile_StockTake_3.aspx.cs" Inherits="Mobile_StockTake_3" %>

<!DOCTYPE HTML>
<html>
<head runat="server">
 <title>FirstPage</title>
 <meta name="viewport" content="width=device-width, initial-scale=1" />
 
</head>

<body>
     <form id="form1" runat="server">
                <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataKeyNames="id" DataSourceID="SqlDataSource1" HorizontalAlign="Center">
                    <Fields>
                        <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                        <asp:BoundField DataField="unitOfMeasure" HeaderText="unitOfMeasure" SortExpression="unitOfMeasure" />
                        <asp:BoundField DataField="currentBalance" HeaderText="currentBalance" SortExpression="currentBalance" />
                    </Fields>
                </asp:DetailsView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ADT9DB1ConnectionString %>" SelectCommand="SELECT [id], [description], [unitOfMeasure], [currentBalance] FROM [stationaryCatelogue] WHERE ([id] = @id)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="id" QueryStringField="itemId" Type="String" DefaultValue="C001" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Enter Balance"></asp:Label>
                <asp:TextBox ID="tb_enterBalance" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Remark"></asp:Label>
                <br />
                <asp:TextBox ID="tb_remark" runat="server" Width="235px"></asp:TextBox>
                <br />
                <asp:Button ID="bt_update" runat="server" OnClick="bt_update_Click" Text="Update" />

                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1" style="z-index: 1"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Button ID="bt_stockTakeFirstPage" runat="server" OnClick="bt_stockTakeFirstPage_Click" style="margin-top: 0px" Text="Go to Stock Take First Page" />
                <br />
                <br />
    </form>

