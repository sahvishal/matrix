<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
Title="Better Value Packages" CodeBehind="BetterValuePackagesOffered.aspx.cs" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer.BetterValuePackagesOffered" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="wrapper_inpg">
	<div class="maindivredmsgbox" id="errordiv" runat="server" visible="false">
	</div>
	 <div class="inrpg_mbdrccrep">		
			<div class="pgnosymbol_regcust">
				<img src="/App/Images/CCRep/page4symbol.gif" alt="" />
			</div>
			<div class="wrpr_content">
				<div class="midwrpr">
					<h2>Existing Customer</h2>
					<div class="fline_regcust"></div>
					<span class="orngbold14_default">Dear <span><< Customer Name >> </span></span><br />
					<span class="graybold14_default">Currently you have selected the following package</span>
					<div class="wrpr_pickd_pkg">
						<span class="graybold12_default">Circulatory Health + Heart Health</span>
					</div>
				</div>
				<div class="rightdivrow_regcust">
					<div class="timeboard_ccrep_dboard">
						<div class="timeboxbg_ccrep_dboard">
							<p class="tboxrow_ccrep_dboard">
								<span class="timetxt_ccrep_dboard"><span id="HH"></span>:<span id="MM"></span>:<span id="SS"></span>
								</span>
							</p>
							<p class="tboxrowformat_ccrep_dboard">
								<span class="smallgraytxt_ccrep">(HH:MM:SS)</span>
							</p>
							<p class="tboxrowbtm_ccrep_dboard">
								<span class="whttxt_ccrep_dboard">Call in Progress</span>
							</p>
						</div>
					</div>							
					<div class="endcall_ccrep_dboard" style="margin-top:2px">
						<span class="endtbtn_ccrep_dboard">
							<asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif"
											OnClientClick="CallNotes(); return false;" />
						</span>
					</div>
				</div>
				<div class="hzrow">				<span class="graybold14_default left">You have made an proactive decision to get screened with <%= IoC.Resolve<ISettings>().CompanyName %> <sup>&reg;</sup>.				While  your <br /> <span class="orngbold14_default"><u>Circulatory Health + Heart Health</u></span> is a very good choice, I hope you are aware that we have 				more tests that can give you more comprehensive information. These packages are a much 				better value.</span>
				</div>
				<div class="grdbettrpckge">
					<asp:GridView runat="server" ID="grdbettrpackages" ShowHeader="false" CssClass="gridbillinfo" AutoGenerateColumns="false"
                        GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
									<asp:RadioButton ID="RadioButton1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                 <div class="pckgnamendtls">
									<span class="orngbold14_default">Total Health Screening Package </span><br />
									<span class="graysmalltxt_default">Abdominal Aortic Aneurysm, Arterial Stiffness Index, Osteoporosis, Peripheral Artery Disease, Stroke </span>
								</div>
								<div class="mdash_spacer"></div>
								<div class="pckgprice">
									$ 199.95 
								</div>
								<div class="othrdtls_grd">
									<span class="graybold14_default">Difference Amount : <span><u>$20.00</u></span></span>
									<span class="blutxt12" style="padding-left:20px">[You have to pay only <span>$20.00</span> more]</span><br />
									<span class="graybold12_default">Additional test:&nbsp;</span><span style="color:#666">OsteoPorosis</span>
								</div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="vertop" />
                    </asp:GridView>
				</div>
			</div>				
	</div>
	<div class="main_area_bdrnone" style="margin-top:5px">
        <div class="rgt">
			<asp:Button ID="Button1" runat="server" Text="Back" CssClass="button" /> <asp:Button ID="Button2" runat="server" Text="Skip Upgrade" CssClass="button" /> <asp:Button ID="btnSave" runat="server" Text="Upgrade & Proceed" CssClass="button" Width="142px" />
		</div>
	</div>
</div>
</asp:Content>
