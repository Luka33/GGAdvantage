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
    public class MarketNotificationTypeRepository : Repository<MarketNotificationTypeLU>, IMarketNotificationTypeRepository
    {
        private readonly GGAdventageDbContext _context;

        public MarketNotificationTypeRepository(GGAdventageDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
