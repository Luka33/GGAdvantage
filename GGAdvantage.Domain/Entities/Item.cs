using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public Guid ItemSubclassId { get; set; }

        public ItemSubclass ItemSubclass { get; set; }
    }
}
