<%@ Page Title="" Language="C#" MasterPageFile="~/priv/Clerk/ClerkMasterPage.master" AutoEventWireup="true" CodeFile="RequestDetail.aspx.cs" Inherits="priv_Clerk_RequestDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div style="margin-left:10px;"><h2> View Requisition</h2></div> 
    <div id="first">
    <table style="border:1px solid black;
                  width:30%; margin-left:10px;
                  border-collapse:collapse">
        <tr style="border:1px solid black;">
            <td style="border:1px solid black;">Requisition Form No.</td>
            <td style="border:1px solid black;"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
            
        </tr>
        <tr style="border:1px solid black;">
            <td style="border:1px solid black;">Request By</td>
            <td style="border:1px solid black;"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr style="border:1px solid black;">
            <td style="border:1px solid black;">Department</td>
            <td style="border:1px solid black;"><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr style="border:1px solid black;">
            <td style="border:1px solid black;">Request Date</td>
            <td style="border:1px solid black;"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
        </tr>
    </table></div>
    <center>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
        Width="1350px" CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
        PageSize="5" PagerSettings-Mode="Numeric" OnPageIndexChanging="PaginateTheData">
        <Columns>
            <asp:BoundField DataField="itemId" HeaderText="Item" />
            <asp:BoundField DataField="remark" HeaderText="Description" />
            <asp:BoundField DataField="requestQty" HeaderText="Request Qty" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="Button1" runat="server" Text="Close" Class="button" OnClick="Button1_Click"></asp:Button>
    </center>
</asp:Content>

