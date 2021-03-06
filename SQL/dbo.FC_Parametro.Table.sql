USE [DM_PRO]
GO
/****** Object:  Table [dbo].[FC_Parametro]    Script Date: 28/04/2022 09:56:13 ******/
DROP TABLE [dbo].[FC_Parametro]
GO
/****** Object:  Table [dbo].[FC_Parametro]    Script Date: 28/04/2022 09:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FC_Parametro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Chave] [nvarchar](100) NOT NULL,
	[Descricao] [nvarchar](100) NOT NULL,
	[Valor] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_FC_Parametro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FC_Parametro] ON 

INSERT [dbo].[FC_Parametro] ([Id], [Chave], [Descricao], [Valor]) VALUES (1, N'3', N'Limitação quantidade/dia de trens', N'2')
INSERT [dbo].[FC_Parametro] ([Id], [Chave], [Descricao], [Valor]) VALUES (2, N'1', N'Limitação quantidade/dia de caminhões', N'1')
INSERT [dbo].[FC_Parametro] ([Id], [Chave], [Descricao], [Valor]) VALUES (3, N'2', N'Limitação quantidade/dia de navios', N'1')
SET IDENTITY_INSERT [dbo].[FC_Parametro] OFF
