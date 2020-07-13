using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class Message : UserControl
    {
        private const string SUCCESS_MESSAGE_SETTING_NAME = "OK-MESSAGES";
        private const string ERROR_MESSAGE_SETTING_NAME = "ERROR-MESSAGES";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session[SUCCESS_MESSAGE_SETTING_NAME] != null)
            {
                var successMessages = (List<string>)HttpContext.Current.Session[SUCCESS_MESSAGE_SETTING_NAME];
                foreach (string message in successMessages)
                {
                    ShowSuccessMessage(message);
                }
                HttpContext.Current.Session[SUCCESS_MESSAGE_SETTING_NAME] = null;
            }
            if (HttpContext.Current.Session[ERROR_MESSAGE_SETTING_NAME] != null)
            {
                var errorMessages = (List<string>)HttpContext.Current.Session[ERROR_MESSAGE_SETTING_NAME];
                foreach (string message in errorMessages)
                {
                    ShowErrorMessage(message);
                }
                HttpContext.Current.Session[ERROR_MESSAGE_SETTING_NAME] = null;
            }
        }

        public void ClearMessages()
        {
            MessagesDiv.Visible = false;
            MessagesDiv.Controls.Clear();
        }

        public void ShowSuccessMessage(string message)
        {
            ShowMessage(message, "ui-state-highlight ui-corner-all", "ui-icon-info");
        }

        public void ShowErrorMessage(string message)
        {
            ShowMessage(message, "ui-state-error ui-corner-all", "ui-icon-alert");
        }

        public void EnqueueSuccessMessage(string message)
        {
            EnqueueMessage(message, SUCCESS_MESSAGE_SETTING_NAME);
        }

        public static void EnqueueErrorMessage(string message)
        {
            EnqueueMessage(message, ERROR_MESSAGE_SETTING_NAME);
        }

        private void ShowMessage(string message, string cssClass, string iconCssClass)
        {
            var messagePanel = new Panel();
            MessagesDiv.Controls.Add(messagePanel);
            messagePanel.Visible = true;
            messagePanel.CssClass = cssClass;
            messagePanel.Style["padding"] = "10px";
            messagePanel.Style["margin-bottom"] = "10px";

            var messageLiteral = new Label();
            messagePanel.Controls.Add(messageLiteral);

            messageLiteral.Text = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode("<p><span class=\"ui-icon " + iconCssClass + "\" style=\"float: left; margin-right: .3em;\"></span></p>" 
                + message,true);
            messageLiteral.Visible = true;
        }

        private static void EnqueueMessage(string message, string messageSettingName)
        {
            var messages = new List<string>();
            if (HttpContext.Current.Session[messageSettingName] != null)
            {
                messages = (List<string>)HttpContext.Current.Session[messageSettingName];
            }
            messages.Add(message);
            HttpContext.Current.Session[messageSettingName] = messages;
        }
    }
}