USE [Practitioner]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateAccountServed]
	@AccountServedId AS INT,
	@EmployeeId AS INT,
	@Account AS VARCHAR(255),
	@ClientService AS VARCHAR(255),
	@Industry AS VARCHAR(255),
	@Sector AS VARCHAR(255),
	@StartDate AS DATE,
	@EndDate AS DATE

AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE dbo.AccountServed
	SET EmployeeId = @EmployeeId,
		Account = @Account,
		ClientService = @ClientService,
		Industry = @Industry,
		Sector = @Sector,
		StartDate = @StartDate,
		EndDate = @EndDate
	WHERE AccountServedId = @AccountServedId;
END
GO
