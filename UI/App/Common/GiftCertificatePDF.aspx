<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GiftCertificatePDF.aspx.cs"
    Inherits="Falcon.App.UI.App.Common.GiftCertificatePDF" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gift Certificate</title>
    <link href="/App/StyleSheets/GiftCertificate.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        body, html
        {
            margin: 0;
            padding: 0;
            background: #fff;
            font-family: Arial, Helvetica, sans-serif;
            color: #000;
            font-size: 12px;
        }
        form
        {
            margin: 0;
            padding: 0;
        }
        .maincontainer
        {
            width: 700px;
            margin: 0px auto;
            background: #fbfbfb;
            padding: 20px 0;
        }
        .container
        {
            width: 670px;
            margin: 0px auto;
        }
        .divtc
        {
            float: left;
            width: 650px;
            padding: 6px;
            color: #666;
        }
        .divtoptxt
        {
            float: left;
            width: 660px;
            padding: 6px;
            line-height: 18px;
            color: #000;
            text-align: justify;
        }
        a:link, a:visited, a:hover
        {
            font: 12px arial;
            text-decoration: underline;
        }
        a:link, a:visited
        {
            color: #287aa8;
        }
        a:hover
        {
            color: #f60;
        }
        .txtb1
        {
            font: bold 13px arial;
            color: #666;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="maincontainer">
        <div class="container">
            <div class="divtoptxt">
                <span class="txtb1"><span class="cupncode" id="FromNameSpan" runat="server" style="color: #F47E1C">
                </span>&nbsp; has sent you a
                    <%= IoC.Resolve<ISettings>().CompanyName %>
                    <sup>&reg;</sup> Gift Certificate to use when purchasing a
                    <%= IoC.Resolve<ISettings>().CompanyName %><sup>&reg;</sup> Preventive Screening.</span><br />
                <br />
                <strong>
                    <%= IoC.Resolve<ISettings>().CompanyName %>
                    <sup>&reg;</sup></strong> is a leading preventive screening provider focused
                on identifying underlying Heart & Stroke risk in asymptomatic individuals, like
                you. Screenings are completely painless and are conducted in the convenience of
                your own neighborhood at community centers, schools, and even faith-based organizations.
            </div>
            <style type="text/css">
                .bckImage
                {
                    background-image: url(<%= IoC.Resolve<ISettings>().GiftCertificateImagePath %>);
                    background-repeat: no-repeat;
                }
            </style>
            <div id="PreviewGC">
                <div class="divcertificate">
                    <div class="inner bckImage">
                        <div class="divamount">
                            <label>
                                Amount:
                            </label>
                            <span class="amonttxt amount-span" id="AmountInput" runat="server" enableviewstate="true">
                                $</span>
                        </div>
                        <div class="custdtlsbox">
                            <div class="hrow">
                                <label>
                                    To:</label>
                                <span class="totxt" id="ToNameInput" runat="server"></span>
                            </div>
                            <div class="hrow" style="height: 70px">
                                <label class="labelmsg">
                                    Personal Message:</label>
                                <span class="prsnlmsg" id="MessageInput" runat="server" style="overflow: hidden;">
                                </span>
                            </div>
                            <div class="hrow" style="height: 30px; margin-top: 20px">
                                <label class="labeld">
                                    Claim Code #:</label>
                                <span class="cupncode" id="ClaimCodeSpan" runat="server"></span>
                            </div>
                            <div class="hrow">
                                <label>
                                    From:</label>
                                <span class="cupncode" id="FromNameInput" runat="server"></span>
                            </div>
                        </div>
                    </div>
                    <div class="grayinfotxt" style="padding: 0px">
                        <sup>*</sup><i>No expiration date. All sales are final. Not returnable or refundable
                            for cash.</i></div>
                </div>
                <div class="divtc">
                    <b>How to redeem your
                        <%= IoC.Resolve<ISettings>().CompanyName %>
                        <sup>&reg;</sup> Gift Certificate?</b>
                    <ol>
                        <li>Go to <a href="<%= IoC.Resolve<ISettings>().SiteUrl%>">
                            <%= IoC.Resolve<ISettings>().SiteUrl%>
                        </a></li>
                        <li>Search for a screening event in your neighborhood using the zip code search tool</li>
                        <li>Click on the preferred screening date/location</li>
                        <li>Register for the screening package of your choice</li>
                        <li>Pick your appointment time of your choice</li>
                        <li>Enter the ‘Claim Code’ above, as your mode of payment on the payment page of the
                            signup process to redeem your
                            <%= IoC.Resolve<ISettings>().CompanyName %>
                            <sup>&reg;</sup> Gift Certificate. </li>
                    </ol>
                </div>
                <div class="divtc">
                    <b>Terms and conditions:</b><br />
                    <%= IoC.Resolve<ISettings>().CompanyName %>
                    <sup>&reg;</sup> expressly disclaims all warranties and responsibilities of any
                    kind, whether express or implied, for the accuracy or reliability of the content
                    of any information contained in this Web Site. While we have made a concerted effort
                    to provide you with the best possible information, this website is not a substitute
                    for a visit with your healthcare professional, and any reliance upon or use of this
                    information by you is at your own independent discretion and risk. By using this
                    site you agree to these terms.
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
