using GGAdvantage.Application.Models.Item;
using GGAdvantage.Application.Models.Realm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Application.Models.Auction
{
    public class AuctionDailyStatisticDataJsonDto
    {
        public List<DateTime> Dates { get; set; }
        public List<long> MeanPrices { get; set; }
        public List<double> MeanQuantities { get; set; }
    }
}
