USE [master]

IF db_id('ExoTravel') IS NULl
  CREATE DATABASE [ExoTravel]
GO

USE [ExoTravel]
GO


DROP TABLE IF EXISTS [About];
DROP TABLE IF EXISTS [HubDrive];
DROP TABLE IF EXISTS [Log];
DROP TABLE IF EXISTS [Review];
DROP TABLE IF EXISTS [Receipt];
DROP TABLE IF EXISTS [ExoPlanet];
DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [UserType];
GO


CREATE TABLE [UserType] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(20) NOT NULL
)
GO

CREATE TABLE [UserProfile] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [FirebaseUserId] NVARCHAR(28) NOT NULL,
  [DisplayName] nvarchar(50) NOT NULL,
  [FirstName] nvarchar(50) NOT NULL,
  [LastName] nvarchar(50) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [CreateDateTime] datetime NOT NULL,
  [ImageLocation] nvarchar(255),
  [UserTypeId] integer NOT NULL,

    CONSTRAINT UQ_FirebaseUserId UNIQUE(FirebaseUserId)

)
GO

CREATE TABLE [ExoPlanet] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] NVARCHAR(28) NOT NULL,
  [Mass] integer NOT NULL,
  [Radius] integer NOT NULL,
  [EqTemp] integer NOT NULL,
  [Orbit] integer NOT NULL,
  [LightYears] integer NOT NULL,
  [Detail] nvarchar(255) NOT NULL,
  [Rating] integer NOT NULL
)
GO

CREATE TABLE [Receipt] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [UserProfileId] integer NOT NULL,
  [ExoPlanetId] integer NOT NULL,
  [DepartureDate] integer NOT NULL,
  [ReturnDate] integer NOT NULL,
  [LogId] integer NOT NULL,
  [Paid] integer NOT NULL,
  [Mode] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [Review] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [UserProfileId] integer NOT NULL,
  [ExoPlanetId] integer NOT NULL,
  [CreateDate] integer NOT NULL,
  [EditDate] integer,
  [Star] integer,
  [Message] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Log] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [UserProfileId] integer NOT NULL,
  [ExoPlanetId] integer NOT NULL,
  [DepartureDate] integer NOT NULL,
  [ReturnDate] integer NOT NULL,
  [ReviewId] integer NOT NULL,
  [Mode] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [HubDrive] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [Detail] nvarchar(255) NOT NULL,
  [CardDetail] nvarchar(255) NOT NULL,
  [Image] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [About] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [Detail] nvarchar(255) NOT NULL,
  [CardDetail] nvarchar(255) NOT NULL,
  [Image] nvarchar(255) NOT NULL
)
GO

ALTER TABLE [UserProfile] ADD FOREIGN KEY ([UserTypeId]) REFERENCES [UserType] ([Id])
GO

ALTER TABLE [Receipt] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Receipt] ADD FOREIGN KEY ([ExoPlanetId]) REFERENCES [ExoPlanet] ([Id])
GO

ALTER TABLE [Review] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Review] ADD FOREIGN KEY ([ExoPlanetId]) REFERENCES [ExoPlanet] ([Id])
GO

ALTER TABLE [Log] ADD FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Log] ADD FOREIGN KEY ([ExoPlanetId]) REFERENCES [ExoPlanet] ([Id])
GO

ALTER TABLE [Log] ADD FOREIGN KEY ([ReviewId]) REFERENCES [Review] ([Id])
GO