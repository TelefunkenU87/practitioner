USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spAddAccountServed]    Script Date: 5/31/2020 8:47:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddReloInterest]
	@EmployeeId AS INT,
	@Location AS VARCHAR(50),
	@InterestLevel AS VARCHAR(5),
	@Timing AS VARCHAR(13),
	@Comments AS TEXT

AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO dbo.ReloInterest VALUES( @EmployeeId, @Location, @InterestLevel, @Timing, @Comments);
END
