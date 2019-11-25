USE [QueMePongo]
GO

/****** Object:  Table [dbo].[PrendasSugerencia]    Script Date: 8/10/2019 00:07:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='[dbo].[PrendasSugerencia]' and xtype='U')
    DROP TABLE [dbo].[PrendasSugerencia]
GO

CREATE TABLE [dbo].[PrendasSugerencia](
	[Indice] [int]PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[SugerenciaId] [int] FOREIGN KEY REFERENCES [dbo].[Sugerencias] NOT NULL,
	[PrendaId] [int] FOREIGN KEY REFERENCES [dbo].[Prendas] NOT NULL
) ON [PRIMARY]
GO

