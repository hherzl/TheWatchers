USE [TheWatcher]
GO

IF OBJECT_ID('dbo.ResourceWatchLog') IS NOT NULL
	DROP TABLE [dbo].[ResourceWatchLog]
GO

IF OBJECT_ID('dbo.ResourceWatchParameter') IS NOT NULL
	DROP TABLE [dbo].[ResourceWatchParameter]
GO

IF OBJECT_ID('dbo.ResourceWatch') IS NOT NULL
	DROP TABLE [dbo].[ResourceWatch]
GO

IF OBJECT_ID('dbo.Environment') IS NOT NULL
	DROP TABLE [dbo].[Environment]
GO

IF OBJECT_ID('dbo.Resource') IS NOT NULL
	DROP TABLE [dbo].[Resource]
GO

IF OBJECT_ID('dbo.ResourceCategory') IS NOT NULL
	DROP TABLE [dbo].[ResourceCategory]
GO

IF OBJECT_ID('dbo.WatcherParameter') IS NOT NULL
	DROP TABLE [dbo].[WatcherParameter]
GO

IF OBJECT_ID('dbo.Watcher') IS NOT NULL
	DROP TABLE [dbo].[Watcher]
GO

CREATE TABLE [dbo].[Watcher]
(
	[Id] SMALLINT NOT NULL IDENTITY(1, 1),
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(MAX) NULL,
	[ClassName] NVARCHAR(511) NOT NULL,
	[ClassGuid] UNIQUEIDENTIFIER NOT NULL,
	[AssemblyQualifiedName] NVARCHAR(511) NOT NULL,
	[Active] BIT NOT NULL,
	[CreationUser] NVARCHAR(50) NOT NULL,
	[CreationDateTime] DATETIME NOT NULL,
	[LastUpdateUser] NVARCHAR(50) NULL,
	[LastUpdateDateTime] DATETIME NULL,
	[Version] ROWVERSION NULL
)
GO

CREATE TABLE [dbo].[WatcherParameter]
(
	[Id] SMALLINT NOT NULL IDENTITY(1, 1),
	[WatcherId] SMALLINT NOT NULL,
	[Parameter] NVARCHAR(100) NOT NULL,
	[Value] NVARCHAR(MAX) NULL,
	[IsDefault] BIT NOT NULL,
	[Description] NVARCHAR(MAX) NULL,
	[Active] BIT NOT NULL,
	[CreationUser] NVARCHAR(50) NOT NULL,
	[CreationDateTime] DATETIME NOT NULL,
	[LastUpdateUser] NVARCHAR(50) NULL,
	[LastUpdateDateTime] DATETIME NULL,
	[Version] ROWVERSION NULL
)
GO

CREATE TABLE [dbo].[ResourceCategory]
(
	[Id] SMALLINT NOT NULL IDENTITY(1, 1),
	[Name] NVARCHAR(100) NOT NULL,
	[WatcherId] SMALLINT NULL,
	[Active] BIT NOT NULL,
	[CreationUser] NVARCHAR(50) NOT NULL,
	[CreationDateTime] DATETIME NOT NULL,
	[LastUpdateUser] NVARCHAR(50) NULL,
	[LastUpdateDateTime] DATETIME NULL,
	[Version] ROWVERSION NULL
)
GO

CREATE TABLE [dbo].[Resource]
(
	[Id] SMALLINT NOT NULL IDENTITY(1, 1),
	[Name] NVARCHAR(100) NULL,
	[ResourceCategoryId] SMALLINT NULL,
	[Active] BIT NOT NULL,
	[CreationUser] NVARCHAR(50) NOT NULL,
	[CreationDateTime] DATETIME NOT NULL,
	[LastUpdateUser] NVARCHAR(50) NULL,
	[LastUpdateDateTime] DATETIME NULL,
	[Version] ROWVERSION NULL
)
GO

CREATE TABLE [dbo].[Environment]
(
	[Id] SMALLINT NOT NULL IDENTITY(1, 1),
	[Name] NVARCHAR(100) NOT NULL,
	[Active] BIT NOT NULL,
	[CreationUser] NVARCHAR(50) NOT NULL,
	[CreationDateTime] DATETIME NOT NULL,
	[LastUpdateUser] NVARCHAR(50) NULL,
	[LastUpdateDateTime] DATETIME NULL,
	[Version] ROWVERSION NULL
)
GO

CREATE TABLE [dbo].[ResourceWatch]
(
	[Id] SMALLINT NOT NULL IDENTITY(1, 1),
	[ResourceId] SMALLINT NOT NULL,
	[EnvironmentId] SMALLINT NOT NULL,
	[Successful] BIT NULL,
	[WatchCount] INT NULL,
	[LastWatch] DATETIME NULL,
	[Interval] INT NOT NULL,
	[Description] NVARCHAR(MAX) NULL,
	[Active] BIT NOT NULL,
	[CreationUser] NVARCHAR(50) NOT NULL,
	[CreationDateTime] DATETIME NOT NULL,
	[LastUpdateUser] NVARCHAR(50) NULL,
	[LastUpdateDateTime] DATETIME NULL,
	[Version] ROWVERSION NULL
)
GO

CREATE TABLE [dbo].[ResourceWatchParameter]
(
	[Id] SMALLINT NOT NULL IDENTITY(1, 1),
	[ResourceWatchId] SMALLINT NOT NULL,
	[Parameter] NVARCHAR(100) NOT NULL,
	[Value] NVARCHAR(MAX) NULL,
	[Description] NVARCHAR(MAX) NULL,
	[Active] BIT NOT NULL,
	[CreationUser] NVARCHAR(50) NOT NULL,
	[CreationDateTime] DATETIME NOT NULL,
	[LastUpdateUser] NVARCHAR(50) NULL,
	[LastUpdateDateTime] DATETIME NULL,
	[Version] ROWVERSION NULL
)
GO

CREATE TABLE [dbo].[ResourceWatchLog]
(
	[Id] SMALLINT NOT NULL IDENTITY(1, 1),
	[ResourceWatchId] SMALLINT NOT NULL,
	[AssemblyQualifiedName] NVARCHAR(511) NOT NULL,
	[ActionName] NVARCHAR(511) NOT NULL,
	[Successful] BIT NOT NULL,
	[Message] NVARCHAR(MAX) NOT NULL,
	[ErrorMessage] NVARCHAR(MAX) NULL,
	[Active] BIT NOT NULL,
	[CreationUser] NVARCHAR(50) NOT NULL,
	[CreationDateTime] DATETIME NOT NULL,
	[LastUpdateUser] NVARCHAR(50) NULL,
	[LastUpdateDateTime] DATETIME NULL,
	[Version] ROWVERSION NULL
)
GO
