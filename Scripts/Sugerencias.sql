USE [QueMePongo]
GO

/****** Object:  Table [dbo].[Sugerencias]    Script Date: 8/10/2019 00:07:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sugerencias](
	[SugerenciaId] [int] NOT NULL,
	[Aceptada] [varchar](1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[CalorTotal] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO

