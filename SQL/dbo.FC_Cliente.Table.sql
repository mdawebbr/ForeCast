USE [DM_PRO]
GO
ALTER TABLE [dbo].[FC_Cliente] DROP CONSTRAINT [DF__FC_Client__perce__37C5420D]
GO
/****** Object:  Table [dbo].[FC_Cliente]    Script Date: 28/04/2022 09:56:13 ******/
DROP TABLE [dbo].[FC_Cliente]
GO
/****** Object:  Table [dbo].[FC_Cliente]    Script Date: 28/04/2022 09:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FC_Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cliente_id] [int] NOT NULL,
	[Nome] [nvarchar](200) NULL,
	[Linha_CAP] [nvarchar](15) NULL,
	[Mercado_CAP] [nvarchar](3) NULL,
	[Cor] [nvarchar](10) NULL,
	[Modal] [nvarchar](15) NULL,
	[Mercado_VF] [nvarchar](15) NULL,
	[Pais] [nvarchar](15) NULL,
	[MercadoCAPId] [int] NULL,
	[MercadoVFId] [int] NULL,
	[LinhaCAPId] [int] NULL,
	[percentual] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_FC_FC_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FC_Cliente] ON 

INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (3, 5011, N'Acos Diamante Comercial Eireli - EPP', N'OutrosMI', N'MI', N'NULL', N'', N'', N'', 0, 0, 0, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (5, 5038, N'ACOS RADIAL', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, CAST(355 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (6, 5007, N'ACOS VENUS LTDA', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (8, 6007, N'AK Steel Corporation', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 3, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (9, 1001, N'AM CALVERT LLC', N'Calvert', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (10, 5023, N'AMR Industria e Comercio', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, CAST(450 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (11, 5024, N'Anglo Americana Comercial de Ferro Ltda', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, CAST(3500 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (12, 5003, N'APERAM INOX AMERICA DO SUL S.A.', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (13, 5018, N'ATLANTA FERRO E ACO LTDA', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (16, 6006, N'BAUMANN INDUSTRIA E COMERCIO DE ACOS LTDA', N'OutrosME', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (17, 4000, N'Bluescope Steel (Ais) Pty Ltd', N'OutrosME', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (20, 5000, N'CIAFAL', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (21, 5002, N'CIPALAM INDUSTRIA E COMERCIO DE LAMINADOS LTDA', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (22, 6004, N'COFERVIL INDUSTRIA E COMERCIO DE FERROS VITORIA LTDA', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (23, 6011, N'Colakoglu Metalurji A.S.', NULL, NULL, NULL, NULL, NULL, NULL, 2, 2, 4, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (24, 5030, N'Comercial Brasileira do Corte Ltda', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (27, 6000, N'CSI', N'USA', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (28, 5001, N'CSN', N'CSN', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (29, 5028, N'DIFERRO ACOS ESPECIAIS LTDA.', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (30, 5012, N'Dinaço Ind. e Com. de Ferro e Aço L', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (31, 6008, N'Essar Steel Alma Inc.', N'OutrosME', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (32, 6009, N'Evraz Oren Steel Mills', N'USA', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (34, 5009, N'Gabicajo Aços Especiais Ltda', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (37, 5010, N'Grupo nçalves Dias S.A', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (39, 2000, N'Habas Sinai Ve Tibbi Gazlar Istihsal Edustrisi A S', N'OutrosME', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (48, 5033, N'Madiba Comercial de Produtos Siderurgicos Ltda', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (49, 6015, N'Maghreb Steel', N'OutrosME', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (50, 5014, N'MAXICORTE INDUSTRIA E COMERCIO DE ACOS LTDA.', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (51, 5020, N'Metalferj Industria e Comercio de M Ltda', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (52, 5060, N'METALLI - ACOS ESPECIAIS LTDA', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (54, 5061, N'MM METALS INDUSTRIA E COMERCIO DE ACOS LTDA', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (57, 5042, N'MW FERRO E ACO EIRELI', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (58, 3000, N'NLMK Pennsylvania, LLC', N'USA', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (64, 5034, N'Pasifer - Distribuidora de Aços par Industria Ltda-Epp', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (72, 6014, N'Shang Chen Steel Co.. LTD.', N'OutrosME', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (74, 5029, N'SOBEPART PROVECTO DO BRASIL INDUSTRIA E COMERCIO DE ACESSORIOS', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (75, 6013, N'SSI  Sahaviriya Steel Industries Pu  Co., Ltd', N'OutrosME', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (76, 5022, N'STEELCARBON ACO E GRAFITE EIRELI', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (80, 5043, N'Super Laminacao de Ferro e Aco Industria e Com LTDA', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (81, 6003, N'Suricata Sobras Industriais Ltda #', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (83, 6024, N'thyssenkrupp Materials Trading EMEA', N'OutrosME', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (86, 6019, N'TX AR', N'TerniumMX', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (87, 6001, N'Ternium Mexico', N'TerniumMX', N'EX', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (89, 5050, N'Union Industria de Moldes e Com. Atacadista De Maquinas Ltda', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (91, 5016, N'Usiminas Cubatao', N'UsiminasCUB', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (92, 5005, N'Usiminas Ipatinga', N'UsiminasCUB', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (94, 5017, N'Valor Trading Comercio de Produtos Siderurgicos - Eireli', N'OutrosMI', N'MI', N'NULL', NULL, NULL, NULL, 1, 1, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (99, 6025, N'Teste 1', N'Ovc', N'Ovc', N'', N'Modal 1', N'MI', N'Brasil', 0, 0, 0, CAST(3 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (100, 6026, N'COSMETAL', N'OutrosMI', N'Ovc', N'', N'Modal 3', N'MI', N'Brasil', 0, 0, 0, CAST(3 AS Decimal(18, 0)))
INSERT [dbo].[FC_Cliente] ([Id], [Cliente_id], [Nome], [Linha_CAP], [Mercado_CAP], [Cor], [Modal], [Mercado_VF], [Pais], [MercadoCAPId], [MercadoVFId], [LinhaCAPId], [percentual]) VALUES (107, 6030, N'Teste 7', NULL, NULL, NULL, NULL, NULL, NULL, 2, 4, 8, CAST(3 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[FC_Cliente] OFF
ALTER TABLE [dbo].[FC_Cliente] ADD  DEFAULT ((3)) FOR [percentual]
GO
