using GGAdvantage.Application.Models.Region;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Application.Models.Item
{
    public class ItemDto : BaseDto
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string IconLink { get; set; }
    }
}
