<%@ Page Title="" Language="C#" MasterPageFile="~/priv/Clerk/ClerkMasterPage.master" AutoEventWireup="true" CodeFile="ClerkDefaultPage.aspx.cs" Inherits="priv_Clerk_ClerkDefaultPage" 
    EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type = "text/javascript">
<!--
function Check_Click(objRef)
{
    //Get the Row based on checkbox
    var row = objRef.parentNode.parentNode;
    if(objRef.checked)
    {
        //If checked change color to Aqua
        row.style.backgroundColor = "aqua";
    }
    else
    {    
        //If not checked change back to original color
        if(row.rowIndex % 2 == 0)
        {
           //Alternating Row Color
           row.style.backgroundColor = "#C2D69B";
        }
        else
        {
           row.style.backgroundColor = "white";
        }
    }
    
    //Get the reference of GridView
    var GridView = row.parentNode;
    
    //Get all input elements in Gridview
    var inputList = GridView.getElementsByTagName("input");
    
    for (var i=0;i<inputList.length;i++)
    {
        //The First element is the Header Checkbox
        var headerCheckBox = inputList[0];
        
        //Based on all or none checkboxes
        //are checked check/uncheck Header Checkbox
        var checked = true;
        if(inputList[i].type == "checkbox")
        {
            if(!inputList[i].checked)
            {
                checked = false;
                break;
            }
        }
    }

    
}

function MouseEvents(objRef, evt)
{
    var checkbox = objRef.getElementsByTagName("input")[0];
   
        if (checkbox.checked)
        {
            objRef.style.backgroundColor = "aqua";
        }
        else if(evt.type == "mouseout")
        {
            if(objRef.rowIndex % 2 == 0)
            {
               //Alternating Row Color
               objRef.style.backgroundColor = "#C2D69B";
            }
            else
            {
               objRef.style.backgroundColor = "white";
            }
           
        }
   
}
</script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
      <h2> Process Requisition</h2>
    <asp:GridView ID="GridView1" runat="server" Width="1350px" AllowPaging="True" CssClass="Grid"                    
    AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" 
    PageSize="2" PagerSettings-Mode="Numeric" OnPageIndexChanging = "OnPaging" OnRowDataBound = "RowDataBound" AutoGenerateColumns="False" >
        <Columns>
              <asp:TemplateField>
             
              <ItemTemplate>
                  <asp:CheckBox ID="CheckBox1" runat="server" onclick = "Check_Click(this)"/>
              </ItemTemplate>
              </asp:TemplateField>
            <asp:BoundField DataField="id"  HeaderText="Request Form No" />
            <asp:BoundField DataField="requestBy" HeaderText="Request By" />
            <asp:BoundField DataField="status" HeaderText="Department" /> 
            <asp:BoundField DataField="requestDate" HeaderText="Request Date" /> 
            <asp:TemplateField>
                <ItemTemplate>
                   <asp:Button id="btnRedirect"
            Text= "Detail"
            CommandArgument="<%# Container.DataItemIndex%>" 
            OnClick="detail"
            runat="server" BorderStyle="Solid" Font-Size="Medium" /> 
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
    </asp:GridView>
       <p>
           <asp:Button ID="Button1" runat="server" 
   Text="Process All" OnClick="button1_Click" class="button"/>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Button ID="btnGetSelected" runat="server" 
   Text="Process Selected" OnClick="btnGetSelected_Click" class="button"/></p>
   </center>
    </asp:Content>

