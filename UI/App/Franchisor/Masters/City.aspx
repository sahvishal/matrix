<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="Franchisor_Masters_City" Title="Untitled Page"
    EnableEventValidation="false" CodeBehind="City.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<style>
.wrapper_pop {float: left; width: 352px; padding: 10px; background-color: #f5f5f5; }
.wrapperin_pop {float: left; width: 328px; border: solid 2px #4888AB; padding: 10px; background-color: #fff; }
.innermain_pop {float: left; width: 328px; }
.innermain_1_pop{float: left; width: 313px; padding-top: 5px; }
.wrapper_pop_l { float: left; width: 425px; padding: 10px; background-color: #f5f5f5; }
.wrapperin_pop_l { float: left; width: 401px; border: solid 2px #4888AB; padding: 10px; background-color: #fff; }
.innermain_pop_l { float: left; width: 391px; }
.innermain_pop_2 { float: left; width: 369px; }
.calright{float:right;}
.rowbdr { width:389px; padding:5px; float:left; border:solid 1px #ccc; margin-top:5px;}
</style>

    <script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js" language="javascript"></script>
    <script language="javascript" type="text/javascript">

 var XmlHttp;
 // Added By Viranjay - Check For Existing ZipCode
function CreateXmlHttp()
{
	var versionList = ["Msxml2.XMLHTTP", "Microsoft.XMLHTTP"] ;
	for(var count = 0; count<= versionList.length; count++)
	{
		try
		{
			XmlHttp = new ActiveXObject(versionList[count]);
			return XmlHttp ; // return the XMLHttp object
		}
		catch(objCreationError)
		{ 
			// Do nothing 
		}
	}
	//Creating object of XMLHTTP in Mozilla and Safari 
	if(!XmlHttp && typeof XMLHttpRequest != "undefined") 
	{
		XmlHttp = new XMLHttpRequest();
		return XmlHttp;
	}
	throw new Error("Unable to create the XMLHttp object.");
}

function CheckForZipCode(mode,zipcode)
{
   var requestUrl="AjaxServer.aspx?mode="+mode+"&zipcode="+zipcode;
   //alert(requestUrl);
   CreateXmlHttp();  
   if(XmlHttp)
   {
			//Setting the event handler for the response
			XmlHttp.onreadystatechange = HandleResponseforZipcode;
			//Initializes the request object with GET (METHOD of posting), Request URL and sets the request as asynchronous.
			XmlHttp.open("GET", requestUrl,false);
			//Sends the request to server
			XmlHttp.send(null);
			pause(300);
	}
	else // Browser does not support XMLHTTPRequest object
	{
		alert("Browser does not support XMLHTTPRequest object." );		
	}               
}
//debugger
function HandleResponseforZipcode()
{
 //To make sure receiving response data from server is completed
    
	if(XmlHttp.readyState == 4)
	{
		// To make sure valid response is received from the server, 200 means response received is OK
		// alert(XmlHttp.responseText);
	
		if(XmlHttp.status == 200) // response status is OK
		{		
			if(XmlHttp.responseText!="")	
			{
			var result='';
			
			result=XmlHttp.responseText;
			//alert(XmlHttp.responseText);
			var result1 = result.substr(46,1);
			//alert(result1);
			//alert(result1);
			if (result1 == 1)
			{
			    document.getElementById('<%= this.hfZipFlag.ClientID %>').value='false';
			    //alert('false1121');// + document.getElementById('<%= this.hfZipFlag.ClientID %>').value);
			    
			    //alert('False Value ' + document.getElementById('<%= this.hfZipFlag.ClientID %>').value);
			}
			else
			{
			     document.getElementById('<%= this.hfZipFlag.ClientID %>').value='true';
			     //alert('true1112');// + document.getElementById('<%= this.hfZipFlag.ClientID %>').value );
			     //document.getElementById('<%= this.hfZipFlag.ClientID %>').value="true";
			     //alert('True Value ' + document.getElementById('<%= this.hfZipFlag.ClientID %>').value);
			    //alert(blnstatus);
			}
			}			
		}
		else
		{
			alert("There was a problem retrieving data from the server." );
		}
	}
	
}


function hidediv() 
        { 
            if (document.getElementById) 
            { // DOM3 = IE5, NS6 
               // document.getElementById('bottom_bdr_master').style.visibility = 'hidden'; 
            } 
            else if (document.layers)
            { // Netscape 4
                //document.hideshow.visibility = 'hidden'; 
            } 
            else 
            { // IE 4 
                //document.all.hideshow.style.visibility = 'hidden'; 
            } 
            //HandleValidators(false);
        } 
        
        function showdiv() 
        { 
            if (document.getElementById) 
            { // DOM3 = IE5, NS6 
                //document.getElementById('bottom_bdr_master').style.visibility = 'visible'; 
            } 
            else if (document.layers)
            { // Netscape 4
                //document.hideshow.visibility = 'visible'; 
            } 
            else 
            { // IE 4 
                //document.all.hideshow.style.visibility = 'visible'; 
            } 
            //HandleValidators(true);
        }
        



        function EmptyBoxes()
        {
            ////debugger
            var txtName= document.getElementById(arrelemjscity[1]);
            var txtDescription= document.getElementById(arrelemjscity[2]);
            var txtZip= document.getElementById(arrelemjscity[7]);
            var ddlCountry= document.getElementById(arrelemjscity[3]);
            var ddlState= document.getElementById(arrelemjscity[4]);
          
            
            txtName.value = '';
            txtDescription.value = '';
            txtZip.value='';
            ddlCountry.options[0].selected = true;
      
            oncountrychange(ddlCountry.id, ddlState.id, false);      
            var popuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');   
            popuptitle.innerHTML = 'Add new City';
            
        }
    function IsNumeric(strString)
    {
        //  check for valid numeric strings	
       var strValidChars = "0123456789";
       var strChar;
       var blnResult = true;

       if (strString.length == 0) return false;

        // test strString consists of valid characters listed above
        for (i = 0; i < strString.length ;i++)
        {
            strChar = strString.charAt(i);
            if (strValidChars.indexOf(strChar) == -1)
            {
                blnResult = false;
                break;
            }
        }      
        return blnResult;
     }
        
        function pause(millisecondi)
     {
         var now = new Date();
         var exitTime = now.getTime() + millisecondi;     
         while(true)
         {
           now = new Date();
            if(now.getTime() > exitTime) return;
        }
    }
        function HandleValidators()
        {
                  
            //debugger
            
            var txtName= document.getElementById(arrelemjscity[1]);
            var txtZip= document.getElementById(arrelemjscity[7]);
            
            if(isBlank(txtName, 'City Name'))
                return false;
             else if(isBlank(txtZip, 'Zip Code'))
               return false;
               
            else if(IsNumeric(txtZip.value)==false)
            {
                alert('Zip Code should be numeric');
                txtZip.focus();
                return false;
            }
            
            var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";

            for (var i = 0; i < trim(txtName.value).length; i++) 
            {
  	            if (iChars.indexOf(trim(txtName.value).charAt(i)) != -1) 
  	            {
  	                document.getElementById('diverrorsummary').innerHTML='<li>Special characters are not allowed in the city name. Please remove them and try again.</li>';
  	                return false;
  	            }
  	        }
  	         if  (checkDropDown(document.getElementById('<%= this.ddlcountry.ClientID %>'),"Country")==false) {return false;}
  	         if  (checkDropDown(document.getElementById('<%= this.ddlstate.ClientID %>'),"State")==false) {return false;}
  	     
  	         
  	     CheckForZipCode(1,txtZip.value); 
          pause(200);           
          //alert(document.getElementById('<%= this.hfZipFlag.ClientID %>').value);
         if (document.getElementById('<%= this.hfZipFlag.ClientID %>').value=='false')
         {
             
             alert('Incorect Zipcode , Please enter correct zipcode ');
             txtZip.focus();             
             return false;
         }
  	         
  	    }
        
        function mastercheckboxclick()
        {
            
            if(arrelemjscity == null)
                return;
            
            var grdCity = document.getElementById(arrelemjscity[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdCity.rows[0].cells[0].childNodes.length)
            {
                if(grdCity.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdCity.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            
            rowcount = 1;
            var nodecount = 0;
            
            while(rowcount < grdCity.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdCity.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdCity.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                
                if(grdCity.rows[rowcount].cells.length > 1)
                    grdCity.rows[rowcount].cells[0].childNodes[nodecount].checked = mstrchkbox.checked;
                    
                rowcount = rowcount + 1;
            }
            
            MultiSelect();

        }
        
        
        function checkallboxes()
        {
            if(arrelemjscity == null)
                return;
            
            MultiSelect();
            var grdCity = document.getElementById(arrelemjscity[0]);
            var rowcount = 0;
            var mstrchkbox;
            
            while(rowcount<grdCity.rows[0].cells[0].childNodes.length)
            {
                if(grdCity.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                {   
                    mstrchkbox = grdCity.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }
            
            rowcount = 1;
            var nodecount = 0;
            
            while(rowcount < grdCity.rows.length)
            {
                if(rowcount == 1)
                {
                    while(nodecount < grdCity.rows[rowcount].cells[0].childNodes.length)
                    {
                        if(grdCity.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                        {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if(grdCity.rows[rowcount].cells.length > 1)
                {
                    if(grdCity.rows[rowcount].cells[0].childNodes[nodecount].checked == false)
                    {
                        mstrchkbox.checked = false;
                        return;
                    }
                }
                rowcount = rowcount + 1;
            }
            mstrchkbox.checked = true;

        }
        
         function ConfirmMultiselect(type)
        {
        ////debugger
//            if (MultiSelect()>=1 && (type=='Deleted'))
//            {
//                var answer = confirm ("Are you sure you want to delete City(s) ? ")
//                return answer;
//            }
            if (MultiSelect()>=1 && (type=='Activate'))
            {
                var answer = confirm ("Are you sure you want to Activate City(s)? ")
                return answer;
            }
            else if (MultiSelect()>=1 && (type=='DeActivate'))
            {
                var answer = confirm ("Are you sure you want to Deactivate City(s)? ")
                return answer;
            }
            else if (MultiSelect()==0)
            {
                alert("Please select atleast one item from the table");
                return false;
            }
               
        }
      
        function MultiSelect()
        {  // //debugger
            if(arrelemjscity == null)
                return;
            var selectcount=0;
            var selectedrow=0;
            var txtName= document.getElementById(arrelemjscity[1]);
            var txtDescription= document.getElementById(arrelemjscity[2]);
            var grdCity= document.getElementById(arrelemjscity[0]);
            var ddlCountry= document.getElementById(arrelemjscity[3]);
            var ddlState= document.getElementById(arrelemjscity[4]);
            var hfCityID= document.getElementById(arrelemjscity[6]);
            
            
            
//            if(arrcheckboxids != null)
//            {
                var arrlength = grdCity.rows.length;
                var count = 1;
                var nodecount = 0;
                while(count < arrlength)
                {
                    if(count == 1)
                    {
                        while(nodecount < grdCity.rows[count].cells[0].childNodes.length)
                        {
                            if(grdCity.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                    }
                    
                    if(grdCity.rows[count].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                
                
                    if(grdCity.rows[count].cells[0].childNodes[nodecount].checked == true)
                    {
                        selectcount=selectcount+1;
                        selectedrow=count+1;
                        if (selectcount>1)
                        {
                            var btnEdit= document.getElementById(arrelemjscity[5]);
                            btnEdit.disabled=true;
                            btnEdit.src="../../Images/edit-button-d.gif"
                            hidediv();
                            txtName.value=  "";
                            txtDescription.value= "";
                            hfCityID.value=  "";
                            return selectcount;
                       }
                    }
                    count = count + 1;
                }
                 
//            }
           
            var btnEdit= document.getElementById(arrelemjscity[5]);
            btnEdit.disabled=false;
            btnEdit.src="../../Images/edit_butt_master.gif"
            if (selectcount==1)
            {
                // showdiv();
                //  txtName.value=  grdCountry.rows[selectedrow].cells[1].innerHTML;
                // txtDescription.value=  grdCountry.rows[selectedrow].cells[2].innerHTML;
                // hfCountryID.value=  grdCountry.rows[selectedrow].cells[0].innerHTML;
            }
            else
            {
                txtName.value=  "";
                txtDescription.value= "";
                hfCityID.value=  "";
            }
            return selectcount;            
        }
        
        function EditCity()
        {
           
            if(arrelemjscity == null)
                return;
            if (MultiSelect()!=1)
            {
                alert("You can select only one item from the table to edit!");
                return false;
            }
            else
            {
                var selectcount=0;
                var selectedrow=0;
                var txtName= document.getElementById(arrelemjscity[1]);
                var txtDescription= document.getElementById(arrelemjscity[2]);
                var grdCity= document.getElementById(arrelemjscity[0]);
                var ddlCountry= document.getElementById(arrelemjscity[3]);
                var ddlState= document.getElementById(arrelemjscity[4]);
                var hfCityID= document.getElementById(arrelemjscity[6]);
                var txtCityCode= document.getElementById(arrelemjscity[7]);
                var txtZipCode=document.getElementById('<%= this.txtZip.ClientID %>')
                
                
                //var txtZipId= document.getElementById(arrelemjscity[9]);
                
                //alert(txtZipId.Value);
                
                var count = 0;
                var nodecount = 0;
         
                while(count < (grdCity.rows.length - 1))
                {
                    if(count == 0)
                    {
                        while(nodecount < grdCity.rows[count + 1].cells[0].childNodes.length)
                        {
                            if(grdCity.rows[count + 1].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                       
                    }
                    
                    if(grdCity.rows[count + 1].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                
                    if(grdCity.rows[count+1].cells[0].childNodes[nodecount].checked == true)
                    {  
                         showdiv();
                         txtName.value =  grdCity.rows[count+1].cells[1].innerHTML;
                         
                         var icount=0;
                         var descpos=0;
                         while(icount < grdCity.rows[count+1].cells[2].childNodes.length)
                         {
                            if(grdCity.rows[count+1].cells[2].childNodes[icount].tagName=="DIV")
                            {
                                descpos=icount;
                                break;
                            }
                            icount=icount + 1;
                         }
                         // For Zip code
                         if(grdCity.rows[count+1].cells[2].innerHTML != '&nbsp;')
                            txtZipCode.value =  grdCity.rows[count+1].cells[2].innerHTML;
                           
                            
                             
                         // Country
                         //alert(grdCity.rows[count+1].cells[4].innerHTML);
                         var countryname = grdCity.rows[count+1].cells[5].innerHTML;
                         
                         var countrycount = 0;
                         while(countrycount < ddlCountry.options.length)
                         {
                            if(ddlCountry.options[countrycount].innerHTML == countryname)
                            {
                                ddlCountry.options[countrycount].selected = true;
                                break;
                            }
                            countrycount = countrycount + 1;
                        }
                        if (grdCity.rows[count + 1].cells[3].childNodes[descpos].innerHTML != '&nbsp;')
                            txtDescription.value = trim(grdCity.rows[count + 1].cells[3].childNodes[descpos].innerHTML);
                        
                       
//                         oncountrychange(ddlCountry.id, ddlState.id);
//                        
//                         var statename = grdCity.rows[count+1].cells[4].innerHTML;
//                         var statecount = 0;
//                         while(statecount < ddlState.options.length)
//                         {
//                            alert(ddlState.options[statecount].innerHTML + '\n' + statename);
//                            if(ddlState.options[statecount].innerHTML == statename)
//                            {
//                                alert('selecting option' );
//                                ddlState.options[statecount].selected = true;
//                                break;
//                            }                            
//                            statecount = statecount + 1;
//                         }
                         //alert(grdCity.rows[count+1].cells[4].innerHTML);
                         //ddlCountry.options(ddlCountry.selectedIndex).innerHTML = grdCity.rows[count+1].cells[5].innerHTML;
                         //ddlState.options(ddlState.selectedIndex).innerHTML = grdCity.rows[count+1].cells[4].innerHTML;
                         hfCityID.value=count;
                         //  grdCity.rows[count+1].cells[0].innerHTML;
                         break;
                          
                     }
                    
                 count++; 
                 }
             }
             return true;
        }
        
        function oncountrychange(cntryclientid, stateclientid, isedit)
        {                      
            ////debugger
            
            var ddlcountry = document.getElementById(cntryclientid);
            var ddlstate = document.getElementById(stateclientid);
            var grdCity= document.getElementById(arrelemjscity[0]);
            var statename = '';
                       
            if(isedit == true)
            {
                var count = 1;
                var nodecount = 0;
                while(count < grdCity.rows.length)
                {
                    if(count == 1)
                    {
                        while(nodecount < grdCity.rows[count].cells[0].childNodes.length)
                        {
                            if(grdCity.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT")
                            {
                                break;
                            }
                            nodecount = nodecount + 1;
                        }
                    }
                    
                    if(grdCity.rows[count].cells.length <= 1)
                    {
                        count = count + 1;
                        continue;
                    }
                    
                    if(grdCity.rows[count].cells[0].childNodes[nodecount].checked == true)
                    {
                        statename = grdCity.rows[count].cells[4].innerHTML;
                        
                        break;
                    }
                    
                    count = count + 1;
                }
            }
            
            var chksearch = '-' + ddlcountry.options[ddlcountry.selectedIndex].value;
            ddlstate.innerHTML = '';
            
            if(arrjsstatecntryids != null)
            {
                var arrlng = 0;
                 var opt1 = document.createElement('option');
                    opt1.text = "Select State";
                    opt1.value = "0";
                    ddlstate.options.add(opt1);
                while(arrlng < arrjsstatecntryids.length)
                {
                    var res  = arrjsstatecntryids[arrlng].indexOf(chksearch);
                    if(res != '-1')
                    {
                        var opt = document.createElement('option');
                        
                        opt.text = arrjsstatenames[arrlng];
                        opt.value = arrjsstateids[arrlng];
                        
                        if(statename == opt.text)
                        {
                            opt.selected = true;
                        }
                        
                        ddlstate.options.add(opt);
                    }
                    arrlng = arrlng + 1;
                }
                
            }
        }  
        
                
        function savecity()
        {
            ////debugger
            var res = HandleValidators();
            if ( res == false)
                return false;
             __doPostBack('save',document.getElementById(arrelemjscity[4]).options[document.getElementById(arrelemjscity[4]).selectedIndex].value);
             return false;
        }      
        
//        function editcountry()
//        {
//             __doPostBack('edit',document.getElementById('ddlstate').options.children[document.getElementById('ddlstate').selectedIndex].value);
//        } 
</script>
    <script type="text/javascript" language="javascript">
//Async Call  
        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequest.failureCallback = requestFailed();
        
        var startTable="<div><table class=\"divgrid_cl\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse;\">";
        var headerTable="<tr class=\"row1\"><th scope=\"col\">City</th><th scope=\"col\">State</th><th scope=\"col\">Remove</th></tr>";
        var endTable="</table></div>";
        var Array_City=new Array();
        var Array_State=new Array();
        var Array_StateID=new Array();
        var count=0;
        
        function requestFailed()
        {
            
        }
        String.prototype.trim = function() 
        {
            a = this.replace(/^\s+/, '');
            return a.replace(/\s+$/, '');
        };
        
        function txtkeypress(evt)
        {
            return KeyPress_NumericAllowedOnly(evt);
        }
        function EmptyFields()
        {
            ////debugger
            var txtMZipCode= document.getElementById("<%=this.txtMZipCode.ClientID %>");
            var txtMCity=document.getElementById("<%=this.txtMCity.ClientID %>");
            var ddlMState=document.getElementById("<%=this.ddlMState.ClientID %>");
            var divZipDetails=document.getElementById('divZipDetails');
            var divGrdAddMultipleCity=document.getElementById("divGrdAddMultipleCity");
            var divBdr=document.getElementById("divBdr");
            var hfAvailabilityChecked=document.getElementById("<%=this.hfAvailabilityChecked.ClientID %>");
            var hfZipAvailable=document.getElementById("<%=this.hfZipAvailable.ClientID %>");
            
            txtMZipCode.value='';
            txtMCity.value = '';
            ddlMState.selectedIndex=0;
            divZipDetails.innerHTML = "";
            divGrdAddMultipleCity.innerHTML="";
            divBdr.style.display="none";
            hfAvailabilityChecked.value=0;
            hfZipAvailable.value=0;
            Array_City=new Array();
            Array_State=new Array();
            Array_StateID=new Array();
            count=0;
            
        }
        function CheckZipCodeAvailability()
        {//debugger
            var txtMZipCode=document.getElementById("<%=this.txtMZipCode.ClientID %>");
            if(txtMZipCode.value.trim()=="")
            {
                alert("Please enter ZipCode.");
                return false;
            }
            postRequest.url ="AjaxServer.aspx?zipcode=" + txtMZipCode.value + "&mode=2";
	        postRequest.successCallback = setZipDetails;
	        postRequest.post("");
        	 
	        return false;
        }
        
        function setZipDetails(httpRequest)
        {//debugger
            var result= httpRequest.responseText;
            var divZipDetails=document.getElementById('divZipDetails');
            divZipDetails.innerHTML = httpRequest.responseText;
            var hfAvailabilityChecked=document.getElementById("<%=this.hfAvailabilityChecked.ClientID %>");
            hfAvailabilityChecked.value=1;
            
            var spZipAvail=document.getElementById("spZipAvail");
            var hfZipAvailable=document.getElementById("<%=this.hfZipAvailable.ClientID %>");
            var spZipNotAvail=document.getElementById("spZipNotAvail");
            if(spZipAvail.innerHTML=="Zip Available")
            {
                hfZipAvailable.value=1;
                divZipDetails.style.display="block";
                spZipNotAvail.style.display="none";
            }
            else
            {
                hfZipAvailable.value=0;
                divZipDetails.style.display="none";
                spZipNotAvail.style.display="block";
            }
        }
        
        function AddCity()
        {
            var txtMCity=document.getElementById("<%=this.txtMCity.ClientID %>");
            if(txtMCity.value.trim()=="")
            {
                alert("Please enter city to add.");
                return false;
            }
            var ddlMState=document.getElementById("<%=this.ddlMState.ClientID %>");
            if(ddlMState.selectedIndex==0)
            {
                alert("Please select a State.");
                return false;
            }
            
            //checking for duplicate entry
            for(icount=0; icount<count; icount++)
            {
                if(Array_City[icount]==txtMCity.value && Array_State[icount]==ddlMState.options[ddlMState.selectedIndex].text)
                {
                    alert("This city has been already added");
                    return false;
                }
            }
            
            //Add city & state
            Array_City[count]=txtMCity.value;
            Array_State[count]=ddlMState.options[ddlMState.selectedIndex].text;
            Array_StateID[count]=ddlMState.value;
            count++;
            
            //display records
            var divGrdAddMultipleCity=document.getElementById("divGrdAddMultipleCity");
            var divBdr=document.getElementById("divBdr");
            if(count>2)
            {
                divGrdAddMultipleCity.style.height="80px";
                divGrdAddMultipleCity.style.overflowY="scroll";
            }
            else
            {
                divGrdAddMultipleCity.style.overflowY="hidden";
            }
            var contentTable="";
            for(icount=0; icount<count; icount++)
            {
                var row=icount%2;
                if(row==0)
                {
                    contentTable= contentTable + "<tr class=\"row2\"><td>" + Array_City[icount] + "</td><td>" + Array_State[icount] + "</td><td><img src='/App/Images/delete.gif' title='Delete' onclick='deleteCity(\"" + Array_City[icount] + "\",\"" + Array_State[icount] + "\");' /></td></tr>";
                }
                else
                {
                    contentTable= contentTable + "<tr class=\"row3\"><td>" + Array_City[icount] + "</td><td>" + Array_State[icount] + "</td><td><img src='/App/Images/delete.gif' title='Delete' onclick='deleteCity(\"" + Array_City[icount] + "\",\"" + Array_State[icount] + "\");' /></td></tr>";
                }
            }
            divGrdAddMultipleCity.innerHTML=startTable + headerTable + contentTable + endTable;
            divBdr.style.display="block";
        }
        
        function deleteCity(cityName,stateName)
        {
            var check=confirm("Are you sure to remove this City from the list?");
            if(check==false)
            {
                return false;
            }
            
            //delete a record
            var tempArray_City=new Array();
            var tempArray_State=new Array();
            var tempArray_StateID=new Array();
            var jcount=0;
            for(icount=0; icount<count; icount++)
            {
                if(Array_City[icount]==cityName && Array_State[icount]==stateName)
                    continue;
                tempArray_City[jcount]=Array_City[icount];
                tempArray_State[jcount]=Array_State[icount];
                tempArray_StateID[jcount]=Array_StateID[icount];
                jcount++;
            }
            Array_City=tempArray_City;
            Array_State=tempArray_State;
            Array_StateID=tempArray_StateID;
            
            //display records
            var divGrdAddMultipleCity=document.getElementById("divGrdAddMultipleCity");
            var divBdr=document.getElementById("divBdr");
            if(Array_City.length>0)
            {
                if(count>2)
                {
                    divGrdAddMultipleCity.style.height="80px";
                    divGrdAddMultipleCity.style.overflowY="scroll";
                }
                else
                {
                    divGrdAddMultipleCity.style.overflowY="hidden";
                }
                var contentTable="";
                for(icount=0; icount<jcount; icount++)
                {
                    var row=icount%2;
                    if(row==0)
                    {
                        contentTable= contentTable + "<tr class=\"row2\"><td>" + Array_City[icount] + "</td><td>" + Array_State[icount] + "</td><td><img src='/App/Images/delete.gif' title='Delete' onclick='deleteCity(\"" + Array_City[icount] + "\",\"" + Array_State[icount] + "\");' /></td></tr>";
                    }
                    else
                    {
                        contentTable= contentTable + "<tr class=\"row3\"><td>" + Array_City[icount] + "</td><td>" + Array_State[icount] + "</td><td><img src='/App/Images/delete.gif' title='Delete' onclick='deleteCity(\"" + Array_City[icount] + "\",\"" + Array_State[icount] + "\");' /></td></tr>";
                    }
                }
                divGrdAddMultipleCity.innerHTML=startTable + headerTable + contentTable + endTable;
                divBdr.style.display="block";
            }
            else
            {
                 divGrdAddMultipleCity.innerHTML="";
                 divBdr.style.display="none";
            }
            tempArray_City=null;
            tempArray_State=null;
            tempArray_StateID=null;
            count=jcount;
            return false;
        }
        
        function saveValidation()
        {
            var txtMZipCode= document.getElementById("<%=this.txtMZipCode.ClientID %>");
            if(txtMZipCode.value.trim()=="")
            {
                alert("Please enter zipcode.");
                return false;
            }
            if(count==0)
            {
                alert("Please add city.");
                return false;
            }
            var hfAvailabilityChecked=document.getElementById("<%=this.hfAvailabilityChecked.ClientID %>");
            var hfZipAvailable=document.getElementById("<%=this.hfZipAvailable.ClientID %>");
            if(hfAvailabilityChecked.value==0)
            {
                alert("Please check ZipCode availability.");
                return false;
            }
            if(hfZipAvailable.value==0)
            {
                alert("ZipCode you entered is not availabe.");
                return false;
            }
            var hfCityName=document.getElementById("<%=this.hfCityName.ClientID %>");
            var hfStateID=document.getElementById("<%=this.hfStateID.ClientID %>");
            hfCityName.value="";
            hfStateID.value="";
            for(icount=0; icount<count; icount++)
            {
                hfCityName.value = hfCityName.value + Array_City[icount] + ",";
                hfStateID.value = hfStateID.value + Array_StateID[icount] + ",";                
            }
            return true;
        }
    </script>

    <div class="mainbody_outer" style="height: 547px">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">City</span> 
                    <span class="headingright_default">
                        <asp:LinkButton ID="addNewCity" runat="server" Text="+ Add New City" OnClientClick="EmptyBoxes();" />&nbsp;&nbsp;|&nbsp;
                        (<asp:LinkButton ID="addMultipleCity" runat="server" Text=" Against given Zip " OnClientClick="EmptyFields();"></asp:LinkButton>)
                    </span>
                    
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" alt="" /></p>
                <p class="graylinefull_common">
                    <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>
            <div class="divbuttonsrow">
                <div class="pagealerttxtCNT" id="errordiv" runat="server">
                </div>
                <div class="master_buttons_row">
                    <div class="master_buttons_con">
                        <asp:ImageButton runat="server" ID="btnActivate" ImageUrl="../../Images/activate_butt_master.gif"
                            OnClientClick="return ConfirmMultiselect('Activate')" OnClick="btnActivate_Click" />&nbsp;</div>
                    <div class="master_buttons_con">
                        <asp:ImageButton runat="server" ID="btnDeActivate" ImageUrl="../../Images/deactivate_butt_master.gif"
                            OnClientClick="return ConfirmMultiselect('DeActivate')" OnClick="btnDeActivate_Click" />&nbsp;</div>
                    <div class="master_buttons_con">
                        <asp:ImageButton runat="server" ID="btnEdit" ImageUrl="../../Images/edit_butt_master.gif"
                            OnClientClick="return EditCity()" OnClick="btnEdit_Click" />&nbsp;</div>
                    <div class="master_buttons_con">
                        <a href="javascript:showdiv()"></a>&nbsp;</div>
                </div>
            </div>
            <div class="main_area_bdrnone">
                <asp:GridView runat="server" ID="grdCity" AllowSorting="true" AutoGenerateColumns="false"
                    DataKeyNames="CityID" CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdCity_RowDataBound"
                    EnableSortingAndPagingCallbacks="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdCity_PageIndexChanging"
                    OnSorting="grdCity_Sorting">
                    <Columns>
                        <asp:BoundField DataField="" Visible="false"></asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" id="chkMaster1" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input type="checkbox" id="chkRowChild" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ZipId" Visible="false" HeaderText="ZipId"></asp:BoundField>
                        <asp:BoundField DataField="CityID" Visible="false" HeaderText="CityID"></asp:BoundField>
                        <asp:BoundField DataField="name" HeaderText="City" SortExpression="name"></asp:BoundField>
                        <asp:BoundField DataField="ZipCode" Visible="true" HeaderText="Zipcode"></asp:BoundField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <div title='<%# DataBinder.Eval(Container.DataItem, "description")%>' class="divitemdesccity">
                                    <%# DataBinder.Eval(Container.DataItem, "description")%>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- 
			                <asp:BoundField DataField="description" HeaderText="Description">
			                    <HeaderStyle CssClass="headerdesccity" />
			                    <ItemStyle CssClass="itemdesccity" />
			                </asp:BoundField>--%>
                        <asp:BoundField DataField="State" HeaderText="State" SortExpression="State"></asp:BoundField>
                        <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country">
                        </asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="Status"></asp:BoundField>
                    </Columns>
                    <RowStyle CssClass="row2" />
                    <HeaderStyle CssClass="row1" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:LinkButton runat="server" ID="lnkhidden"></asp:LinkButton>
    <asp:Panel ID="Panel1" runat="server">    
    <div class="wrapper_pop">
            <div class="wrapperin_pop">
                <div class="innermain_pop">
                    <p class="innermain_pop">
                        <span class="orngheadtxt_heading" runat="server" id="sppopuptitle">Edit City</span>
                        <span style="float: right">
                            <asp:ImageButton runat="server" ID="ibtnclosesymbol" ImageUrl="~/App/Images/close-button-symbol.gif" />
                        </span>
                    </p>
                      <p class="innermain_pop" style="border-top: solid 1px #ccc;">
                    <span style="float:right; margin-top:3px;">
                       <span class="graysmalltxt_default"><span class="reqiredmark"><sup>*</sup> </span>Mandatory Fields</span>
                       </span>
                    </p>
                    <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletextsmallbld_default" style="margin-right: 10px;">City:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                              <asp:TextBox runat="server" ID="txtName" CssClass="inputf_def" Width="235px"></asp:TextBox>
                        </span>
                      </span>
                    </p>
                     <p class="innermain_pop">
                    <span style="float:left; margin-top:10px;">
                        <span class="titletextsmallbld_default" style="margin-right: 10px;">Zip:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                               <asp:TextBox runat="server" ID="txtZip" CssClass="inputf_def" Width="235px"></asp:TextBox>
                        </span>
                      </span>
                    </p>
                    <p class="innermain_pop" style="margin-top:5px;">
                        <span class="titletextsmallbld_default" style="margin-right: 10px;">Country: <span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                            <asp:DropDownList ID="ddlcountry" CssClass="inputf_def" runat="server" Width="240px">
                    </asp:DropDownList>
                          </span>
                    </p>
                     <p class="innermain_pop" style="margin-top:5px;">
                        <span class="titletextsmallbld_default" style="margin-right: 10px;"> State:<span class="reqiredmark"><sup>*</sup> </span></span>
                         <span class="inputfldnowidth_default">
                         <asp:DropDownList ID="ddlstate" CssClass="inputf_def" runat="server" Width="240px">
                    </asp:DropDownList>
                        </span>
                    </p>
                     <p class="innermain_pop" style="margin-top:5px;">
                        <span class="titletextsmallbld_default" style="margin-right: 10px;"> Description:</span>
                         <span class="inputfldnowidth_default">
                            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="3" CssClass="inputf_def"
                        Width="235px"></asp:TextBox>
                        </span>
                    </p>
                   <asp:HiddenField ID="hfCityID" runat="server" Value="" />
                    <asp:HiddenField ID="hfZipFlag" runat="server" Value="" />
                    <p class="innermain_pop" style="margin-top:5px;">
                    <span class="buttoncon_default">
                       <asp:ImageButton runat="server" ID="btnSave" ImageUrl="../../Images/save-button.gif"
                        OnClick="btnSave_Click" />
                    </span>
                     <span class="buttoncon_default">
                       <asp:ImageButton runat="server" ID="btnCancel" ImageUrl="../../Images/cancel-button.gif"
                        Width="57" Height="25" OnClientClick="$find('mdlPopup').hide(); return false;" /> 
                     </span>
                    </p>
                    
                </div>
            </div>
        </div>
   </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="addNewCity"
        PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="ibtnclosesymbol"
        BehaviorID="mdlPopup" />
    <asp:Panel ID="pnlAddMultipleCity" runat="server">
        <div id="divPopUpAddMultipleCity">
        <div class="wrapper_pop_l">
            <div class="wrapperin_pop_l">
                <div class="innermain_pop_l">
                    <p class="innermain_pop_l">
                        <span class="orngheadtxt_heading">Add Multiple Cities</span>
                        <span style="float: right">
                            <asp:ImageButton runat="server" ID="iBtnCloseMultipleCity" ImageUrl="~/App/Images/close-button-symbol.gif" />
                        </span>
                    </p>
                      <p class="innermain_pop_l" style="border-top: solid 1px #ccc; padding-top:5px;">
                       <span class="orngbold12_default" style="float:left; color:Red; display:none;" id="spZipNotAvail">Zip Not Available</span>
                    <span style="float:right; margin-top:3px;">
                       <span class="graysmalltxt_default"><span class="reqiredmark"><sup>*</sup> </span>Mandatory Fields</span>
                       </span>
                    </p>
                    <p class="innermain_pop_l" style="margin-top:5px">
                        <span class="titletextsmallbld_default"> Zip:<span class="reqiredmark"><sup>*</sup> </span></span>
                        <span class="inputfldnowidth_default">
                             <asp:TextBox runat="server" ID="txtMZipCode" CssClass="inputf_def" Width="215px"></asp:TextBox>
                        </span>
                        <span style="padding-left:5px; padding-top:4px; float:left; cursor:pointer;"><img src="/App/Images/headerfname_arrow.gif" title="Check Availability" onclick="return CheckZipCodeAvailability();" /></span>
                    </p>
                    <div id="divZipDetails">
                
                    </div>
                     <p class="innermain_pop_l" style="margin-top:10px;">
                       <span class="titletextsmallbld_default"> City:<span class="reqiredmark"><sup>*</sup> </span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox runat="server" ID="txtMCity" CssClass="inputf_def" Width="215px"></asp:TextBox>
                    </span>
                    </p>
                    <p class="innermain_pop_l" style="margin-top:10px;">
                       <span class="titletextsmallbld_default">State:<span class="reqiredmark"><sup>*</sup> </span></span>
                    <span class="inputfldnowidth_default">
                        <asp:DropDownList ID="ddlMState" CssClass="inputf_def" runat="server" Width="220px">
                            <asp:ListItem Text="Select State" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </span>
                    <span style="padding-left:5px; float:left; cursor:pointer;"><img src="/App/Images/Plus-signbox.gif" title="Add City" onclick="return AddCity();" /></span>
                    </p>
                    <div class="rowbdr" id="divBdr" style="display:none;">
                    <div class="innermain_pop_2" style="overflow-y:auto; overflow-x:hidden;" id="divGrdAddMultipleCity">
                    <asp:GridView runat="server" ID="grdAddMultipleCity" AutoGenerateColumns="False" CssClass="divgrid_cl"
                        GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="City" HeaderText="City" />
                            <asp:BoundField DataField="State" HeaderText="State" /> 
                            <asp:TemplateField HeaderText="Remove">
                                <ItemTemplate>
                                    <img src='/App/Images/delete.gif' alt='Delete' />
                                </ItemTemplate>
                            </asp:TemplateField>                         
                        </Columns>
                        <RowStyle CssClass="row2" />
                        <HeaderStyle CssClass="row1" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView> 
                    </div>
                </div>
                    <p class="innermain_pop_l" style="margin-top:5px;">
                    <span class="buttoncon_default">
                       <asp:ImageButton runat="server" ID="iBtnSaveMultipleCity" ImageUrl="../../Images/save-button.gif" OnClientClick="return saveValidation();" onclick="iBtnSaveMultipleCity_Click" />
                    </span>
                     <span class="buttoncon_default">
                        <asp:ImageButton runat="server" ID="iBtnCancelMultipleCity" ImageUrl="../../Images/cancel-button.gif"
                    Width="57" Height="25" OnClientClick="$find('mdlPopupMultipleCity').hide(); return false;" />
                     </span>
                    </p>
                    
                </div>
            </div>
        </div>
      
        </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="addMultipleCity"
        PopupControlID="pnlAddMultipleCity" BackgroundCssClass="modalBackground" CancelControlID="iBtnCloseMultipleCity"
        BehaviorID="mdlPopupMultipleCity"  />
    <asp:HiddenField ID="hfAvailabilityChecked" runat="server" Value="0" />
    <asp:HiddenField ID="hfZipAvailable" runat="server" Value="0" />
    <asp:HiddenField ID="hfCityName" runat="server" Value="" />
    <asp:HiddenField ID="hfStateID" runat="server" Value="" />
</asp:Content>
