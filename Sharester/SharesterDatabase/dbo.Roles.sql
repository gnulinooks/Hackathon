USE [Sharester]
GO

/****** Object: Table [dbo].[Roles] Script Date: 7/26/2014 3:19:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Roles] (
    [RoleId]        UNIQUEIDENTIFIER NOT NULL,
    [ApplicationId] UNIQUEIDENTIFIER NOT NULL,
    [RoleName]      NVARCHAR (256)   NOT NULL,
    [Description]   NVARCHAR (256)   NULL
);


