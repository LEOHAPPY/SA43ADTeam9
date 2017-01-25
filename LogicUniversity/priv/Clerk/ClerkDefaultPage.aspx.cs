using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class priv_Clerk_ClerkDefaultPage : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        ADT9DB1Entities4 content = new ADT9DB1Entities4();


        var requestList = content.transactionLists.Where(x => x.status.Equals("approved")).ToList();
        var profiles = ProfileManager.GetAllProfiles(ProfileAuthenticationOption.All);
        if (requestList.Count<1)
        {
            btnGetSelected.Visible = false;
            Button1.Visible = false;
        }
        foreach (var r in requestList)
        {
            var profile = profiles[r.requestBy];
            ProfileCommon profileCommon = (ProfileCommon)Profile.GetProfile(profile.UserName);

            if (profile != null)
            {
                r.status = content.userDepartmentLists.Where(x => x.id == profileCommon.departmentID).Select(y => y.deptName).FirstOrDefault().ToString();
                r.requestBy = profileCommon.employeeName.ToString();
                r.requestDate = Convert.ToDateTime(r.requestDate).Date;
            }
        }
        ArrayList CheckBoxArray;
        if (ViewState["CheckBoxArray"] != null )
        {
            CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
        }
        else
        {
            CheckBoxArray = new ArrayList();
        }

        if (IsPostBack)
        {
            int CheckBoxIndex;
            bool CheckAllWasChecked = false;
   
            string checkAllIndex = "chkAll-" + GridView1.PageIndex;
                if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
                {
                    CheckBoxArray.Remove(checkAllIndex);
                    CheckAllWasChecked = true;
                }
           
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
                    CheckBoxIndex = GridView1.PageSize * GridView1.PageIndex + (i + 1);
                    if (chk.Checked)
                    {
                        if (CheckBoxArray.IndexOf(CheckBoxIndex) == -1 && !CheckAllWasChecked)
                        {
                            CheckBoxArray.Add(CheckBoxIndex);
                        }
                    }
                    else
                    {
                        if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1 || CheckAllWasChecked)
                        {
                            CheckBoxArray.Remove(CheckBoxIndex);
                        }
                    }
                }
            }
        }
        ViewState["CheckBoxArray"] = CheckBoxArray;
        GridView1.DataSource = requestList;
        GridView1.DataBind();

    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {

        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
        if (ViewState["CheckBoxArray"] != null)
        {
            ArrayList CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
            string checkAllIndex = "chkAll-" + GridView1.PageIndex;

            if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
            {
                CheckBox chkAll = (CheckBox)GridView1.HeaderRow.Cells[0].FindControl("chkAll");
                chkAll.Checked = true;
            }
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                if (GridView1.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
                    {
                        CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
                        chk.Checked = true;
                        GridView1.Rows[i].Attributes.Add("style", "background-color:aqua");
                    }
                    else
                    {
                        int CheckBoxIndex = GridView1.PageSize * (GridView1.PageIndex) + (i + 1);
                        if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1)
                        {
                            CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");
                            chk.Checked = true;
                            GridView1.Rows[i].Attributes.Add("style", "background-color:aqua");
                        }
                    }
                }
            }
        }
    }
    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "MouseEvents(this, event)");
            e.Row.Attributes.Add("onmouseout", "MouseEvents(this, event)");
        }
    }



    protected void detail(object sender, EventArgs e)
    {
        Button theButton = sender as Button;
        Response.Redirect("RequestDetail.aspx?id=" + theButton.CommandArgument);
    }

    protected void btnGetSelected_Click(object sender, EventArgs e)
    {
        Session["list"] =(ArrayList) ViewState["CheckBoxArray"];
        
        Response.Redirect("retrieval.aspx");
    }

    protected void button1_Click(object sender, EventArgs e)
    {
        Session["list"] = null;

        Response.Redirect("retrieval.aspx");
    }
}

