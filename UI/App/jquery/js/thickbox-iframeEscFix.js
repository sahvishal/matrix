document.onkeyup=function(e)
{
    if(e==null)
    {keycode=event.keyCode;}
    else
    {keycode=e.which;}
    if(keycode==27)    
    //{$(":input:visible:text:first",parent.document).focus();parent.top.tb_remove();}//original line
    {
        //$(":input:visible:text:first[className!='date hasDatepicker']", parent.document).focus();
        parent.top.tb_remove();
    }
}
