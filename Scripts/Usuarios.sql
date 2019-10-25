USE [QueMePongo]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 6/10/2019 21:14:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='[dbo].[Usuarios]' and xtype='U')
    DROP TABLE [dbo].[Usuarios]
GO

CREATE TABLE [dbo].[Usuarios](
	[UsuarioId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[Mail] [varchar](50) NULL,
	[TipoUsuario] [varchar](50) NULL,
	[Sensibilidad] [varchar](50) NULL
) ON [PRIMARY]
GO

