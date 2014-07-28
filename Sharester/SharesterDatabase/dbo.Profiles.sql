USE [Sharester]
GO

/****** Object: Table [dbo].[Profiles] Script Date: 7/26/2014 3:19:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Profiles] (
    [UserId]               UNIQUEIDENTIFIER NOT NULL,
    [PropertyNames]        NVARCHAR (MAX)   NOT NULL,
    [PropertyValueStrings] NVARCHAR (MAX)   NOT NULL,
    [PropertyValueBinary]  VARBINARY (MAX)  NOT NULL,
    [LastUpdatedDate]      DATETIME         NOT NULL
);


