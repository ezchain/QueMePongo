USE [QueMePongo]
GO

/****** Object:  Table [dbo].[GuardarropasUsuarios]    Script Date: 8/10/2019 00:07:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GuardarropasUsuarios](
	[RelacionId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[GuardarropaId] [int] FOREIGN KEY REFERENCES [dbo].[Guardarropas] NOT NULL,
	[UsuarioId] [int] FOREIGN KEY REFErences [dbo].[Usuarios] NOT NULL,
) ON [PRIMARY]
GO

