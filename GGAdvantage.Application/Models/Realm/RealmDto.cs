using GGAdvantage.Application.Models.Region;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Application.Models.Realm
{
    public class RealmDto : BaseDto
    {
        public string Type { get; set; }
        public string Population { get; set; }
        public bool Queue { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string BattleGroup { get; set; }
        public string Locale { get; set; }
        public string Timezone { get; set; }
        public List<string> ConnectedRealms { get; set; }
        public RegionDto Region { get; set; }
    }
}
