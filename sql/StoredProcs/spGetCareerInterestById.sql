USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spGetAccountServedById]    Script Date: 5/31/2020 7:56:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetCareerInterestById] @CareerInterestId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT * FROM dbo.CareerInterest WHERE CareerInterestId = @CareerInterestId;
END
