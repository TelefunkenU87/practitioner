USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spGetEmployees]    Script Date: 6/1/2020 9:48:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetReportCriterias] 

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT * FROM dbo.ReportCriteria;
END
