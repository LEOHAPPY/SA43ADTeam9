using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mobile_StockTake_3 : System.Web.UI.Page
{
    static List<transactionListItem> adjustmentList = new List<transactionListItem>();
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = (string)Application["adjustmentId"];

    }
    protected void bt_update_Click(object sender, EventArgs e)
    {
        int enterBalance = Convert.ToInt32(tb_enterBalance.Text);
        string binNum = (string)Session["binNum"];
        string itemId = Request.QueryString["itemId"];

        ADT9DB1Entities4 context = new ADT9DB1Entities4();
        stockTake st = new stockTake();
        st.itemId = itemId;
        st.conductedBy = User.Identity.Name;
        st.stockTakeDate = System.DateTime.Now;
        context.stockTakes.Add(st);
        context.SaveChanges();

        //check Adjustment
        stationaryCatelogue sc = context.stationaryCatelogues.Where(x => x.id == itemId).FirstOrDefault();
        int currentBalance = (int)sc.currentBalance;
        int adjustment = enterBalance - currentBalance;

        if (adjustment != 0)
        {
            // sc.currentBalance = enterBalance;    //should change after approved 
            transactionList tl = new transactionList();
            if (Application["adjustmentId"].Equals(""))
            {
                //create adjustmentId and the the table
                //initilise new memory
                Application.Lock();
                Application["adjustmentId"] = "iav" + "/" + User.Identity.Name  + "/"+ DateTime.Now;
                Application["adjustmentList"] = adjustmentList;
                Application.UnLock();
            }
            transactionListItem tli = new transactionListItem();

            tli.transactionId = (string)Application["adjustmentId"];
            tli.itemId = itemId;
            tli.finalQty = enterBalance;
            tli.remark = tb_remark.Text;
            tli.adjustment = adjustment;
            tli.description = sc.description;
            adjustmentList.Add(tli);
            //remember in container
            Application.Lock();
            Application["adjustmentList"] = adjustmentList;
            Application.UnLock();
        }

        Response.Redirect("~/priv/Clerk/Mobile_StockTake_2.aspx?binNum=" + binNum);
    }

    protected void bt_stockTakeFirstPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/priv/Clerk/Mobile_StockTake_1.aspx" );
    }

    
}

/*
  count = (int)Session["count"];
        count

     if ((int)Session["count"] > 1)
        {
            Response.Redirect("~/Mobile_StockTake_2.aspx?binNum=" + binNum);
        }
        else
        {
            Response.Redirect("~/Mobile_StockTake_1.aspx");

        }

 */
