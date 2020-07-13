using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Linq;

using System.Threading;
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;

namespace Falcon.App.Lib
{
	public class HelperFunctions
	{

		 
		/// <summary>
		///     This ties a form control to a button. 
		/// </summary>
		/// <param name="TextBoxToTie">
		///     This is the textbox to tie to. It doesn't have to be a TextBox control, but must be derived from either HtmlControl or WebControl,
		///     and the html control should accept an 'onkeydown' attribute.
		/// </param>
		/// <param name="ButtonToTie">
		///     This is the button to tie to. All we need from this is it's ClientID. The Html tag it renders should support click()
		/// </param>		
		public static void TieButton(Control TextBoxToTie, IButtonControl ButtonToTie)
		{
			// This is our javascript - we fire the client-side click event of the button if the enter key is pressed.
			//string jsString = "if ((event.which && event.which == 13) || (event.keyCode && event.keyCode == 13)) { if (document.getElementById('" + ButtonToTie.ClientID + "') && typeof(document.getElementById('" + ButtonToTie.ClientID + "').click) != \"undefined\"){ document.getElementById('" + ButtonToTie.ClientID + "').click();return false; } else { __doPostBack('" + ButtonToTie.ClientID + "',''); return false; } }";

			PostBackOptions myPostBackOptions = new PostBackOptions((Control)ButtonToTie);

			if (ButtonToTie.CausesValidation)
			{
				myPostBackOptions.PerformValidation = true;
			}

			//Need to replace double quotes with single quotes for javascript to work.
			string postBackFunction = ((Control)ButtonToTie).Page.ClientScript.GetPostBackEventReference(myPostBackOptions).Replace("\"", "'");
            //string jsString = "javascript:if (event.keyCode == 13) {try{needDataLossConfirmation=false;}catch(e){} " + postBackFunction + " }";
            string jsString = "javascript:if (event.keyCode == 13) {try{ $('#" + ((Control)ButtonToTie).ClientID + "').click();  }catch(e){} }";
            
			// We attach this to the onkeydown attribute - we have to cater for HtmlControl or WebControl.
			if (TextBoxToTie is System.Web.UI.HtmlControls.HtmlControl)
			{
				if (((HtmlControl)TextBoxToTie).Attributes["onkeydown"] == null)
				{
					((HtmlControl)TextBoxToTie).Attributes.Add("onkeydown", jsString);
				}
				else if (((HtmlControl)TextBoxToTie).Attributes["onkeydown"].IndexOf(jsString) == -1)
				{
                    ((HtmlControl)TextBoxToTie).Attributes["onkeydown"] = jsString + " " + ((HtmlControl)TextBoxToTie).Attributes["onkeydown"];
				}
			}
			else if (TextBoxToTie is System.Web.UI.WebControls.WebControl)
			{
				//we don't want to tie multiline textboxes, since people need to hit enter inside them
				TextBox txtBox = TextBoxToTie as TextBox;
				if (txtBox == null || txtBox.TextMode != TextBoxMode.MultiLine)
				{
					if (((WebControl)TextBoxToTie).Attributes["onkeydown"] == null)
					{
						((WebControl)TextBoxToTie).Attributes.Add("onkeydown", jsString);
					}
					else if (((WebControl)TextBoxToTie).Attributes["onkeydown"].IndexOf(jsString) == -1)
					{
                        ((WebControl)TextBoxToTie).Attributes["onkeydown"] = jsString + " " + ((WebControl)TextBoxToTie).Attributes["onkeydown"];
					}
				}
			}
			else
			{
				// We throw an exception if TextBoxToTie is not of type HtmlControl or WebControl.
				throw new ArgumentException("Control TextBoxToTie should be derived from either System.Web.UI.HtmlControls.HtmlControl or System.Web.UI.WebControls.WebControl", "TextBoxToTie");
			}
		}
 
	}
}
