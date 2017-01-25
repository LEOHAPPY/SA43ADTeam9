<%@ Page Title="" Language="C#" MasterPageFile="~/priv/Clerk/ClerkMasterPage.master" AutoEventWireup="true" CodeFile="retrieval.aspx.cs" Inherits="priv_Clerk_retrieval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <asp:Panel ID="Panel1" runat="server">
       <div style="margin-left:10px;"><h2>Retrieve for Disbursement</h2></div> 
    <div id="first">
    <table style="border:1px solid black;
                  width:30%; margin-left:10px;
                  border-collapse:collapse;
                 ">
        <tr style="border:1px solid black;">
            <td style="border:1px solid black;">Retrieval Form No.</td>
            <td style="border:1px solid black;"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
            
        </tr>
        <tr style="border:1px solid black;background-color:#f4f3ef;">
            <td style="border:1px solid black;">Date</td>
            <td style="border:1px solid black;"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
        </tr>
        
    </table></div></asp:Panel>
    
    <br />
    <div>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </div>
    <center><p>
           <asp:Button ID="Button1" runat="server" 
   Text="Process Disbursement" class="button" OnClick="Button1_Click"/></p></center>
</asp:Content>

