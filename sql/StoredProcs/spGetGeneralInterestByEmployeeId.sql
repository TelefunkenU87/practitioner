USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spGetAccountServedByEmployeeId]    Script Date: 5/31/2020 8:19:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetGeneralInterestByEmployeeId] @EmployeeId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;
    
	SELECT * FROM dbo.GeneralInterest WHERE EmployeeId = @EmployeeId;
END
