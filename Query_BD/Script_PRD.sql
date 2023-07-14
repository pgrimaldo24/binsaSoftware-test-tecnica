USE [BinsaSoftwareBD]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 14/07/2023 05:36:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](40) NOT NULL,
	[Domicilio] [nvarchar](40) NOT NULL,
	[CodigoPostal] [nvarchar](40) NOT NULL,
	[Poblacion] [nvarchar](40) NOT NULL,
	[CreatedBy] [varchar](100) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerContact]    Script Date: 14/07/2023 05:36:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerContact](
	[IdCustomer] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[Nombre] [nvarchar](40) NOT NULL,
	[Telefono] [nvarchar](40) NOT NULL,
	[Email] [nvarchar](40) NOT NULL,
	[CreatedBy] [varchar](100) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 
GO
INSERT [dbo].[Client] ([ClientId], [Nombre], [Domicilio], [CodigoPostal], [Poblacion], [CreatedBy], [CreatedAt]) VALUES (2, N'ANGIE ROSMERY ZENON VILLANUEVA', N'JR. ALVARADO 745', N'20043', N'LIMA, LIMA, CALLAO', N'Administrator', CAST(N'2023-07-14T01:05:32.743' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
ALTER TABLE [dbo].[Client] ADD  DEFAULT ('Administrator') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[Client] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[CustomerContact] ADD  DEFAULT ('Administrator') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[CustomerContact] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
