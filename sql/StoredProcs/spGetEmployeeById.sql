USE [Practitioner]
Go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetEmployeeById] @EmployeeId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT * FROM dbo.Employee WHERE @EmployeeId = @EmployeeId;
END
GO
