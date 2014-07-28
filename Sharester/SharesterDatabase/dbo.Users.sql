USE [Sharester]
GO

/****** Object: Table [dbo].[Users] Script Date: 7/26/2014 3:19:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users] (
    [UserId]           UNIQUEIDENTIFIER NOT NULL,
    [ApplicationId]    UNIQUEIDENTIFIER NOT NULL,
    [UserName]         NVARCHAR (50)    NOT NULL,
    [IsAnonymous]      BIT              NOT NULL,
    [LastActivityDate] DATETIME         NOT NULL
);


