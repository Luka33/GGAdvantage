USE [master]
GO
/****** Object:  Database [GGAdvantage]    Script Date: 11/18/2019 10:04:05 AM ******/
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
/****** Object:  Table [dbo].[DailyAuctionStatistic]    Script Date: 11/18/2019 10:04:05 AM ******/
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
	[RealmId] [uniqueidentifier] NOT NULL,
	[ItemId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [IX_DailyAuctionStatistic_Date] UNIQUE CLUSTERED 
(
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 11/18/2019 10:04:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Id] [uniqueidentifier] NOT NULL,
	[ItemID] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Icon] [varchar](200) NOT NULL,
	[ItemSubclassId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemClass]    Script Date: 11/18/2019 10:04:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemClass](
	[Id] [uniqueidentifier] NOT NULL,
	[ClassID] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_ItemClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemSubclass]    Script Date: 11/18/2019 10:04:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemSubclass](
	[Id] [uniqueidentifier] NOT NULL,
	[SubclassID] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[ItemClassId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ItemSubclass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Realm]    Script Date: 11/18/2019 10:04:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Realm](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[RegionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [IX_Realms_Name] UNIQUE CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 11/18/2019 10:04:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[Id] [uniqueidentifier] NOT NULL,
	[ShortName] [varchar](2) NOT NULL,
	[Name] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Item] ([Id], [ItemID], [Name], [Icon], [ItemSubclassId]) VALUES (N'3057b9e2-2281-40a2-8af0-708a975aba88', 124104, N'Fjarnskaggl', N'inv_herbalism_70_fjarnskaggl', N'06e966c5-7ae2-4b3e-bf71-15276174f3fc')
GO
INSERT [dbo].[Item] ([Id], [ItemID], [Name], [Icon], [ItemSubclassId]) VALUES (N'ece46f51-27a1-488e-852e-f43b611962b3', 124105, N'Starlight Rose', N'inv_herbalism_70_starlightrosepetals', N'06e966c5-7ae2-4b3e-bf71-15276174f3fc')
GO
INSERT [dbo].[Item] ([Id], [ItemID], [Name], [Icon], [ItemSubclassId]) VALUES (N'8ee1ea32-1f39-4a3e-b80d-f9cb4ce160a7', 129287, N'Fjarnskaggl Seed', N'inv_farm_pumpkinseed_yellow', N'06e966c5-7ae2-4b3e-bf71-15276174f3fc')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'05ffb336-f1a6-4e48-82b5-153782322c10', 11, N'Quiver')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'3a5d0871-dca2-4dfb-b435-2d9019826713', 18, N'WoW Token')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'df2d012a-46c0-4ed2-8d97-35eacd979017', 6, N'Projectile')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'2c891695-ae4c-4b43-8f91-3ca98eecb79e', 9, N'Recipe')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'd4ab4c90-910e-40c2-a760-4d85c7aca63a', 15, N'Miscellaneous')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'04cc7608-e240-4115-86ef-57a63647bdc3', 3, N'Gem')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'daf4c30f-923e-45b5-a871-58cb946152ee', 16, N'Glyph')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'610c4f8a-6b12-4951-bbd0-6882cb419e4e', 12, N'Quest')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'6d6cbcb2-90be-4ca1-8fa0-69777ba327cb', 1, N'Container')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'24d8ae4b-c1c3-4b05-a5e5-89200a0ab7fd', 0, N'Consumable')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'90a717ac-f881-434f-8e4a-8cef8b990031', 7, N'Tradeskill')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'9f7aeb6b-4894-4c37-a61f-a660e4fd2ff6', 17, N'Battle Pets')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'8800e048-634a-422a-8297-b3b6081535ff', 13, N'Key')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'dd2b8d06-866d-40b6-a16c-e4f3913f84ff', 4, N'Armor')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'c7afad3d-1b00-4c34-8a8b-f0fe3fb8b891', 5, N'Reagent')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'c6aa9399-ffc8-4382-b885-fa1d2699fc8e', 2, N'Weapon')
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (N'2a782e51-436c-4838-ad51-0eb601367c84', 2, N'Elixir', N'24d8ae4b-c1c3-4b05-a5e5-89200a0ab7fd')
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (N'06e966c5-7ae2-4b3e-bf71-15276174f3fc', 9, N'Herb', N'90a717ac-f881-434f-8e4a-8cef8b990031')
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (N'c0a90ff4-9498-4f91-ab1c-1c285a9f2d6b', 1, N'Potion', N'24d8ae4b-c1c3-4b05-a5e5-89200a0ab7fd')
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (N'30d8ce29-a2db-4acc-b4fe-7fc19ccf5e3e', 0, N'Explosives and Devices', N'24d8ae4b-c1c3-4b05-a5e5-89200a0ab7fd')
GO
INSERT [dbo].[Realm] ([Id], [Name], [RegionId]) VALUES (N'dd9977af-f40e-484e-8d99-d3ecdb22176d', N'Argent Dawn', N'db43804c-b5d9-473e-a0c8-a79e3e365ab8')
GO
INSERT [dbo].[Realm] ([Id], [Name], [RegionId]) VALUES (N'8b8e0644-5ab3-43a2-99f6-b8e16e841857', N'Ravencrest', N'db43804c-b5d9-473e-a0c8-a79e3e365ab8')
GO
INSERT [dbo].[Region] ([Id], [ShortName], [Name]) VALUES (N'31b37faf-c2f5-48a1-b475-1770f5ce80b9', N'US', N'Americas and Oceania')
GO
INSERT [dbo].[Region] ([Id], [ShortName], [Name]) VALUES (N'db43804c-b5d9-473e-a0c8-a79e3e365ab8', N'EU', N'Europe')
GO
INSERT [dbo].[Region] ([Id], [ShortName], [Name]) VALUES (N'0bc35481-b6d0-4c6c-a2c7-da786a436569', N'KR', N'Korea')
GO
INSERT [dbo].[Region] ([Id], [ShortName], [Name]) VALUES (N'062607bf-5b01-4375-831b-e0ce2c86ba40', N'TW', N'Taiwan')
GO
/****** Object:  Index [PK_DailyAuctionStatistic]    Script Date: 11/18/2019 10:04:05 AM ******/
ALTER TABLE [dbo].[DailyAuctionStatistic] ADD  CONSTRAINT [PK_DailyAuctionStatistic] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_Realm]    Script Date: 11/18/2019 10:04:05 AM ******/
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
