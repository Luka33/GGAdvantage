using GGAdvantage.Application.Models.Item;
using GGAdvantage.Application.Models.Realm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Application.Models.Auction
{
    public class AuctionDailyStatisticDto : BaseDto
    {
        public List<long> MeanPrices { get; set; }
        public List<int> MeanQuantities { get; set; }
        public List<DateTime> Dates { get; set; }
        public ItemDto Item { get; set; }
        public RealmDto Realm { get; set; }
    }
}
