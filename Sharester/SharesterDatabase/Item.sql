CREATE TABLE [dbo].[Item]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(200) NULL, 
    [Description] VARCHAR(200) NULL, 
    [Reference] VARCHAR(200) NULL, 
    [Images] VARCHAR(200) NULL, 
    [Cost] FLOAT NULL, 
    [Availability] VARCHAR(100) NOT NULL, 
    [Negotiable] BIT NOT NULL DEFAULT 0, 
    [Bidding] BIT NOT NULL DEFAULT 0, 
    [Category] VARCHAR(200) NOT NULL, 
    [PostId] UNIQUEIDENTIFIER NOT NULL Foreign Key references Post(id), 
    [CreatedOn] DATETIME NOT NULL, 
    [UpdatedOn] DATETIME NOT NULL, 
    [SoldOn] DATETIME NULL
)
