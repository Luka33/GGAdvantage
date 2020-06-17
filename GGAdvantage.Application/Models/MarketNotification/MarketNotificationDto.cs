using GGAdvantage.Application.Models.Item;
using GGAdvantage.Application.Models.Realm;
using GGAdvantage.Application.Models.Region;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Application.Models.MarketNotification
{
    public class MarketNotificationDto : BaseDto
    {
        public long? Quantity { get; set; }
        public MarketNotificationTypeDto QuantityType { get; set; }
        public long? Price { get; set; }
        public MarketNotificationTypeDto PriceType { get; set; }
        public ItemDto Item { get; set; }
        public RealmDto Realm { get; set; }
        public eActionState ActionState { get; set; }
    }
}
