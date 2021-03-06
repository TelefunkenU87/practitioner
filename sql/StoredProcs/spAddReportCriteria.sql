USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spAddReportCriteria]    Script Date: 7/3/2020 8:55:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddReportCriteria]
	-- @Field AS VARCHAR(255),
	@Id AS INT,
	@Operator AS VARCHAR(255),
	@FriendlyWhere AS VARCHAR(255)

AS
BEGIN
	
	SET NOCOUNT ON;

    -- INSERT INTO dbo.ReportCriteria VALUES( @Field, @Operator, @FriendlyWhere);
	INSERT INTO dbo.ReportCriteria (Field, Operator, FriendlyWhere)
		VALUES ( (SELECT Field FROM dbo.BaseReportCriteria WHERE BaseReportCriteriaId = @Id), @Operator, @FriendlyWhere );
END
