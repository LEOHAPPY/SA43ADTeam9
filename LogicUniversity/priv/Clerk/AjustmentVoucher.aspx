<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AjustmentVoucher.aspx.cs" Inherits="Mobile_AjustmentVoucher" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: -8px;
            left: 121px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 454px;
            left: 16px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 422px;
            left: 16px;
            z-index: 1;
        }
        .auto-style7 {
            width: 364px;
            height: 182px;
            position: absolute;
            top: 258px;
            left: 301px;
            z-index: 1;
        }
        .auto-style8 {
            height: 953px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style8">
        <asp:Label ID="Label1" runat="server" Text="Adj. Voucher No"></asp:Label>
        <br />
        <asp:TextBox ID="tb_adjustmentId" runat="server" ReadOnly="true"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <div id="container">
            <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" 
                OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowDeleting="GridView1_RowDeleting" 
                OnRowEditing="GridView1_RowEditing" 
                OnRowUpdating="GridView1_RowUpdating"
                DataKeyNames = "itemId" >
            <Columns>
            <asp:BoundField DataField="itemId" HeaderText="itemId" ReadOnly="true"/>
            <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="true" />
            <asp:BoundField DataField="adjustment" HeaderText="Adjustment" />
            <asp:BoundField DataField="remark" HeaderText="Reason" />
                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
                <asp:CommandField HeaderText="Edit" ShowEditButton="True" ShowHeader="True" />
            </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />

        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style7">
            <asp:Label ID="lb_description" runat="server" Text="Description"></asp:Label>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ADT9DB1ConnectionString %>" SelectCommand="SELECT [description] FROM [stationaryCatelogue]"></asp:SqlDataSource>
            <br />
            <asp:Label ID="lb_adjustemnt" runat="server" Text="Adjustment"></asp:Label>
            <asp:TextBox ID="tb_adjustment" runat="server" Text="0"></asp:TextBox>
            <br />
            <asp:Label ID="lb_mark" runat="server" Text="Reason"></asp:Label>
            <asp:TextBox ID="tb_mark" runat="server"></asp:TextBox>
            <br />
            <asp:DropDownList ID="ddl_description" runat="server" CssClass="auto-style1" DataSourceID="SqlDataSource1" DataTextField="description" DataValueField="description">
            </asp:DropDownList>
                <br />
            <asp:Button ID="bt_save" runat="server" OnClick="bt_save_Click" Text="Save" />
        </asp:Panel>
        <asp:Button ID="bt_add" runat="server" OnClick="bt_add_Click" Text="Add" />
        <br />
        <asp:Button ID="bt_calculatePrice" runat="server" CssClass="auto-style6" Text="calculate" OnClick="bt_calculatePrice_Click" />
        <br />
        <asp:Button ID="bt_cancelAjustment" runat="server" OnClick="bt_cancelAjustment_Click" Text="Cancel This  Adjustment" />
        <br />
        <br />
        <asp:Button ID="bt_submit" runat="server" Text="Submit for Authorisation" OnClick="bt_submit_Click" />
        <asp:TextBox ID="tb_totalPrice" runat="server" CssClass="auto-style4" ></asp:TextBox>
        <br />
        <br />
    </form>
</body>
</html>
