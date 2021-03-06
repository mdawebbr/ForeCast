USE [DM_PRO]
GO
/****** Object:  Table [dbo].[FC_MeioTransporte]    Script Date: 28/04/2022 09:56:13 ******/
DROP TABLE [dbo].[FC_MeioTransporte]
GO
/****** Object:  Table [dbo].[FC_MeioTransporte]    Script Date: 28/04/2022 09:56:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FC_MeioTransporte](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Icone] [nvarchar](50) NULL,
 CONSTRAINT [PK_FC_MeioTransporte] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FC_MeioTransporte] ON 

INSERT [dbo].[FC_MeioTransporte] ([Id], [Nome], [Icone]) VALUES (1, N'Caminhão', N'fa fa-truck')
INSERT [dbo].[FC_MeioTransporte] ([Id], [Nome], [Icone]) VALUES (2, N'Navio', N'fa fa-ship')
INSERT [dbo].[FC_MeioTransporte] ([Id], [Nome], [Icone]) VALUES (3, N'Trem', N'fa fa-train')
SET IDENTITY_INSERT [dbo].[FC_MeioTransporte] OFF
