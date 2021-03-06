USE [DM_PRO]
GO
/****** Object:  Table [dbo].[FC_ClienteMesAno]    Script Date: 28/04/2022 09:56:13 ******/
DROP TABLE [dbo].[FC_ClienteMesAno]
GO
/****** Object:  Table [dbo].[FC_ClienteMesAno]    Script Date: 28/04/2022 09:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FC_ClienteMesAno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cliente_Id] [int] NULL,
	[Mes] [int] NULL,
	[Ano] [int] NULL,
	[Valor] [int] NULL,
 CONSTRAINT [PK_FC_FC_ClienteMesAno] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FC_ClienteMesAno] ON 

INSERT [dbo].[FC_ClienteMesAno] ([Id], [Cliente_Id], [Mes], [Ano], [Valor]) VALUES (1070, 5016, 1, 2022, NULL)
INSERT [dbo].[FC_ClienteMesAno] ([Id], [Cliente_Id], [Mes], [Ano], [Valor]) VALUES (1071, 5016, 2, 2022, NULL)
INSERT [dbo].[FC_ClienteMesAno] ([Id], [Cliente_Id], [Mes], [Ano], [Valor]) VALUES (1073, 6001, 12, 2021, NULL)
INSERT [dbo].[FC_ClienteMesAno] ([Id], [Cliente_Id], [Mes], [Ano], [Valor]) VALUES (1075, 6019, 12, 2021, NULL)
INSERT [dbo].[FC_ClienteMesAno] ([Id], [Cliente_Id], [Mes], [Ano], [Valor]) VALUES (1076, 5016, 12, 2021, NULL)
INSERT [dbo].[FC_ClienteMesAno] ([Id], [Cliente_Id], [Mes], [Ano], [Valor]) VALUES (1077, 6001, 1, 2022, NULL)
INSERT [dbo].[FC_ClienteMesAno] ([Id], [Cliente_Id], [Mes], [Ano], [Valor]) VALUES (1078, 6019, 1, 2022, NULL)
INSERT [dbo].[FC_ClienteMesAno] ([Id], [Cliente_Id], [Mes], [Ano], [Valor]) VALUES (1079, 6001, 2, 2022, NULL)
INSERT [dbo].[FC_ClienteMesAno] ([Id], [Cliente_Id], [Mes], [Ano], [Valor]) VALUES (1080, 6019, 2, 2022, NULL)
SET IDENTITY_INSERT [dbo].[FC_ClienteMesAno] OFF
