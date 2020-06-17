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
    public class RealmRepository : Repository<Realm>, IRealmRepository
    {
        private readonly GGAdventageDbContext _context;

        public RealmRepository(GGAdventageDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Realm> GetByIDAsync(object id)
        {
            IQueryable<Realm> query = _context.Set<Realm>();

            return await query.Include(_ => _.Region).SingleOrDefaultAsync(_ => _.Id == (Guid)id);
        }



        //public async Task<List<Realm>> GetRealmsByRegion(Guid regionId)
        //{
        //    var realmConnectedGroups = await _context.RealmConnectedGroup.Where(_ => _.RegionLUId == regionId).Include(_ => _.Realms).ToListAsync();

        //    var realms = new List<Realm>();

        //    foreach (var group in realmConnectedGroups)
        //    {
        //        if (group.Realms != null)
        //        {
        //            realms.AddRange(group.Realms);
        //        }
        //    }

        //    return realms.OrderBy(_ => _.Name).ToList();
        //}

    }
}
