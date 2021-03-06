USE [DM_PRO]
GO
/****** Object:  Table [dbo].[FC_PlanoEmbarque]    Script Date: 28/04/2022 09:56:13 ******/
DROP TABLE [dbo].[FC_PlanoEmbarque]
GO
/****** Object:  Table [dbo].[FC_PlanoEmbarque]    Script Date: 28/04/2022 09:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FC_PlanoEmbarque](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Dia] [int] NOT NULL,
	[Mes] [int] NOT NULL,
	[Ano] [int] NOT NULL,
	[Valor] [float] NOT NULL,
	[PEA_Ano] [int] NOT NULL,
	[MeioTransporte_Id] [int] NOT NULL,
	[Cliente_Id] [int] NOT NULL,
	[Pacote] [nvarchar](200) NULL,
	[DataEmbarque] [datetime] NULL,
	[Quadrimestre] [varchar](2) NULL,
	[Contador] [int] NULL,
 CONSTRAINT [PK_FC_PlanoEmbarque] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FC_PlanoEmbarque] ON 

INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (236, 4, 2, 2022, 50000, 2021, 2, 6001, N'TE182', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (237, 12, 2, 2022, 50000, 2021, 2, 6001, N'TE183', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (238, 16, 2, 2022, 50000, 2021, 2, 6001, N'TE184', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (239, 20, 2, 2022, 50000, 2021, 2, 6001, N'TE185', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (240, 24, 2, 2022, 50000, 2021, 2, 6001, N'TE186', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (241, 8, 2, 2022, 28500, 2021, 2, 6019, N'TXA23', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (242, 28, 2, 2022, 28500, 2021, 2, 6019, N'TXA24', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (243, 3, 2, 2022, 4000, 2021, 3, 5016, N'USC_02221', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (244, 5, 2, 2022, 4000, 2021, 3, 5016, N'USC_02221', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (245, 7, 2, 2022, 4000, 2021, 3, 5016, N'USC_02221', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (246, 9, 2, 2022, 4000, 2021, 3, 5016, N'USC_02221', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (247, 11, 2, 2022, 4000, 2021, 3, 5016, N'USC_02222', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (248, 13, 2, 2022, 4000, 2021, 3, 5016, N'USC_02222', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (249, 15, 2, 2022, 4000, 2021, 3, 5016, N'USC_02222', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (250, 17, 2, 2022, 4000, 2021, 3, 5016, N'USC_02222', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (251, 19, 2, 2022, 4000, 2021, 3, 5016, N'USC_02222', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (252, 21, 2, 2022, 4000, 2021, 3, 5016, N'USC_02223', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (253, 23, 2, 2022, 4000, 2021, 3, 5016, N'USC_02223', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (254, 25, 2, 2022, 4000, 2021, 3, 5016, N'USC_02223', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (255, 27, 2, 2022, 2000, 2021, 3, 5016, N'USC_02223', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (536, 4, 4, 2022, 50000, 2021, 2, 6001, N'TE182', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (537, 12, 4, 2022, 50000, 2021, 2, 6001, N'TE183', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (538, 16, 4, 2022, 50000, 2021, 2, 6001, N'TE184', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (539, 20, 4, 2022, 50000, 2021, 2, 6001, N'TE185', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (540, 24, 4, 2022, 50000, 2021, 2, 6001, N'TE186', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (541, 8, 4, 2022, 28500, 2021, 2, 6019, N'TXA23', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (542, 28, 4, 2022, 28500, 2021, 2, 6019, N'TXA24', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (543, 3, 4, 2022, 4000, 2021, 3, 5016, N'USC_02221', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (544, 5, 4, 2022, 4000, 2021, 3, 5016, N'USC_02221', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (545, 7, 4, 2022, 4000, 2021, 3, 5016, N'USC_02221', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (546, 9, 4, 2022, 4000, 2021, 3, 5016, N'USC_02221', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (547, 11, 4, 2022, 4000, 2021, 3, 5016, N'USC_02222', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (548, 13, 4, 2022, 4000, 2021, 3, 5016, N'USC_02222', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (549, 15, 4, 2022, 4000, 2021, 3, 5016, N'USC_02222', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (550, 17, 4, 2022, 4000, 2021, 3, 5016, N'USC_02222', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (551, 19, 4, 2022, 4000, 2021, 3, 5016, N'USC_02222', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (552, 21, 4, 2022, 4000, 2021, 3, 5016, N'USC_02223', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (553, 23, 4, 2022, 4000, 2021, 3, 5016, N'USC_02223', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (554, 25, 4, 2022, 4000, 2021, 3, 5016, N'USC_02223', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (555, 27, 4, 2022, 2000, 2021, 3, 5016, N'USC_02223', NULL, NULL, NULL)
INSERT [dbo].[FC_PlanoEmbarque] ([Id], [Dia], [Mes], [Ano], [Valor], [PEA_Ano], [MeioTransporte_Id], [Cliente_Id], [Pacote], [DataEmbarque], [Quadrimestre], [Contador]) VALUES (556, 3, 6, 2022, 50000, 2021, 2, 6001, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[FC_PlanoEmbarque] OFF
