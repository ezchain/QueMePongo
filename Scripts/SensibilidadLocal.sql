USE [QueMePongo]
GO

/****** Object:  Table [dbo].[SensibilidadLocal]    Script Date: 8/10/2019 00:07:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='[dbo].[SensibilidadLocal]' and xtype='U')
    DROP TABLE [dbo].[SensibilidadLocal]
GO

CREATE TABLE [dbo].[SensibilidadLocal](
	[Id] [int] PRIMARY KEY IDENTITY(1,1),
	[UsuarioId] [int] FOREIGN KEY REFERENCES [dbo].[Usuarios] NOT NULL,
	[Cuello] [varchar](50) NULL,
	[Manos] [varchar](50) NULL,
	[Cabeza] [varchar](50) NULL
) ON [PRIMARY]
GO

