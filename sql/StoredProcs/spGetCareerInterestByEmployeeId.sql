USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spGetAccountServedByEmployeeId]    Script Date: 5/31/2020 7:53:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetCareerInterestByEmployeeId] @EmployeeId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;
    
	SELECT * FROM dbo.CareerInterest WHERE EmployeeId = @EmployeeId;
END
