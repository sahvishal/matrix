<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="App_UCCommon_ucMiniAddNewContact" Codebehind="ucMiniAddNewContact.ascx.cs" %>

<style type="text/css">
.wrapper_popup{float: left; width:738px; padding:10px; background-color: #f5f5f5;}
.wrapperin_popup{float: left; width:714px; border:solid 2px #4888AB; padding: 10px; background-color: #fff; }
.innermain_popup{float: left; width:714px;}
     
</style>


<script language="javascript" type="text/javascript">
    function ClearContactFields()
    {
        document.getElementById('<%= this.txtTitle.ClientID %>').value = '';
        document.getElementById('<%= this.txtFName.ClientID %>').value = '';
        document.getElementById('<%= this.txtMName.ClientID %>').value = '';
        document.getElementById('<%= this.txtLName.ClientID %>').value = '';
        document.getElementById('<%= this.txtPhoneOffice.ClientID %>').value = '';
        document.getElementById('<%= this.txtPhoneExtension.ClientID %>').value = '';
        document.getElementById('<%= this.txtFax.ClientID %>').value = '';
        document.getElementById('<%= this.txtEmailContact.ClientID %>').value = '';
        document.getElementById('<%= this.txtTitleContact.ClientID %>').value = '';
        
        document.getElementById('<%= this.txtNotesContact.ClientID %>').value = '';
        document.getElementById('<%= this.txtBday.ClientID %>').value = '';
        document.getElementById('<%= this.txtSecondaryEmail.ClientID %>').value = '';
        document.getElementById('<%= this.txtPhoneHome.ClientID %>').value = '';
        document.getElementById('<%= this.txtPhoneCell.ClientID %>').value = '';        
        
        var chkTable = document.getElementById('<%= this.chkRoleContact.ClientID %>');
        
        if(chkTable != null)
        {
            var arrinputelems = chkTable.getElementsByTagName('INPUT');
            var loopcounter = 0;
            
            while(loopcounter < arrinputelems.length)
            {
                arrinputelems[loopcounter].checked = false;
                loopcounter = loopcounter + 1;
            }
            
        }
        
    }
    function SetContactTitle(contacttitle)
    {
        document.getElementById('<%= this.pgtitle.ClientID %>').innerHTML=contacttitle;
    }
    function SetContact(contacts)
    {
        var contactAll = contacts.split("|");
        if(contactAll.length >0)
        {
            document.getElementById('<%= this.txtTitle.ClientID %>').value = contactAll[1];        
            document.getElementById('<%= this.txtFName.ClientID %>').value =  contactAll[2];
            document.getElementById('<%= this.txtMName.ClientID %>').value =  contactAll[3];
            document.getElementById('<%= this.txtLName.ClientID %>').value = contactAll[4];
            document.getElementById('<%= this.txtPhoneOffice.ClientID %>').value = contactAll[5];
            document.getElementById('<%= this.txtPhoneExtension.ClientID %>').value =  contactAll[6];
            document.getElementById('<%= this.txtPhoneHome.ClientID %>').value =  contactAll[7];
            document.getElementById('<%= this.txtPhoneCell.ClientID %>').value =  contactAll[8];
            document.getElementById('<%= this.txtEmailContact.ClientID %>').value =  contactAll[9];
            document.getElementById('<%= this.txtSecondaryEmail.ClientID %>').value =  contactAll[10];
            if(contactAll[11]=="True")
            {   
                document.getElementById('<%= this.rbtMale.ClientID %>').checked=true;
                document.getElementById('<%= this.rbtFemale.ClientID %>').checked=false;
            }
            else 
            {
                document.getElementById('<%= this.rbtMale.ClientID %>').checked=false;
                document.getElementById('<%= this.rbtFemale.ClientID %>').checked=true;
            }
            document.getElementById('<%= this.txtBday.ClientID %>').value=contactAll[12];
            
            
            document.getElementById('<%= this.txtTitleContact.ClientID %>').value=contactAll[13];
            document.getElementById('<%= this.txtNotesContact.ClientID %>').value=contactAll[14];
            
            // Put for contact role
            // put contactAll[15] as comma separate
            
            var chkTable = document.getElementById('<%= this.chkRoleContact.ClientID %>');
            if(chkTable != null && contactAll[15].length > 0)
            {
                var arrvalues = contactAll[15].split(",");
                
                var arrinputelems = chkTable.getElementsByTagName('INPUT');
                var loopcounter = 0;
                var loopcounterval = 0;
                
                if(ArrCheckBoxValue != null)
                {
                    while(loopcounterval < arrvalues.length)
                    {
                        while(loopcounter < ArrCheckBoxValue.length)
                        {
                            if(ArrCheckBoxValue[loopcounter] == arrvalues[loopcounterval])
                            {
                                arrinputelems[loopcounter].checked = true;
                                break;
                            }
                            loopcounter = loopcounter + 1;
                        }
                        loopcounterval = loopcounterval + 1;
                    } 
                }  
            }
         }
    }
    function ValidatePopUp() 
    {
        var txtBday = document.getElementById('<%= this.txtBday.ClientID %>');
        
        if (isBlank(document.getElementById('<%= this.txtFName.ClientID %>'), 'First Name'))
            return false;

        var txtEmailContact = document.getElementById('<%= this.txtEmailContact.ClientID %>');

        if (txtEmailContact.value != '') {
            if (validateEmail(document.getElementById('<%= this.txtEmailContact.ClientID %>'), "Email") != true) {
                return false;
            }
        }
        if (txtBday.value != '')
		{
				
		    if (ValidateDate(txtBday.value, 'Date of Birth.') == false)
			{
					return false;
			}
		}
		
        return true;
    }

</script>
<div class="wrapper_popup">
<div class="wrapperin_popup">
    <div class="innermain_popup">
        <div class="maindivoutr_addnc">
                <div class="row">
                        <h1 id="pgtitle" runat="server" style="float:left">Add New Contact</h1>
                </div>
                    <p style="border-top:solid 1px #e5e5e5;">
                        <span class="input140px_addnc">Salutation:<asp:TextBox ID="txtTitle" runat="server" CssClass="inputf_anp" Width="140px"></asp:TextBox>
                        </span>
                        <span class="input165px_addnc">First Name:<span class="reqiredmark"><sup>*</sup></span><asp:TextBox ID="txtFName" runat="server" CssClass="inputf_anp" Width="165px"></asp:TextBox>
                        </span>
                        <span class="input110px_addnc">Middle Name:<asp:TextBox ID="txtMName" runat="server" CssClass="inputf_anp" Width="110px"></asp:TextBox>
                        </span>
                        <span class="input140px_addnc" style="margin-right: 0px;">Last Name:<asp:TextBox ID="txtLName" runat="server" CssClass="inputf_anp" Width="140px"></asp:TextBox>
                        </span>
                    </p>
                    
                    <p>
                    <span class="input140px_addnc">Title: <asp:TextBox
                                ID="txtTitleContact" runat="server" Width="140px" CssClass="inputf_anp"></asp:TextBox>
                      </span>
                    <span class="input110px_addnc" style="margin-right:5px">Phone Direct:<asp:TextBox ID="txtPhoneOffice" runat="server" CssClass="inputf_anp mask-phone" Width="105px"></asp:TextBox>
                     
                    </span>
                     <span class="input50px_addnc">Ext: <asp:TextBox ID="txtPhoneExtension" runat="server" CssClass="inputf_anp" MaxLength="6"
                                    Width="50px"></asp:TextBox></span>
                     <span class="input110px_addnc">Phone Cell:<asp:TextBox ID="txtPhoneCell" runat="server" CssClass="inputf_anp mask-phone" Width="110px"></asp:TextBox>
                      
                     </span>
                      <span class="input140px_addnc">Phone Home:<asp:TextBox ID="txtPhoneHome" runat="server" CssClass="inputf_anp mask-phone" Width="120px"></asp:TextBox>                      
                      </span>
                    </p>
                    <p>
                     <span class="input140px_addnc">Email: <asp:TextBox ID="txtEmailContact" runat="server" CssClass="inputf_anp" Width="140px"></asp:TextBox></span>
                     <span class="input165px_addnc">Secondary Email:<asp:TextBox ID="txtSecondaryEmail" runat="server" CssClass="inputf_anp" Width="165px"></asp:TextBox></span>
                      <span class="input110px_addnc" style=" width:90px; margin-right:10px;">Date of Birth: <asp:TextBox ID="txtBday" runat="server" CssClass="inputf_anp date-picker" Width="90px"></asp:TextBox><span style=" float:left; font-size: 7pt;" CssClass="inputf_anp">(mm/dd/yyyy)</span></span>
                      
                    <span class="input140px_addnc">Fax:
                        <asp:TextBox ID="txtFax" runat="server" CssClass="inputf_anp mask-phone" Width="120px"></asp:TextBox>
                    </span>
                    </p>
                    <div class="row">
                     <div id="divRole" runat="server" style="display:block" class="input165px_addnc">
                    <span class="inputnowidth_addnc" style="padding-top:3px">Role:</span>
                     <span class="inputfieldrightcon_anp">
                                <asp:CheckBoxList ID="chkRoleContact" runat="server" RepeatColumns="1" RepeatDirection="Vertical">
                                </asp:CheckBoxList>
                            </span>
                      </div>
                      <div class="left">    
                      <span class="inputnowidth_addnc"  style="padding-top:3px">Gender:</span>
                       <span class="left">
                       <asp:RadioButton runat="server" ID="rbtMale" Text="Male" Checked="true" GroupName="Gender" /><br />
                                <asp:RadioButton runat="server" ID="rbtFemale" Text="Female" GroupName="Gender" />
                       </span>
                       </div>       
                    
                    </div>
                    <p>
                      <span class="input140px_addnc">Contact Notes:
                   <asp:TextBox ID="txtNotesContact" runat="server" CssClass="inputf_def" Width="680px" TextMode="MultiLine"
                                Height="80px"></asp:TextBox></span>
                    </p>

                <p style="margin-top:10px;">
                    <span class="buttoncon_default">
                        <asp:ImageButton runat="server" CausesValidation="true" ID="ibtnSaveContact" ImageUrl="~/App/Images/save-button.gif"
                            OnClientClick="return ValidatePopUp();" OnClick="ibtnSaveContact_Click" />
                    </span>
                    <span class="buttoncon_default">
                        <asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="~/App/Images/cancel-button.gif"
                            OnClientClick="return HideAddContactPopup();" />
                    </span>
                </p>
    </div>
  </div>  
</div>
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {
            $(".date-picker").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-10:+50"
            });
            $('.mask-phone').mask("(999)-999-9999");
            
        });
    
    </script>
</div>
