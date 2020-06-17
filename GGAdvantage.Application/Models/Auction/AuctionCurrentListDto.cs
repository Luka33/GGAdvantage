using GGAdvantage.Application.Models.Item;
using GGAdvantage.Application.Models.Realm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Application.Models.Auction
{
    public class AuctionCurrentListDto
    {
        public AuctionCurrentDto auctionCurrent { get; set; }
        public ItemDto Item { get; set; }
        public RealmDto Realm { get; set; }
    }
}
