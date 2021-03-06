USE [Practitioner];
GO

/****** Object:  StoredProcedure [dbo].[RptGetPop]    Script Date: 6/4/2020 9:51:02 AM ******/

SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE PROCEDURE [dbo].[RptGetPop]
AS
    BEGIN
        SET NOCOUNT ON;
        DECLARE @sql VARCHAR(MAX);
        DECLARE @Field AS VARCHAR(255);
        DECLARE @Operator AS VARCHAR(255);
        DECLARE @FriendlyWhere AS VARCHAR(255);
        DECLARE @pWhere AS VARCHAR(MAX);
        DECLARE @CriteriaCursor AS CURSOR;
        SET @CriteriaCursor = CURSOR
        FOR SELECT Field, 
                   Operator, 
                   FriendlyWhere
            FROM dbo.ReportCriteria;
        OPEN @CriteriaCursor;
        FETCH NEXT FROM @CriteriaCursor INTO @Field, @Operator, @FriendlyWhere;
        SET @pWhere = 'WHERE';
        WHILE @@FETCH_STATUS = 0
            BEGIN
                SET @pWhere+=' ' + @Field + ' ' + @Operator + ' ''' + @FriendlyWhere + ''' AND';
                FETCH NEXT FROM @CriteriaCursor INTO @Field, @Operator, @FriendlyWhere;
            END;
        CLOSE @CriteriaCursor;
        DEALLOCATE @CriteriaCursor;
        SET @pWhere = SUBSTRING(@pWhere, 0, DATALENGTH(@pWhere) - 3);
        BEGIN
            SET @sql = 'SELECT DISTINCT dbo.Employee.EmployeeId FROM dbo.Employee ' + 
						'LEFT JOIN dbo.AccountServed ON dbo.Employee.EmployeeId = dbo.AccountServed.EmployeeId ' + 
						'LEFT JOIN dbo.PracticeManagement ON dbo.Employee.EmployeeId = dbo.AccountServed.EmployeeId ' + 
						'LEFT JOIN dbo.BoardsCommittees ON dbo.Employee.EmployeeId = dbo.BoardsCommittees.EmployeeId ' + 
						'LEFT JOIN dbo.CareerInterest ON dbo.Employee.EmployeeId = dbo.CareerInterest.EmployeeId ' + 
						'LEFT JOIN dbo.GeneralInterest ON dbo.Employee.EmployeeId = dbo.GeneralInterest.EmployeeId ' + 
						'LEFT JOIN dbo.ReloInterest ON dbo.Employee.EmployeeId = dbo.ReloInterest.EmployeeId ' + @pWhere;
        END;

        --Print @sql
        EXEC (@sql);
    END;