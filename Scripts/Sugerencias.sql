USE [QueMePongo]
GO

/****** Object:  Table [dbo].[Sugerencias]    Script Date: 8/10/2019 00:07:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sugerencias](
	[SugerenciaId] [INT] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Aceptada] BIT NOT NULL,--[varchar](1) NOT NULL, si esto es un bool tiene que ser BIT, si no es un bool descomenten esto
	[UsuarioId] [int] FOREIGN KEY REFERENCES [dbo].[Usuarios] NOT NULL,
	[CalorTotal] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO

