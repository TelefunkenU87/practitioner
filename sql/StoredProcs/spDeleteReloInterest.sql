USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAccountServed]    Script Date: 5/31/2020 8:51:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDeleteReloInterest] @ReloInterestId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM dbo.ReloInterest WHERE ReloInterestId = @ReloInterestId;
END
