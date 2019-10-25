USE [QueMePongo]
GO

/****** Object:  Table [dbo].[Guardarropas]    Script Date: 8/10/2019 00:06:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='[dbo].[Guardarropas]' and xtype='U')
    DROP TABLE [dbo].[Guardarropas]
GO

CREATE TABLE [dbo].[Guardarropas](
	[GuardarropaId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[PrendasMaximas] [int] NOT NULL
) ON [PRIMARY]
GO

