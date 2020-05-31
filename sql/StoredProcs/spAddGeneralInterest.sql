USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spAddAccountServed]    Script Date: 5/31/2020 8:15:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddGeneralInterest]
	@EmployeeId AS INT,
	@Department AS VARCHAR(255),
	@Comments AS TEXT

AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO dbo.GeneralInterest VALUES( @EmployeeId, @Department, @Comments);
END
