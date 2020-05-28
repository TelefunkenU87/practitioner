USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAccountServed]    Script Date: 5/28/2020 11:02:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDeletePracticeManagement] @PracticeManagementId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM dbo.PracticeManagement WHERE PracticeManagementId = @PracticeManagementId;
END
