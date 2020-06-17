using GGAdvantage.Application.Models.Item;
using GGAdvantage.Application.Models.Realm;
using GGAdvantage.Application.Models.Region;
using GGAdvantage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using GGAdvantage.Application.Models;
using GGAdvantage.Application.Models.Auction;
using System.ComponentModel;
using System.Diagnostics;
using GGAdvantage.Application.Models.MarketNotification;

namespace GGAdvantage.Application
{
    public static class Extensions
    {

        public static RealmDto ToRealmDto(this Realm realm)
        {
            if (realm != null && realm.Region != null)
            {
                return new RealmDto
                {
                    Id = realm.Id,
                    Name = realm.Name,
                    BattleGroup = realm.BattleGroup,
                    Locale = realm.Locale,
                    Population = realm.Population,
                    Queue = realm.Queue,                
                    Status = realm.Status,
                    Timezone = realm.Timezone,
                    Type = realm.Type,
                    ConnectedRealms = JsonConvert.DeserializeObject<List<string>>(realm.ConnectedrealmsJson),
                    Region = realm.Region.ToRegionDto()
                };
            }

            return null;
        }

        public static RegionDto ToRegionDto(this Region region)
        {
            if (region != null)
            {
                return new RegionDto
                {
                    Id = region.Id,
                    ShortName = region.ShortName,
                    Name = region.Name                   
                };
            }

            return null;
        }

        public static AuctionCurrentDto ToAuctionCurrentDto(this AuctionCurrent auctionCurrent)
        {
            try
            {
                return new AuctionCurrentDto
                {
                    Id = auctionCurrent.Id,
                    AuctionTimeLeftId = auctionCurrent.AuctionTimeLeftLUId,
                    AuctionTimeLeft = auctionCurrent.AuctionTimeLeftLU.Name,
                    Bid = auctionCurrent.Bid,
                    Buyout = auctionCurrent.Buyout,
                    Owner = auctionCurrent.Owner,
                    Quantity = auctionCurrent.Quantity
                };
            }
            catch (Exception)
            {

                return null;
            }
        }
        //public static RealmWithRegionDto ToRealmWithRegionDto(this RealmConnectedGroup realmConnectedGroup, Guid realmId)
        //{
        //    if (realmConnectedGroup != null)
        //    {
        //        var region = realmConnectedGroup.Region;
        //        var realm = realmConnectedGroup.Realms.SingleOrDefault(_ => _.Id == realmId);

        //        if (region == null || realm == null)
        //            return null;

        //        return new RealmWithRegionDto
        //        {                 
        //            Id = realm.Id,
        //            Name = realm.Name,
        //            Region = region.ToRegionDto()
        //        };

        //    }

        //    return null;
        //}

        public static RegionWithRealmsDto ToRegionWithRealmsDto(this IList<Realm> realms)
        {
            if (realms != null && realms.Count > 0)
            {
                var region = realms.First().Region;

                if (region == null)
                    return null;

                var regionWithRealmsDto = new RegionWithRealmsDto
                {

                    Id = region.Id,
                    ShortName = region.ShortName,
                    Name = region.Name,
                    Realms = new List<RealmDto>()
                };

                foreach (var realm in realms)
                {
                    var realmDto = new RealmDto
                    {
                        Id = realm.Id,
                        Name = realm.Name
                    };

                    regionWithRealmsDto.Realms.Add(realmDto);

                }

                return regionWithRealmsDto;
            }

            return null;
        }

        public static ItemDto ToItemDto(this Item item)
        {
            if (item != null)
            {
                return new ItemDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    ItemID = item.ItemID,
                    IconLink = string.Format(Constants.ICON_URL_PATH, item.Icon, eIconSize.Large.ToDescriptionString())
                };
            }

            return null;
        }

        public static List<ItemWithCurrentAuctionSummaryDto> ToItemsWithCurrentAuctionSummaryDto(this IList<Item> items, IList<AuctionCurrentRealmAssoc> auctionCurrentRealmAssocs)
        {
            if (items == null || auctionCurrentRealmAssocs == null || auctionCurrentRealmAssocs.Count == 0)
            {
                return null;
            }

            try
            {
                var itemsWithSummary = auctionCurrentRealmAssocs.GroupBy(_ => _.AuctionCurrent.Item).Select(_ => new ItemWithCurrentAuctionSummaryDto
                {
                    Id = _.Key.Id,
                    Name = _.Key.Name,
                    ItemID = _.Key.ItemID,
                    IconLink = string.Format(Constants.ICON_URL_PATH, _.Key.Icon, eIconSize.Large.ToDescriptionString()),
                    TotalQuantity = auctionCurrentRealmAssocs.Where(a => a.AuctionCurrent.Item.Id == _.Key.Id).Sum(a => a.AuctionCurrent.Quantity),
                    CurrentPrice = auctionCurrentRealmAssocs.Select(a => a.AuctionCurrent.Buyout).Min(),
                    CreatedOn = auctionCurrentRealmAssocs.First().CreatedOn
                }).ToList();                

                foreach (var item in items)
                {
                    if (itemsWithSummary.Any(_ => _.Id == item.Id))                   
                       continue;
                    
                    var itemWithCurrentAuctionSummary = new ItemWithCurrentAuctionSummaryDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        ItemID = item.ItemID,
                        IconLink = string.Format(Constants.ICON_URL_PATH, item.Icon, eIconSize.Large.ToDescriptionString())                       
                    };

                    itemsWithSummary.Add(itemWithCurrentAuctionSummary);
                }            

                return itemsWithSummary.OrderBy(_ => _.Name).ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static List<MenuItemDto> ToMenuItemDtos(this IList<ItemClass> classes)
        {
            if (classes == null || classes.Count == 0)
            {
                return null;
            }

            try
            {
                var menuItems = new List<MenuItemDto>();

                foreach (var itemClass in classes)
                {
                    var menuItem = new MenuItemDto
                    {
                        Id = itemClass.Id,
                        Label = itemClass.Name,
                        Items = new List<MenuItemDto>()
                    };

                    if (itemClass.Subclasses.Count > 0)
                    {
                        foreach (var subclass in itemClass.Subclasses)
                        {
                            var subMenuItem = new MenuItemDto
                            {
                                Id = subclass.Id,
                                Label = subclass.Name
                            };
                            menuItem.Items.Add(subMenuItem);
                        }
                    }

                    menuItems.Add(menuItem);
                }

                return menuItems;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static ItemWithRealmAuctionDailyStatisticsDto ToItemWithRealmAuctionDailyStatisticsDto(this AuctionDailyStatisticRealmAssoc assoc)
        {
            if (assoc == null || assoc.AuctionDailyStatistic == null || assoc.Realm == null)
            {
                return null;
            }

            try
            {

                var jsonData = JsonConvert.DeserializeObject<AuctionDailyStatisticDataJsonDto>(assoc.AuctionDailyStatistic.DataJson);


                return new ItemWithRealmAuctionDailyStatisticsDto
                {
                    Id = assoc.AuctionDailyStatistic.Item.Id,
                    Name = assoc.AuctionDailyStatistic.Item.Name,
                    IconLink = string.Format(Constants.ICON_URL_PATH, assoc.AuctionDailyStatistic.Item.Icon, eIconSize.Large.ToDescriptionString()),
                    ItemID = assoc.AuctionDailyStatistic.Item.ItemID,
                    Realm = assoc.Realm.ToRealmDto(),
                    Dates = jsonData.Dates,
                    MeanPrices = jsonData.MeanPrices,
                    MeanQuantities = jsonData.MeanQuantities
                };

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }

        }

        public static ItemWithRealmAuctionDailyStatisticsDto ToItemWithRealmAuctionDailyStatisticsDto(this AuctionDailyStatisticRealmAssoc assoc, List<AuctionCurrent> currentAuctions)
        {
            if (assoc == null || assoc.AuctionDailyStatistic == null || assoc.Realm == null || currentAuctions == null)
            {
                return null;
            }

            try
            {

                var jsonData = JsonConvert.DeserializeObject<AuctionDailyStatisticDataJsonDto>(assoc.AuctionDailyStatistic.DataJson);


                var itemWithRealmAuctionDailyStatisticsDto = new ItemWithRealmAuctionDailyStatisticsDto
                {
                    Id = assoc.AuctionDailyStatistic.Item.Id,
                    Name = assoc.AuctionDailyStatistic.Item.Name,
                    IconLink = string.Format(Constants.ICON_URL_PATH, assoc.AuctionDailyStatistic.Item.Icon, eIconSize.Large.ToDescriptionString()),
                    ItemID = assoc.AuctionDailyStatistic.Item.ItemID,
                    Realm = assoc.Realm.ToRealmDto(),
                    Dates = jsonData.Dates,
                    MeanPrices = jsonData.MeanPrices,
                    MeanQuantities = jsonData.MeanQuantities,
                    CurrentAuctions = new List<AuctionCurrentDto>()
                };

                foreach (var auction in currentAuctions)
                {
                    var aucDto = auction.ToAuctionCurrentDto();

                    if(aucDto != null)
                        itemWithRealmAuctionDailyStatisticsDto.CurrentAuctions.Add(aucDto);
                }


                return itemWithRealmAuctionDailyStatisticsDto;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }

        }

        public static MarketNotificationTypeDto ToMarketNotificationTypeDto(this MarketNotificationTypeLU type)
        {
            if (type != null)
            {
                return new MarketNotificationTypeDto
                {
                    Id = type.Id,
                    Name = type.Name
                };
            }

            return null;
        }

        public static MarketNotificationDto ToMarketNotificationDto(this MarketNotification marketNotification)
        {
            if (marketNotification != null)
            {
                return new MarketNotificationDto
                {
                    Id = marketNotification.Id,
                    Price = marketNotification.Price,
                    PriceType = marketNotification.PriceType.ToMarketNotificationTypeDto(),
                    Quantity = marketNotification.Quantity,
                    QuantityType = marketNotification.QuantityType.ToMarketNotificationTypeDto(),
                    Item = marketNotification.Item.ToItemDto(),
                    Realm = marketNotification.Realm.ToRealmDto(),
                    ActionState = eActionState.None
                };
            }

            return null;
        }

        public static string ToDescriptionString(this Enum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
