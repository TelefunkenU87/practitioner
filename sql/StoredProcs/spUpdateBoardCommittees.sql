USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateAccountServed]    Script Date: 5/28/2020 2:40:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateBoardCommittees]
	@BoardCommitteeId AS INT,
	@EmployeeId AS INT,
	@BoardCommittee AS VARCHAR(29),
	@Other AS VARCHAR(50),
	@Role AS VARCHAR(8),
	@Comments AS TEXT

AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE dbo.BoardsCommittees
	SET EmployeeId = @EmployeeId,
		BoardCommittee = @BoardCommittee,
		Other = @Other,
		Role = @Role,
		Comments = @Comments
	WHERE BoardsCommitteesId = @BoardCommitteeId;
END
