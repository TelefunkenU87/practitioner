USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spGetEmployeeById]    Script Date: 6/1/2020 9:55:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetReportCriteriaById] @ReportCriteriaId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT * FROM dbo.ReportCriteria WHERE ReportCriteriaId = @ReportCriteriaId;
END
