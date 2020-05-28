USE [Practitioner]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetAccountServedByEmployeeId] @EmployeeId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;
    
	SELECT * FROM dbo.AccountServed WHERE EmployeeId = @EmployeeId;
END
GO
