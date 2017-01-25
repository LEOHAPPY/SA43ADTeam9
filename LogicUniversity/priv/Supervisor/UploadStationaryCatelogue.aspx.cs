using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UploadStationaryCatelogue : System.Web.UI.Page
{
    static string fileName;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // try catch whether the file is excel file or not 
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if (FileUploadControl.HasFile)
        {
            try
            {
                fileName = System.IO.Path.GetFileName(FileUploadControl.FileName);
                FileUploadControl.SaveAs(Server.MapPath("~/UploadFile/") + fileName);
                StatusLabel.Text = "Upload status: File uploaded!" + fileName;
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        ADT9DB1Entities4 content = new ADT9DB1Entities4();
        var all = from c in content.stationaryCatelogues select c;
        content.stationaryCatelogues.RemoveRange(all);
        content.SaveChanges();
        /*
         alter table dbo.transactionListItems
nocheck constraint FK_transactionListItems_stationaryCatelogue
         */
    }

    protected void bt_ViewData_Click(object sender, EventArgs e)
    {
        //get excelfile from ~/UploadFile/
        string filePath = @"C:\inetpub\wwwroot\LogicUniversity\UploadFile\" + fileName;
        
        //get data
        string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;";

        //
        using (OleDbConnection conn = new System.Data.OleDb.OleDbConnection(ConnectionString))
        {
            conn.Open();
            using (DataTable dtExcelSchema = conn.GetSchema("Tables"))
            {
                string sheetName = dtExcelSchema.Rows[0].ToString();

                Label1.Text = sheetName.ToString();

                //string query = "SELECT * FROM [" + sheetName + "]";
                string query = "Select * from [Sheet1$]";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }
    }

    protected void bt_UpdateSC_Click(object sender, EventArgs e)
    {
        ADT9DB1Entities4 content = new ADT9DB1Entities4();
        var all = from c in content.stationaryCatelogues select c;
        content.stationaryCatelogues.RemoveRange(all);
        content.SaveChanges();
        /*
         alter table dbo.transactionListItems
nocheck constraint FK_transactionListItems_stationaryCatelogue
         */

        //fill dataset
        //string filePath = "~/UploadFile/" + fileName;  //need to change path
        string filePath = @"C:\inetpub\wwwroot\LogicUniversity\UploadFile\" + fileName;  //need to change path

        string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;";

        DataSet ds = new DataSet();
        using (OleDbConnection conn = new System.Data.OleDb.OleDbConnection(ConnectionString))
        {
            conn.Open();
            using (DataTable dtExcelSchema = conn.GetSchema("Tables"))
            {
                string sheetName = dtExcelSchema.Rows[0].ToString();

                Label1.Text = sheetName.ToString();

                //string query = "SELECT * FROM [" + sheetName + "]";
                string query = "Select * from [Sheet1$]"; //must use default Sheet1
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                adapter.Fill(ds);
            }
        }


        DataTable Exceldt = ds.Tables[0];
        foreach (DataRow dr in Exceldt.Rows)
        {
            stationaryCatelogue sc = new stationaryCatelogue();

            sc.id = dr[0].ToString();
            sc.category = dr[1].ToString();
            sc.description = dr[2].ToString();
            sc.reorderLevel = Convert.ToInt32(dr[3].ToString());
            sc.currentBalance = Convert.ToInt32(dr[4].ToString());
            sc.reorderQty = Convert.ToInt32(dr[5].ToString());
            sc.unitOfMeasure = dr[6].ToString();
            sc.binNum = dr[7].ToString();
            sc.supplier1Id = dr[8].ToString();
            sc.supplier2Id = dr[9].ToString();
            sc.supplier3Id = dr[10].ToString();
            sc.price1 = Convert.ToDouble(dr[11].ToString());
            sc.price2 = Convert.ToDouble(dr[12].ToString());
            sc.price3 = Convert.ToDouble(dr[13].ToString());
            sc.image = dr[14].ToString();

            content.stationaryCatelogues.Add(sc);
            content.SaveChanges();
        }

        //notice
        Label1.Text = "Refreshed Stationary Catelogue Successfullly!";
    }
}