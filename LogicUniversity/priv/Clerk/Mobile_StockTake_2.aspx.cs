using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StockTake_Mobile_ : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ADT9DB1Entities4 content = new ADT9DB1Entities4();
        string binNum = Request.QueryString["binNum"];
        var q = content.stationaryCatelogues.Where(x => x.binNum == binNum).ToList();
        Session["binNum"] = binNum;
        //GridView1.DataSource = q;
        //GridView1.DataBind();
        if (!IsPostBack)
        {
            Session["count"] = q.Count;
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string itemId = GridView1.SelectedValue.ToString();


        Label1.Text = itemId;
       
    }

    protected void bt_makeAjustment_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/priv/Clerk/AjustmentVoucher.aspx");

    }
}