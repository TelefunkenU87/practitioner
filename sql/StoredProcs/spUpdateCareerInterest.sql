USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateAccountServed]    Script Date: 5/31/2020 7:58:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateCareerInterest]
	@CareerInterestId AS INT,
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

    UPDATE dbo.CareerInterest
	SET EmployeeId = @EmployeeId,
		Role = @Role,
		Other = @Other,
		Office = @Office,
		Industry = @Industry,
		Sector = @Sector,
		Comment = @Comment
	WHERE CareerInterestId = @CareerInterestId;
END
