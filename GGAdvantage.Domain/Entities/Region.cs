using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Domain.Entities
{
    public class Region
    {
        public Guid Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; } 
    }
}