USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spAddAccountServed]    Script Date: 5/28/2020 2:36:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddBoardsCommittees]
	@EmployeeId AS INT,
	@BoardCommittee AS VARCHAR(29),
	@Other AS VARCHAR(50),
	@Role AS VARCHAR(8),
	@Comments AS TEXT

AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO dbo.BoardsCommittees VALUES( @EmployeeId, @BoardCommittee, @Other, @Role, @Comments);
END
