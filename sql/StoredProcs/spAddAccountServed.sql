USE [Practitioner]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddAccountServed]
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

    INSERT INTO dbo.AccountServed VALUES( @EmployeeId, @Account, @ClientService, @Industry, @Sector, @StartDate, @EndDate);
END
GO
