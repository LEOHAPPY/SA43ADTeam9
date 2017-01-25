<%@ Page Title="" Language="C#" MasterPageFile="~/priv/Clerk/ClerkMasterPage.master" AutoEventWireup="true" CodeFile="Disbursement.aspx.cs" Inherits="priv_Clerk_Disbursement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
   
        <div style="margin-left:10px;"><h2>Acknowledge Disbursement</h2></div>
     <center>
    <asp:Panel ID="Panel2" runat="server" >
        <br /><br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Font-Bold="true" Font-Size="Large"></asp:RadioButtonList>
        <asp:Button ID="Button1" runat="server" Text="Ok" class="button" OnClick="Button1_Click" Font-Size="Small" />
        
    </asp:Panel></center>
    
    <asp:Panel ID="Panel1" runat="server">
         
        <div id="first">
    <table style="border:1px solid black;
                  width:30%; margin-left:10px;
                  border-collapse:collapse;
                 ">
        <tr style="border:1px solid black;">
            <td style="border:1px solid black;">Disbursement Form No.</td>
            <td style="border:1px solid black;"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
            
        </tr>
        <tr style="border:1px solid black;background-color:#f4f3ef;">
            <td style="border:1px solid black;">Collection Point</td>
            <td style="border:1px solid black;"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
        </tr>
    </table></div>
    <br />
    <div>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </div>
    <center><p>
<asp:Label ID="Label3" runat="server" Text="ID" Font-Size="Medium"></asp:Label> : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
           <asp:Button ID="Button2" runat="server" 
   Text="Acknoledge" class="button" /></p></center>
        </asp:Panel>
</asp:Content>

