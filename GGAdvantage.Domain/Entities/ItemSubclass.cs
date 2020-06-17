using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Domain.Entities
{
    public class ItemSubclass
    {
        public ItemSubclass()
        {
            Items = new HashSet<Item>();
        }

        public Guid Id { get; set; }
        public int SubclassID { get; set; }
        public string Name { get; set; }
        public Guid ItemClassId { get; set; }

        public ItemClass ItemClass { get; set; }
        public ICollection<Item> Items { get; private set; }
    }
}
