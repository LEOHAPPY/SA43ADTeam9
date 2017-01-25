using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class priv_Clerk_RequestDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            this.GetData();
        }
    }
    private void GetData()
    {
        string id = Request.QueryString["id"];
        ADT9DB1Entities4 content = new ADT9DB1Entities4();

        var requestlist = content.transactionLists.Where(x => x.status == "approved").ToList();

        var profiles = ProfileManager.GetAllProfiles(ProfileAuthenticationOption.All);
        foreach (var r in requestlist)
        {
            var profile = profiles[r.requestBy];
            ProfileCommon profileCommon = (ProfileCommon)Profile.GetProfile(profile.UserName);

            if (profile != null)
            {

                r.status = content.userDepartmentLists.Where(x => x.id == profileCommon.departmentID).Select(y => y.deptName).FirstOrDefault().ToString();
                r.requestBy = profileCommon.employeeName.ToString();

            }
        }
        var rr = requestlist[Convert.ToInt32(id)];
        var requestItem = content.transactionListItems.Where(x => x.transactionId.Equals(rr.id)).ToList();
        foreach (var item in requestItem)
        {
            item.remark = content.stationaryCatelogues.Where(x => x.id.Equals(item.itemId)).Select(y => y.description).FirstOrDefault().ToString();
        }
        Label1.Text = rr.id;
        Label2.Text = rr.requestBy;
        string today = Convert.ToDateTime(rr.requestDate).Date.ToString();
        Label3.Text = today.Substring(0, 10);
        //Label3.Text = Convert.ToDateTime(rr.requestDate).Date.ToShortDateString();
        Label4.Text = rr.status;
        GridView1.DataSource = requestItem;
        GridView1.DataBind();
    }
    protected void PaginateTheData(object sender, GridViewPageEventArgs e)
    {
        
        GridView1.PageIndex = e.NewPageIndex;
        this.GetData();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string history = Request.QueryString["history"];
        if(history!=null)
            Response.Redirect("requisitionHistory.aspx");
        Response.Redirect("ClerkDefaultPage.aspx");
    }
}