CREATE DATABASE notepad;
GO

USE notepad;
GO
-- CREATE SCHEMAS

CREATE SCHEMA security;
GO

-- TABLE DEFINITIONS

CREATE TABLE security.[BlacklistPassword] (
  Id INT IDENTITY(1, 1),
  Password NVARCHAR(MAX)
  CONSTRAINT [PK_BlackListPasswords] PRIMARY KEY CLUSTERED([Id] ASC)
);
GO

CREATE TABLE security.[User] (
  Id VARCHAR(100) NOT NULL,
  PasswordHash VARCHAR(MAX),
  FailedAttempts INT,
  LockoutEnd DATETIME2,
  CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED([Id] ASC)
);
GO

CREATE TABLE dbo.Note (
  Id VARCHAR(36),
  Title NVARCHAR(100),
  Text NVARCHAR(MAX),
  UserId VARCHAR(36),
  Encrypted BIT,
  CreationDate DATETIME,
  ScopeType INT,
  CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED([Id] ASC)
);
GO

CREATE TABLE dbo.UserNote (
  UserId VARCHAR(100) CONSTRAINT FK_UserNote_User REFERENCES security.[User](Id),
  NoteId VARCHAR(36) CONSTRAINT FK_UserNote_Note REFERENCES dbo.Note(Id)
  CONSTRAINT [PK_UserNote] PRIMARY KEY CLUSTERED([UserId] ASC, [NoteId] ASC)
);
GO

-- OTHER OPERATIONS

CREATE TABLE ##BLACKLIST_STAGE (Password NVARCHAR(MAX));
GO

BULK INSERT ##BLACKLIST_STAGE
FROM '/db/passwords'
WITH (
  FIELDTERMINATOR = '\n',
  ROWTERMINATOR = '\n'
)
GO

INSERT INTO [security].[BlacklistPassword] (Password)
SELECT * FROM ##BLACKLIST_STAGE;
GO

DROP TABLE ##BLACKLIST_STAGE;
GO

PRINT 'initialization finished'
GO
