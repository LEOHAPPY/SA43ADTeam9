using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.IsInRole("Store_Supervisor"))
            login.DestinationPageUrl = "~/priv/Supervisor/Default.aspx";
        else if (User.IsInRole("Store_Manager"))
            login.DestinationPageUrl = "~/priv/Manager/Default.aspx";
        else if (User.IsInRole("Store_Clerk"))
            login.DestinationPageUrl = "~/priv/Clerk/ClerkDefault.aspx";
        else if (User.IsInRole("Employee"))
            login.DestinationPageUrl = "~/priv/Employee/Default.aspx";
        else if (User.IsInRole("Department_Rep"))
            login.DestinationPageUrl = "~/priv/DepRep/Default.aspx";
        else
            login.DestinationPageUrl = "~/priv/DepHead/Default.aspx";
    }
}