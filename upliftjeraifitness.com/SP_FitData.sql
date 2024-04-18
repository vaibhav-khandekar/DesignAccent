USE [Vaibhav]
GO
/****** Object:  StoredProcedure [dbo].[SP_Customer]    Script Date: 13-04-2024 12:32:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[SP_FitData](
@Action varchar(100)= NULL,
@ID int= NULL,
@FullName varchar(100)= NULL,
@EmailAddress varchar(100)= NULL,
@MobileNumber varchar(100)= NULL,
@Statee varchar(100)= NULL,
@City varchar(100)= NULL,
@Gender varchar(100)= NULL
)
AS
BEGIN
	IF @Action = 'INSERT'
	BEGIN
		INSERT INTO FitnessCentre(FullName, EmailAddress, MobileNumber, Statee, City, Gender) VALUES(@FullName, @EmailAddress, @MobileNumber, @Statee, @City, @Gender);
		SELECT 'SUCCESS'[Retval]
	END
	ELSE IF @Action = 'UPDATE'
	BEGIN
		UPDATE FitnessCentre SET FullName=@FullName,EmailAddress=@EmailAddress,MobileNumber=@MobileNumber,Statee=@Statee,City=@City,Gender=@Gender WHERE ID=@ID;
		SELECT 'SUCCESS'[Retval]
	END
	ELSE IF @Action = 'DELETE'
	BEGIN
		UPDATE FitnessCentre SET isDelete = 1 WHERE ID=@ID;
		SELECT 'SUCCESS'[Retval]
	END
	ELSE IF @Action = 'SELECT'
	BEGIN
		SELECT 'SUCCESS'[Retval],ID,FullName, EmailAddress, MobileNumber, Statee, City, Gender FROM FitnessCentre WHERE isDelete = 0;
	END
END
