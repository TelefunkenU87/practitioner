USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAccountServed]    Script Date: 5/31/2020 7:50:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDeleteCareerInterest] @CareerInterestId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM dbo.CareerInterest WHERE CareerInterestId = @CareerInterestId;
END
