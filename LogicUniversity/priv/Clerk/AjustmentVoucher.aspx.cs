using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mobile_AjustmentVoucher : System.Web.UI.Page
{
    ADT9DB1Entities4 context;
    transactionList tl;
    transactionListItem tli;
    stationaryCatelogue sc;
    static List<transactionListItem> adjustmentList;

    protected void Page_Load(object sender, EventArgs e)
    {
        context = new ADT9DB1Entities4();
        tl = new transactionList();
        tli = new transactionListItem();
        sc = new stationaryCatelogue();

        if (!IsPostBack)
        {
            if (Application["adjustmentId"].Equals(""))
            {
                getAdjustmentId();
            }
            Panel1.Visible = false;
            tb_adjustmentId.Text = (string)Application["adjustmentId"];
            adjustmentList = (List<transactionListItem>)Application["adjustmentList"];
            bind();
        }
    }

    public void bind()
    {
        GridView1.DataSource = adjustmentList;
        GridView1.DataBind();
    }

    public void getAdjustmentId()
    {
        if (Application ["adjustmentId"].Equals(""))
        {
            //create adjustmentId and the the table
            Application.Lock();
            Application["adjustmentId"] = "iav" + "/" + User.Identity.Name + "/" + DateTime.Now; ;
            Application["adjustmentList"] = new List<transactionListItem>();
            Application.UnLock();
        }
    }

    protected void bt_submit_Click(object sender, EventArgs e)
    {
        if (!adjustmentList.Equals(null) )
        {
            saveToDatabse();
            clearModel();
            Response.Redirect("~/priv/Clerk/DefaultPage.aspx");

        }
        //redirct
    }

    protected void bt_cancel_Click(object sender, EventArgs e)
    {
        clearModel();
        //redirect
    }

    public void clearModel()
    {
        adjustmentList = new List<transactionListItem>();

        Application.Lock();
        Application ["adjustmentId"] = "";
        Application ["adjustmentList"] = new List<transactionListItem>();
        Application.UnLock();
    }

    protected void bt_add_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }

    public void clearInputs()
    {
        ddl_description.Text = null;
        tb_adjustment.Text = "0";
        tb_mark.Text = null;
    }


    public void fillTransactionItemsModel()
    {
        stationaryCatelogue q = context.stationaryCatelogues.Where(x => x.description == ddl_description.SelectedValue).FirstOrDefault();

        tli.transactionId = (string)Application["adjustmentId"];
        tli.itemId = q.id.ToString();
        tli.finalQty = q.currentBalance + Convert.ToInt32(tb_adjustment.Text);
        tli.remark = tb_mark.Text.ToString();
        tli.description = ddl_description.SelectedValue;
        tli.adjustment = Convert.ToInt32(tb_adjustment.Text);

        adjustmentList.Add(tli);
        
    }


    protected void bt_save_Click(object sender, EventArgs e)
    {
        fillTransactionItemsModel();

        bind();
        //clear
        clearInputs();

        calculatePrice();
    }

    public double calculatePrice()
    {
        double totalPrice = 0;

        foreach (var item in adjustmentList)
        {
            sc = context.stationaryCatelogues.Where(x => x.id == item.itemId).FirstOrDefault();
            totalPrice += Convert.ToDouble(item.adjustment * sc.price1);
        }
        return totalPrice;
    }

    public void saveToDatabse()
    {
        //write to 
        //transactionList Database
        tl.id = (string)Application["adjustmentId"];
        tl.requestBy = User.Identity.Name;
        tl.requestDate = DateTime.Now;
        tl.type = "iav";
        tl.status = "submitted";
        context.transactionLists.Add(tl);
        context.SaveChanges();
        
        //transactionListItems Database
        foreach (transactionListItem item in adjustmentList)
        {
            item.id = context.transactionListItems.Select(x => x.id).ToList().LastOrDefault() + 1 ;
            context.transactionListItems.Add(item);
            context.SaveChanges();
        }
        //clear adjustmentId session
        clearModel();
        ////redirect 
    }

    protected void bt_calculatePrice_Click(object sender, EventArgs e)
    {
        tb_totalPrice.Text = calculatePrice().ToString();

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string itemId = GridView1.DataKeys[e.RowIndex].Value.ToString();
        adjustmentList.RemoveAll(x => x.itemId == itemId);
        bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //GridViewRow row = GridView1.Rows[e.RowIndex];
        ////TextBox adjustment = (TextBox)row.FindControl("adjustment");
        ////TextBox remark = (TextBox)row.FindControl("remark");
        //TextBox adjustment = (TextBox)row.Cells[0].Controls[0];
        //TextBox remark = (TextBox)row.Cells[1].Controls[0];

        string itemId = GridView1.DataKeys[e.RowIndex].Value.ToString();
        //read only
        //string description = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
        string adjustment = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
        string remark = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();

        //?
        //update in the adjustmentList
        transactionListItem q = adjustmentList.First(x => x.itemId == itemId);
        q.adjustment = Convert.ToInt32(adjustment);
        q.remark = remark;

        GridView1.EditIndex = -1;

        bind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }

        protected void bt_cancelAjustment_Click(object sender, EventArgs e)
    {
        clearModel();
        Response.Redirect("~/priv/Clerk/DefaultPage.aspx");
    }
}