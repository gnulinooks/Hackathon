USE [Sharester]
GO

/****** Object: Table [dbo].[Applications] Script Date: 7/26/2014 3:18:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Applications] (
    [ApplicationId]   UNIQUEIDENTIFIER NOT NULL,
    [ApplicationName] NVARCHAR (235)   NOT NULL,
    [Description]     NVARCHAR (256)   NULL
);


