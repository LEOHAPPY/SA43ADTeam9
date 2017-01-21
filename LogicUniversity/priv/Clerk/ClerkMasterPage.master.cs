using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class priv_Clerk_ClerkMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var members = Membership.GetAllUsers();
        var profiles = ProfileManager.GetAllProfiles(ProfileAuthenticationOption.All);


        var originalPath = new Uri(HttpContext.Current.Request.Url.AbsoluteUri).OriginalString;
        String parentDirectory = originalPath.Substring(0, originalPath.LastIndexOf("/"));
        int count = originalPath.Length - parentDirectory.Length - 1;

        

        foreach (MembershipUser member in members)
        {
            if (member.UserName.Equals(Page.User.Identity.Name.ToString()))
            {
                var profile = profiles[member.UserName];
                ProfileCommon profileCommon = (ProfileCommon)Profile.GetProfile(profile.UserName);
                if (profile != null)
                {
                    Label1.Text = profileCommon.employeeName;
                    userImage.ImageUrl = "~/" + profileCommon.image;
                }
            }
        }
    }
}
