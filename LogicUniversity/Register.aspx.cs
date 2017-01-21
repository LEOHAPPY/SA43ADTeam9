using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        string username = CreateUserWizard1.UserName;
        string password = CreateUserWizard1.Password;


        CreateUserWizardStep step1 = (CreateUserWizardStep)CreateUserWizard1.FindControl("Step1");

        var role = (DropDownList)step1.ContentTemplateContainer.FindControl("roleD");

        TextBox k1 = (TextBox)step1.ContentTemplateContainer.FindControl("name");
        TextBox k2 = (TextBox)step1.ContentTemplateContainer.FindControl("departmentIDText");
        TextBox k3 = (TextBox)step1.ContentTemplateContainer.FindControl("imagTeText");

        ProfileCommon profile = Profile.GetProfile(username);

        profile.employeeName = k1.Text;
        profile.departmentID = k2.Text;
        profile.image = k3.Text;
        profile.Save();

        string userRole = role.Text;
        Roles.AddUserToRole(username, userRole);
        if (Membership.ValidateUser(username, password))
        {
            FormsAuthentication.SetAuthCookie(username, false);
            Response.Redirect("~/priv/viewallProfile.aspx");
        }
    }
}