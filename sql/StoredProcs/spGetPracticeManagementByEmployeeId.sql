USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spGetAccountServedByEmployeeId]    Script Date: 5/28/2020 10:54:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetPracticeManagementByEmployeeId] @EmployeeId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;
    
	SELECT * FROM dbo.PracticeManagement WHERE EmployeeId = @EmployeeId;
END
