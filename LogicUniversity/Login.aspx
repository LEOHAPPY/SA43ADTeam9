<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://code.jquery.com/jquery-1.11.1.min.js"></script>
<script
	src="https://cdn.jsdelivr.net/jquery.validation/1.15.0/jquery.validate.min.js"></script>
<script
	src="https://cdn.jsdelivr.net/jquery.validation/1.15.0/additional-methods.min.js"></script>
<style>
    .bo {
        background-color: #f8f4ee;
        width: 100%;
        height: 1400px;
        padding-top: 6%;
        color :black;
    
    }
</style>
<link href="styles/vendor/bootstrap/css/bootstrap.min.css"
	rel="stylesheet">
<!-- Theme CSS -->
<link href="styles/css/grayscale.css" rel="stylesheet">
<title>Login Form</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="bo">
   
    <center>
		
			<img src="images/LogoSmall.png"/>
		
	</center>
    <br />
	<center><asp:login runat="server" id="login">
        <LayoutTemplate>
            <table cellpadding="1" cellspacing="1" style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center"><h3>Log In</h3></td>
                            </tr>
                            <tr><td>
                                <div class="form-group">
				
			
                                    <asp:TextBox ID="UserName" runat="server" width="500px" class="form-control"
					name="username" placeholder="UserID"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl02">*</asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="form-group">
			
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" width="500px" class="form-control"
					name="password" placeholder="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl02">*</asp:RequiredFieldValidator>
                               </div>
                                         </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="color:Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" >
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="ctl02" class="btn btn-primary btn-lg active"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        </asp:login>
        

	</center>
    </div>
    </form>
</body>
</html>
