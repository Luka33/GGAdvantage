using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Domain.Entities
{
    public class AuctionDailyStatisticRealmAssoc
    {
        public Guid Id { get; set; }
        public Guid AuctionDailyStatisticId { get; set; }
        public Guid RealmId { get; set; }
        public DateTime CreatedOn { get; set; }

        public AuctionDailyStatistic AuctionDailyStatistic { get; set; }
        public Realm Realm { get; set; }
    }
}
