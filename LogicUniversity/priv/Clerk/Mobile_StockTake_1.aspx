<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mobile_StockTake_1.aspx.cs" Inherits="Mobile_Test" %>

<!DOCTYPE HTML>
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
            <div data-role="header">
                <h1>MasionExpert</h1>
            </div>

            <div data-role="navbar">
	            <ul>
		            <li><a href="Login.aspx" class="ui-btn-active ui-state-persist">Login</a></li>
		            <li><a href="Signup.aspx">Signup</a></li>
	            </ul>
            </div><!-- /navbar -->

            <div data-role="content">
                
                <div class="gridView_all" style="display: block">
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" width="75%" HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundField DataField="binNum" HeaderText="binNum" SortExpression="binNum" FooterStyle-HorizontalAlign="Left" />
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate><a href="http://localhost/LogicUniversity/priv/Clerk/Mobile_StockTake_2.aspx?binNum=<%# Eval("binNum") %>">Select</a></ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ADT9DB1ConnectionString %>" SelectCommand="SELECT DISTINCT [binNum] FROM [stationaryCatelogue]"></asp:SqlDataSource>
                </div>

            </div>
            <div data-role="footer" data-position="fixed"><h2>&copy;SA43Team9 ISS NUS</h2></div>
        </div>
    </form>
</body>
</html>