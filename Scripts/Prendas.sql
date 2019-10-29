USE [QueMePongo]
GO

/****** Object:  Table [dbo].[Prendas]    Script Date: 8/10/2019 00:07:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Prendas](
	[PrendaId] [int] IDENTITY(1,1),
	[Nombre] [varchar](50) NOT NULL,
	[GuardarropaId] [int] NOT NULL,
	[Categoria] [varchar](50) NOT NULL,
	[Temperatura] [decimal](18, 0) NOT NULL,
	[Formalidad] [varchar](50) NOT NULL,
	[Posicion] [int] NOT NULL,
	[Nivel] [int] NOT NULL,
	[Tela] [varchar](50) NOT NULL,
	[ColorPrimario] [varchar](50) NOT NULL,
	[ColorSecundario] [varchar](50) NULL,
	[Imagen] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PrendaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

