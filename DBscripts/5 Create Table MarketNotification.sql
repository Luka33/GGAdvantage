USE [GGAdvantage]
GO
/****** Object:  Table [dbo].[MarketNotification]    Script Date: 6/12/2020 1:42:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarketNotification](
	[Id] [uniqueidentifier] NOT NULL,
	[Quantity] [bigint] NULL,
	[QuantityType] [int] NULL,
	[Price] [bigint] NULL,
	[PriceType] [int] NULL,
	[ItemId] [uniqueidentifier] NOT NULL,
	[RealmId] [uniqueidentifier] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_MarketNotification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MarketNotification]  WITH CHECK ADD  CONSTRAINT [FK_MarketNotification_Item_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO
ALTER TABLE [dbo].[MarketNotification] CHECK CONSTRAINT [FK_MarketNotification_Item_ItemId]
GO
ALTER TABLE [dbo].[MarketNotification]  WITH CHECK ADD  CONSTRAINT [FK_MarketNotification_Realm_RealmId] FOREIGN KEY([RealmId])
REFERENCES [dbo].[Realm] ([Id])
GO
ALTER TABLE [dbo].[MarketNotification] CHECK CONSTRAINT [FK_MarketNotification_Realm_RealmId]
GO
ALTER TABLE [dbo].[MarketNotification]  WITH CHECK ADD  CONSTRAINT [FK_MarketNotification_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[MarketNotification] CHECK CONSTRAINT [FK_MarketNotification_User_UserId]
GO
