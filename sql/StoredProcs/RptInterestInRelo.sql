USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[RptInterestInRelo]    Script Date: 6/4/2020 9:23:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RptInterestInRelo]
AS

BEGIN
	
	SET NOCOUNT ON;

	CREATE TABLE #tmpPop ( EmployeeId int )
	INSERT INTO #tmpPop ( EmployeeId ) EXEC RptGetPop

    SELECT DISTINCT
		Employee.EmployeeId, Employee.Email, Employee.LastName, Employee.FirstName, Employee.Department,
		ReloInterest.Location, ReloInterest.InterestLevel, ReloInterest.Timing, ReloInterest.Comments
	FROM dbo.Employee
			LEFT OUTER JOIN dbo.ReloInterest ON Employee.EmployeeId = ReloInterest.EmployeeId
	WHERE dbo.Employee.EmployeeId IN ( SELECT EmployeeId FROM #tmpPop )

END
