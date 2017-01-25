using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class priv_Clerk_requisitionHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ADT9DB1Entities4 content = new ADT9DB1Entities4();


        var requestList = content.transactionLists.Where(x => x.status.Equals("delivered")).ToList();
        var profiles = ProfileManager.GetAllProfiles(ProfileAuthenticationOption.All);
        if (requestList.Count < 1)
        {
            btnGetSelected.Visible = false;
        }
        foreach (var r in requestList)
        {
            var profile = profiles[r.requestBy];
            var clerkProfile= profiles[r.responseBy];
            ProfileCommon profileCommon = (ProfileCommon)Profile.GetProfile(profile.UserName);
            ProfileCommon responseby = (ProfileCommon)Profile.GetProfile(clerkProfile.UserName);
            if (profile != null)
            {
                r.status = content.userDepartmentLists.Where(x => x.id == profileCommon.departmentID).Select(y => y.deptName).FirstOrDefault().ToString();
                r.requestBy = profileCommon.employeeName.ToString();
                r.responseBy = responseby.employeeName.ToString();
                r.requestDate = Convert.ToDateTime(r.requestDate).Date;
            }
        }
        
        GridView1.DataSource = requestList;
        GridView1.DataBind();

    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {

        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
        
    }
    protected void detail(object sender, EventArgs e)
    {
        Button theButton = sender as Button;
        Response.Redirect("RequestDetail.aspx?id=" + theButton.CommandArgument+"&history=true");
    }
    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "MouseEvents(this, event)");
            e.Row.Attributes.Add("onmouseout", "MouseEvents(this, event)");
        }
    }
    protected void btnGetSelected_Click(object sender, EventArgs e)
    {
       
        Response.Redirect("ClerkDefault.aspx");
    }

}