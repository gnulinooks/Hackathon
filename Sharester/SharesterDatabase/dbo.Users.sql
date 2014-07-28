
CREATE TABLE [dbo].[Users] (
    [UserId]           UNIQUEIDENTIFIER NOT NULL primary key,
    [ApplicationId]    UNIQUEIDENTIFIER NOT NULL,
    [UserName]         NVARCHAR (50)    NOT NULL,
    [IsAnonymous]      BIT              NOT NULL,
    [LastActivityDate] DATETIME         NOT NULL
);


