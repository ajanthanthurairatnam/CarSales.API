USE [CarSalesDB]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ViewPortSetting_ViewPort]') AND parent_object_id = OBJECT_ID(N'[dbo].[ViewPortSetting]'))
ALTER TABLE [dbo].[ViewPortSetting] DROP CONSTRAINT [FK_ViewPortSetting_ViewPort]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleSeller_VehicleAdvertisement]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleSeller]'))
ALTER TABLE [dbo].[VehicleSeller] DROP CONSTRAINT [FK_VehicleSeller_VehicleAdvertisement]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleSeller_Seller]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleSeller]'))
ALTER TABLE [dbo].[VehicleSeller] DROP CONSTRAINT [FK_VehicleSeller_Seller]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleAdvertisement_VehicleModel]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]'))
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT [FK_VehicleAdvertisement_VehicleModel]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleAdvertisement_VehicleMake]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]'))
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT [FK_VehicleAdvertisement_VehicleMake]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleAdvertisement_VehicleFuel]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]'))
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT [FK_VehicleAdvertisement_VehicleFuel]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleAdvertisement_VehicleBody]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]'))
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT [FK_VehicleAdvertisement_VehicleBody]
GO
/****** Object:  Table [dbo].[ViewPortSetting]    Script Date: 1/2/2018 5:55:05 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewPortSetting]') AND type in (N'U'))
DROP TABLE [dbo].[ViewPortSetting]
GO
/****** Object:  Table [dbo].[ViewPort]    Script Date: 1/2/2018 5:55:05 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewPort]') AND type in (N'U'))
DROP TABLE [dbo].[ViewPort]
GO
/****** Object:  Table [dbo].[VehicleSeller]    Script Date: 1/2/2018 5:55:05 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleSeller]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleSeller]
GO
/****** Object:  Table [dbo].[VehicleModel]    Script Date: 1/2/2018 5:55:05 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleModel]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleModel]
GO
/****** Object:  Table [dbo].[VehicleMake]    Script Date: 1/2/2018 5:55:05 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleMake]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleMake]
GO
/****** Object:  Table [dbo].[VehicleFuel]    Script Date: 1/2/2018 5:55:05 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleFuel]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleFuel]
GO
/****** Object:  Table [dbo].[VehicleBody]    Script Date: 1/2/2018 5:55:05 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleBody]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleBody]
GO
/****** Object:  Table [dbo].[VehicleAdvertisement]    Script Date: 1/2/2018 5:55:05 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleAdvertisement]
GO
/****** Object:  Table [dbo].[Seller]    Script Date: 1/2/2018 5:55:05 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Seller]') AND type in (N'U'))
DROP TABLE [dbo].[Seller]
GO
/****** Object:  Table [dbo].[ConfigSetting]    Script Date: 1/2/2018 5:55:05 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConfigSetting]') AND type in (N'U'))
DROP TABLE [dbo].[ConfigSetting]
GO
/****** Object:  Table [dbo].[ConfigSetting]    Script Date: 1/2/2018 5:55:05 AM ******/
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
/****** Object:  Table [dbo].[Seller]    Script Date: 1/2/2018 5:55:05 AM ******/
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
/****** Object:  Table [dbo].[VehicleAdvertisement]    Script Date: 1/2/2018 5:55:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VehicleAdvertisement](
	[Reference_ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Reference_No] [varchar](10) NULL,
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
 CONSTRAINT [PK_VehicleAdvertisement] PRIMARY KEY CLUSTERED 
(
	[Reference_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VehicleBody]    Script Date: 1/2/2018 5:55:05 AM ******/
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
/****** Object:  Table [dbo].[VehicleFuel]    Script Date: 1/2/2018 5:55:05 AM ******/
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
/****** Object:  Table [dbo].[VehicleMake]    Script Date: 1/2/2018 5:55:05 AM ******/
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
/****** Object:  Table [dbo].[VehicleModel]    Script Date: 1/2/2018 5:55:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleModel]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[VehicleModel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleModel] [varchar](50) NULL,
 CONSTRAINT [PK_VehicleModel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VehicleSeller]    Script Date: 1/2/2018 5:55:05 AM ******/
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
/****** Object:  Table [dbo].[ViewPort]    Script Date: 1/2/2018 5:55:05 AM ******/
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
/****** Object:  Table [dbo].[ViewPortSetting]    Script Date: 1/2/2018 5:55:05 AM ******/
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
