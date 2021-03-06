USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateAccountServed]    Script Date: 5/31/2020 9:10:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateReloInterest]
	@ReloInterestId AS INT,
	@EmployeeId AS INT,
	@Location AS VARCHAR(50),
	@InterestLevel AS VARCHAR(5),
	@Timing AS VARCHAR(13),
	@Comments AS TEXT

AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE dbo.ReloInterest
	SET EmployeeId = @EmployeeId,
		Location = @Location,
		InterestLevel = @InterestLevel,
		Timing = @Timing,
		Comments = @Comments
	WHERE ReloInterestId = @ReloInterestId;
END
