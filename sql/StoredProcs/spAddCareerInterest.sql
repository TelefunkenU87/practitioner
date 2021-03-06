USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spAddAccountServed]    Script Date: 5/31/2020 7:39:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddCareerInterest]
	@EmployeeId AS INT,
	@Role AS VARCHAR(44),
	@Other AS VARCHAR(50),
	@Office AS VARCHAR(50),
	@Industry AS VARCHAR(255),
	@Sector AS VARCHAR(255),
	@Comment AS TEXT

AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO dbo.CareerInterest VALUES( @EmployeeId, @Role, @Other, @Office, @Industry, @Sector, @Comment);
END
