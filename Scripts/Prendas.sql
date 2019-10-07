USE [QueMePongo]
GO

/****** Object:  Table [dbo].[Prendas]    Script Date: 5/10/2019 19:13:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Prendas](
	[PrendaId] [int] NOT NULL,
	[GuardarropaId] [int] NOT NULL,
	[Categoria] [varchar](50) NOT NULL,
	[Temperatura] [decimal](18, 0) NOT NULL,
	[Formalidad] [varchar](50) NOT NULL,
	[Posicion] [int] NOT NULL,
	[Nivel] [int] NOT NULL,
	[Tela] [varchar](50) NOT NULL,
	[ColorPrimario] [varchar](50) NOT NULL,
	[ColorSecundario] [varchar](50) NULL,
	[Imagen] [bit] NOT NULL
) ON [PRIMARY]
GO


