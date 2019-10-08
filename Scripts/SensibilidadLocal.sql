USE [QueMePongo]
GO

/****** Object:  Table [dbo].[SensibilidadLocal]    Script Date: 8/10/2019 00:07:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SensibilidadLocal](
	[UsuarioId] [int] NOT NULL,
	[Cuello] [varchar](50) NULL,
	[Manos] [varchar](50) NULL,
	[Cabeza] [varchar](50) NULL
) ON [PRIMARY]
GO

