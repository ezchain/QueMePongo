USE [QueMePongo]
GO

/****** Object:  Table [dbo].[SensibilidadLocal]    Script Date: 6/10/2019 12:13:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SensibilidadLocal](
	[UsuarioId] [int] NOT NULL,
	[Cuello] [varchar](50) NOT NULL,
	[Manos] [varchar](50) NOT NULL,
	[Cabeza] [varchar](50) NOT NULL
) ON [PRIMARY]
GO

