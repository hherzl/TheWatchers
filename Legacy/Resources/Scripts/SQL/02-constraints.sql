ALTER TABLE [dbo].[Watcher] ADD CONSTRAINT [PK_dbo_Watcher]
	PRIMARY KEY ([Id])
GO

ALTER TABLE [dbo].[Watcher] ADD CONSTRAINT [UQ_dbo_Watcher_Name]
	UNIQUE ([Name])
GO

ALTER TABLE [dbo].[Watcher] ADD CONSTRAINT [UQ_dbo_Watcher_ClassName]
	UNIQUE ([ClassName])
GO

ALTER TABLE [dbo].[Watcher] ADD CONSTRAINT [UQ_dbo_Watcher_ClassGuid]
	UNIQUE ([ClassGuid])
GO

ALTER TABLE [dbo].[Watcher] ADD CONSTRAINT [UQ_dbo_Watcher_AssemblyQualifiedName]
	UNIQUE ([AssemblyQualifiedName])
GO

ALTER TABLE [dbo].[WatcherParameter] ADD CONSTRAINT [PK_dbo_WatcherParameter]
	PRIMARY KEY ([Id])
GO

ALTER TABLE [dbo].[WatcherParameter] ADD CONSTRAINT [UQ_dbo_WatcherParameter_WatcherId_Parameter]
	UNIQUE ([WatcherId], [Parameter])
GO

ALTER TABLE [dbo].[WatcherParameter] ADD CONSTRAINT [FK_dbo_WatcherParameter_WatcherId_dbo_Watcher]
	FOREIGN KEY ([WatcherId]) REFERENCES [dbo].[Watcher]
GO

ALTER TABLE [dbo].[ResourceCategory] ADD CONSTRAINT [PK_dbo_ResourceCategory]
	PRIMARY KEY ([Id])
GO

ALTER TABLE [dbo].[ResourceCategory] ADD CONSTRAINT [UQ_dbo_ResourceCategory_Name]
	UNIQUE ([Name])
GO

ALTER TABLE [dbo].[ResourceCategory] ADD CONSTRAINT [FK_dbo_ResourceCategory_WatcherId_dbo_Watcher]
	FOREIGN KEY ([WatcherId]) REFERENCES [dbo].[Watcher]
GO

ALTER TABLE [dbo].[Resource] ADD CONSTRAINT [PK_dbo_Resource]
	PRIMARY KEY ([Id])
GO

ALTER TABLE [dbo].[Resource] ADD CONSTRAINT [FK_dbo_Resource_ResourceCategoryId_dbo_ResourceCategory]
	FOREIGN KEY ([ResourceCategoryId]) REFERENCES [dbo].[ResourceCategory]
GO

ALTER TABLE [dbo].[Environment] ADD CONSTRAINT [PK_dbo_Environment]
	PRIMARY KEY ([Id])
GO

ALTER TABLE [dbo].[Environment] ADD CONSTRAINT [UQ_dbo_Environment_Name]
	UNIQUE ([Name])
GO

ALTER TABLE [dbo].[ResourceWatch] ADD CONSTRAINT [PK_dbo_ResourceWatch]
	PRIMARY KEY ([Id])
GO

ALTER TABLE [dbo].[ResourceWatch] ADD CONSTRAINT [UQ_dbo_ResourceWatch_ResourceId_EnvironmentId]
	UNIQUE ([ResourceId], [EnvironmentId])
GO

ALTER TABLE [dbo].[ResourceWatch] ADD CONSTRAINT [FK_dbo_ResourceWatch_ResourceId_dbo_Resource]
	FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[Resource]
GO

ALTER TABLE [dbo].[ResourceWatch] ADD CONSTRAINT [FK_dbo_ResourceWatch_EnvironmentId_dbo_Environment]
	FOREIGN KEY ([EnvironmentId]) REFERENCES [dbo].[Environment]
GO

ALTER TABLE [dbo].[ResourceWatchParameter] ADD CONSTRAINT [PK_dbo_ResourceWatchParameter]
	PRIMARY KEY ([Id])
GO

ALTER TABLE [dbo].[ResourceWatchParameter] ADD CONSTRAINT [UQ_dbo_ResourceWatchParameter_ResourceWatchId_Parameter]
	UNIQUE ([ResourceWatchId], [Parameter])
GO

ALTER TABLE [dbo].[ResourceWatchParameter] ADD CONSTRAINT [FK_dbo_ResourceWatchParameter_ResourceWatchId_dbo_ResourceWatch]
	FOREIGN KEY ([ResourceWatchId]) REFERENCES [dbo].[ResourceWatch]
GO

ALTER TABLE [dbo].[ResourceWatchLog] ADD CONSTRAINT [PK_dbo_ResourceWatchLog]
	PRIMARY KEY ([Id])
GO

ALTER TABLE [dbo].[ResourceWatchLog] ADD CONSTRAINT [FK_dbo_ResourceWatchLog_ResourceWatchId_dbo_ResourceWatch]
	FOREIGN KEY ([ResourceWatchId]) REFERENCES [dbo].[ResourceWatch]
GO
