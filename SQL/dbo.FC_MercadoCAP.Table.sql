USE [DM_PRO]
GO
/****** Object:  Table [dbo].[FC_MercadoCAP]    Script Date: 28/04/2022 09:56:13 ******/
DROP TABLE [dbo].[FC_MercadoCAP]
GO
/****** Object:  Table [dbo].[FC_MercadoCAP]    Script Date: 28/04/2022 09:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FC_MercadoCAP](
	[MercadoCAPId] [int] IDENTITY(1,1) NOT NULL,
	[Mercado_CAP] [nvarchar](25) NULL,
 CONSTRAINT [PK_FC_FC_MercadoCAP] PRIMARY KEY CLUSTERED 
(
	[MercadoCAPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FC_MercadoCAP] ON 

INSERT [dbo].[FC_MercadoCAP] ([MercadoCAPId], [Mercado_CAP]) VALUES (1, N'MI')
INSERT [dbo].[FC_MercadoCAP] ([MercadoCAPId], [Mercado_CAP]) VALUES (2, N'EX')
INSERT [dbo].[FC_MercadoCAP] ([MercadoCAPId], [Mercado_CAP]) VALUES (3, N'Ovc')
INSERT [dbo].[FC_MercadoCAP] ([MercadoCAPId], [Mercado_CAP]) VALUES (4, N'CHINA')
SET IDENTITY_INSERT [dbo].[FC_MercadoCAP] OFF
