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
    public class AuctionTimeLeftRepository : Repository<AuctionTimeLeftLU>, IAuctionTimeLeftRepository
    {
        private readonly GGAdventageDbContext _context;

        public AuctionTimeLeftRepository(GGAdventageDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
