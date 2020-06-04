USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAccountServed]    Script Date: 6/1/2020 10:18:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDeleteReportCriteria] @ReportCriteriaId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM dbo.ReportCriteria WHERE ReportCriteriaId = @ReportCriteriaId;
END
