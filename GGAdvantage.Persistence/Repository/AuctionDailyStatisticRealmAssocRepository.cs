using GGAdvantage.Application.Interfaces;
using GGAdvantage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGAdvantage.Persistence.Repository
{
    public class AuctionDailyStatisticRealmAssocRepository : Repository<AuctionDailyStatisticRealmAssoc>, IAuctionDailyStatisticRealmAssocRepository
    {
        private readonly GGAdventageDbContext _context;

        public AuctionDailyStatisticRealmAssocRepository(GGAdventageDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
