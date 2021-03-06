USE [DM_PRO]
GO
/****** Object:  Table [dbo].[FC_quadrimestre]    Script Date: 28/04/2022 09:56:13 ******/
DROP TABLE [dbo].[FC_quadrimestre]
GO
/****** Object:  Table [dbo].[FC_quadrimestre]    Script Date: 28/04/2022 09:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FC_quadrimestre](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Chave] [nvarchar](3) NOT NULL,
	[DTInicio] [datetime] NOT NULL,
	[DTFimValor] [datetime] NOT NULL,
 CONSTRAINT [PK_FC_quadrimestre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FC_quadrimestre] ON 

INSERT [dbo].[FC_quadrimestre] ([Id], [Chave], [DTInicio], [DTFimValor]) VALUES (1, N'Q1', CAST(N'2021-07-01T00:00:00.000' AS DateTime), CAST(N'2021-09-30T00:00:00.000' AS DateTime))
INSERT [dbo].[FC_quadrimestre] ([Id], [Chave], [DTInicio], [DTFimValor]) VALUES (2, N'Q2', CAST(N'2021-10-01T00:00:00.000' AS DateTime), CAST(N'2021-12-31T00:00:00.000' AS DateTime))
INSERT [dbo].[FC_quadrimestre] ([Id], [Chave], [DTInicio], [DTFimValor]) VALUES (3, N'Q3', CAST(N'2022-01-01T00:00:00.000' AS DateTime), CAST(N'2022-03-31T00:00:00.000' AS DateTime))
INSERT [dbo].[FC_quadrimestre] ([Id], [Chave], [DTInicio], [DTFimValor]) VALUES (4, N'Q4', CAST(N'2022-04-01T00:00:00.000' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[FC_quadrimestre] OFF
