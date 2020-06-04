USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spAddAccountServed]    Script Date: 6/1/2020 10:19:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddReportCriteria]
	@Field AS VARCHAR(255),
	@Operator AS VARCHAR(255),
	@FriendlyWhere AS VARCHAR(255)

AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO dbo.ReportCriteria VALUES( @Field, @Operator, @FriendlyWhere);
END
