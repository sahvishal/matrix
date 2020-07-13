USE [$(dbName)]
GO
 
ALTER PROCEDURE [dbo].[usp_EmailTemplateGetAll]           
(        
 @EmailSubject varchar(100),    
 @TemplateType int      
)        
AS            
BEGIN    
if(@TemplateType=0)  
 Begin  
  if (@EmailSubject!='' and len(@EmailSubject) > 0)        
    BEGIN        
     print 'if'        
     set @EmailSubject='%'+@EmailSubject+'%'        
    select *from TblEmailTemplate where EmailSubject like @EmailSubject   
    END        
   else        
    BEGIN        
     print 'else'        
    select *from TblEmailTemplate   
   END       
 End  
Else  
 Begin        
   if (@EmailSubject!='' and len(@EmailSubject) > 0)        
    BEGIN        
     print 'if'        
     set @EmailSubject='%'+@EmailSubject+'%'        
    select *from TblEmailTemplate where EmailSubject like @EmailSubject and TemplateType=@TemplateType       
    END        
   else        
    BEGIN        
     print 'else'        
    select *from TblEmailTemplate where TemplateType=@TemplateType      
   END        
 END   
End  