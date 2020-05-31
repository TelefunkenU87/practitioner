USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spGetAccountServedByEmployeeId]    Script Date: 5/31/2020 8:54:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetReloInterestByEmployeeId] @EmployeeId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;
    
	SELECT * FROM dbo.ReloInterest WHERE EmployeeId = @EmployeeId;
END
