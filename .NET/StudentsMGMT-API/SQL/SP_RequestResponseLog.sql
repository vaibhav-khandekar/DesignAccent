
CREATE proc [dbo].[SP_RequestResponseLog]
@Action varchar(max) = null,
@Id int = null,
@MethodName varchar(max) = null,
@ClassName varchar(max) = null, 
@Request varchar(max) = null,
@Response varchar(max) = null, 
@Exception varchar(max) = null, 
@Createdate datetime = null
AS
BEGIN
	Insert into [dbo].[tbl_RequestResponseLog] (MethodName,ClassName,Request,Response,Exception,CreateDate)
	values(@MethodName,@ClassName,@Request,@Response,@Exception,getdate())
	Select 'Success'[retval]
END

CREATE TABLE tbl_RequestResponseLog (Id int, MethodName varchar(max), ClassName varchar(max), Request varchar(max), Response varchar(max), Exception varchar(max), Createdate datetime);
