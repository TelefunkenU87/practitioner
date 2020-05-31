USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAccountServed]    Script Date: 5/31/2020 8:17:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDeleteGeneralInterest] @GeneralInterestId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM dbo.GeneralInterest WHERE GeneralInterestId = @GeneralInterestId;
END
