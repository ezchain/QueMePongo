USE [QueMePongo]
GO

/****** Object:  Table [dbo].[PrendasSugerencia]    Script Date: 6/10/2019 12:22:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PrendasSugerencia](
	[Indice] [int] NOT NULL,
	[SugerenciaId] [int] NOT NULL,
	[PrendaId] [int] NOT NULL
) ON [PRIMARY]
GO

