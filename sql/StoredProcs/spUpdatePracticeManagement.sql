USE [Practitioner]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdatePracticeManagement]
	@PracticeManagementId AS INT,
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

    UPDATE dbo.PracticeManagement
	SET EmployeeId = @EmployeeId,
		Role = @Role,
		Other = @Other,
		Office = @Office,
		Industry = @Industry,
		Sector = @Sector,
		StartDate = @StartDate,
		EndDate = @EndDate,
		Comments = @Comments
	WHERE PracticeManagementId = @PracticeManagementId;
END
