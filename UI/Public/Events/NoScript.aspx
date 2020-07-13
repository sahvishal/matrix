<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="" Inherits="Falcon.App.UI.Public.Events.NoScript" EnableEventValidation="false" CodeBehind="NoScript.aspx.cs" Title="JavaScript Disabled" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <link rel='shortcut icon' href='/favicon.ico' type="image/x-icon" />
    <link href="/Content/Styles/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
        <center>
            <br />
            <br />
            <b>Javascript is <u>NOT</u> activated in your browser.This web site needs javascript activated to work properly.</b><br />
            <br />
            You can register for events by calling our toll free number <strong>
                <%= IoC.Resolve<ISettings>().PhoneTollFree%></strong>
            <br />
            <br />
            <img src="/Content/Images/no_javascript.gif" alt="Javascript Disabled!" />
        </center>

    <br />
    <br />
    <h3>Learn How to enable JavaScript in your browser. </h3>
    <p>
        Javascript is the programming language that makes it possible for you to interact with an online application form and view a special effects slideshow for example. Behind the scenes it also performs calculations and data tasks (i.e. Balances on an Order Form), time and date functions and so on. Cookies are files that are normally used for storing website Preferences (settings) and Username &amp; Password details so that you do not have to type log-in details or set preferences (settings) each time you visit a particular website or webpage. Javascript can check if cookie functionality is switched on. Therefore, the two go hand-in-hand.
    </p>
    <br />
    <p>
        Sometimes a webpage might complain "Cookies are not enabled" or "Javascript is not switched on". Under normal circumstances there is no reason to have Cookies and Javascript functionality switched off - They should both be switched on by default. However. Sometimes a security program may have switched them off for security reasons or a virus may of tricked you to switching them off for bad reasons. Either way. You should investigate why they are switched off, if possible. In this section we will show you how to enable/disable Cookies and Javascript functionality. I will begin with Javascript.
        <br />
        <br />
        Open Internet Explorer and then select the INTERNET OPTIONS menu-item from either the TOOLS menu-button of the Commands Bar (Fig 1.0) or the TOOLS menu of the Menu Bar (Fig 1.1). Either way will open the Internet Options window (Fig 1.2). You can also go to the Control Panel and double click on the INTERNET OPTIONS icon (control panel) if you wish (not shown here).
    </p>
    <div align="center" class="pngs">
        <img src="/Content/images/iogt11.png" alt="">
        <br />
        <br />
        <font size="3">Fig 1.0&nbsp;&nbsp;</font>Click on the TOOLS menu-button and select INTERNET OPTIONS....
        <br />
        <br />
        <br />
        <img src="/Content/images/iogt10.png" alt="">
        <br />
        <br />
        <font size="3">Fig 1.1&nbsp;&nbsp;</font>....or click on the TOOLS menu and select INTERNET OPTIONS.
        <br />
        <br />
        <br />
        <img src="/Content/images/iost12.png" alt="">
        <br />
        <br />
        <font size="3">Fig 1.2&nbsp;&nbsp;</font>Click on the SECURITY Tab (window) and then on the CUSTOM LEVEL button to continue
    </div>
    <br />
    <p>
        With the Internet Options window open click on the SECURITY Tab (window) and then on the CUSTOM LEVEL button (above) to open the Security Settings - Internet Zone window (below). The Security Settings window displays the settings of the Internet Zone simply because this is the default zone when you click on the CUSTOM LEVEL button.
    </p>
    <div align="center" class="pngs">
        <img src="/Content/images/iost13.png" alt="">
        <br />
        <br />
        <font size="3">Fig 1.3&nbsp;&nbsp;</font>Select the DISABLE button underneath the Active Scripting setting and then click on the OK button
    </div>
    <br />
    <p>
        The next thing to do is scroll down the settings that are displayed on the Security Settings - Internet Zone window (above) until you reach the SCRIPTING section, towards the bottom of the display area. From there. Select the DISABLE radio (circle) button underneath the ACTIVE SCRIPTING setting and then click on the OK button to continue.
        <br />
        <br />
        After clicking on the OK button (above) a message requester will appear (below) asking you if you want to change the ACTIVE SCRIPTING setting, which is the same as asking you if you want to disable Javascript - Active Scripting means scripts in general. Click on the YES button to disable Javascripts from running (functioning).
    </p>
    <div align="center" class="pngs">
        <img src="/Content/images/iost14.png" alt="">
        <br />
        <br />
        <font size="3">Fig 1.4&nbsp;&nbsp;</font>Click on the YES button to disable Javascripts from running (functioning)
    </div>
    <br />
    <p>
        To enable Javascripting again simply follow the above steps but this time select the ENABLE radio (circle) button underneath the ACTIVE SCRIPTING setting before clicking on the OK and YES buttons respectively.
    </p>
    <div>
        <table style="background-image: url(/Content/images/homepage_banner.png)" cellspacing="0" cellpadding="0" width="100%" class="borderheading">
            <tr>
                <td height="32" align="center">
                    ENABLE&nbsp;&nbsp;/&nbsp;&nbsp;DISABLE&nbsp;&nbsp;COOKIES
                </td>
            </tr>
        </table>
    </div>
    <br />
    <p>
        To disable Cookies you first need to click on the PRIVACY Tab (window), on the Internet Options window, and then on the ADVANCED button (Fig 2.0 below) to bring up the Advanced Privacy Settings window (Fig 2.1). From there you can ACCEPT cookies, BLOCK cookies or be PROMPTed for cookies action.
    </p>
    <div align="center" class="pngs">
        <img src="/Content/images/iost15.png" alt="">
        <br />
        <br />
        <font size="3">Fig 2.0&nbsp;&nbsp;</font>Click on the PRIVACY Tab (window) and then on the ADVANCED button to continue
        <br />
        <br />
        <br />
        <img src="/Content/images/jscookies5.png" alt="">
        <br />
        <br />
        <font size="3">Fig 2.1&nbsp;&nbsp;</font>Tick the OVERRIDE AUTOMATIC COOKIE HANDLING setting and then BLOCK all cookies
    </div>
    <br />
    <p>
        With the Advanced Privacy Settings window open (above) for the first time its default settings are set to accept (allow) all cookies. To disable these default settings simply put a tick next to the OVERRIDE AUTOMATIC COOKIE HANDLING setting, so that the other settings become available, and then click on both of the BLOCK radio (circle) buttons - BLOCK first party Cookies and BLOCK third party Cookies. When you have done that click on the OK button to set your new settings.
        <br />
        <br />
        The above settings are really only for certain types of cookies (cookie file) but are not a proven way to disable all cookies, partly due to other setting configurations and factors. Therefore, if you really want to disable all cookies you are better off using the Privacy Settings slider on the PRIVACY Tab itself - Simply move the slider upwards, to its topmost setting of BLOCK ALL COOKIES, and then click on the OK button.
    </p>
    <div align="center" class="pngs">
        <img src="/Content/images/iost16.png" alt="">
        <br />
        <br />
        <font size="3">Fig 2.2&nbsp;&nbsp;</font>Set the slider to the BLOCK ALL COOKIES setting and then click on the OK button
    </div>
    <br />
    <p>
        Once you have disable Javascripting and/or Cookies close/exit all of the Internet Options windows and internet explorer as well for the settings to take effect. The effects can be seen when you reopen internet explorer and go to a website or webpage that relies on Javascript and/or Cookies - You should notice that that website or webpage does not function correctly. It might display correctly but not function correctly. Some websites display non-javascript/non-cookies webpages whereas other websites complain with an error message: "Cookies are not enabled.... Javascript is switched off....".
    </p>
    <div>
        <table style="background-image: url(/Content/images/homepage_banner.png)" cellspacing="0" cellpadding="0" width="100%" class="borderheading">
            <tr>
                <td height="32" align="center">
                    OTHER&nbsp;&nbsp;WEB&nbsp;&nbsp;BROWSERS
                </td>
            </tr>
        </table>
    </div>
    <br />
    <p>
        Here are some examples of how to enable or disable Javascript and/or Cookies in other web browsers. The first example is for Firefox 3. In firefox start by going to the TOOLS menu and then click on the OPTIONS menu-item. From there, click on the CONTENT Tab to tick/untick the ENABLE JAVASCRIPT option. To enable/disable cookies select the PRIVACY Tab and then tick/untick the ACCEPT COOKIES FROM SITES option.
    </p>
    <div align="center" class="pngs">
        <img src="/Content/images/jscookies7.png" alt="">
        <br />
        <br />
        <font size="3">Fig 3.0&nbsp;&nbsp;</font>Untick the ENABLE JAVASCRIPT option to disable Javascripting
        <br />
        <br />
        <br />
        <img src="/Content/images/jscookies8.png" alt="">
        <br />
        <br />
        <font size="3">Fig 3.1&nbsp;&nbsp;</font>Untick the ACCEPT COOKIES FROM SITES option to disable Cookies
    </div>
    <br />
    <p>
        With Opera 6 it is a slightly different process. First go to the TOOLS menu and then click on the PREFERENCES menu-item. From there click on the ADVANCED Tab. To disable Javascript click on the CONTENT preference, on the left of the window, and then untick the ENABLE JAVASCRIPT option (Fig 3.2). Tick that option to enable Javascript again. Cookies can be disabled by clicking on the COOKIES preference, on the left of the window, and then by clicking on the NEVER ACCEPT COOKIES option (Fig 3.3). To enable cookies again click on the ACCEPT COOKIES option.
    </p>
    <div align="center" class="pngs">
        <img src="/Content/images/jscookies9.png" alt="">
        <br />
        <br />
        <font size="3">Fig 3.2&nbsp;&nbsp;</font>Untick the ENABLE JAVASCRIPT option to disable Javascripting
        <br />
        <br />
        <br />
        <img src="/Content/images/jscookies10.png" alt="">
        <br />
        <br />
        <font size="3">Fig 3.3&nbsp;&nbsp;</font>Click on the NEVER ACCEPT COOKIES option to disable Cookies
    </div>
    <br />
    <p>
        Opera also has a QUICK PREFERENCES menu-item on the TOOLS menu whereby you can quickly tick (enable) and untick (disable) an option (preference) but I have showed you the ADVANCED Preferences tab because it has more options (preferences) on it that you might like to see/investigate.
        <br />
        <br />
        With the Apple Safari web browser you first go to the EDIT menu and click on the PREFERENCES menu-item. From there. Click on the SECURITY Tab and change the preferences (options). Fig 3.4 shows Javascript disabled (the Web Content preference has the ENABLE JAVASCRIPT option unticked) and Cookies disabled (the Accept Cookies preference has the NEVER option selected).
    </p>
    <div align="center" class="pngs">
        <img src="/Content/images/jscookies11.png" alt="">
        <br />
        <br />
        <font size="3">Fig 3.4&nbsp;&nbsp;</font>Javascript is disabled (ENABLE JAVASCRIPT unticked) and so are Cookies (NEVER option selected)
    </div>
    <br />
    <p>
        In general you should have Javascript and Cookies switched on (enabled). If you notice any one of them switched off ask yourself Why? Then enable them and see if they get switched off again. If so, try and find out which program/task is switching them off because it could mean you have security problems (i.e. Malware, Spyware, etc tampering with your computer).
    </p>
    <br />
</body>
</html>
