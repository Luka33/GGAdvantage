using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Domain.Entities
{
    public class AuctionCurrentRealmAssoc
    {
        public Guid Id { get; set; }
        public Guid AuctionCurrentId { get; set; }
        public Guid RealmId { get; set; }
        public DateTime CreatedOn { get; set; } 

        public AuctionCurrent AuctionCurrent { get; set; }
        public Realm Realm { get; set; }
    }
}
