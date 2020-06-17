USE [GGAdvantage]
GO
/****** Object:  Table [dbo].[AuctionCurrent]    Script Date: 6/12/2020 10:22:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuctionCurrent](
	[Id] [uniqueidentifier] NOT NULL,
	[Owner] [nvarchar](100) NOT NULL,
	[Bid] [bigint] NULL,
	[Buyout] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[AuctionTimeLeftLUId] [int] NOT NULL,
	[ItemId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AuctionCurrent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuctionCurrentRealmAssoc]    Script Date: 6/12/2020 10:22:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuctionCurrentRealmAssoc](
	[Id] [uniqueidentifier] NOT NULL,
	[AuctionCurrentId] [uniqueidentifier] NOT NULL,
	[RealmId] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_AuctionCurrentRealmAssoc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuctionDailyStatistic]    Script Date: 6/12/2020 10:22:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuctionDailyStatistic](
	[Id] [uniqueidentifier] NOT NULL,
	[DataJson] [nvarchar](max) NOT NULL,
	[ItemId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AuctionDailyStatistic] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuctionDailyStatisticRealmAssoc]    Script Date: 6/12/2020 10:22:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuctionDailyStatisticRealmAssoc](
	[Id] [uniqueidentifier] NOT NULL,
	[AuctionDailyStatisticId] [uniqueidentifier] NOT NULL,
	[RealmId] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_AuctionDailyStatisticRealmAssoc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuctionTimeLeftLU]    Script Date: 6/12/2020 10:22:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuctionTimeLeftLU](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_AuctionTimeLeftLU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 6/12/2020 10:22:37 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemClass]    Script Date: 6/12/2020 10:22:37 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemSubclass]    Script Date: 6/12/2020 10:22:37 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Realm]    Script Date: 6/12/2020 10:22:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Realm](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [varchar](100) NOT NULL,
	[Population] [varchar](100) NOT NULL,
	[Queue] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Battlegroup] [varchar](100) NOT NULL,
	[Locale] [varchar](100) NOT NULL,
	[Timezone] [varchar](100) NOT NULL,
	[ConnectedRealmsJson] [varchar](max) NOT NULL,
	[RegionLUId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Realm] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegionLU]    Script Date: 6/12/2020 10:22:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegionLU](
	[Id] [uniqueidentifier] NOT NULL,
	[ShortName] [varchar](2) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[SortOrder] [int] NOT NULL,
 CONSTRAINT [PK_RegionLU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuctionCurrent]  WITH CHECK ADD  CONSTRAINT [FK_AuctionCurrent_AuctionTimeLeftLU_AuctionTimeLeftLUId] FOREIGN KEY([AuctionTimeLeftLUId])
REFERENCES [dbo].[AuctionTimeLeftLU] ([Id])
GO
ALTER TABLE [dbo].[AuctionCurrent] CHECK CONSTRAINT [FK_AuctionCurrent_AuctionTimeLeftLU_AuctionTimeLeftLUId]
GO
ALTER TABLE [dbo].[AuctionCurrent]  WITH CHECK ADD  CONSTRAINT [FK_AuctionCurrent_Item_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[AuctionCurrent] CHECK CONSTRAINT [FK_AuctionCurrent_Item_ItemId]
GO
ALTER TABLE [dbo].[AuctionCurrentRealmAssoc]  WITH CHECK ADD  CONSTRAINT [FK_AuctionCurrentRealmAssoc_AuctionCurrent_AuctionCurrentId] FOREIGN KEY([AuctionCurrentId])
REFERENCES [dbo].[AuctionCurrent] ([Id])
GO
ALTER TABLE [dbo].[AuctionCurrentRealmAssoc] CHECK CONSTRAINT [FK_AuctionCurrentRealmAssoc_AuctionCurrent_AuctionCurrentId]
GO
ALTER TABLE [dbo].[AuctionCurrentRealmAssoc]  WITH CHECK ADD  CONSTRAINT [FK_AuctionCurrentRealmAssoc_Realm_RealmId] FOREIGN KEY([RealmId])
REFERENCES [dbo].[Realm] ([Id])
GO
ALTER TABLE [dbo].[AuctionCurrentRealmAssoc] CHECK CONSTRAINT [FK_AuctionCurrentRealmAssoc_Realm_RealmId]
GO
ALTER TABLE [dbo].[AuctionDailyStatistic]  WITH CHECK ADD  CONSTRAINT [FK_DailyAuctionStatistic_Item_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[AuctionDailyStatistic] CHECK CONSTRAINT [FK_DailyAuctionStatistic_Item_ItemId]
GO
ALTER TABLE [dbo].[AuctionDailyStatisticRealmAssoc]  WITH CHECK ADD  CONSTRAINT [FK_AuctionDailyStatisticRealmAssoc_AuctionDailyStatistic_AuctionDailyStatisticId] FOREIGN KEY([AuctionDailyStatisticId])
REFERENCES [dbo].[AuctionDailyStatistic] ([Id])
GO
ALTER TABLE [dbo].[AuctionDailyStatisticRealmAssoc] CHECK CONSTRAINT [FK_AuctionDailyStatisticRealmAssoc_AuctionDailyStatistic_AuctionDailyStatisticId]
GO
ALTER TABLE [dbo].[AuctionDailyStatisticRealmAssoc]  WITH CHECK ADD  CONSTRAINT [FK_AuctionDailyStatisticRealmAssoc_Realm_RealmId] FOREIGN KEY([RealmId])
REFERENCES [dbo].[Realm] ([Id])
GO
ALTER TABLE [dbo].[AuctionDailyStatisticRealmAssoc] CHECK CONSTRAINT [FK_AuctionDailyStatisticRealmAssoc_Realm_RealmId]
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
ALTER TABLE [dbo].[Realm]  WITH CHECK ADD  CONSTRAINT [FK_Realm_RegionLU_RegionLUId] FOREIGN KEY([RegionLUId])
REFERENCES [dbo].[RegionLU] ([Id])
GO
ALTER TABLE [dbo].[Realm] CHECK CONSTRAINT [FK_Realm_RegionLU_RegionLUId]
GO
