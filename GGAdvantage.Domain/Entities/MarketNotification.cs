using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Domain.Entities
{
    public class MarketNotification
    {
        public Guid Id { get; set; }
        public long? Quantity { get; set; }
        public int? QuantityTypeId { get; set; }
        public long? Price { get; set; }
        public int? PriceTypeId { get; set; }
        public Guid ItemId { get; set; }
        public Guid RealmId { get; set; }
        public int UserId { get; set; }

        public Item Item { get; set; }
        public Realm Realm { get; set; }
        public MarketNotificationTypeLU QuantityType { get; set; }
        public MarketNotificationTypeLU PriceType { get; set; }
    }
}
