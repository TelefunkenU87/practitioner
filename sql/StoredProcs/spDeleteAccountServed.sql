USE [Practitioner]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDeleteAccountServed] @AccountServedId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM dbo.AccountServed WHERE AccountServedId = @AccountServedId;
END
GO
