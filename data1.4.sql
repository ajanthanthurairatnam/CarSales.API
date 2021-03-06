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
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_VehicleModel_VehicleMake]') AND parent_object_id = OBJECT_ID(N'[dbo].[VehicleModel]'))
ALTER TABLE [dbo].[VehicleModel] DROP CONSTRAINT [FK_VehicleModel_VehicleMake]
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
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]'))
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]'))
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_VehicleAdvertisement_Archived]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT [DF_VehicleAdvertisement_Archived]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_VehicleAdvertisement_Sold]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT [DF_VehicleAdvertisement_Sold]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_VehicleAdvertisement_Transmission]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT [DF_VehicleAdvertisement_Transmission]
END

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_VehicleAdvertisement_IsFeatured]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[VehicleAdvertisement] DROP CONSTRAINT [DF_VehicleAdvertisement_IsFeatured]
END

GO
/****** Object:  Index [UserNameIndex]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUsers]') AND name = N'UserNameIndex')
DROP INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
GO
/****** Object:  Index [IX_UserId]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND name = N'IX_UserId')
DROP INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
GO
/****** Object:  Index [IX_RoleId]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND name = N'IX_RoleId')
DROP INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
GO
/****** Object:  Index [IX_UserId]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND name = N'IX_UserId')
DROP INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
GO
/****** Object:  Index [IX_UserId]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND name = N'IX_UserId')
DROP INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoles]') AND name = N'RoleNameIndex')
DROP INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[ViewPortSetting]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewPortSetting]') AND type in (N'U'))
DROP TABLE [dbo].[ViewPortSetting]
GO
/****** Object:  Table [dbo].[ViewPort]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ViewPort]') AND type in (N'U'))
DROP TABLE [dbo].[ViewPort]
GO
/****** Object:  Table [dbo].[VehicleSeller]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleSeller]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleSeller]
GO
/****** Object:  Table [dbo].[VehicleModel]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleModel]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleModel]
GO
/****** Object:  Table [dbo].[VehicleMake]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleMake]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleMake]
GO
/****** Object:  Table [dbo].[VehicleFuel]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleFuel]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleFuel]
GO
/****** Object:  Table [dbo].[VehicleBody]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleBody]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleBody]
GO
/****** Object:  Table [dbo].[VehicleAdvertisement]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleAdvertisement]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleAdvertisement]
GO
/****** Object:  Table [dbo].[Seller]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Seller]') AND type in (N'U'))
DROP TABLE [dbo].[Seller]
GO
/****** Object:  Table [dbo].[ConfigSetting]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConfigSetting]') AND type in (N'U'))
DROP TABLE [dbo].[ConfigSetting]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUsers]') AND type in (N'U'))
DROP TABLE [dbo].[AspNetUsers]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
DROP TABLE [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND type in (N'U'))
DROP TABLE [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND type in (N'U'))
DROP TABLE [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoles]') AND type in (N'U'))
DROP TABLE [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__MigrationHistory]
GO
USE [master]
GO
/****** Object:  Database [CarSalesDB]    Script Date: 1/30/2018 11:32:44 PM ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'CarSalesDB')
DROP DATABASE [CarSalesDB]
GO
/****** Object:  Database [CarSalesDB]    Script Date: 1/30/2018 11:32:44 PM ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'CarSalesDB')
BEGIN
CREATE DATABASE [CarSalesDB] ON  PRIMARY 
( NAME = N'CarSalesDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS01\MSSQL\DATA\CarSalesDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarSalesDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS01\MSSQL\DATA\CarSalesDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
END

GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarSalesDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarSalesDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarSalesDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarSalesDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarSalesDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarSalesDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarSalesDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarSalesDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarSalesDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarSalesDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarSalesDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarSalesDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarSalesDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarSalesDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarSalesDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarSalesDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarSalesDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarSalesDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarSalesDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarSalesDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarSalesDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarSalesDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarSalesDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarSalesDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarSalesDB] SET  MULTI_USER 
GO
ALTER DATABASE [CarSalesDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarSalesDB] SET DB_CHAINING OFF 
GO
USE [CarSalesDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CarSalesDB]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 1/30/2018 11:32:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/30/2018 11:32:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/30/2018 11:32:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/30/2018 11:32:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/30/2018 11:32:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/30/2018 11:32:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUsers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ConfigSetting]    Script Date: 1/30/2018 11:32:44 PM ******/
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
/****** Object:  Table [dbo].[Seller]    Script Date: 1/30/2018 11:32:44 PM ******/
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
	[AspNetUsersId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_Seller] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VehicleAdvertisement]    Script Date: 1/30/2018 11:32:44 PM ******/
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
	[DateAdvertised] [datetime] NULL,
	[Sold] [bit] NOT NULL,
	[Archived] [bit] NOT NULL,
 CONSTRAINT [PK_VehicleAdvertisement] PRIMARY KEY CLUSTERED 
(
	[Reference_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[VehicleBody]    Script Date: 1/30/2018 11:32:44 PM ******/
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
/****** Object:  Table [dbo].[VehicleFuel]    Script Date: 1/30/2018 11:32:44 PM ******/
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
/****** Object:  Table [dbo].[VehicleMake]    Script Date: 1/30/2018 11:32:44 PM ******/
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
/****** Object:  Table [dbo].[VehicleModel]    Script Date: 1/30/2018 11:32:44 PM ******/
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
/****** Object:  Table [dbo].[VehicleSeller]    Script Date: 1/30/2018 11:32:44 PM ******/
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
/****** Object:  Table [dbo].[ViewPort]    Script Date: 1/30/2018 11:32:44 PM ******/
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
/****** Object:  Table [dbo].[ViewPortSetting]    Script Date: 1/30/2018 11:32:44 PM ******/
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
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201801210800252_InitialCreate', N'Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext', 0x1F8B0800000000000400DD5CDD6EDC3616BE2FD0771074D52DDC917F3641D6182770C7766B6CFC838C53EC5DC09138632112A58A9463A3E893F5A28FB4AFB0A44469448AD4501A8D465E14483322F99DC3C343F2F0F063FEFBD7DFD30FCF61603DC104FB113AB38F2687B605911B793E5A9DD92959FEF4CEFEF0FEFBEFA6975EF86CFD56D43B61F5684B84CFEC4742E253C7C1EE230C019E84BE9B44385A92891B850EF022E7F8F0F05FCED1910329844DB12C6BFA2945C40F61F683FE9C45C88531494170137930C0FC3B2D9967A8D62D08218E810BCFEC9B12FF1CC7B7904CAE3D48C1C8CBE432FBDF5542EB7E8B92AFB6751EF8802A3887C1D2B60042110184AA7FFA19C3394922B49AC7F403081E5E6248EB2D418021EFD6E9BABA690F0F8F590F9D75C302CA4D3189C296804727DC648EDCBC93E1EDD2A4D4A8B9A158AF33C39ED985093F450135802CF0741624AC720BDB4FAA88079671BB83D2C58E2787ECBF036B9606244DE019822949407060DDA78BC077FF0D5F1EA2AF109D9D1C2D9627EFDEBC05DEC9DB7FC29337D59ED2BED27AC207FAE93E89629850DDE0B2ECBF6D39623B476E5836ABB4C9AD427D89CE16DBBA01CF1F215A91473A8F8EDFD9D695FF0CBDE20B77AECFC8A7938B3622494A7FDEA6410016012CCB9D4699ECCF06A9C76FDEF622F5163CF9AB6CE825F974E224D8B63EC1202BC58F7E9C4F2F61BCBFF06A574914B2DFA27FE5A55FE6519AB8AC3391B6CA0348569088DA4D9DB5F31AB93483EADFAD0BD4F1BB36D3B4EEDECAAAAC435D66422162E8D950E8BB5BB99D3CAE7F6F1BBFA7BD9645F432047ED0C32A6A2085C6354B3F0961D9CB9F23EAB300B5D6F91E604C87D6FB15E0C706D5E95F7B507D0EDD34A10E3527208C772EEDFE3142F0360D176CD60C27ABB7A179F8165D019744C92562ADB6C6FB18B95FA3945C22EF0210F899B80520FBF9E087E600BDA873EEBA10E32BEACCD09B45346C2F00AF1139396E0DC796B27D4731B300F8617318C3D4FC52D4ABC73195626D2053ADA38A649A34FC18AD7C64A061514FA3615EDCAC21AFD356438664A020AFA6D12F2B6D562FAFD25B24988D47FF9B7306FBFFBE43EB267CC58C73BA0CC25F2082095DABBC7B40084CD07A044C16877D4404D9F031A13BDF803249BF8120ED5B54A7D990CDFDFE6743063BFED990A9493F3FF91E0B3D0C0E4845650A6F545F7DF6DA3CE724CD869E0E423787163ECC1AA09B2EE71847AE9FCD02456A8C273644FD69A0666DCE72E4BD913325B463D4D1FD98BA36FD42FB66CB4E75872E600009B4CEDD3C753803D8055EDD8CB4435E0BC58A1D55A1D83A63222AF7634D26F57498B046809D74309DA93E22F569E123D78F41B0D14A524BC32D8CF5BD9421975CC018222670A3254C84AB13244C81528E34289B2C34752A1E67E688D5D074D3802BE354F5880FEC8AAAE858A3198FD976EA8C0A430DE88D0A639848D7A6F60677477E0E311A74F950321E77948E421ACD78D0B47B77140D35B43B8AC6785DEE989F3A8DC65C3A828EC719C583EFFEB6E9BA9586F644C1122373C43C8AA46D086D0113C9192F16AC043E13C5198B2AC98F599847ACB25B3084392462C2651DB62AC349A71944F69D26C0B57F6D00E5B77D8D40AD342BF26E8D883C2A68015B24CB1A61F9EA2EC15646BF8E5DBDF2AC54D45F8CCA6E697482287B56BA42CDBD8D02FE0A8EC21BE4D54AEC780BA3080954BD55B4C1AC71385BE90F1F0303BBA8A24F8D618A3EF46B99C2173758461557194756DD2D2305421ACB147DE8D732DC11371846B1C39BEEF1DDCD226EC93D4DA4221351EE2165D9D4C9C94FFCC3D4D1B0A4A637208E7DB4AAB0A6F8176B9E53A6663FCDDB9386C21CC371B1823B546A5B4A22510256502AA5A2A9A6577E82C905206001581E66E685B56AF51D53B3AE17F2AA9B627DF88A05BEA8CDFE9EB7E8C66052841D1C9AD65F852C70C952DF0A9F5037B718B30D04205164DB67519086481F47E95BE7176BD5F6F9973AC2D491F4AF854A3523D6E25871448CC6AB3E51763B76650CD37DFCF410BA5128C2CFEA38E842523D4A916BAAA2E8F24F7B1B4F5D3CD3F7186E397E43CD3FCE2CA902F04F2D312AE4841A58A5CC1C55E48F5431C512734489245285948A5A6859A582084A560B3AE1692CAAAE612EA14EFEA8A2D74BCD911534902AB4A2B803B64267B9CC1C55C114A9022B8ACDB1D7B41179551DF10EA73DD7F4BD3CE667E1EDD6480DC66E16CA7EB6C8CAB57D15A8F2B92516BF98AF81F1EFA37432ED11B16F27CB3323DB39990643BF4E09F7E0E232D57879AFC7142EB785ADA0E9725F8FD7CE9577EA30B5A3A45CA5945E1E29A5A3E3941FE336BFC2A99DEBF22AB655989186012F98C070C22A4CE6BF07B3C0876CD12F2ADC00E42F212639A1C33E3E3C3A965EEC8CE7F58C83B117B47842238ED900DC2CF40412F7112475A6C4162F4CD6A0B5ECF535F2E0F399FD47D6EA344B96B0BF659F0FAC6BFC19F9BFA7B4E02149A1F5679DDED93FE3BEABDD077F1F616ED5EBFF7CC99B1E5877099D31A7D6A164CB2E232CBE9A68A54DDE740B6DBABDA578BDB349786AA044956643F797050B9FF4F2AAA0D0F287103CFFA3AD6ACA97035B212A5E07F485D78B0975ECFF2E585AE6BF477F928CF9DFAEB3EA97005D54D3BE02F0517B30F90D80F91A54B4DCE33EA338270DB1246576DE48AFDE8A6BB9EF8DA9C6C2DE6AA2D799D62DE0B6605377F08C574644EE6D7754F08C7BC3DEA76BEF9C5C3C163EF19A22B25F1AF1D094246399AF92303C261A1C67F9EC99193CB47FE9F2B963E65CB6A0008FC9C138DF6BCF5CDFA11D4C97CB1DB38399937AC7E45FFBDE1EF7E15DC6DBE3DE89BA757692E6FE4595E4DDC4C5CD33E2F4F4BE88A807E4D1627EE1A2E688E984AD3D452B705D452F544F4E6B12BC91D7DB2CB09D30BE9F374AE4759AC56A489B4DB2F952DF289BD76996ADA145EE8342AC2429AA38DD1B962FCD6D9E921D3E42CAB0B603C666101C537375FE0A18C2DB1B4298259AEBDDD11382B737439FD3A20501B87E3B4B77C4CABFA4487765ECAFD610ECDF5544D015F6C2B2CE355A46C5962C69545491722A3790008F6E94E709F197C025B4986585B307DA59A68DDD4D2CA0778DEE5212A7847619868B404851B1ADBD497EC67216759EDEC5D93F31D24717A89A3ECBA6DFA19F533FF04ABDAF14591C0D048B19780E968D2561B9D8D54B89741B2143206EBE32D47980611C50307C87E6E00976D18DBADF47B802EECB3A67A703D93C10A2D9A7173E582520C41C63DD9EFEA43EEC85CFEFFF07D8F4487350540000, N'6.1.3-40302')
INSERT [dbo].[AspNetUserLogins] ([LoginProvider], [ProviderKey], [UserId]) VALUES (N'Google', N'111403723795691239967', N'6cf4cc63-9b91-4aa7-ab76-b7f814b63dc2')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'190ceaad-16e2-457c-8f5a-3178d590da2f', N'ajanthan.ktt@gmail.com', 0, N'AEkDdgZBbrns0IgFKyblI7am1eNAtl5mOIsuuzhslF42rpD0JNHva16fs1dmOoibMQ==', N'ea827c89-e0b8-45a2-b035-985a923a48cd', NULL, 0, 0, NULL, 1, 0, N'ajanthan.ktt@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5999b474-5d13-44b7-8892-b5ad52a5e434', N'ajanthan2019@outlook.com', 0, N'AApzBc8MBpPxbUnBrBmlgZOFDzkG/W/sjvc927J8ciF25n6cCUI8kJB2DzsScUw2eQ==', N'86cabe09-b1b5-422c-8a5e-3c2b69ec11a8', NULL, 0, 0, NULL, 1, 0, N'ajanthan2019@outlook.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'648c88d2-af15-4426-9023-76ae0ad2c1b7', N'ajanthan61@gmail.com', 0, N'AAoJK88gtI6BbsYYHSvOG04QHyf71x9y4VQRvyXb/uUEsD1v0tynpBRz62XTobgVSA==', N'f07fd5fb-22bb-4fd3-9d01-230294c1ebe5', NULL, 0, 0, NULL, 1, 0, N'ajanthan61@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6cf4cc63-9b91-4aa7-ab76-b7f814b63dc2', N'ajanthan.kt@gmail.com', 0, N'ABvVITmAh2N6ycY38Q4U8aMFv14p6toRualwyTVmxkCUuLN51qRmVPXNmlOMg2OYJw==', N'1b496402-ce7b-44da-9f6b-e8af6c74925b', NULL, 0, 0, CAST(N'2018-01-26T21:50:57.907' AS DateTime), 0, 0, N'ajanthan.kt@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7ad9d969-2f05-4668-859a-96fb62ca5bd8', N'ajanthan3@gmail.com', 0, N'ALAAOLbWNpq5C5aQnK3JvNlYYHDhx0HcoUe9lnHbmjspLXNnRXQqDuYYppFOaYa8Zg==', N'24cef4ab-31dd-4fb5-9310-3f261fbef78b', NULL, 0, 0, NULL, 1, 0, N'ajanthan3@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7d4879f6-c4ea-44ab-b7e9-7cd11d3618b3', N'samith@q2soft.lk', 0, N'AA/kQAyCKH6RBBoeaZNSMKrsPOtZCdW1tQHwVvpDkRSgdyQH1/Ryq4jENowC6TEYsg==', N'2c48096e-1035-4bdd-9609-f2cc5a2bb519', NULL, 0, 0, NULL, 1, 0, N'samith@q2soft.lk')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7ff376cd-5ab6-4d2f-aa27-c4639d283be2', N'ajanthan5@gmail.com', 0, N'AE4q0s0sDKWAib+i74+/53YxqDRSFGZ82CssmUaLfAcqZXKHbk6wW5LWyE6d400yLw==', N'1bd487ce-3ae8-42b1-bbca-ba6585402e94', NULL, 0, 0, NULL, 1, 0, N'ajanthan5@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9accd3fc-9188-4148-92a8-9020705b188d', NULL, 0, N'ALK7It2V7MP+yehdR1Vlw9FPvD0XaxHyHbSzgxiMzoJgNdGCf59crYoNqGO/rGL+Dg==', N'f3acf03c-5d90-4efc-8e54-4d5f0c8222c0', NULL, 0, 0, NULL, 0, 0, N'ajanthan')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9f765bdb-351c-4bc6-800d-5cb1d715d7f3', N'ajanthan2@gmail.com', 0, N'AHocAgDIXZlV02pjOVwrZERM1ZpfQeu1BZN+oO1FBcklx0T/Sil8rOCkCwptzbgRdg==', N'3899d77a-8b1a-4be4-b314-d80af9396605', NULL, 0, 0, NULL, 1, 0, N'ajanthan2@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a9ba2e11-7769-449e-8134-5e6763c69206', N'ajanthan2018@outlook.com', 0, N'ADYujc6JYOHscD6BYa/MxHANHgfh4yJ9KotUgPJXZA0g94tB7Z0Ra9G94Hr/sAgX4w==', N'48b55ca6-f538-43bd-992c-cb4465859a64', NULL, 0, 0, NULL, 1, 0, N'ajanthan2018@outlook.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bc46df88-4c6f-495c-a7ef-c9c2417d58ff', N'ajanthan2020@outlook.com', 0, N'AF0sAc86h523gSFPHqiqRy5BEchSe1erulX9GFJvnFVhPnAVWGX/p+cbQX1ZtZd1wQ==', N'60492375-a9fb-4a34-95c4-26066ee7def1', NULL, 0, 0, NULL, 1, 0, N'ajanthan2020@outlook.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd22b5a4c-2bd7-4b67-a9ca-fd27a99c0403', N'ajanthan6@gmail.com', 0, N'AAfYbcApwE7DvL8TWiD6tooqCj4ioKFF4EBqzhxSwlmeG5zL7J5rVHq3hCTzN7u6tg==', N'96417e00-8a65-430e-90cb-36ba86b7c92a', NULL, 0, 0, NULL, 1, 0, N'ajanthan6@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dc4c0194-a047-4ebc-9b5c-e588d50cadbd', N'ajanthan1@gmail.com', 0, N'AOvcl7kxLxta/IkLAdmhsdflpVPDw/vaP5AA4o8NfNFnHA5ETiN9r4KAdluOsDzcFA==', N'07614d16-9020-4d92-a43f-c842e054f4a8', NULL, 0, 0, NULL, 1, 0, N'ajanthan1@gmail.com')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'df7a8c08-d514-4553-93bf-134a6065a242', N'samitha@q2soft.lk', 0, N'AOHs1u/VKA2iSMz/Hn1NMF5KDdVL1uyw1vxqQgTrOyeuQ8UbHLWDOsm8B5NZ0+F5nA==', N'e34436bd-8cd2-4e53-844f-7cfadbb83881', NULL, 0, 0, CAST(N'2018-01-27T22:13:03.987' AS DateTime), 1, 0, N'samitha@q2soft.lk')
SET IDENTITY_INSERT [dbo].[Seller] ON 

INSERT [dbo].[Seller] ([ID], [Name], [ContactPhone], [ContactMobile], [ContactEMail], [PickupAddress], [PostCode], [AspNetUsersId]) VALUES (1, N'ajanthan4', N'04314314', N'04314314', N'ajanthan5@gmail.com', N'soysapura', N'3124', N'7ff376cd-5ab6-4d2f-aa27-c4639d283be2')
INSERT [dbo].[Seller] ([ID], [Name], [ContactPhone], [ContactMobile], [ContactEMail], [PickupAddress], [PostCode], [AspNetUsersId]) VALUES (2, N'ajanthan6', N'0406314133', N'0406314133', N'ajanthan6@gmail.com', N'ajanthan6', N'3153', N'd22b5a4c-2bd7-4b67-a9ca-fd27a99c0403')
INSERT [dbo].[Seller] ([ID], [Name], [ContactPhone], [ContactMobile], [ContactEMail], [PickupAddress], [PostCode], [AspNetUsersId]) VALUES (3, N'sam', N'0111111', N'11111', N'samith@q2soft.lk', N'b28/24', N'3124', N'7d4879f6-c4ea-44ab-b7e9-7cd11d3618b3')
INSERT [dbo].[Seller] ([ID], [Name], [ContactPhone], [ContactMobile], [ContactEMail], [PickupAddress], [PostCode], [AspNetUsersId]) VALUES (4, N'samitha', NULL, NULL, N'samitha@q2soft.lk', NULL, NULL, N'df7a8c08-d514-4553-93bf-134a6065a242')
INSERT [dbo].[Seller] ([ID], [Name], [ContactPhone], [ContactMobile], [ContactEMail], [PickupAddress], [PostCode], [AspNetUsersId]) VALUES (5, N'ewewe', N'0406314133', N'0406314133', N'ajanthan61@gmail.com', N'1', N'3124', N'648c88d2-af15-4426-9023-76ae0ad2c1b7')
INSERT [dbo].[Seller] ([ID], [Name], [ContactPhone], [ContactMobile], [ContactEMail], [PickupAddress], [PostCode], [AspNetUsersId]) VALUES (6, N'Aj', N'0406314133', N'0406314133', N'ajanthan2020@outlook.com', N'w', N'1222', N'bc46df88-4c6f-495c-a7ef-c9c2417d58ff')
INSERT [dbo].[Seller] ([ID], [Name], [ContactPhone], [ContactMobile], [ContactEMail], [PickupAddress], [PostCode], [AspNetUsersId]) VALUES (7, N'AJANTHAN', N'0406314133', N'0406314133', N'ajanthan2018@outlook.com', N'Some', N'0314', N'a9ba2e11-7769-449e-8134-5e6763c69206')
SET IDENTITY_INSERT [dbo].[Seller] OFF
SET IDENTITY_INSERT [dbo].[VehicleAdvertisement] ON 

INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (1, N'Car Sale', N'REF0001', CAST(100.00 AS Decimal(18, 2)), 3, 1000, CAST(1000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 1, N'A', NULL, 0, 0)
INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (3, N'AAAA', N'REF0002', CAST(150.00 AS Decimal(18, 2)), 3, 2000, CAST(15000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 0, N'A', NULL, 0, 0)
INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (4, N'BBBB', N'REF0003', CAST(200.00 AS Decimal(18, 2)), 3, 2000, CAST(15000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 1, N'A', NULL, 0, 0)
INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (5, N'BBBB', N'REF0003', CAST(200.00 AS Decimal(18, 2)), 3, 2000, CAST(15000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 1, N'A', NULL, 0, 0)
INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (6, N'Car Sales', N'REF0003', CAST(200.00 AS Decimal(18, 2)), 3, 2000, CAST(15000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 1, N'A', NULL, 0, 0)
INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (7, N'Car Sales', N'REF0003', CAST(200.00 AS Decimal(18, 2)), 3, 2000, CAST(15000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 1, N'A', NULL, 0, 0)
INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (8, N'Car Sales', N'REF0003', CAST(200.00 AS Decimal(18, 2)), 3, 2000, CAST(15000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 1, N'A', NULL, 0, 0)
INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (9, N'Car Sales', N'REF0003', CAST(200.00 AS Decimal(18, 2)), 3, 2000, CAST(15000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 1, N'A', NULL, 0, 0)
INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (10, N'Car Sales', N'REF0003', CAST(200.00 AS Decimal(18, 2)), 3, 2000, CAST(15000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 1, N'A', NULL, 0, 0)
INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (11, N'Car Sales', N'REF0003', CAST(200.00 AS Decimal(18, 2)), 3, 2000, CAST(15000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 1, N'A', NULL, 0, 0)
INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (12, N'Car Sales', N'REF0003', CAST(200.00 AS Decimal(18, 2)), 3, 2000, CAST(15000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 1, N'A', NULL, 0, 0)
INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (13, N'Car Sales', N'REF0003', CAST(200.00 AS Decimal(18, 2)), 3, 2000, CAST(15000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 1, N'A', NULL, 0, 0)
INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (14, N'Car Sales', N'REF0003', CAST(200.00 AS Decimal(18, 2)), 3, 2000, CAST(15000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 1, N'A', NULL, 0, 0)
INSERT [dbo].[VehicleAdvertisement] ([Reference_ID], [Title], [Reference_No], [Price], [BodyType], [EngineCapacity], [AudoMeter], [Fuel], [Description], [Feature], [Spects], [Make], [Model], [IsFeatured], [Transmission], [DateAdvertised], [Sold], [Archived]) VALUES (15, N'Car Sales', N'REF0003', CAST(200.00 AS Decimal(18, 2)), 3, 2000, CAST(15000 AS Decimal(18, 0)), 1, NULL, NULL, NULL, NULL, NULL, 1, N'A', NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[VehicleAdvertisement] OFF
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
SET IDENTITY_INSERT [dbo].[VehicleSeller] ON 

INSERT [dbo].[VehicleSeller] ([ID], [VehicleID], [SellerID]) VALUES (1, 15, 4)
INSERT [dbo].[VehicleSeller] ([ID], [VehicleID], [SellerID]) VALUES (2, 5, 4)
SET IDENTITY_INSERT [dbo].[VehicleSeller] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 1/30/2018 11:32:44 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoles]') AND name = N'RoleNameIndex')
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 1/30/2018 11:32:44 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]') AND name = N'IX_UserId')
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 1/30/2018 11:32:44 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]') AND name = N'IX_UserId')
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 1/30/2018 11:32:44 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND name = N'IX_RoleId')
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 1/30/2018 11:32:44 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]') AND name = N'IX_UserId')
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 1/30/2018 11:32:44 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUsers]') AND name = N'UserNameIndex')
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_VehicleAdvertisement_Sold]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[VehicleAdvertisement] ADD  CONSTRAINT [DF_VehicleAdvertisement_Sold]  DEFAULT ((0)) FOR [Sold]
END

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_VehicleAdvertisement_Archived]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[VehicleAdvertisement] ADD  CONSTRAINT [DF_VehicleAdvertisement_Archived]  DEFAULT ((0)) FOR [Archived]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]'))
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]'))
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]'))
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]'))
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
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
USE [master]
GO
ALTER DATABASE [CarSalesDB] SET  READ_WRITE 
GO
