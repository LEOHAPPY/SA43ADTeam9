<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="priv_Clerk_ClerkDefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title></title>
    <script type="text/javascript">

   $(function () {
        // this will get the full URL at the address bar
        var url = window.location.href;
       
        // passes on every "a" tag 
        $("#nav a").each(function () {
            // checks if its the same on the address bar
            var temp = "http://localhost/LogicUniversity/priv/Clerk/"+this.href;
            if (url == (temp)) {
                $('#nav li').removeClass('current');
                $(this).closest("li").addClass("current");
            }
        });
        $("#header a").each(function () {
            // checks if its the same on the address bar
            if (url == (this.href)) {
                $(this).closest("li").addClass("current");
            }
        });

    });
</script>
    <style type="text/css">
body {
    font: normal .9em/1.5em Arial, Helvetica, sans-serif;
	background: #f4f3ef;
    margin: auto auto;
	color: #505558;
}
#logo {
    float:right;  
     margin:unset;  
    margin-right:10px;   
}


a {
	color: #333;
}
#nav {
    clear:right;
    margin-top:1px;	
	padding: 7px 6px 0;
	line-height: 100%;    
	border-radius: 2em;
	-webkit-border-radius: 2em;
	-moz-border-radius: 2em;
	font: normal 1em/1.5em Arial, Helvetica, sans-serif;
	-webkit-box-shadow: 0 1px 3px rgba(0, 0, 0, .4);
	-moz-box-shadow: 0 1px 3px rgba(0, 0, 0, .4);
	background: #8b8b8b; /* for non-css3 browsers */
     
    /*---Change Color According to departement and Store----*/
    filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#efa14b', endColorstr='#ef8d22'); /* for IE */
	background: -webkit-gradient(linear, left top, left bottom, from(#efa14b), to(#ef8d22)); /* for webkit browsers */
    background: -moz-linear-gradient(top,  #efa14b,  #ef8d22); /* for firefox 3.6+ */

	border: solid 1px #6d6d6d;
}
#nav li {
	margin: 0 5px;
	padding: 0 0 8px;
    
	float: left;
	position: relative;
	list-style: none;
}
/* main level link */
#nav a {
	font-weight: bold;
	color: #e7e5e5;
	text-decoration: none;
	display: block;
	padding:  8px 20px;
	margin: 0;
	-webkit-border-radius: 1.6em;
	-moz-border-radius: 1.6em;
	text-shadow: 0 1px 1px rgba(0, 0, 0, .3);
}
/* main level link hover */
#nav .current a, #nav li:hover > a {
	background: #d1d1d1; /* for non-css3 browsers */
	filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#ebebeb', endColorstr='#a1a1a1'); /* for IE */
	background: -webkit-gradient(linear, left top, left bottom, from(#ebebeb), to(#a1a1a1)); /* for webkit browsers */
	background: -moz-linear-gradient(top,  #ebebeb,  #a1a1a1); /* for firefox 3.6+ */
    

	color: #444;
	border-top: solid 1px #f8f8f8;
	-webkit-box-shadow: 0 1px 1px rgba(0, 0, 0, .2);
	-moz-box-shadow: 0 1px 1px rgba(0, 0, 0, .2);
	box-shadow: 0 1px 1px rgba(0, 0, 0, .2);
	text-shadow: 0 1px 0 rgba(255, 255, 255, .8);
}
/* sub levels link hover */
#nav ul li:hover a, #nav li:hover li a {
	background: none;
	border: none;
	color: #666;
	-webkit-box-shadow: none;
	-moz-box-shadow: none;
}
#nav ul a:hover {
	background: #0399d4 !important; /* for non-css3 browsers */

    /* --- Change Color According to Department and Store ----- */
	filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#efa14b', endColorstr='#ef8d22'); /* for IE */
	background: -webkit-gradient(linear, left top, left bottom, from(#efa14b), to(#ef8d22)) !important; /* for webkit browsers */
    background: -moz-linear-gradient(top,  #efa14b,  #ef8d22) !important; /* for firefox 3.6+ */

	color: #fff !important;
	-webkit-border-radius: 0;
	-moz-border-radius: 0;
	text-shadow: 0 1px 1px rgba(0, 0, 0, .1);
}
/* level 2 list */
#nav ul {
	background: #ddd; /* for non-css3 browsers */
	filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#ffffff', endColorstr='#cfcfcf'); /* for IE */
	background: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#cfcfcf)); /* for webkit browsers */
	background: -moz-linear-gradient(top,  #fff,  #cfcfcf); /* for firefox 3.6+ */
	display: none;
	margin: 0;
	padding: 0;
	width: 185px;
	position: absolute;
	top: 35px;
	left: 0;
	border: solid 1px #b4b4b4;
	-webkit-border-radius: 10px;
	-moz-border-radius: 10px;
	border-radius: 10px;
	-webkit-box-shadow: 0 1px 3px rgba(0, 0, 0, .3);
	-moz-box-shadow: 0 1px 3px rgba(0, 0, 0, .3);
	box-shadow: 0 1px 3px rgba(0, 0, 0, .3);
}
/* dropdown */
#nav li:hover > ul {
	display: block;
}
#nav ul li {
	float: none;
	margin: 0;
	padding: 0;
}
#nav ul a {
	font-weight: normal;
	text-shadow: 0 1px 1px rgba(255, 255, 255, .9);
}
/* level 3+ list */
#nav ul ul {
	left: 181px;
	top: -3px;
}
/* rounded corners for first and last child */
#nav ul li:first-child > a {
	-webkit-border-top-left-radius: 9px;
	-moz-border-radius-topleft: 9px;
	-webkit-border-top-right-radius: 9px;
	-moz-border-radius-topright: 9px;
}
#nav ul li:last-child > a {
	-webkit-border-bottom-left-radius: 9px;
	-moz-border-radius-bottomleft: 9px;
	-webkit-border-bottom-right-radius: 9px;
	-moz-border-radius-bottomright: 9px;
}
/* clearfix */
#nav:after {
	content: ".";
	display: block;
	clear: both;
	visibility: hidden;
	line-height: 0;
	height: 0;
}
#nav {
	display: inline-block;
}
html[xmlns] #nav {
	display: block;
}
* html #nav {
	height: 1%;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
     <%--Part of "Logo and Image of Login User--%>
     <div id="logo">
        <asp:Image runat="server" id="userImage"/>
        <asp:Image ImageUrl="~/images/LogoSmaller.png" runat="server" />
     </div>
     <%--Menu(Nav)--%>     
    <div>   
    <ul id="nav" >
	<li  class="current"><a href="requestList.aspx">Requisition</a></li>
    <li><a href="disbursement.aspx">Disbursement</a></li>
    <li><a href="discrepancy.aspx">Discrepancy</a></li>
	<li>Inventory
		<ul>
			<li><a href="stockList.aspx">StockManagement</a></li>
			<li><a href="adjustList.aspx">StockAdjustment</a></li>
			<li><a href=""></a></li>
			<li><a href="http://www.ndesign-studio.com/wallpapers">Wallpapers</a></li>
			<li><a href="http://www.ndesign-studio.com/tutorials">Illustrator Tutorials</a></li>
				
			<li><a href="http://www.webdesignerwall.com/">Web Designer Wall</a>
				<ul>
					<li><a href="http://jobs.webdesignerwall.com/">Design Job Wall</a></li>
				</ul>
			</li>
			<li><a href="http://icondock.com/">IconDock</a></li>
			<li><a href="http://bestwebgallery.com/">Best Web Gallery</a></li>
		</ul>
	</li>
	<li><a href="#">Multi-Levels</a>
		<ul>
			<li><a href="#">Team</a>
				<ul>
					<li><a href="#">Sub-Level Item</a></li>
					<li><a href="#">Sub-Level Item</a>
						<ul>
							<li><a href="#">Sub-Level Item</a></li>
							<li><a href="#">Sub-Level Item</a></li>
							<li><a href="#">Sub-Level Item</a></li>
						</ul>
					</li>
					<li><a href="#">Sub-Level Item</a></li>
				</ul>
			</li>
			<li><a href="#">Sales</a></li>
			<li><a href="#">Another Link</a></li>
			<li><a href="#">Department</a>
				<ul>
					<li><a href="#">Sub-Level Item</a></li>
					<li><a href="#">Sub-Level Item</a></li>
					<li><a href="#">Sub-Level Item</a></li>
				</ul>
			</li>
		</ul>
	</li>
	<li><a href="#">About</a></li>
	<li><a href="#">Contact Us</a></li>
</ul>
    </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </form>
</body>
    
</html>
