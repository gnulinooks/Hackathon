CREATE TABLE [dbo].[Notifications]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Sender] UNIQUEIDENTIFIER NOT NULL Foreign Key References Users(userid), 
    [Receiver] UNIQUEIDENTIFIER NOT NULL Foreign Key References Users(userid), 
    [PostId] UNIQUEIDENTIFIER NOT NULL Foreign Key References Post(id), 
    [ItemId] UNIQUEIDENTIFIER NOT NULL Foreign Key References Item(id), 
    [Content] VARCHAR(MAX) NULL, 
    [CreatedOn] DATETIME NOT NULL, 
    [State] VARCHAR(200) NOT NULL 
)
