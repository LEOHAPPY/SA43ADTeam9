using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class priv_Clerk_Disbursement : System.Web.UI.Page
{

    ADT9DB1Entities4 content = new ADT9DB1Entities4();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["id"];
            packageList disbursement = content.packageLists.Where(x => x.id.Equals(id)).FirstOrDefault();
            List<packageListItem> temp = content.packageListItems.Where(x => x.packageListId.Equals(disbursement.id)).ToList();
            List<packageListItem> itemList=new List<packageListItem>();
            for(int j = 0; j < temp.Count; j++)
            {
                int idtemp = temp[j].id;
                packageListItem ack = content.packageListItems.Where(x => x.id == idtemp).Where(z=>z.acknowledgedBy.Equals(null)).FirstOrDefault();
                itemList.Add(ack);
                
            }

            KeyValuePair<ArrayList, ArrayList> datasource = distinctDepartment(itemList);
            for (int i = 0; i < datasource.Key.Count; i++)
            {
                RadioButtonList1.Items.Add(new ListItem(datasource.Key[i].ToString(), datasource.Value[i].ToString()));
            }
            RadioButtonList1.SelectedIndex = 0;
            Panel1.Visible = false;
        }
    }
    protected KeyValuePair<ArrayList, ArrayList> distinctDepartment(List<packageListItem> tlist)
    {
        ArrayList did = new ArrayList();
        ArrayList dname = new ArrayList();
        for (int i = 0; i < tlist.Count; i++)
        { 
            Boolean overlap = false;
            for (int j = i + 1; j < tlist.Count; j++)
            {
                if (tlist[i].departmentId.Equals(tlist[j].departmentId))
                    overlap = true;
            }
            if (!overlap) {
                string id = tlist[i].departmentId;
                did.Add(id);
                string name = content.userDepartmentLists.Where(x => x.id.Equals(id)).Select(y => y.deptName).FirstOrDefault().ToString();
                dname.Add(name);
            }
        }
        return new KeyValuePair<ArrayList, ArrayList>(dname,did);
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel1.Visible = true;

        string id = Request.QueryString["id"];
        packageList disbursement = content.packageLists.Where(x => x.id.Equals(id)).FirstOrDefault();
        string department = RadioButtonList1.SelectedItem.Value.ToString();
        List<packageListItem> itemList = content.packageListItems.Where(x => x.packageListId.Equals(disbursement.id)).Where(z=>z.departmentId.Equals(department)).ToList();
        Label1.Text = disbursement.id;
        string collection = content.userDepartmentLists.Where(x => x.id.Equals(department)).Select(y => y.collectionPoint).FirstOrDefault().ToString();
        Label2.Text = collection;

        //show data
        StringBuilder html = new StringBuilder();
        html.Append("<center><div><table style='Width:1350px;'>");
        html.Append("<tr><th>Item Description</th><th>Request Qty</th><th>Issued Qty</th><th>Discrepancy</th>");
        html.Append("<th>Received Qty</th></tr>");
        for(int i = 0; i < itemList.Count; i++)
        {
            string tempID = itemList[i].itemId;
            string description = content.stationaryCatelogues.Where(x => x.id.Equals(tempID)).Select(y => y.description).FirstOrDefault();
            html.Append("<td>"+description+"</td>");
            html.Append("<td>"+itemList[i].requestQty+"</td>");
            html.Append("<td>" + itemList[i].issusedQty + "</td>");
            if (itemList[i].issusedQty < itemList[i].requestQty)
            {
                html.Append("<td>" + (itemList[i].requestQty - itemList[i].issusedQty) + "</td>");
            }
            else
                html.Append("<td></td>");
            html.Append("<td><input type='text' ID='TextBox" + itemList[i].id + "' value='"+ itemList[i].issusedQty + "' runat='server'/>" + "</td></tr>");
        }



        html.Append("</table></div></center>");
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }
}