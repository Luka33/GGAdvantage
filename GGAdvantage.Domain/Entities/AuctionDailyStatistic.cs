using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Domain.Entities
{
    public class AuctionDailyStatistic
    {
        public Guid Id { get; set; }
        public string DataJson { get; set; }      
        public Guid ItemId { get; set; }

        public Item Item { get; set; }
    }
}
