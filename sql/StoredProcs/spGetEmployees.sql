USE [Practitioner]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetEmployees] 

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT * FROM dbo.Employee;
END
GO
