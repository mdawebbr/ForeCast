USE [DM_PRO]
GO
/****** Object:  Table [dbo].[FC_AuxiliarProgecaoDespachos]    Script Date: 28/04/2022 09:56:13 ******/
DROP TABLE [dbo].[FC_AuxiliarProgecaoDespachos]
GO
/****** Object:  Table [dbo].[FC_AuxiliarProgecaoDespachos]    Script Date: 28/04/2022 09:56:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FC_AuxiliarProgecaoDespachos](
	[Cliente_Id] [varchar](10) NOT NULL,
	[Mes] [int] NOT NULL,
	[Ano] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[FC_AuxiliarProgecaoDespachos] ([Cliente_Id], [Mes], [Ano]) VALUES (N'5016', 10, 2021)
INSERT [dbo].[FC_AuxiliarProgecaoDespachos] ([Cliente_Id], [Mes], [Ano]) VALUES (N'5016', 11, 2021)
INSERT [dbo].[FC_AuxiliarProgecaoDespachos] ([Cliente_Id], [Mes], [Ano]) VALUES (N'5016', 12, 2021)
