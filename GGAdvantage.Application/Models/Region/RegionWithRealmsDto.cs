using GGAdvantage.Application.Models.Realm;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Application.Models.Region
{
    public class RegionWithRealmsDto : RegionDto
    {
        public List<RealmDto> Realms { get; set; }
    }
}
