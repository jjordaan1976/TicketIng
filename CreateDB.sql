-- Drop tables if they already exist (for reruns)
IF OBJECT_ID('dbo.Issue', 'U') IS NOT NULL DROP TABLE dbo.Issue;
IF OBJECT_ID('dbo.Release', 'U') IS NOT NULL DROP TABLE dbo.Release;
IF OBJECT_ID('dbo.Status', 'U') IS NOT NULL DROP TABLE dbo.Status;
IF OBJECT_ID('dbo.[User]', 'U') IS NOT NULL DROP TABLE dbo.[User];
IF OBJECT_ID('dbo.Client', 'U') IS NOT NULL DROP TABLE dbo.Client;
IF OBJECT_ID('dbo.Category', 'U') IS NOT NULL DROP TABLE dbo.Category;
GO

-- Client table
CREATE TABLE dbo.Client (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    ContactEmail NVARCHAR(200) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);

CREATE TABLE dbo.[Role] (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Description] NVARCHAR(100) NOT NULL, -- e.g., Admin, Support, ClientUser
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);

-- User table
CREATE TABLE dbo.[User] (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ClientId INT NULL,
    UserName NVARCHAR(200) NOT NULL,
    Email NVARCHAR(200) NOT NULL,
    [RoleId] int NOT NULL, -- e.g., Admin, Support, ClientUser
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_User_Client FOREIGN KEY (ClientId) REFERENCES dbo.Client(Id),
	CONSTRAINT FK_User_Role FOREIGN KEY (RoleId) REFERENCES dbo.[Role](Id)
);

-- Category table
CREATE TABLE dbo.Category (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(500) NULL
);

-- Status table
CREATE TABLE dbo.Status (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL, -- e.g., Open, In Progress, Resolved, Closed
    IsFinal BIT NOT NULL DEFAULT 0
);

-- Release table
CREATE TABLE dbo.Release (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Version NVARCHAR(100) NOT NULL,
    ReleaseDate DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    Notes NVARCHAR(MAX) NULL
);

-- Issue table
CREATE TABLE dbo.Issue (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    CreatedByUserId INT NOT NULL,
    AssignedToUserId INT NULL,
    ClientId INT NOT NULL,
    CategoryId INT NULL,
    StatusId INT NOT NULL,
    ReleaseId INT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL,

    CONSTRAINT FK_Issue_CreatedBy FOREIGN KEY (CreatedByUserId) REFERENCES dbo.[User](Id),
    CONSTRAINT FK_Issue_AssignedTo FOREIGN KEY (AssignedToUserId) REFERENCES dbo.[User](Id),
    CONSTRAINT FK_Issue_Client FOREIGN KEY (ClientId) REFERENCES dbo.Client(Id),
    CONSTRAINT FK_Issue_Category FOREIGN KEY (CategoryId) REFERENCES dbo.Category(Id),
    CONSTRAINT FK_Issue_Status FOREIGN KEY (StatusId) REFERENCES dbo.Status(Id),
    CONSTRAINT FK_Issue_Release FOREIGN KEY (ReleaseId) REFERENCES dbo.Release(Id)
);
