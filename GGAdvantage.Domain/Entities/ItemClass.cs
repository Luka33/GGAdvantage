using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Domain.Entities
{
    public class ItemClass
    {
        public ItemClass()
        {
            Subclasses = new HashSet<ItemSubclass>();
        }

        public Guid Id { get; set; }
        public int ClassID { get; set; }
        public string Name { get; set; }

        public ICollection<ItemSubclass> Subclasses { get; private set; }
    }
}
