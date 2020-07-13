using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Falcon.App.UI.App.Common
{
    public class LockDownPageUI
    {
        

        public void LockDownPage(Page page)
        {
           foreach (var mycontrol in page.Controls)
            {
                IterateControl((Control)mycontrol, false);
            }
        }
        public void LockControl(Control control)
        {
            IterateControl((Control)control, false);
            
        }
        public void DisableGridView(GridView grdView)
        {
            for (int i = 0; i < grdView.Rows.Count;i++ )
            {
                DisableAllControl(grdView.Rows[i].Controls);
            }
            
        }

        private void DisableAllControl(ControlCollection ctrl)
        {
            foreach(Control ctr in ctrl)
            {
                IterateControl(ctr, false);
            }
        }
        public void UnLockControl(Control controlObject)
        {
            LockDown(controlObject, true);
        }
       private void IterateControl(Control controlObject,bool Lock)
       {
          LockDown(controlObject,Lock);
            
           foreach(var currentControl in controlObject.Controls)
           {
               IterateControl((Control)currentControl, Lock);
           }
       }
       private void LockDown(Control UIControl, bool ControlEnabled)
       {
           switch (UIControl.GetType().Name)
           {
               case "TextBox":
                   ((TextBox)UIControl).Enabled = ControlEnabled;
                   break;
               case "DropDownList":
                   ((DropDownList)UIControl).Enabled= ControlEnabled;
                   break;
               case "RadioButtonList":
                   ((RadioButtonList)UIControl).Enabled = ControlEnabled;
                   break;
               case "CheckBox":
                   ((CheckBox)UIControl).Enabled = ControlEnabled;
                   break;
               case "HtmlTextArea":
                   if (!ControlEnabled)
                   {
                       ((HtmlTextArea)UIControl).Disabled = !ControlEnabled;
                   }
                   else if (ControlEnabled) ((HtmlTextArea)UIControl).Disabled = ControlEnabled;
                   break;
               case "Button":
                   ((Button)UIControl).Enabled = ControlEnabled;
                   ((Button)UIControl).OnClientClick = "return false;";
                   break;
               case "LinkButton":
                   ((LinkButton)UIControl).Enabled = ControlEnabled;
                   ((LinkButton)UIControl).OnClientClick = "return false;";
                   break;
               case "ImageButton":
                   ((ImageButton)UIControl).Enabled = ControlEnabled;
                   ((ImageButton)UIControl).OnClientClick = "return false;";
                   break;
               case "HtmlContainerControl":
                   if (!ControlEnabled)
                   {
                       ((HtmlContainerControl)UIControl).Disabled = !ControlEnabled;
                   }
                   else if (ControlEnabled) ((HtmlContainerControl)UIControl).Disabled = ControlEnabled;
                   break;
               case "HtmlAnchor":
                   if (!ControlEnabled)
                   {
                       ((HtmlAnchor)UIControl).Disabled = !ControlEnabled;
                       ((HtmlAnchor)UIControl).Attributes.Add("onclick", "javascript:void(0);");
                       ((HtmlAnchor)UIControl).HRef="#";
                   }
                   else if (ControlEnabled) ((HtmlAnchor)UIControl).Disabled = ControlEnabled;
                   break;
               case "HtmlLink":
                   if (!ControlEnabled)
                   {
                       ((HtmlLink)UIControl).Disabled = !ControlEnabled;
                       ((HtmlLink)UIControl).Attributes.Add("onclick", "javascript:void(0);");
                   }
                   else if (ControlEnabled) ((HtmlLink)UIControl).Disabled = ControlEnabled;
                   break;
               case "HtmlTable":
                   if (!ControlEnabled)
                   {
                       ((HtmlTable)UIControl).Disabled = !ControlEnabled;
                       ((HtmlTable)UIControl).Attributes.Add("onclick", "javascript:void(0);");
                   }
                   else if (ControlEnabled) ((HtmlTable)UIControl).Disabled = ControlEnabled;
                   break;
               case "HtmlTableRow":
                   if (!ControlEnabled)
                   {
                       ((HtmlTableRow)UIControl).Disabled = !ControlEnabled;
                       ((HtmlTableRow)UIControl).Attributes.Add("onclick", "javascript:void(0);");
                   }
                   else if (ControlEnabled) ((HtmlTableRow)UIControl).Disabled = ControlEnabled;
                   break;
               case "HtmlTableCell":
                   if (!ControlEnabled)
                   {
                       ((HtmlTableCell)UIControl).Disabled = !ControlEnabled;
                       ((HtmlTableCell)UIControl).Attributes.Add("onclick", "javascript:void(0);");
                   }
                   else if (ControlEnabled) ((HtmlTableCell)UIControl).Disabled = ControlEnabled;
                   break;
               case "HyperLink":
                   ((HyperLink)UIControl).Enabled = ControlEnabled;
                   ((HyperLink)UIControl).Attributes.Add("onclick", "javascript:void(0);");
                   break;               
               case "HtmlImage":
                   if (!ControlEnabled)
                   {
                       ((HtmlImage)UIControl).Disabled = !ControlEnabled;
                       ((HtmlImage)UIControl).Attributes.Add("onclick", "javascript:void(0);");
                   }
                   else if (ControlEnabled) ((HtmlImage)UIControl).Disabled = ControlEnabled;
                   break;
               case "DataControlFieldCell":
                   ((DataControlFieldCell)UIControl).Enabled = ControlEnabled;
                   break;
               case "HtmlInputCheckBox":
                   if (!ControlEnabled) 
                   {
                       ((HtmlInputCheckBox)UIControl).Disabled=!ControlEnabled;
                       ((HtmlInputCheckBox)UIControl).Attributes.Add("onclick", "javascript:void(0);");
                   }
                   else if (ControlEnabled) ((HtmlInputCheckBox)UIControl).Disabled = ControlEnabled;
                   break;
               case "HtmlGenericControl":
                   if (!ControlEnabled) 
                   { 
                       ((HtmlGenericControl)UIControl).Disabled = !ControlEnabled; 
                       ((HtmlGenericControl)UIControl).Attributes.Add("onclick", "javascript:void(0);");
                   }
                   else if (ControlEnabled) ((HtmlGenericControl)UIControl).Disabled = ControlEnabled;
                   break;
               default:                   
                   break;
           }
       }
       

    }
}
