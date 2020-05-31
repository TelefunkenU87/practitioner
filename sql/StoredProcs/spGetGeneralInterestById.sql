USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spGetAccountServedById]    Script Date: 5/31/2020 8:21:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetGeneralInterestById] @GeneralInterestId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT * FROM dbo.GeneralInterest WHERE GeneralInterestId = @GeneralInterestId;
END
