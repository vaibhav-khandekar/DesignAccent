USE [Vaibhav]
GO
/****** Object:  StoredProcedure [dbo].[SP_Customer]    Script Date: 13-04-2024 12:32:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_StdData](
@Action varchar(100)= NULL,
@StdID int= NULL,
@StdName varchar(100)= NULL,
@StdLocation varchar(100)= NULL,
@StdAge varchar(100)= NULL
)
AS
BEGIN
	IF @Action = 'INSERT'
	BEGIN
		INSERT INTO Students(StdName,StdLocation,StdAge) VALUES(@StdName,@StdLocation,@StdAge);
		BEGIN
		SELECT 'SUCCESS'[Retval]
		END
	END
	ELSE IF @Action = 'UPDATE'
	BEGIN
		UPDATE Students SET StdName=@StdName,StdLocation=@StdLocation,StdAge=@StdAge WHERE StdID=@StdID;
		BEGIN
		SELECT 'SUCCESS'[Retval]
		END
	END
	ELSE IF @Action = 'DELETE'
	BEGIN
		UPDATE Students SET isDelete = 1 WHERE StdID=@StdID;
		BEGIN
		SELECT 'SUCCESS'[Retval]
		END
	END
	ELSE IF @Action = 'SELECT'
	BEGIN
		SELECT 'SUCCESS'[Retval],StdID,StdName,StdLocation,StdAge FROM Students WHERE isDelete = 0;
	END
END
