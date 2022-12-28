CREATE DATABASE notepad;
GO

USE notepad;
GO
-- CREATE SCHEMAS

CREATE SCHEMA security;
GO

-- TABLE DEFINITIONS

CREATE TABLE security.IdentityUser (
  Id VARCHAR(36),
  AccessFailedCount INT,
  Avatar NVARCHAR(MAX),
  ConcurrencyStamp NVARCHAR(MAX),
  Email VARCHAR(50),
  EmailConfirmed BIT,
  LockoutEnabled BIT,
  LockoutEnd DATETIMEOFFSET,
  Name NVARCHAR(MAX),
  NormalizedEmail NVARCHAR(256),
  NormalizedUserName NVARCHAR(256),
  PasswordHash VARCHAR(MAX),
  PhoneNumber NVARCHAR(MAX),
  PhoneNumberConfirmed BIT,
  SecurityStamp NVARCHAR(MAX),
  TwoFactorEnabled BIT,
  UserName NVARCHAR(256)
  CONSTRAINT [PK_IdentityUser] PRIMARY KEY CLUSTERED([Id] ASC)
);
GO
