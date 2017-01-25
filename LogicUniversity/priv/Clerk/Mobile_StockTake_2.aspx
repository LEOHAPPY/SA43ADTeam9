<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mobile_StockTake_2.aspx.cs" Inherits="StockTake_Mobile_" EnableEventValidation = "false" %>

<!DOCTYPE html>
<html>
<head runat="server">
 <title>FirstPage</title>
 <meta name="viewport" content="width=device-width, initial-scale=1" />
 <link rel="stylesheet" href=
   "http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.css" />
 <script src="http://code.jquery.com/jquery-1.11.1.min.js"> </script>
 <script src=
   "http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.js">
 </script>
</head>

<body>
    <form id="form1" runat="server">
        <div data-role="page" id="p1">
            <div data-role="header" data-position="fixed">
                <h1>MasionExpert</h1>
                <a href="#" class="ui-btn ui-btn-inline   ui-corner-all ui-icon-arrow-l ui-btn-icon-notext" data-rel="back">arrowLeft</a> 
            </div>

            <div data-role="navbar">
	            <ul>
		            <li><a href="Login.aspx" class="ui-btn-active ui-state-persist">Login</a></li>
		            <li><a href="Signup.aspx">Signup</a></li>
	            </ul>
            
            </div><!-- /navbar -->

            <div data-role="content">
                
                <asp:GridView ID="GridView1" runat="server" width="75%" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                    <SelectedRowStyle BackColor="#FFFFCC" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                        <asp:TemplateField HeaderText="Select">
                                <ItemTemplate><a href="Mobile_StockTake_3.aspx?itemId=<%# Eval("id") %>">Select</a></ItemTemplate>
                            </asp:TemplateField>
                    </Columns>
                    
                </asp:GridView>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ADT9DB1ConnectionString %>" SelectCommand="SELECT [description], [id] FROM [stationaryCatelogue] WHERE ([binNum] = @binNum)">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="A3" Name="binNum" QueryStringField="binNum" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Button ID="bt_makeAjustment" runat="server" OnClick="bt_makeAjustment_Click" Text="Go to Make an Adjustment Voucher" />
                <br />
                
            </div>

            <div data-role="footer" data-position="fixed">
                <h2>&copy;SA43Team9 ISS NUS </div>
        </div>
    </form>
</body>
</html>

