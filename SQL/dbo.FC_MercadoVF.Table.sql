USE [DM_PRO]
GO
/****** Object:  Table [dbo].[FC_MercadoVF]    Script Date: 28/04/2022 09:56:13 ******/
DROP TABLE [dbo].[FC_MercadoVF]
GO
/****** Object:  Table [dbo].[FC_MercadoVF]    Script Date: 28/04/2022 09:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FC_MercadoVF](
	[MercadoVFId] [int] IDENTITY(1,1) NOT NULL,
	[Mercado_VF] [nvarchar](25) NULL,
	[MercadoCAPId] [int] NOT NULL,
 CONSTRAINT [PK_FC_FC_MercadoVF] PRIMARY KEY CLUSTERED 
(
	[MercadoVFId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FC_MercadoVF] ON 

INSERT [dbo].[FC_MercadoVF] ([MercadoVFId], [Mercado_VF], [MercadoCAPId]) VALUES (1, N'MI', 1)
INSERT [dbo].[FC_MercadoVF] ([MercadoVFId], [Mercado_VF], [MercadoCAPId]) VALUES (2, N'TRF', 2)
INSERT [dbo].[FC_MercadoVF] ([MercadoVFId], [Mercado_VF], [MercadoCAPId]) VALUES (3, N'ME', 3)
INSERT [dbo].[FC_MercadoVF] ([MercadoVFId], [Mercado_VF], [MercadoCAPId]) VALUES (4, N'MI', 2)
INSERT [dbo].[FC_MercadoVF] ([MercadoVFId], [Mercado_VF], [MercadoCAPId]) VALUES (5, N'TRF', 1)
INSERT [dbo].[FC_MercadoVF] ([MercadoVFId], [Mercado_VF], [MercadoCAPId]) VALUES (6, N'ME', 1)
SET IDENTITY_INSERT [dbo].[FC_MercadoVF] OFF
