USE [Practitioner]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetAccountServedById] @AccountServedId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT * FROM dbo.AccountServed WHERE AccountServedId = @AccountServedId;
END
GO
