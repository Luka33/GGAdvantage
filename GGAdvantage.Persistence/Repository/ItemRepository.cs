using GGAdvantage.Application.Interfaces;
using GGAdvantage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace GGAdvantage.Persistence.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private readonly GGAdventageDbContext _context;

        public ItemRepository(GGAdventageDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
