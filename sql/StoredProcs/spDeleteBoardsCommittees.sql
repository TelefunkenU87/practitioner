USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAccountServed]    Script Date: 5/28/2020 2:34:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDeleteBoardsCommittees] @BoardsCommitteesId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM dbo.BoardsCommittees WHERE BoardsCommitteesId = @BoardsCommitteesId;
END
