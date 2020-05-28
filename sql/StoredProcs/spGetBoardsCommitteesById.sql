USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spGetAccountServedById]    Script Date: 5/28/2020 2:31:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetBoardsCommitteesById] @BoardsCommitteesId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT * FROM dbo.BoardsCommittees WHERE BoardsCommitteesId = @BoardsCommitteesId;
END
