// JScript File

/*
Space for Comments
*/
function Grid_MasterCheckBoxClick(grdControl_ClientID)
{
//debugger
    var grdControl = document.getElementById(grdControl_ClientID);
    var rowcount = 0;
    var mstrchkbox;
            
    while(rowcount < grdControl.rows[0].cells[0].childNodes.length)
    {
        if(grdControl.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
        {   
            mstrchkbox = grdControl.rows[0].cells[0].childNodes[rowcount];
            break;
        }
        rowcount = rowcount + 1;
    }
            
            
    rowcount = 1;
    var nodecount = 0;
            
    while(rowcount < grdControl.rows.length)
    {
        if(rowcount == 1)
        {
            while(nodecount < grdControl.rows[rowcount].cells[0].childNodes.length)
            {
                if(grdControl.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
                {
                    break;
                }
                nodecount = nodecount + 1;
            }
        }
        if(grdControl.rows[rowcount].cells.length > 1)
            grdControl.rows[rowcount].cells[0].childNodes[nodecount].checked = mstrchkbox.checked;      
                            
        rowcount = rowcount + 1;
    }
}

/*
Space for Comments
*/
function Grid_ChildCheckBoxClick(grdControl_ClientID)
{
    var grdControl = document.getElementById(grdControl_ClientID);
	var rowcount = 0;
	var mstrchkbox;
			
	while(rowcount<grdControl.rows[0].cells[0].childNodes.length)
    {
	    if(grdControl.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
		{   
		    mstrchkbox = grdControl.rows[0].cells[0].childNodes[rowcount];
			break;
        }
		rowcount = rowcount + 1;
    }
			
	rowcount = 1;
	var nodecount = 0;
			
	while(rowcount < grdControl.rows.length)
	{
	    if(rowcount == 1)
		{
		    while(nodecount < grdControl.rows[rowcount].cells[0].childNodes.length)
			{
			    if(grdControl.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT")
				{
				    break;
                }
				nodecount = nodecount + 1;
            }
        }
		if(grdControl.rows[rowcount].cells.length > 1)
		{
		    if(grdControl.rows[rowcount].cells[0].childNodes[nodecount].checked == false && !grdControl.rows[rowcount].cells[0].childNodes[nodecount].disabled)
			{
			    mstrchkbox.checked = false;
				return;
            }
        }
		rowcount = rowcount + 1;
    }
	mstrchkbox.checked = true;
}

/*
Space for Comments
*/
function Grid_MultiSelect(grdControl_ClientID, objelement_rowindex)
{
    var grdControl = document.getElementById(grdControl_ClientID);
    if(grdControl == null)
        return 0;
    if(grdControl.rows == null)
        return 0;
    var arrlength = grdControl.rows.length;
    var count = 1;
    var nodecount = 0;
    var selectcount=0;
    var selectedrow=0;
    while(count < arrlength)
    {
        if(count == 1)
        {
            while(nodecount < grdControl.rows[count].cells[0].childNodes.length)
            {
                if(grdControl.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT")
                {
                    break;
                }
                nodecount = nodecount + 1;
            }
        }
                    
        if(grdControl.rows[count].cells.length <= 1)
        {
            count = count + 1;
            continue;
        }
                
                
        if(grdControl.rows[count].cells[0].childNodes[nodecount].checked == true)
        {
            objelement_rowindex.value = count - 1;
            selectcount = selectcount+1;
            selectedrow = count+1;
            if (selectcount>1)
            {
                objelement_rowindex.value = "0";
                return selectcount;
            }
        }
        count = count + 1;
    }
    return selectcount;
}

function Grid_DisableEditbutton(btnEdit_ClientID)
{
    var btnEdit = document.getElementById(btnEdit_ClientID);
    btnEdit.disabled = 'disabled';
    btnEdit.src="/App/Images/edit-button-d.gif";
}

function Grid_EnableEditbutton(btnEdit_ClientID)
{
    var btnEdit = document.getElementById(btnEdit_ClientID);
    btnEdit.disabled = '';
    btnEdit.src="/App/Images/edit_butt_master.gif";
}

/*
Grid without header
*/
function Grid_MultiSelect_noheader(grdControl_ClientID, objelement_rowindex)
{
    var grdControl = document.getElementById(grdControl_ClientID);
    if(grdControl == null)
        return 0;
    if(grdControl.rows == null)
        return 0;
    var arrlength = grdControl.rows.length;
    var count = 0;
    var nodecount = 0;
    var selectcount=0;
    var selectedrow=0;
    while(count < arrlength)
    {
        if(count == 1)
        {
            while(nodecount < grdControl.rows[count].cells[0].childNodes.length)
            {
                if(grdControl.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT")
                {
                    break;
                }
                nodecount = nodecount + 1;
            }
        }
                    
        if(grdControl.rows[count].cells.length <= 1)
        {
            count = count + 1;
            continue;
        }
                
                
        if(grdControl.rows[count].cells[0].childNodes[nodecount].checked == true)
        {
            objelement_rowindex.value = count - 1;
            selectcount = selectcount+1;
            selectedrow = count+1;
            if (selectcount>1)
            {
                objelement_rowindex.value = "0";
                return selectcount;
            }
        }
        count = count + 1;
    }
    return selectcount;
}