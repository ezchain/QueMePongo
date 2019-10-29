USE [QueMePongo]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 6/10/2019 21:14:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[UsuarioId] [int]  IDENTITY,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[Mail] [varchar](50) NULL,
	[TipoUsuario] [varchar](50) NULL,
	[Sensibilidad] [varchar](50) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON,SET IDENTITY_INSERT = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

