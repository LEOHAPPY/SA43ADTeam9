using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdjustmentVouncherList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        String iavId = (GridView1.SelectedRow.Cells[1].Text).ToString();
        Response.Redirect("VouncherDetails.aspx?"+"iavId="+iavId);
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

        String iavId = (GridView2.SelectedRow.Cells[1].Text).ToString();
        Response.Redirect("VouncherDetails.aspx?" + "iavId=" + iavId);
    }
}