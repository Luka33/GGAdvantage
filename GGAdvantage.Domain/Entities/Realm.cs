using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Domain.Entities
{
    public class Realm
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Population { get; set; }
        public bool Queue { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string BattleGroup { get; set; }
        public string Locale { get; set; }
        public string Timezone { get; set; }
        public string ConnectedrealmsJson { get; set; }
        public Guid RegionId { get; set; }

        public Region Region { get; set; }
    }
}
