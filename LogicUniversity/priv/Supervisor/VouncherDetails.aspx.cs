using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VouncherDetails : System.Web.UI.Page
{
    String iavId;
    ADT9DB1Entities4 adEF = new ADT9DB1Entities4();

    protected void Page_Load(object sender, EventArgs e)
    {
        iavId = Request.QueryString["iavId"];
        List<transactionListItem> iavList = adEF.transactionListItems.Where(x => x.transactionId == iavId).ToList();
        GridView1.DataSource = iavList;
        GridView1.DataBind();
        transactionList tranList = adEF.transactionLists.Where(y => y.id == iavId).ToList().FirstOrDefault();
        TextBox1.Text = tranList.remark;
        if (tranList.status == "approved")
        {
            Button_Approve.Visible = false;
            Button_Reject.Visible = false;
        }

        else
        {
            if (tranList.status == "rejected")
                Button_Reject.Visible = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        transactionList tList = adEF.transactionLists.Where(y => y.id == iavId).ToList().First();
        tList.status = "approved";
        tList.remark = TextBox1.Text;
        updateBalance();
        adEF.SaveChanges();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        transactionList tList = adEF.transactionLists.Where(y => y.id == iavId).ToList().First();
        tList.status = "rejected";
        tList.remark = TextBox1.Text;
        adEF.SaveChanges();
    }

    protected void Button_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdjustmentVouncherList.aspx");
    }

    protected void updateBalance()
    {
        List<stationaryCatelogue> stationeryList = adEF.stationaryCatelogues.ToList();
        iavId = Request.QueryString["iavId"];
        List<transactionListItem> tranItems = adEF.transactionListItems.Where(x => x.transactionId == iavId).ToList();
        foreach (transactionListItem tranItem in tranItems)
        {
            foreach (stationaryCatelogue item in stationeryList)
            {
                if (item.id==tranItem.itemId)
                {
                    item.currentBalance = item.currentBalance + Int32.Parse(tranItem.finalQty.ToString());
                }
            }
        }
        adEF.SaveChanges();
    }
}