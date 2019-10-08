USE [QueMePongo]
GO

/****** Object:  Table [dbo].[GuardarropasUsuarios]    Script Date: 8/10/2019 00:07:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GuardarropasUsuarios](
	[RelacionId] [int] IDENTITY(1,1) NOT NULL,
	[IDGuardarropa] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RelacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

