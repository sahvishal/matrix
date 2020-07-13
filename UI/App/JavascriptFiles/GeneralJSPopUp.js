/***********************************************
    * Image w/ description tooltipPD- By Dynamic Web Coding (www.dyn-web.com)
    * Copyright 2002-2007 by Sharon Paine
    * Visit Dynamic Drive at http://www.dynamicdrive.com/ for full source code
    ***********************************************/

    /* IMPORTANT: Put script after tooltipPD div or 
	    put tooltipPD div just before </BODY>. */

    

    var dom = (document.getElementById) ? true : false;
    var ns5 = (!document.all && dom || window.opera) ? true: false;
    var ie5 = ((navigator.userAgent.indexOf("MSIE")>-1) && dom) ? true : false;
    var ie4 = (document.all && !dom) ? true : false;
    var nodyn = (!ns5 && !ie4 && !ie5 && !dom) ? true : false;
    
    // avoid error of passing event object in older browsers
    if (nodyn) { event = "nope" }
    
    var divId = '';

    ///////////////////////  CUSTOMIZE HERE   ////////////////////
    // settings for tooltip 
    // Do you want tip to move when mouse moves over link?
    var tipFollowMouse= true;	
    // Be sure to set tipWidth wide enough for widest image
    var tipWidth= 360;
    var offX= 20;	// how far from mouse to show tip
    var offY= 12; 
    var tipFontFamily= " arial, helvetica, sans-serif";
    var tipFontSize= "12px";
    // set default text color and background color for tooltip here
    // individual tooltips can have their own (set in messages arrays)
    // but don't have to
    var tipFontColor= "#000000";
    var tipBgColor= "#fff"; 
    var tipBorderColor= "#5997B9";
    var tipBorderWidth= 2;
    var tipBorderStyle= "solid";
    var tipPadding= 8;
    
    var ContentPosition = { Right : 0 , Left : 1, Center : 2}; 
    var screenPosition = '';

    // to layout image and text, 2-row table, image centered in top cell
    // these go in var tip in doTooltip function
    var contentPopUp = '';
    
    function SetVariables(content, width, idText, contentPos)
    {
        
        screenPosition = contentPos;
        contentPopUp = content;
        tipWidth = width;
        divId = idText;
        
    }
    ////////////////////////////////////////////////////////////
    //  initTip	- initialization for tooltip.
    //		Global variables for tooltip. 
    //		Set styles
    //		Set up mousemove capture if tipFollowMouse set true.
    ////////////////////////////////////////////////////////////
    var tooltip, tipcss;
    function initTip() 
    {
   
	    if (nodyn) return;
	    tooltip = (ie4)? document.all[divId]: (ie5||ns5)? document.getElementById(divId): null;
	    tipcss = tooltip.style;
	    if (ie4||ie5||ns5) 
	    {	// ns4 would lose all this on rewrites
		    tipcss.width = tipWidth+"px";
		    tipcss.fontFamily = tipFontFamily;
		    tipcss.fontSize = tipFontSize;
		    tipcss.color = tipFontColor;
		    tipcss.backgroundColor = tipBgColor;
		    tipcss.borderColor = tipBorderColor;
		    tipcss.borderWidth = tipBorderWidth+"px";
		    tipcss.padding = tipPadding+"px";
		    tipcss.borderStyle = tipBorderStyle;
	    }
	    if (tooltip&&tipFollowMouse) {
		    document.onmousemove = trackMouse;
	    }
    }

    /////////////////////////////////////////////////
    //  doTooltip function
    //			Assembles content for tooltip and writes 
    //			it to tipDiv
    /////////////////////////////////////////////////
    var t1,t2;	// for setTimeouts
    var tipOn = false;	// check if over tooltip link
    function doTooltip(evt) 
    {
        initTip();
        
	    if (!tooltip) return;
	    if (t1) clearTimeout(t1);	if (t2) clearTimeout(t2);
	    tipOn = true;
	    if (ie4||ie5||ns5) {
		    var tip = contentPopUp; 
		    tipcss.backgroundColor = "#fff";
	 	    tooltip.innerHTML = tip;
	    }
	    if (!tipFollowMouse) positionTip(evt);
	    else t1=setTimeout("tipcss.visibility='visible'; tipcss.display='block';",100);
	    
    }

    var mouseX, mouseY;
    function trackMouse(evt) 
    {
	    standardbody=(document.compatMode=="CSS1Compat")? document.documentElement : document.body //create reference to common "body" across doctypes
	    mouseX = (ns5)? evt.pageX: window.event.clientX + standardbody.scrollLeft;
	    mouseY = (ns5)? evt.pageY: window.event.clientY + standardbody.scrollTop;
	    if (tipOn) positionTip(evt);
    }

    /////////////////////////////////////////////////////////////
    //  positionTip function
    //		If tipFollowMouse set false, so trackMouse function
    //		not being used, get position of mouseover event.
    //		Calculations use mouseover event position, 
    //		offset amounts and tooltip width to position
    //		tooltip within window.
    /////////////////////////////////////////////////////////////
    function positionTip(evt) 
    {
    //debugger
    
        var screenwidth = "";
        var screenheight = "";
        
        var Imgtop, ImgLeft;
        var screenleft, screentop;
    
        screenwidth = document.body.offsetWidth;
        screentop = document.body.parentNode.scrollTop;
        
        if(screenPosition == ContentPosition.Center)
        {
            ImgLeft = (Number(screenwidth) - tipWidth) / 2;
            Imgtop = screentop + 100; 
        }
        else if(screenPosition == ContentPosition.Right)
        {
            ImgLeft = Number(screenwidth) - tipWidth - 25;
            Imgtop = screentop + 5; 
        }
        
        tipcss.left = ImgLeft + "px";
        tipcss.top = Imgtop + "px";

	    if (!tipFollowMouse) t1=setTimeout("tipcss.visibility='visible'; tipcss.display='block';",100);
    }
    
    function hideTip() 
    {
	    if (!tooltip) return;
	    t2=setTimeout("tipcss.visibility='hidden'; tipcss.display='none'; ",100);
	    tipOn = false;
    }
    
    
    function hideTipImageOutOfScope(evt) {
        if (!tooltip) return;

        var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body
        var mouseX = (ns5) ? evt.pageX : event.clientX + standardbody.scrollLeft;
        var mouseY = (ns5) ? evt.pageY : event.clientY + standardbody.scrollTop;

        var topY, leftX, bottomY, rightX;
        topY = document.getElementById(divId).offsetTop;
        leftX = document.getElementById(divId).offsetLeft;
        bottomY = document.getElementById(divId).offsetTop + document.getElementById(divId).clientHeight;
        rightX = document.getElementById(divId).offsetLeft + document.getElementById(divId).clientWidth;

        if (topY < mouseY && leftX < mouseX && bottomY > mouseY && rightX > mouseX) {
            return;
        }

        t2 = setTimeout("tipcss.visibility='hidden'; tipcss.display='none'; ", 100);
        tipOn = false;
    }


