USE [CarSalesDB]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewPortSetting]') AND type in (N'U'))
ALTER TABLE [dbo].[ViewPortSetting] DROP CONSTRAINT IF EXISTS [FK_ViewPortSetting_ViewPort]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleSeller]') AND type in (N'U'))
ALTER TABLE [dbo].[VehicleSeller] DROP CONSTRAINT IF EXISTS [FK_VehicleSeller_VehicleAdvertisement]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleSeller]') AND type in (N'U'))
ALTER TABLE [dbo].[VehicleSeller] DROP CONSTRAINT IF EXISTS [FK_VehicleSeller_Seller]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleModel]') AND type in (N'U'))
ALTER TABLE [dbo].[VehicleModel] DROP CONSTRAINT IF EXISTS [FK_VehicleModel_VehicleMake]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]') AND type in (N'U'))
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT IF EXISTS [FK_VehicleAdvertisement_VehicleModel]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]') AND type in (N'U'))
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT IF EXISTS [FK_VehicleAdvertisement_VehicleMake]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]') AND type in (N'U'))
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT IF EXISTS [FK_VehicleAdvertisement_VehicleFuel]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]') AND type in (N'U'))
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT IF EXISTS [FK_VehicleAdvertisement_VehicleBody]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]') AND type in (N'U'))
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT IF EXISTS [DF_VehicleAdvertisement_Transmission]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]') AND type in (N'U'))
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT IF EXISTS [DF_VehicleAdvertisement_IsFeatured]
GO
/****** Object:  Table [dbo].[ViewPortSetting]    Script Date: 1/13/2018 7:43:24 PM ******/
DROP TABLE IF EXISTS [dbo].[ViewPortSetting]
GO
/****** Object:  Table [dbo].[ViewPort]    Script Date: 1/13/2018 7:43:24 PM ******/
DROP TABLE IF EXISTS [dbo].[ViewPort]
GO
/****** Object:  Table [dbo].[VehicleSeller]    Script Date: 1/13/2018 7:43:24 PM ******/
DROP TABLE IF EXISTS [dbo].[VehicleSeller]
GO
/****** Object:  Table [dbo].[VehicleModel]    Script Date: 1/13/2018 7:43:24 PM ******/
DROP TABLE IF EXISTS [dbo].[VehicleModel]
GO
/****** Object:  Table [dbo].[VehicleMake]    Script Date: 1/13/2018 7:43:24 PM ******/
DROP TABLE IF EXISTS [dbo].[VehicleMake]
GO
/****** Object:  Table [dbo].[VehicleFuel]    Script Date: 1/13/2018 7:43:24 PM ******/
DROP TABLE IF EXISTS [dbo].[VehicleFuel]
GO
/****** Object:  Table [dbo].[VehicleBody]    Script Date: 1/13/2018 7:43:24 PM ******/
DROP TABLE IF EXISTS [dbo].[VehicleBody]
GO
/****** Object:  Table [dbo].[VehicleAdvertisement]    Script Date: 1/13/2018 7:43:24 PM ******/
DROP TABLE IF EXISTS [dbo].[VehicleAdvertisement]
GO
/****** Object:  Table [dbo].[Seller]    Script Date: 1/13/2018 7:43:24 PM ******/
DROP TABLE IF EXISTS [dbo].[Seller]
GO
/****** Object:  Table [dbo].[ConfigSetting]    Script Date: 1/13/2018 7:43:24 PM ******/
DROP TABLE IF EXISTS [dbo].[ConfigSetting]
GO
/****** Object:  Table [dbo].[ConfigSetting]    Script Date: 1/13/2018 7:43:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConfigSetting]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ConfigSetting](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleAdvertisementNextRefNo] [int] NULL,
 CONSTRAINT [PK_ConfigSetting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Seller]    Script Date: 1/13/2018 7:43:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Seller]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Seller](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[ContactPhone] [varchar](50) NULL,
	[ContactMobile] [varchar](50) NULL,
	[ContactEMail] [varchar](50) NULL,
	[PickupAddress] [varchar](max) NULL,
	[PostCode] [varchar](4) NULL,
 CONSTRAINT [PK_Seller] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VehicleAdvertisement]    Script Date: 1/13/2018 7:43:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VehicleAdvertisement](
	[Reference_ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Reference_No] [varchar](10) NOT NULL,
	[Price] [decimal](18, 2) NULL,
	[BodyType] [int] NULL,
	[EngineCapacity] [int] NULL,
	[AudoMeter] [decimal](18, 0) NULL,
	[Fuel] [int] NULL,
	[Description] [varchar](max) NULL,
	[Feature] [ntext] NULL,
	[Spects] [ntext] NULL,
	[Make] [int] NULL,
	[Model] [int] NULL,
	[IsFeatured] [bit] NOT NULL,
	[Transmission] [varchar](1) NOT NULL,
 CONSTRAINT [PK_VehicleAdvertisement] PRIMARY KEY CLUSTERED 
(
	[Reference_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VehicleBody]    Script Date: 1/13/2018 7:43:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleBody]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VehicleBody](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BodyDescription] [varchar](50) NULL,
	[ImageURL] [varchar](max) NULL,
 CONSTRAINT [PK_VehicleBody] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VehicleFuel]    Script Date: 1/13/2018 7:43:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleFuel]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VehicleFuel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FuelType] [varchar](50) NULL,
 CONSTRAINT [PK_VehicleFuel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VehicleMake]    Script Date: 1/13/2018 7:43:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleMake]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VehicleMake](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleMake] [varchar](50) NULL,
 CONSTRAINT [PK_VehicleMake] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VehicleModel]    Script Date: 1/13/2018 7:43:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleModel]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VehicleModel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleModel] [varchar](50) NULL,
	[VehicleMakeID] [int] NULL,
 CONSTRAINT [PK_VehicleModel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VehicleSeller]    Script Date: 1/13/2018 7:43:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleSeller]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VehicleSeller](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleID] [int] NULL,
	[SellerID] [int] NOT NULL,
 CONSTRAINT [PK_VehicleSeller] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ViewPort]    Script Date: 1/13/2018 7:43:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewPort]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ViewPort](
	[ID] [int] NOT NULL,
	[Description] [varchar](500) NULL,
 CONSTRAINT [PK_ViewPort] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ViewPortSetting]    Script Date: 1/13/2018 7:43:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewPortSetting]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ViewPortSetting](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ViewPortID] [int] NULL,
	[SettingCode] [varchar](50) NULL,
	[PageSize] [int] NULL,
 CONSTRAINT [PK_ViewPortSetting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[VehicleBody] ON 

INSERT [dbo].[VehicleBody] ([ID], [BodyDescription], [ImageURL]) VALUES (1, N'Sedan', NULL)
INSERT [dbo].[VehicleBody] ([ID], [BodyDescription], [ImageURL]) VALUES (2, N'Wagon', NULL)
INSERT [dbo].[VehicleBody] ([ID], [BodyDescription], [ImageURL]) VALUES (3, N'SUV', NULL)
INSERT [dbo].[VehicleBody] ([ID], [BodyDescription], [ImageURL]) VALUES (4, N'Hatchbag', NULL)
INSERT [dbo].[VehicleBody] ([ID], [BodyDescription], [ImageURL]) VALUES (5, N'UTE', NULL)
SET IDENTITY_INSERT [dbo].[VehicleBody] OFF
SET IDENTITY_INSERT [dbo].[VehicleFuel] ON 

INSERT [dbo].[VehicleFuel] ([ID], [FuelType]) VALUES (1, N'Petrol')
INSERT [dbo].[VehicleFuel] ([ID], [FuelType]) VALUES (2, N'Diesel')
INSERT [dbo].[VehicleFuel] ([ID], [FuelType]) VALUES (3, N'Electric')
INSERT [dbo].[VehicleFuel] ([ID], [FuelType]) VALUES (4, N'Hybrid')
SET IDENTITY_INSERT [dbo].[VehicleFuel] OFF
SET IDENTITY_INSERT [dbo].[VehicleMake] ON 

INSERT [dbo].[VehicleMake] ([ID], [VehicleMake]) VALUES (1, N'Toyota')
INSERT [dbo].[VehicleMake] ([ID], [VehicleMake]) VALUES (2, N'Honda')
INSERT [dbo].[VehicleMake] ([ID], [VehicleMake]) VALUES (3, N'Hundai')
INSERT [dbo].[VehicleMake] ([ID], [VehicleMake]) VALUES (4, N'BMW')
INSERT [dbo].[VehicleMake] ([ID], [VehicleMake]) VALUES (5, N'Suzuki')
INSERT [dbo].[VehicleMake] ([ID], [VehicleMake]) VALUES (6, N'Mazda')
INSERT [dbo].[VehicleMake] ([ID], [VehicleMake]) VALUES (7, N'Ben1')
SET IDENTITY_INSERT [dbo].[VehicleMake] OFF
SET IDENTITY_INSERT [dbo].[VehicleModel] ON 

INSERT [dbo].[VehicleModel] ([ID], [VehicleModel], [VehicleMakeID]) VALUES (1, N'Axio', 1)
INSERT [dbo].[VehicleModel] ([ID], [VehicleModel], [VehicleMakeID]) VALUES (2, N'Prius', 1)
INSERT [dbo].[VehicleModel] ([ID], [VehicleModel], [VehicleMakeID]) VALUES (3, N'Corolla', 1)
INSERT [dbo].[VehicleModel] ([ID], [VehicleModel], [VehicleMakeID]) VALUES (4, N'Mazda3', 6)
INSERT [dbo].[VehicleModel] ([ID], [VehicleModel], [VehicleMakeID]) VALUES (5, N'Eon30', 3)
SET IDENTITY_INSERT [dbo].[VehicleModel] OFF
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_VehicleAdvertisement_IsFeatured]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[VehicleAdvertisement] ADD  CONSTRAINT [DF_VehicleAdvertisement_IsFeatured]  DEFAULT ((0)) FOR [IsFeatured]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_VehicleAdvertisement_Transmission]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[VehicleAdvertisement] ADD  CONSTRAINT [DF_VehicleAdvertisement_Transmission]  DEFAULT ('A') FOR [Transmission]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleAdvertisement_VehicleBody]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]'))
ALTER TABLE [dbo].[VehicleAdvertisement]  WITH CHECK ADD  CONSTRAINT [FK_VehicleAdvertisement_VehicleBody] FOREIGN KEY([BodyType])
REFERENCES [dbo].[VehicleBody] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleAdvertisement_VehicleBody]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]'))
ALTER TABLE [dbo].[VehicleAdvertisement] CHECK CONSTRAINT [FK_VehicleAdvertisement_VehicleBody]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleAdvertisement_VehicleFuel]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]'))
ALTER TABLE [dbo].[VehicleAdvertisement]  WITH CHECK ADD  CONSTRAINT [FK_VehicleAdvertisement_VehicleFuel] FOREIGN KEY([Fuel])
REFERENCES [dbo].[VehicleFuel] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleAdvertisement_VehicleFuel]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]'))
ALTER TABLE [dbo].[VehicleAdvertisement] CHECK CONSTRAINT [FK_VehicleAdvertisement_VehicleFuel]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleAdvertisement_VehicleMake]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]'))
ALTER TABLE [dbo].[VehicleAdvertisement]  WITH CHECK ADD  CONSTRAINT [FK_VehicleAdvertisement_VehicleMake] FOREIGN KEY([Make])
REFERENCES [dbo].[VehicleMake] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleAdvertisement_VehicleMake]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]'))
ALTER TABLE [dbo].[VehicleAdvertisement] CHECK CONSTRAINT [FK_VehicleAdvertisement_VehicleMake]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleAdvertisement_VehicleModel]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]'))
ALTER TABLE [dbo].[VehicleAdvertisement]  WITH CHECK ADD  CONSTRAINT [FK_VehicleAdvertisement_VehicleModel] FOREIGN KEY([Model])
REFERENCES [dbo].[VehicleModel] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleAdvertisement_VehicleModel]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]'))
ALTER TABLE [dbo].[VehicleAdvertisement] CHECK CONSTRAINT [FK_VehicleAdvertisement_VehicleModel]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleModel_VehicleMake]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleModel]'))
ALTER TABLE [dbo].[VehicleModel]  WITH CHECK ADD  CONSTRAINT [FK_VehicleModel_VehicleMake] FOREIGN KEY([VehicleMakeID])
REFERENCES [dbo].[VehicleMake] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleModel_VehicleMake]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleModel]'))
ALTER TABLE [dbo].[VehicleModel] CHECK CONSTRAINT [FK_VehicleModel_VehicleMake]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleSeller_Seller]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleSeller]'))
ALTER TABLE [dbo].[VehicleSeller]  WITH CHECK ADD  CONSTRAINT [FK_VehicleSeller_Seller] FOREIGN KEY([SellerID])
REFERENCES [dbo].[Seller] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleSeller_Seller]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleSeller]'))
ALTER TABLE [dbo].[VehicleSeller] CHECK CONSTRAINT [FK_VehicleSeller_Seller]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleSeller_VehicleAdvertisement]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleSeller]'))
ALTER TABLE [dbo].[VehicleSeller]  WITH CHECK ADD  CONSTRAINT [FK_VehicleSeller_VehicleAdvertisement] FOREIGN KEY([VehicleID])
REFERENCES [dbo].[VehicleAdvertisement] ([Reference_ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleSeller_VehicleAdvertisement]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleSeller]'))
ALTER TABLE [dbo].[VehicleSeller] CHECK CONSTRAINT [FK_VehicleSeller_VehicleAdvertisement]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ViewPortSetting_ViewPort]') AND parent_object_id = OBJECT_ID(N'[dbo].[ViewPortSetting]'))
ALTER TABLE [dbo].[ViewPortSetting]  WITH CHECK ADD  CONSTRAINT [FK_ViewPortSetting_ViewPort] FOREIGN KEY([ID])
REFERENCES [dbo].[ViewPort] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ViewPortSetting_ViewPort]') AND parent_object_id = OBJECT_ID(N'[dbo].[ViewPortSetting]'))
ALTER TABLE [dbo].[ViewPortSetting] CHECK CONSTRAINT [FK_ViewPortSetting_ViewPort]
GO
