USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spGetAccountServedById]    Script Date: 5/31/2020 9:08:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetReloInterestById] @ReloInterestId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT * FROM dbo.ReloInterest WHERE ReloInterestId = @ReloInterestId;
END
