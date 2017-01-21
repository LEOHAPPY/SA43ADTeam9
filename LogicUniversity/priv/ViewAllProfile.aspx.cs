using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class priv_ViewAllProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<UserModel> userModelList = new List<UserModel>();
        int count = 0;
        var members = Membership.GetAllUsers();
        var profiles = ProfileManager.GetAllProfiles(ProfileAuthenticationOption.All);
        foreach (MembershipUser member in members)
        {
            var profile = profiles[member.UserName];
            ProfileCommon profileCommon = (ProfileCommon)Profile.GetProfile(profile.UserName);

            if (profile != null)
            {

                UserModel userMoldel = new UserModel();
                count++;
                userMoldel.Id = count.ToString();
                userMoldel.Name = profileCommon.employeeName;
                userMoldel.DepartmentId = profileCommon.departmentID;

                userMoldel.Image = profileCommon.image;

                userModelList.Add(userMoldel);
            }
        }
        GridView1.DataSource = userModelList;
        GridView1.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Register.aspx");
    }
}