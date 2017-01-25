using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class priv_Clerk_retrieval : System.Web.UI.Page
{
    private ADT9DB1Entities4 content = new ADT9DB1Entities4();
    protected void Page_Load(object sender, EventArgs e)
    {

        ArrayList list = (ArrayList)Session["list"];
        var requestList = content.transactionLists.Where(x => x.status.Equals("approved")).ToList();
        StringBuilder html = new StringBuilder();
        List<packageListItem> toshow = new List<packageListItem>();
        packageList retrievalForm =new packageList();
        if (requestList.Count > 0)
        {
            //create new retrieval form in database
            retrievalForm = new packageList();
            string rid="pk/" + User.Identity.Name + "/" + DateTime.Now;
            retrievalForm.id = rid;
            retrievalForm.issuedBy = User.Identity.Name;
            retrievalForm.status = "In Process";
            content.packageLists.Add(retrievalForm);
            //content.SaveChanges();

            List<transactionList> selectedrlist = new List<transactionList>();


            if (list == null)
            {

                for (int i = 0; i < requestList.Count; i++)
                {
                    transactionList t = requestList[i];
                    t.packageListId = retrievalForm.id;
                    t.responseBy = User.Identity.Name;
                    t.status = "In process";
                    t.departmentId = getDepIdByEmpId(t.requestBy);

                }
                selectedrlist = requestList;
            }
            else
            {
                int temp;
                for (int i = 0; i < list.Count; i++)
                {
                    temp = Convert.ToInt32(list[i])-1;
                    Response.Write(list[i] + " " + temp + " " + requestList.Count);
                    transactionList t = requestList[temp];
                    Response.Write(requestList[temp].id);
                    t.packageListId = retrievalForm.id;
                    t.responseBy = User.Identity.Name;
                    t.status = "In process";
                    t.departmentId = getDepIdByEmpId(t.requestBy);
                    selectedrlist.Add(t);
                }
            }
            content.SaveChanges();

            List<transactionListItem> itemlist = new List<transactionListItem>();
            ArrayList distinctDep = distinctDepartment(selectedrlist);


            //Retrieve all item from selected Request Form
            for (int j = 0; j < selectedrlist.Count; j++)
            {
                List<transactionListItem> foreachrequest = new List<transactionListItem>();
                string tid = selectedrlist[j].id;
                foreachrequest = content.transactionListItems.Where(x => x.transactionId.Equals(tid)).ToList();
                foreach (transactionListItem item in foreachrequest)
                {
                    item.departmentId = selectedrlist[j].departmentId;
                    itemlist.Add(item);
                }
            }

            //divide item count according to deapartment
            for (int d = 0; d < distinctDep.Count; d++)
            {
                KeyValuePair<ArrayList, ArrayList> titem = itemCountByDepartment(distinctDep[d].ToString(), itemlist);
                ArrayList keyItem = titem.Key;
                ArrayList valueCount = titem.Value;
                for (int itemCount = 0; itemCount < keyItem.Count; itemCount++)
                {
                    packageListItem newitem = new packageListItem();
                    newitem.packageListId = retrievalForm.id;
                    newitem.departmentId = distinctDep[d].ToString();
                    newitem.itemId = keyItem[itemCount].ToString();
                    newitem.requestQty = Convert.ToInt32(valueCount[itemCount]);
                    content.packageListItems.Add(newitem);
                    content.SaveChanges();
                }

            }

            
            toshow = content.packageListItems.Where(x => x.packageListId.Equals(rid)).ToList();
        }
        string fromMenu = Request.QueryString["menu"];
        if (fromMenu!=null)
        {
            retrievalForm = content.packageLists.Where(x => x.status.Equals("In Process")).FirstOrDefault();
            toshow = content.packageListItems.Where(x => x.packageListId.Equals(retrievalForm.id)).ToList();
        }
        //show the data into tableFormat
        if (toshow.Count>0)
        {
            Label1.Text = retrievalForm.id;
             string today= DateTime.Now.Date.ToString();
            Label2.Text = today.Substring(0,10);
            html.Append("<center><div><table style='Width:1350px;'>");
            html.Append("<tr><th>Bin Number</th><th>Item No</th><th>Description</th>");
            html.Append("<th>Qty Needed</th><th>Qty Retrieved</th><th>Department</th>");
            html.Append("<th>Needed</th><th>Retrieve</th></tr>");

            List<string> dpitem = content.packageListItems.Where(x => x.packageListId.Equals(retrievalForm.id)).Select(y => y.itemId).Distinct().ToList();
            ArrayList disBin = distinctBinNo(toshow);
            for (int bin = 0; bin < disBin.Count; bin++)
            {
                int firstBin = 0;
                for (int pitem = 0; pitem < dpitem.Count; pitem++)
                {
                    string dpitemTemp = dpitem[pitem];
                    string tempBin = content.stationaryCatelogues.Where(x => x.id.Equals(dpitemTemp)).Select(y => y.binNum).FirstOrDefault().ToString();
                    int firstItem = 0;
                    if (disBin[bin].Equals(tempBin))
                    {
                        firstBin++;
                        for (int dep = 0; dep < toshow.Count; dep++)
                        {

                            if (dpitem[pitem].Equals(toshow[dep].itemId))
                            {
                                string idtemp = dpitem[pitem];
                                int qtyNeed = Convert.ToInt32(content.packageListItems.Where(x => x.packageListId.Equals(retrievalForm.id)).Where(y => y.itemId.Equals(idtemp)).Sum(z => z.requestQty).ToString());
                                stationaryCatelogue cat = content.stationaryCatelogues.Where(x => x.id.Equals(idtemp)).FirstOrDefault();
                                firstItem++;
                                if (firstBin == 1)
                                {

                                    if (firstItem == 1)
                                    {
                                        html.Append("<tr><td>" + disBin[bin] + "</td>");
                                        html.Append("<td>" + dpitem[pitem] + "</td>");
                                        html.Append("<td>" + cat.description + "</td>");
                                        html.Append("<td>" + qtyNeed + "</td>");
                                        if (qtyNeed <= cat.currentBalance)
                                        {
                                            html.Append("<td>" + qtyNeed + "</td>");
                                        }
                                        else
                                        {
                                            html.Append("<td>" + cat.currentBalance + "</td>");
                                        }
                                    }
                                    else
                                    {
                                        html.Append("<tr><td></td><td></td><td></td><td></td><td></td>");
                                    }
                                }
                                else
                                {
                                    html.Append("<tr><td></td>");
                                    if (firstItem == 1)
                                    {
                                        html.Append("<td>" + dpitem[pitem] + "</td>");
                                        html.Append("<td>" + cat.description + "</td>");
                                        html.Append("<td>" + qtyNeed + "</td>");
                                        if (qtyNeed <= cat.currentBalance)
                                        {
                                            html.Append("<td>" + qtyNeed + "</td>");
                                        }
                                        else
                                            html.Append("<td>" + cat.currentBalance + "</td>");
                                    }
                                    else
                                    {
                                        html.Append("<td></td><td></td><td></td><td></td>");
                                    }
                                }


                                html.Append("<td>" + toshow[dep].departmentId + "</td>");
                                html.Append("<td>" + toshow[dep].requestQty + "</td>");

                                html.Append("<td><input type='text' ID='TextBox" + toshow[dep].id + "' value='' runat='server'/>" + "</td>");//actual Qty
                            }
                        }
                        html.Append("</tr>");
                    }
                }


            }

            html.Append("</table></div></center>");
        }
        else
        {
            html.Append("<center><h2>There is no Requisition Form to Process</h2></center>");
            Panel1.Visible = false;
            Button1.Visible = false;
        }
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }

    //Get department id according to employee id
    protected string getDepIdByEmpId(string empid)
    {

        var profiles = ProfileManager.GetAllProfiles(ProfileAuthenticationOption.All);
        var profile = profiles[empid];
        ProfileCommon profileCommon = (ProfileCommon)Profile.GetProfile(profile.UserName);

        if (profile != null)
        {
            return profileCommon.departmentID;
        }
        return null;
    }

    //dinstinct department for all Requisition
    protected ArrayList distinctDepartment(List<transactionList> tlist)
    {
        ArrayList list = new ArrayList();
        for (int i = 0; i < tlist.Count; i++)
        {
            Boolean overlap = false;
            for (int j = i + 1; j < tlist.Count; j++)
            {
                if (tlist[i].departmentId.Equals(tlist[j].departmentId))
                    overlap = true;
            }
            if (!overlap)
                list.Add(tlist[i].departmentId);
        }

        return list;
    }
    //distinct items from requisitions
    protected ArrayList distinctItem(List<transactionListItem> tlist)
    {
        ArrayList list = new ArrayList();
        for (int i = 0; i < tlist.Count; i++)
        {
            Boolean overlap = false;
            for (int j = i + 1; j < tlist.Count; j++)
            {
                if (tlist[i].itemId.Equals(tlist[j].itemId))
                    overlap = true;
            }
            if (!overlap)
                list.Add(tlist[i].itemId);
        }

        return list;
    }
    

    //retrieve distinct bin
    protected ArrayList distinctBinNo(List<packageListItem> tlist)
    {
        ArrayList list = new ArrayList();
        for (int i = 0; i < tlist.Count; i++)
        {
            string outerBinTemp = tlist[i].itemId.ToString();
            string outerBin = content.stationaryCatelogues.Where(x => x.id.Equals(outerBinTemp)).Select(y => y.binNum).FirstOrDefault().ToString();
            Boolean overlap = false;
            for (int j = i + 1; j < tlist.Count; j++)
            {
                string innerBinTemp = tlist[j].itemId.ToString();
                string innerBin = content.stationaryCatelogues.Where(x => x.id.Equals(innerBinTemp)).Select(y => y.binNum).FirstOrDefault().ToString();
                if (outerBin.Equals(innerBin))
                    overlap = true;
            }
            if (!overlap)
                list.Add(outerBin);
        }

        return list;
    }

    protected KeyValuePair<ArrayList, ArrayList> itemCountByDepartment(string deparmentid, List<transactionListItem> item)
    {
        
        List<transactionListItem> temp = new List<transactionListItem>();
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].departmentId.Equals(deparmentid))
            {
                temp.Add(item[i]);
            }
        }
        ArrayList ditem = distinctItem(temp);
        ArrayList itemcount = new ArrayList();
        for(int i = 0; i < ditem.Count; i++)
        {
            itemcount.Add(0); 
        }
        
        for (int templist = 0; templist < temp.Count; templist++)
        {
            transactionListItem itemtemp = temp[templist];
            for (int map = 0; map < ditem.Count; map++)
            {
                

                if (ditem[map].ToString().Equals(itemtemp.itemId))
                {
                    int count =Convert.ToInt32(itemcount[map])+(int)itemtemp.requestQty;
                    itemcount[map] = count;

                }

            }
        }

        return new KeyValuePair<ArrayList, ArrayList>(ditem, itemcount);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Disbursement.aspx?id="+ Label1.Text);
    }
}