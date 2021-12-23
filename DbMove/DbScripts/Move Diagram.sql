CREATE TABLE [Movers] (
  [Id] bigint PRIMARY KEY IDENTITY(1, 1),
  [Username] nvarchar(255),
  [Password] nvarchar(255),
  [Firstname] nvarchar(255),
  [Lastname] nvarchar(255),
  [Birthdate] datetime
)
GO

CREATE TABLE [Moves] (
  [Id] bigint PRIMARY KEY IDENTITY(1, 1),
  [Title] nvarchar(255),
  [Description] nvarchar(255),
  [MoveDate] datetime,
  [SportId] int,
  [Longitude] decimal,
  [Latitude] decimal,
  [MediaId] bigint
)
GO

CREATE TABLE [Sports] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255)
)
GO

CREATE TABLE [MoveMovers] (
  [Id] bigint PRIMARY KEY IDENTITY(1, 1),
  [MoveId] bigint,
  [MoverId] bigint
)
GO

CREATE TABLE [Media] (
  [Id] bigint PRIMARY KEY IDENTITY(1, 1),
  [Media] nvarchar(max),
  [MediaUrl] nvarchar(500)
)
GO

ALTER TABLE [Moves] ADD FOREIGN KEY ([SportId]) REFERENCES [Sports] ([Id])
GO

ALTER TABLE [MoveMovers] ADD FOREIGN KEY ([MoveId]) REFERENCES [Moves] ([Id])
GO

ALTER TABLE [MoveMovers] ADD FOREIGN KEY ([MoverId]) REFERENCES [Movers] ([Id])
GO

ALTER TABLE [Moves] ADD FOREIGN KEY ([MediaId]) REFERENCES [Media] ([Id])
GO
