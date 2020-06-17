USE [GGAdvantage]
GO
SET IDENTITY_INSERT [dbo].[AuctionTimeLeftLU] ON 
GO
INSERT [dbo].[AuctionTimeLeftLU] ([Id], [Name], [SortOrder]) VALUES (1, N'VERY_LONG', 3)
GO
INSERT [dbo].[AuctionTimeLeftLU] ([Id], [Name], [SortOrder]) VALUES (2, N'LONG', 2)
GO
INSERT [dbo].[AuctionTimeLeftLU] ([Id], [Name], [SortOrder]) VALUES (3, N'SHORT', 1)
GO
SET IDENTITY_INSERT [dbo].[AuctionTimeLeftLU] OFF
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'2c891695-ae4c-4b43-8f91-3ca98eecb79e', 9, N'Recipe')
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
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'dd2b8d06-866d-40b6-a16c-e4f3913f84ff', 4, N'Armor')
GO
INSERT [dbo].[ItemClass] ([Id], [ClassID], [Name]) VALUES (N'c6aa9399-ffc8-4382-b885-fa1d2699fc8e', 2, N'Weapon')
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (N'e9e93b20-8109-4c8b-95ff-0aba423d72c0', 5, N'Cloth', N'90a717ac-f881-434f-8e4a-8cef8b990031')
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (N'2a782e51-436c-4838-ad51-0eb601367c84', 2, N'Elixir', N'24d8ae4b-c1c3-4b05-a5e5-89200a0ab7fd')
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (N'06e966c5-7ae2-4b3e-bf71-15276174f3fc', 9, N'Herb', N'90a717ac-f881-434f-8e4a-8cef8b990031')
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (N'c0a90ff4-9498-4f91-ab1c-1c285a9f2d6b', 1, N'Potion', N'24d8ae4b-c1c3-4b05-a5e5-89200a0ab7fd')
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (N'c71f74a1-bc0c-4c81-87f5-7853add98999', 6, N'Leather', N'90a717ac-f881-434f-8e4a-8cef8b990031')
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (N'30d8ce29-a2db-4acc-b4fe-7fc19ccf5e3e', 0, N'Explosives and Devices', N'24d8ae4b-c1c3-4b05-a5e5-89200a0ab7fd')
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (N'78525cdc-2845-4af0-ad23-a837d845dec9', 12, N'Enchanting', N'90a717ac-f881-434f-8e4a-8cef8b990031')
GO
INSERT [dbo].[ItemSubclass] ([Id], [SubclassID], [Name], [ItemClassId]) VALUES (N'03911981-3546-4e56-bb16-e2b24b454769', 7, N'Metal & Stone', N'90a717ac-f881-434f-8e4a-8cef8b990031')
GO
INSERT [dbo].[Item] ([Id], [ItemID], [Name], [Icon], [ItemSubclassId]) VALUES (N'3057b9e2-2281-40a2-8af0-708a975aba88', 124104, N'Fjarnskaggl', N'inv_herbalism_70_fjarnskaggl', N'06e966c5-7ae2-4b3e-bf71-15276174f3fc')
GO
INSERT [dbo].[Item] ([Id], [ItemID], [Name], [Icon], [ItemSubclassId]) VALUES (N'ece46f51-27a1-488e-852e-f43b611962b3', 124105, N'Starlight Rose', N'inv_herbalism_70_starlightrosepetals', N'06e966c5-7ae2-4b3e-bf71-15276174f3fc')
GO
INSERT [dbo].[Item] ([Id], [ItemID], [Name], [Icon], [ItemSubclassId]) VALUES (N'8ee1ea32-1f39-4a3e-b80d-f9cb4ce160a7', 129287, N'Fjarnskaggl Seed', N'inv_farm_pumpkinseed_yellow', N'06e966c5-7ae2-4b3e-bf71-15276174f3fc')
GO
INSERT [dbo].[AuctionCurrent] ([Id], [Owner], [Bid], [Buyout], [Quantity], [AuctionTimeLeftLUId], [ItemId]) VALUES (N'85744933-f111-42a5-b005-332bfb903138', N'Arkayn', 126749, 126749, 1, 1, N'3057b9e2-2281-40a2-8af0-708a975aba88')
GO
INSERT [dbo].[AuctionCurrent] ([Id], [Owner], [Bid], [Buyout], [Quantity], [AuctionTimeLeftLUId], [ItemId]) VALUES (N'3ee38eef-df6b-4ae1-8dd8-60b9de0ec313', N'Zaoirse', 99999, 99999, 15, 1, N'3057b9e2-2281-40a2-8af0-708a975aba88')
GO
INSERT [dbo].[AuctionCurrent] ([Id], [Owner], [Bid], [Buyout], [Quantity], [AuctionTimeLeftLUId], [ItemId]) VALUES (N'239d0acf-5d3a-4abf-995d-8300ec2e2bc0', N'Arkayn', 126749, 126749, 1, 1, N'3057b9e2-2281-40a2-8af0-708a975aba88')
GO
INSERT [dbo].[AuctionCurrent] ([Id], [Owner], [Bid], [Buyout], [Quantity], [AuctionTimeLeftLUId], [ItemId]) VALUES (N'1beb07cd-ae2c-4da8-b1af-ee2939878e65', N'Lizardfriend', 120000, 120000, 200, 1, N'3057b9e2-2281-40a2-8af0-708a975aba88')
GO
INSERT [dbo].[RegionLU] ([Id], [ShortName], [Name], [SortOrder]) VALUES (N'31b37faf-c2f5-48a1-b475-1770f5ce80b9', N'US', N'Americas and Oceania', 1)
GO
INSERT [dbo].[RegionLU] ([Id], [ShortName], [Name], [SortOrder]) VALUES (N'db43804c-b5d9-473e-a0c8-a79e3e365ab8', N'EU', N'Europe', 2)
GO
INSERT [dbo].[RegionLU] ([Id], [ShortName], [Name], [SortOrder]) VALUES (N'0bc35481-b6d0-4c6c-a2c7-da786a436569', N'KR', N'Korea', 3)
GO
INSERT [dbo].[RegionLU] ([Id], [ShortName], [Name], [SortOrder]) VALUES (N'062607bf-5b01-4375-831b-e0ce2c86ba40', N'TW', N'Taiwan', 4)
GO
INSERT [dbo].[Realm] ([Id], [Type], [Population], [Queue], [Status], [Name], [Battlegroup], [Locale], [Timezone], [ConnectedRealmsJson], [RegionLUId]) VALUES (N'5b1d6375-5be3-4154-9d58-a75dfddbb31e', N'normal', N'high', 0, 1, N'Aegwynn', N'Misery', N'de_DE', N'Europe/Paris', N'["aegwynn"]', N'db43804c-b5d9-473e-a0c8-a79e3e365ab8')
GO
INSERT [dbo].[Realm] ([Id], [Type], [Population], [Queue], [Status], [Name], [Battlegroup], [Locale], [Timezone], [ConnectedRealmsJson], [RegionLUId]) VALUES (N'e5c4dd9c-d1e9-4051-945d-ec4ad1e55d74', N'roleplaying', N'full', 0, 1, N'Argent Dawn', N'Reckoning / Abrechnung', N'en_GB', N'Europe/Paris', N'["argent-dawn"]', N'db43804c-b5d9-473e-a0c8-a79e3e365ab8')
GO
INSERT [dbo].[Realm] ([Id], [Type], [Population], [Queue], [Status], [Name], [Battlegroup], [Locale], [Timezone], [ConnectedRealmsJson], [RegionLUId]) VALUES (N'e26608c0-bbea-458f-bc6f-1d9f9812cd2b', N'normal', N'full', 0, 1, N'Ravencrest', N'Vengeance / Rache', N'en_GB', N'Europe/Paris', N'["ravencrest"]', N'db43804c-b5d9-473e-a0c8-a79e3e365ab8')
GO
INSERT [dbo].[AuctionCurrentRealmAssoc] ([Id], [AuctionCurrentId], [RealmId], [CreatedOn]) VALUES (N'ecb097b8-c2b6-4d18-9966-02ea4450ea19', N'85744933-f111-42a5-b005-332bfb903138', N'e5c4dd9c-d1e9-4051-945d-ec4ad1e55d74', CAST(N'2019-11-28T12:12:03.5870000' AS DateTime2))
GO
INSERT [dbo].[AuctionCurrentRealmAssoc] ([Id], [AuctionCurrentId], [RealmId], [CreatedOn]) VALUES (N'4d6b3af9-8a33-4408-a4a4-5353669b760c', N'239d0acf-5d3a-4abf-995d-8300ec2e2bc0', N'e5c4dd9c-d1e9-4051-945d-ec4ad1e55d74', CAST(N'2019-11-28T12:12:03.5800000' AS DateTime2))
GO
INSERT [dbo].[AuctionCurrentRealmAssoc] ([Id], [AuctionCurrentId], [RealmId], [CreatedOn]) VALUES (N'5c0f69b0-fbe7-4085-abaf-898361ed7033', N'3ee38eef-df6b-4ae1-8dd8-60b9de0ec313', N'e5c4dd9c-d1e9-4051-945d-ec4ad1e55d74', CAST(N'2019-11-28T12:12:03.5900000' AS DateTime2))
GO
INSERT [dbo].[AuctionCurrentRealmAssoc] ([Id], [AuctionCurrentId], [RealmId], [CreatedOn]) VALUES (N'09f9c7ca-3a40-4e15-b88a-e079f0cc147b', N'1beb07cd-ae2c-4da8-b1af-ee2939878e65', N'e5c4dd9c-d1e9-4051-945d-ec4ad1e55d74', CAST(N'2019-11-28T12:12:03.5930000' AS DateTime2))
GO
INSERT [dbo].[AuctionDailyStatistic] ([Id], [DataJson], [ItemId]) VALUES (N'3a0cf345-6529-4a62-9ec8-30dd617de798', N'{"Dates":["2019-11-13","2019-11-14","2019-11-15","2019-11-16","2019-11-17","2019-11-18","2019-11-19"],"MeanPrices":[112000,130000,170000,128000,162500,118000,124000],"MeanQuantities":[422.22,488.00,888.00,124.50,450.00,456.00,540.00]}
', N'3057b9e2-2281-40a2-8af0-708a975aba88')
GO
INSERT [dbo].[AuctionDailyStatisticRealmAssoc] ([Id], [AuctionDailyStatisticId], [RealmId], [CreatedOn]) VALUES (N'592614da-5e1a-4fe6-8097-89d08657a48f', N'3a0cf345-6529-4a62-9ec8-30dd617de798', N'e5c4dd9c-d1e9-4051-945d-ec4ad1e55d74', CAST(N'2019-11-30T19:11:16.1700000' AS DateTime2))
GO
