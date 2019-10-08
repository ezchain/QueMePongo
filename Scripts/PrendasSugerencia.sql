USE [QueMePongo]
GO

/****** Object:  Table [dbo].[PrendasSugerencia]    Script Date: 8/10/2019 00:07:34 ******/
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

