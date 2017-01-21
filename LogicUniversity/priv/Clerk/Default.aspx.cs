using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class priv_Clerk_ClerkDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        var members = Membership.GetAllUsers();
        var profiles = ProfileManager.GetAllProfiles(ProfileAuthenticationOption.All);


        var originalPath = new Uri(HttpContext.Current.Request.Url.AbsoluteUri).OriginalString;
        String parentDirectory = originalPath.Substring(0, originalPath.LastIndexOf("/"));
        int count = originalPath.Length - parentDirectory.Length - 1;
        
        TextBox1.Text = originalPath.Substring(parentDirectory.Length + 1, count);

        foreach (MembershipUser member in members)
        {
            if (member.UserName.Equals(User.Identity.Name))
            {
                var profile = profiles[member.UserName];
                ProfileCommon profileCommon = (ProfileCommon)Profile.GetProfile(profile.UserName);
                if (profile != null)
                    userImage.ImageUrl = "~/" + profileCommon.image;
            }
        }
    }
}