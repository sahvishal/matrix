// [dFilter] - A Numerical Input Mask for JavaScript
// Written By Dwayne Forehand - March 27th, 2003
// Please reuse & redistribute while keeping this notice.
// Way to use
// E.g. http://javascript.internet.com/forms/dfilter.html
// OR Use Like This:
//><input value="" type="text" onKeyDown="javascript:return dFilter (event.keyCode, this, '(###) ###-####');" style="font-family:verdana;font-size:10pt;width:110px;">


var dFilterStep;

function dFilterStrip (dFilterTemp, dFilterMask)
{
    dFilterMask = replace(dFilterMask,'#','');
    for (dFilterStep = 0; dFilterStep < dFilterMask.length++; dFilterStep++)
	{
	    dFilterTemp = replace(dFilterTemp,dFilterMask.substring(dFilterStep,dFilterStep+1),'');
	}
	return dFilterTemp;
}

function dFilter_AutoFill(textbox)
{
    var textval = textbox.value;
    if(textval.length < 1) return;
    
    var ampmunit = textval.substring(textval.length - 2, textval.length);
    var hrunit = '';
    var minunit = '';
    var substr;
    var bolhrunitplacing = true;
    
    for (dFilterStep = 0; dFilterStep < textval.length; dFilterStep++)
    {
        substr = '';
        substr = textval.substring(dFilterStep, dFilterStep + 1);
        
        if(substr == 'A' || substr == 'a' || substr == 'P'|| substr == 'p')
            break;
            
        if(substr == ' ') break;        
        
        if(substr == ':')
        {
            bolhrunitplacing = false;
            continue;
        }
        
        if(bolhrunitplacing) hrunit = hrunit + substr;
        else minunit = minunit + substr;
    }
    
    if(hrunit.length < 1 && minunit.length < 1)  
    {
        textbox.value = "";
        return;
    }
    
    if(hrunit.length < 1) hrunit = '00';
    else if(hrunit.length < 2) hrunit = '0' + hrunit;
    
    if(minunit.length < 1) minunit = '00';
    else if(minunit.length < 2) minunit = '0' + minunit;
    
    textbox.value = hrunit + ':' + minunit + ' ' + ampmunit;
    
}

function dFilterMax (dFilterMask)
{
	dFilterTemp = dFilterMask;
    for (dFilterStep = 0; dFilterStep < (dFilterMask.length+1); dFilterStep++)
	{
 		if (dFilterMask.charAt(dFilterStep)!='#')
		{
            dFilterTemp = replace(dFilterTemp,dFilterMask.charAt(dFilterStep),'');
		}
	}
	return dFilterTemp.length;
}

function dFilter (key, textbox, dFilterMask)
{
        //debugger
		dFilterNum = dFilterStrip(textbox.value, dFilterMask);
		
		if (key==9)
		{
		    return true;
		}
		else if (key==8&&dFilterNum.length!=0)
		{
		    dFilterNum = dFilterNum.substring(0,dFilterNum.length-1);
		}
 	    else if ( ((key>47&&key<58)||(key>95&&key<106)) && dFilterNum.length<dFilterMax(dFilterMask) )
		{
		    if(key>95&&key<106)
		        key=key - 48;
            dFilterNum=dFilterNum+String.fromCharCode(key);
		}

		var dFilterFinal='';
        for (dFilterStep = 0; dFilterStep < dFilterMask.length; dFilterStep++)
		{
            if (dFilterMask.charAt(dFilterStep)=='#')
			{
			    if (dFilterNum.length!=0)
			    {
		            dFilterFinal = dFilterFinal + dFilterNum.charAt(0);
			        dFilterNum = dFilterNum.substring(1,dFilterNum.length);
			    }
		        else
		        {
		            dFilterFinal = dFilterFinal + "";
		        }
			}
	 		else if (dFilterMask.charAt(dFilterStep)!='#')
			{
			    dFilterFinal = dFilterFinal + dFilterMask.charAt(dFilterStep); 			
			}
//		    dFilterTemp = replace(dFilterTemp,dFilterMask.substring(dFilterStep,dFilterStep+1),'');
            
		}

		if (key==80)
		{
			dFilterFinal = replace(dFilterFinal,'AM','PM');
		}
		else if (key==65)
		{
			dFilterFinal = replace(dFilterFinal,'PM','AM');
		}
		
		// *** Begin Changes Made to Put Only 12H time format
		var dFilterFinalTemp;
		var dFilterFinalTemp=dFilterFinal.split(":");
		
		dFilterFinalTemp[1]=replace(dFilterFinalTemp[1],'AM','');
		dFilterFinalTemp[1]=replace(dFilterFinalTemp[1],'PM','');
				
		if (dFilterFinalTemp[0] > 12)
		{
		    dFilter_AutoFillHour(textbox);
		    return false;		                    
		}
        	
		if(dFilterFinalTemp[1] > 59)
		{
		    dFilter_AutoFillHour(textbox);
		    return false;
		}
		
		textbox.value = dFilterFinal;
		if (dFilterFinalTemp[0].length ==1 && dFilterFinalTemp[0] >= 1)
        {
            if (key >= 50 && key <=57 && dFilterFinalTemp[0]!=1)
            {
                dFilter_AutoFillHour(textbox);
                return false;                
            }
        }
    // *** End Changes Made to Put Only 12H time format
    return false;
}

function dFilter_AutoFillHour(textbox)
{
    var textval = textbox.value;
    if(textval.length < 1) return;
    
    var ampmunit = textval.substring(textval.length - 2, textval.length);
    var hrunit = '';
    var minunit = '';
    var substr;
    var bolhrunitplacing = true;
    
    for (dFilterStep = 0; dFilterStep < textval.length; dFilterStep++)
    {
        substr = '';
        substr = textval.substring(dFilterStep, dFilterStep + 1);
        
        if(substr == 'A' || substr == 'a' || substr == 'P'|| substr == 'p')
            break;
            
        if(substr == ' ') break;        
        
        if(substr == ':')
        {
            bolhrunitplacing = false;
            continue;
        }
        
        if(bolhrunitplacing) hrunit = hrunit + substr;
        else minunit = minunit + substr;
    }
    
    if(hrunit.length < 1 && minunit.length < 1)  
    {
        textbox.value = "";
        return;
    }
    
    if(hrunit.length < 1) hrunit = '00';
    else if(hrunit.length < 2) hrunit = '0' + hrunit;
    
//    if(minunit.length < 1) minunit = '00';
//    else if(minunit.length < 2) minunit = '0' + minunit;
      if(minunit.length == 2 && minunit > 59) minunit = '00' ;
    
    textbox.value = hrunit + ':' + minunit + ' ' + ampmunit;
    
}

function replace(fullString,text,by) {
// Replaces text with by in string
    var strLength = fullString.length, txtLength = text.length;
    if ((strLength == 0) || (txtLength == 0)) return fullString;

    var i = fullString.indexOf(text);
    if ((!i) && (text != fullString.substring(0,txtLength))) return fullString;
    if (i == -1) return fullString;

    var newstr = fullString.substring(0,i) + by;

    if (i+txtLength < strLength)
        newstr += replace(fullString.substring(i+txtLength,strLength),text,by);

    return newstr;
}
