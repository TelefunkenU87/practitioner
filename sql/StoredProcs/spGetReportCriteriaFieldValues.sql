USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spGetEmployees]    Script Date: 7/6/2020 11:04:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetReportCriteriaFieldValues] @BaseReportCriteriaId AS INT

AS
BEGIN
	
	DECLARE @Table AS VARCHAR(255),
			@Field AS VARCHAR(255);
	SET	@Table = (SELECT SourceTable FROM dbo.BaseReportCriteria WHERE BaseReportCriteriaId = @BaseReportCriteriaId);
	SET	@Field = (SELECT Field FROM dbo.BaseReportCriteria WHERE BaseReportCriteriaId = @BaseReportCriteriaId);

	--print(@Table);
	--print(@Field);

	DECLARE @sql as nvarchar(max);
	SET @sql = 'SELECT DISTINCT ' + @Field + ' FROM ' + @Table

	exec(@sql)
END
