using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mobile_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ADT9DB1Entities4 content = new ADT9DB1Entities4();
        List<string> binNumList = content.stationaryCatelogues.Select(x => x.binNum).Distinct().ToList();
      
        
    }
}