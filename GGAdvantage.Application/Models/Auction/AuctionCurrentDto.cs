using GGAdvantage.Application.Models.Item;
using GGAdvantage.Application.Models.Realm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Application.Models.Auction
{
    public class AuctionCurrentDto : BaseDto
    {
        public string Owner { get; set; }
        public long? Bid { get; set; }
        public long Buyout { get; set; }
        public int Quantity { get; set; }
        public int AuctionTimeLeftId { get; set; }
        public string AuctionTimeLeft { get; set; }
    }
}
