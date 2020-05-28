USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spGetAccountServedById]    Script Date: 5/28/2020 10:59:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetPracticeManagementById] @PracticeManagementId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT * FROM dbo.PracticeManagement WHERE PracticeManagementId = @PracticeManagementId;
END
