USE [GGAdvantage]
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (1, N'luka', N'LUKA', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEIp5weLT5tl6/VGJTLAx7NZCedMJY+t3MZoQLFYpkfBQE1B2aYnQ1tdTjqnsRsb8pA==', N'SPVRF33MZRYHI4K36NXXM64L2YXDWPGA', N'3d9323b0-0c12-4a12-a909-24e97fea62fb', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
