USE [master]
GO
/****** Object:  Database [GGAdvantage]    Script Date: 11/18/2019 9:12:02 AM ******/
CREATE DATABASE [GGAdvantage]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GGAdvantage', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQL_SERVER_2016\MSSQL\DATA\GGAdvantage.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GGAdvantage_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQL_SERVER_2016\MSSQL\DATA\GGAdvantage_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GGAdvantage] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GGAdvantage].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GGAdvantage] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GGAdvantage] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GGAdvantage] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GGAdvantage] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GGAdvantage] SET ARITHABORT OFF 
GO
ALTER DATABASE [GGAdvantage] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GGAdvantage] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GGAdvantage] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GGAdvantage] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GGAdvantage] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GGAdvantage] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GGAdvantage] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GGAdvantage] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GGAdvantage] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GGAdvantage] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GGAdvantage] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GGAdvantage] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GGAdvantage] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GGAdvantage] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GGAdvantage] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GGAdvantage] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GGAdvantage] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GGAdvantage] SET RECOVERY FULL 
GO
ALTER DATABASE [GGAdvantage] SET  MULTI_USER 
GO
ALTER DATABASE [GGAdvantage] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GGAdvantage] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GGAdvantage] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GGAdvantage] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GGAdvantage] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GGAdvantage] SET QUERY_STORE = OFF
GO
USE [GGAdvantage]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [GGAdvantage]
GO
/****** Object:  Table [dbo].[DailyAuctionStatistic]    Script Date: 11/18/2019 9:12:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyAuctionStatistic](
	[Id] [uniqueidentifier] NOT NULL,
	[MeanPrice] [decimal](11, 2) NOT NULL,
	[StandardDeviationPrice] [decimal](11, 2) NOT NULL,
	[MeanQuantity] [decimal](11, 2) NOT NULL,
	[Date] [date] NOT NULL,
	[RealmId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
 CONSTRAINT [IX_DailyAuctionStatistic_Date] UNIQUE CLUSTERED 
(
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 11/18/2019 9:12:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Icon] [varchar](200) NOT NULL,
	[ItemSubclassId] [int] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemClass]    Script Date: 11/18/2019 9:12:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassID] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_ItemClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemSubclass]    Script Date: 11/18/2019 9:12:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemSubclass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubclassID] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[ItemClassId] [int] NOT NULL,
 CONSTRAINT [PK_ItemSubclass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Realm]    Script Date: 11/18/2019 9:12:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Realm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[RegionId] [int] NOT NULL,
 CONSTRAINT [IX_Realms_Name] UNIQUE CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 11/18/2019 9:12:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [varchar](2) NOT NULL,
	[Name] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Item] ON 
GO
INSERT [dbo].[Item] ([Id], [ItemID], [Name], [Icon], [ItemSubclassId]) VALUES (1, 124104, N'Fjarnskaggl', N'inv_herbalism_70_fjarnskaggl', 4)
GO
INSERT [dbo].[Item] ([Id], [ItemID], [Name], [Icon], [ItemSubclassId]) VALUES (2, 129287, N'Fjarnskaggl Seed', N'inv_farm_pumpkinseed_yellow', 4)
GO
INSERT [dbo].[Item] ([Id], [ItemID], [Name], [Icon], [ItemSubclassId]) VALUES (3, 124105, N'Starlight Rose', N'inv_herbalism_70_starlightrosepetals', 4)
GO
SET IDENTITY_INSERT [dbo].[Item] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemClass] ON 
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (1, 0, N'Consumable')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (2, 1, N'Container')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (3, 2, N'Weapon')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (4, 3, N'Gem')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (5, 4, N'Armor')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (6, 5, N'Reagent')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (7, 6, N'Projectile')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (8, 7, N'Tradeskill')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (9, 9, N'Recipe')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (10, 11, N'Quiver')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (11, 12, N'Quest')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (12, 13, N'Key')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (13, 15, N'Miscellaneous')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (14, 16, N'Glyph')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (15, 17, N'Battle Pets')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (16, 18, N'WoW Token')
GO
SET IDENTITY_INSERT [dbo].[ItemClass] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemSubclass] ON 
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (1, 0, N'Explosives and Devices', 1)
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (2, 1, N'Potion', 1)
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (3, 2, N'Elixir', 1)
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (4, 9, N'Herb', 8)
GO
SET IDENTITY_INSERT [dbo].[ItemSubclass] OFF
GO
SET IDENTITY_INSERT [dbo].[Realm] ON 
GO
INSERT [dbo].[Realm] ([Id], [Name], [RegionId]) VALUES (2, N'Argent Dawn', 1)
GO
INSERT [dbo].[Realm] ([Id], [Name], [RegionId]) VALUES (1, N'Ravencrest', 1)
GO
SET IDENTITY_INSERT [dbo].[Realm] OFF
GO
SET IDENTITY_INSERT [dbo].[Region] ON 
GO
INSERT [dbo].[Region] ([Id], [ShortName], [Name]) VALUES (1, N'EU', N'Europe')
GO
INSERT [dbo].[Region] ([Id], [ShortName], [Name]) VALUES (2, N'US', N'Americas and Oceania')
GO
INSERT [dbo].[Region] ([Id], [ShortName], [Name]) VALUES (1002, N'KR', N'Korea')
GO
INSERT [dbo].[Region] ([Id], [ShortName], [Name]) VALUES (1003, N'TW', N'Taiwan')
GO
SET IDENTITY_INSERT [dbo].[Region] OFF
GO
/****** Object:  Index [PK_DailyAuctionStatistic]    Script Date: 11/18/2019 9:12:02 AM ******/
ALTER TABLE [dbo].[DailyAuctionStatistic] ADD  CONSTRAINT [PK_DailyAuctionStatistic] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DailyAuctionStatistic_ItemID]    Script Date: 11/18/2019 9:12:02 AM ******/
ALTER TABLE [dbo].[DailyAuctionStatistic] ADD  CONSTRAINT [IX_DailyAuctionStatistic_ItemID] UNIQUE NONCLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DailyAuctionStatistic_RealmID]    Script Date: 11/18/2019 9:12:02 AM ******/
ALTER TABLE [dbo].[DailyAuctionStatistic] ADD  CONSTRAINT [IX_DailyAuctionStatistic_RealmID] UNIQUE NONCLUSTERED 
(
	[RealmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_Realm]    Script Date: 11/18/2019 9:12:02 AM ******/
ALTER TABLE [dbo].[Realm] ADD  CONSTRAINT [PK_Realm] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DailyAuctionStatistic]  WITH CHECK ADD  CONSTRAINT [FK_DailyAuctionStatistic_Item_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[DailyAuctionStatistic] CHECK CONSTRAINT [FK_DailyAuctionStatistic_Item_ItemId]
GO
ALTER TABLE [dbo].[DailyAuctionStatistic]  WITH CHECK ADD  CONSTRAINT [FK_DailyAuctionStatistic_Realm_RealmId] FOREIGN KEY([RealmId])
REFERENCES [dbo].[Realm] ([Id])
GO
ALTER TABLE [dbo].[DailyAuctionStatistic] CHECK CONSTRAINT [FK_DailyAuctionStatistic_Realm_RealmId]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_ItemSubclass_ItemSubclassId] FOREIGN KEY([ItemSubclassId])
REFERENCES [dbo].[ItemSubclass] ([Id])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_ItemSubclass_ItemSubclassId]
GO
ALTER TABLE [dbo].[ItemSubclass]  WITH CHECK ADD  CONSTRAINT [FK_ItemSubclass_ItemClass_ItemClassId] FOREIGN KEY([ItemClassId])
REFERENCES [dbo].[ItemClass] ([Id])
GO
ALTER TABLE [dbo].[ItemSubclass] CHECK CONSTRAINT [FK_ItemSubclass_ItemClass_ItemClassId]
GO
ALTER TABLE [dbo].[Realm]  WITH CHECK ADD  CONSTRAINT [FK_Realm_Region_RegionId] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Region] ([Id])
GO
ALTER TABLE [dbo].[Realm] CHECK CONSTRAINT [FK_Realm_Region_RegionId]
GO
USE [master]
GO
ALTER DATABASE [GGAdvantage] SET  READ_WRITE 
GO
