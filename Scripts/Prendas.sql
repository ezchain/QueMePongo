USE [QueMePongo]
GO

/****** Object:  Table [dbo].[Prendas]    Script Date: 8/10/2019 00:07:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='[dbo].[Prendas]' and xtype='U')
   DROP TABLE [dbo].[Prendas]
GO

CREATE TABLE [dbo].[Prendas](
	[PrendaId] [INT] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[GuardarropaId] [int] FOREIGN KEY REFERENCES [dbo].[Guardarropas] NOT NULL,
	[Categoria] [varchar](50) NOT NULL,
	[Temperatura] [decimal](18, 0) NOT NULL,
	[Formalidad] [varchar](50) NOT NULL,
	[Posicion] [int] NOT NULL,
	[Nivel] [int] NOT NULL,
	[Tela] [varchar](50) NOT NULL,
	[ColorPrimario] [varchar](50) NOT NULL,
	[ColorSecundario] [varchar](50) NULL,
	[Imagen] VARBINARY(max) NULL
) ON [PRIMARY]
GO

