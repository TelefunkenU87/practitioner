USE [Practitioner]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddPracticeManagement]
	@EmployeeId AS INT,
	@Role AS VARCHAR(50),
	@Other AS VARCHAR(50),
	@Office AS VARCHAR(50),
	@Industry AS VARCHAR(255),
	@Sector AS VARCHAR(255),
	@StartDate AS DATE,
	@EndDate AS DATE,
	@Comments AS TEXT

AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO dbo.PracticeManagement VALUES( @EmployeeId, @Role, @Other, @Office, @Industry, @Sector, @StartDate, @EndDate, @Comments);
END
