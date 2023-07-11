CREATE TABLE Analysis (
    AnalysisId int identity(1,1) primary key not null,
    Name varchar(50),
    State int not null,
    AuditCreateDate datetime2(7) not null
)
GO

CREATE PROCEDURE uspAnalysisList
AS
BEGIN
    SELECT
        AnalysisId,
        Name,
        AuditCreateDate,
        State
    FROM Analysis
END

exec uspAnalysisList

CREATE OR ALTER PROCEDURE uspAnalysisById
(
    @AnalysisId int
)
AS
BEGIN
    SELECT
        AnalysisId,
        Name
    FROM Analysis
    WHERE AnalysisId = @AnalysisId;
END

SELECT * FROM Analysis

uspAnalysisById 1