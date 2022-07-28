USE [master]

IF db_id('ExoTravel') IS NULl
  CREATE DATABASE [ExoTravel]
GO

USE [ExoTravel]
GO

CREATE TABLE [UserType] (
  [Id] integer PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(20) NOT NULL
)
GO

CREATE TABLE [UserProfile] (
  [Id] integer PRIMARY KEY IDENTITY,
  [FirebaseUserId] NVARCHAR(28) NOT NULL,
  [DisplayName] nvarchar(50) NOT NULL,
  [FirstName] nvarchar(50) NOT NULL,
  [LastName] nvarchar(50) NOT NULL,
  [Email] nvarchar(555) NOT NULL,
  [CreateDateTime] datetime NOT NULL,
  [ImageLocation] nvarchar(255),
  [UserTypeId] integer NOT NULL,

  CONSTRAINT [FK_User_UserType] FOREIGN KEY ([UserTypeId]) REFERENCES [UserType] ([Id]),
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
  [ReviewId] integer,
  [Mode] nvarchar(50) NOT NULL
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



ALTER TABLE [Receipt] ADD FOREIGN KEY ([ExoPlanetId]) REFERENCES [ExoPlanet] ([Id])
GO

ALTER TABLE [Receipt] ADD FOREIGN KEY ([LogId]) REFERENCES [Log] ([Id]) ON DELETE CASCADE
GO




