using GGAdvantage.Application.Models.Auction;
using GGAdvantage.Application.Models.Realm;
using GGAdvantage.Application.Models.Region;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Application.Models.Item
{
    public class ItemWithRealmAuctionDailyStatisticsDto : ItemDto
    {
        public RealmDto Realm { get; set; }
        public List<DateTime> Dates { get; set; }
        public List<long> MeanPrices { get; set; }
        public List<double> MeanQuantities { get; set; }
        public List<AuctionCurrentDto> CurrentAuctions { get; set; }
    }
}
