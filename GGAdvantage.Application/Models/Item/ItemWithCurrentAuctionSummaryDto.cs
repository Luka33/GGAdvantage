using GGAdvantage.Application.Models.Region;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Application.Models.Item
{
    public class ItemWithCurrentAuctionSummaryDto : ItemDto
    {
        public int? TotalQuantity { get; set; }
        public long? CurrentPrice { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
