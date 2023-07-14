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

uspAnalysisById 

CREATE PROCEDURE uspAnalysisRegister
(
    @Name varchar(100),
    @State int,
    @AuditCreateDate DATETIME
)
AS
BEGIN
    INSERT INTO Analysis
        (
            Name,
            State,
            AuditCreateDate
        )
    VALUES
        (
            @Name,
            @State,
            @AuditCreateDate
        )
END

CREATE PROCEDURE uspAnalysisEdit
(
    @AnalysisId int,
    @Name varchar(50)
)
AS
BEGIN 
    UPDATE Analysis
        SET Name = @Name
    WHERE AnalysisId = @AnalysisId
END

CREATE PROCEDURE uspAnalysisRemove
(
    @AnalysisId INT
)
AS
BEGIN 
    DELETE FROM Analysis
    WHERE AnalysisId = @AnalysisId
END

uspAnalysisRemove 1
    
    select * from Analysis