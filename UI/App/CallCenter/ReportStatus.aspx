<%@ Page Language="C#" AutoEventWireup="true" Inherits="CallCenter_ReportStatus" Codebehind="ReportStatus.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Report Status</title>
     <link href="~/App/StyleSheets/Wizardstyle.css" rel="Stylesheet" type="text/css" />
   
</head>
<body style="background-color:#fff;">
    <form id="form1" runat="server">
<%--       <div class="mainbody_outer_rs">--%>
        <div class="defaultdivwizard">
        <div class="mainbody_inner">
		<div class="mainbody_inner_left"></div>
		<div class="mainbody_inner_mid">
		<div class="mainbody_titletxtleft">Report Status</div>
		<div class="titlelnkright_v_prospects"></div>
		</div>
		<div class="mainbody_inner_right"></div>
		<div class="main_area_bdr">
		<div class="main_content_area_rs">
		
	
		
		<div class="headbgtop_box_prr">
		<div class="head_text_prr">Customer Information </div>
		</div>
		<div class="singlerow_rs">
		<div class="custd_name_rs">Customer Name:</div>
		<div class="inputboxdetails_rs" id="dvCustName" runat=server>Dale Wekkan Wood</div>
		<div class="custd_name_rs">Address:</div>
		<div class="inputboxdetails_rs" id="dvCustAddress" runat=server>121/4, Jon Villa, CA-92563</div>
		<div class="custd_name_rs">Email:</div>
		<div class="inputboxdetails_rs" id="dvCustEmail" runat=server>dwwood@gmail.com</div>
		</div>
		
		<div >
		<div class="headbg_box_rs">
		<div class="head_text_rs">Report Collection </div>
		</div>
		<div class="singlerow_rs" disabled=disabled>
		<div class="reportcollectionm_rs">Report Collection Mode:</div>
		<div class="moderepcoll_rs">
		<asp:DropDownList Enabled=false runat="server" ID="rcmode" CssClass="" Width="150">
		<asp:ListItem Text="Select Mode" ></asp:ListItem>
		<asp:ListItem Text="Online" ></asp:ListItem>
        <asp:ListItem Text="Mail" ></asp:ListItem>
        <asp:ListItem Text="Mail(Include Image)" ></asp:ListItem>
        </asp:DropDownList></div>
        <div class="right_area_rs">
            &nbsp;</div>
		</div>
		</div>
		<%---start grid-------%>
		
		
		<div class="headbg_box_rs">
		<div class="head_text_rs">Event History </div>
		</div>
		<div class="divgrideventhistory_rs" style="overflow:scroll;">
		
     <asp:DataGrid runat="server" ID="grideventhistory_rs" AutoGenerateColumns="false" CellPadding="0" CellSpacing="0" CssClass="grideventhistory_rs" GridLines="none" >
		<Columns>
		
				    		                
		<asp:BoundColumn DataField="EventID" HeaderText="Event ID">
		<HeaderStyle CssClass="headereventid_rs" />
		<ItemStyle CssClass="itemeventid_rs" />
		</asp:BoundColumn>
		
		<asp:BoundColumn DataField="EventName" HeaderText="Event Name">
		<HeaderStyle CssClass="headereventname_rs" />
		<ItemStyle CssClass="itemeventname_rs" />
		</asp:BoundColumn>
		
		<asp:BoundColumn DataField="Date" HeaderText="Date">
		<HeaderStyle CssClass="headerdate_rs" />
		<ItemStyle CssClass="itemdate_rs" />
		</asp:BoundColumn>
		        
	    <asp:BoundColumn DataField="City" HeaderText="City">
		<HeaderStyle CssClass="headercity_rs" />
		<ItemStyle CssClass="itemcity_rs" />
		</asp:BoundColumn>
			        
				
		<asp:BoundColumn DataField="AppointmentTime" HeaderText="Appointment Time">
		<HeaderStyle CssClass="headerapptime_rs" />
		<ItemStyle CssClass="itemapptime_rs" />
		</asp:BoundColumn>
		
		
		<asp:BoundColumn DataField="PackageAvailed" HeaderText="Package Availed">
		<HeaderStyle CssClass="headerpackageavail_rs" />
		<ItemStyle CssClass="itempackageavail_rs" />
		</asp:BoundColumn>
		
		<asp:BoundColumn DataField="PaymentMethod" HeaderText="Payment Method">
		<HeaderStyle CssClass="headerpaymentmethod_rs" />
		<ItemStyle CssClass="itempaymentmethod_rs" />
		</asp:BoundColumn>
		
		
		<asp:BoundColumn DataField="ReportStatus" HeaderText="Report Status">
		<HeaderStyle CssClass="headerrepstatus_rs" />
		<ItemStyle CssClass="itemrepstatus_rs" />
		</asp:BoundColumn>
		
		<asp:BoundColumn DataField="HealthInformation" HeaderText="Health Information">
		<HeaderStyle CssClass="headerhealthinfo_rs" />
		<ItemStyle CssClass="itemhealthinfo_rs" />
		</asp:BoundColumn>	
	
			                 
	  
			                
		</Columns>
		<HeaderStyle CssClass="headereventhistory_rs" />
		<ItemStyle CssClass="itemeventhistory_rs"  />
		<AlternatingItemStyle CssClass="alteventhistory_rs" />
		</asp:DataGrid>		
		</div>
		
		
		     
        </div>
        </div>
        </div>
        </div>
<%--        </div>--%>
        </form>
</body>
</html>
