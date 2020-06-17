using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Domain.Entities
{
    public class AuctionCurrent
    {
        public Guid Id { get; set; }
        public string Owner { get; set; }
        public long? Bid { get; set; }
        public long Buyout { get; set; }
        public int Quantity { get; set; }
        public int AuctionTimeLeftLUId { get; set; }
        public Guid ItemId { get; set; }

        public AuctionTimeLeftLU AuctionTimeLeftLU { get; set; }
        public Item Item { get; set; }
    }
}
