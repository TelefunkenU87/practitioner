USE [Practitioner]
GO
/****** Object:  StoredProcedure [dbo].[spGetAccountServedByEmployeeId]    Script Date: 5/28/2020 2:28:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetBoardsCommitteesByEmployeeId] @EmployeeId AS INT

AS
BEGIN
	
	SET NOCOUNT ON;
    
	SELECT * FROM dbo.BoardsCommittees WHERE EmployeeId = @EmployeeId;
END
