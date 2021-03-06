USE [DM_PRO]
GO
/****** Object:  Table [dbo].[FC_LinhaCAP]    Script Date: 28/04/2022 09:56:13 ******/
DROP TABLE [dbo].[FC_LinhaCAP]
GO
/****** Object:  Table [dbo].[FC_LinhaCAP]    Script Date: 28/04/2022 09:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FC_LinhaCAP](
	[LinhaCAPId] [int] IDENTITY(1,1) NOT NULL,
	[Linha_CAP] [nvarchar](25) NULL,
	[MercadoCAPId] [int] NOT NULL,
	[MercadoVFId] [int] NOT NULL,
 CONSTRAINT [PK_FC_FC_LinhaCAP] PRIMARY KEY CLUSTERED 
(
	[LinhaCAPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FC_LinhaCAP] ON 

INSERT [dbo].[FC_LinhaCAP] ([LinhaCAPId], [Linha_CAP], [MercadoCAPId], [MercadoVFId]) VALUES (1, N'UsiminasCUB', 2, 2)
INSERT [dbo].[FC_LinhaCAP] ([LinhaCAPId], [Linha_CAP], [MercadoCAPId], [MercadoVFId]) VALUES (2, N'CSN', 1, 1)
INSERT [dbo].[FC_LinhaCAP] ([LinhaCAPId], [Linha_CAP], [MercadoCAPId], [MercadoVFId]) VALUES (3, N'OutrosMI', 1, 1)
INSERT [dbo].[FC_LinhaCAP] ([LinhaCAPId], [Linha_CAP], [MercadoCAPId], [MercadoVFId]) VALUES (4, N'TerniumTX', 2, 2)
INSERT [dbo].[FC_LinhaCAP] ([LinhaCAPId], [Linha_CAP], [MercadoCAPId], [MercadoVFId]) VALUES (5, N'USA', 2, 3)
INSERT [dbo].[FC_LinhaCAP] ([LinhaCAPId], [Linha_CAP], [MercadoCAPId], [MercadoVFId]) VALUES (6, N'Calvert', 2, 3)
INSERT [dbo].[FC_LinhaCAP] ([LinhaCAPId], [Linha_CAP], [MercadoCAPId], [MercadoVFId]) VALUES (7, N'OutrosME', 2, 3)
INSERT [dbo].[FC_LinhaCAP] ([LinhaCAPId], [Linha_CAP], [MercadoCAPId], [MercadoVFId]) VALUES (8, N'Ovc', 3, 4)
INSERT [dbo].[FC_LinhaCAP] ([LinhaCAPId], [Linha_CAP], [MercadoCAPId], [MercadoVFId]) VALUES (9, N'Teste', 2, 2)
INSERT [dbo].[FC_LinhaCAP] ([LinhaCAPId], [Linha_CAP], [MercadoCAPId], [MercadoVFId]) VALUES (10, N'Calvert', 2, 3)
INSERT [dbo].[FC_LinhaCAP] ([LinhaCAPId], [Linha_CAP], [MercadoCAPId], [MercadoVFId]) VALUES (12, N'Teste 2', 3, 3)
SET IDENTITY_INSERT [dbo].[FC_LinhaCAP] OFF
