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
    public class AuctionCurrentRepository : Repository<AuctionCurrent>, IAuctionCurrentRepository
    {
        private readonly GGAdventageDbContext _context;

        public AuctionCurrentRepository(GGAdventageDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
