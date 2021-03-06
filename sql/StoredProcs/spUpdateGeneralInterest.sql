USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateAccountServed]    Script Date: 5/31/2020 8:24:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateGeneralInterest]
	@GeneralInterestId AS INT,
	@EmployeeId AS INT,
	@Department AS VARCHAR(255),
	@Comments AS TEXT

AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE dbo.GeneralInterest
	SET EmployeeId = @EmployeeId,
		Department = @Department,
		Comments = @Comments
	WHERE GeneralInterestId = @GeneralInterestId;
END
