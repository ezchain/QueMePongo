USE [QueMePongo]
GO

/****** Object:  Table [dbo].[Eventos]    Script Date: 8/10/2019 00:06:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Eventos](
	[EventoId] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Latitud] [varchar](50) NOT NULL,
	[Longitud] [varchar](50) NOT NULL,
	[Formalidad] [varchar](50) NOT NULL,
	[Frecuencia] [varchar](50) NOT NULL,
	[FechaInicio] [date] NOT NULL
) ON [PRIMARY]
GO

