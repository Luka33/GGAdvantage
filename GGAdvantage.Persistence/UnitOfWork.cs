using GGAdvantage.Application.Interfaces;
using GGAdvantage.Persistence.Repository;
using System;
using System.Threading.Tasks;

namespace GGAdvantage.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private GGAdventageDbContext Context;
        private AuctionCurrentRepository _auctionCurrentRepository;
        private AuctionCurrentRealmAssocRepository _auctionCurrentRealmAssocRepository;
        private AuctionDailyStatisticRepository _auctionDailyStatisticRepository;
        private AuctionDailyStatisticRealmAssocRepository _auctionDailyStatisticRealmAssocRepository;
        private AuctionTimeLeftRepository _auctionTimeLeftLURepository;
        private ItemRepository _itemRepository;
        private ItemClassRepository _itemClassRepository;
        private ItemSubclassRepository _itemSubclassRepository;
        private RealmRepository _realmRepository;
        private RegionRepository _regionRepository;
        private MarketNotificationRepository _marketNotificationRepository;
        private MarketNotificationTypeRepository _marketNotificationTypeRepository;

        public UnitOfWork(GGAdventageDbContext context)
        {
            Context = context;
        }

        public IAuctionCurrentRepository AuctionCurrentRepository
        {
            get
            {
                if (_auctionCurrentRepository == null)
                {
                    _auctionCurrentRepository = new AuctionCurrentRepository(Context);
                }
                return _auctionCurrentRepository;
            }
        }
        public IAuctionCurrentRealmAssocRepository AuctionCurrentRealmAssocRepository
        {
            get
            {
                if (_auctionCurrentRealmAssocRepository == null)
                {
                    _auctionCurrentRealmAssocRepository = new AuctionCurrentRealmAssocRepository(Context);
                }
                return _auctionCurrentRealmAssocRepository;
            }
        }
        public IAuctionDailyStatisticRepository AuctionDailyStatisticRepository
        {
            get
            {
                if (_auctionDailyStatisticRepository == null)
                {
                    _auctionDailyStatisticRepository = new AuctionDailyStatisticRepository(Context);
                }
                return _auctionDailyStatisticRepository;
            }
        }
        public IAuctionDailyStatisticRealmAssocRepository AuctionDailyStatisticRealmAssocRepository
        {
            get
            {
                if (_auctionDailyStatisticRealmAssocRepository == null)
                {
                    _auctionDailyStatisticRealmAssocRepository = new AuctionDailyStatisticRealmAssocRepository(Context);
                }
                return _auctionDailyStatisticRealmAssocRepository;
            }
        }
        public IAuctionTimeLeftRepository AuctionTimeLeftRepository
        {
            get
            {
                if (_auctionTimeLeftLURepository == null)
                {
                    _auctionTimeLeftLURepository = new AuctionTimeLeftRepository(Context);
                }
                return _auctionTimeLeftLURepository;
            }
        }
        public IItemRepository ItemRepository
        {
            get
            {
                if (_itemRepository == null)
                {
                    _itemRepository = new ItemRepository(Context);
                }
                return _itemRepository;
            }
        }
        public IItemClassRepository ItemClassRepository
        {
            get
            {
                if (_itemClassRepository == null)
                {
                    _itemClassRepository = new ItemClassRepository(Context);
                }
                return _itemClassRepository;
            }
        }
        public IItemSubclassRepository ItemSubclassRepository
        {
            get
            {
                if (_itemSubclassRepository == null)
                {
                    _itemSubclassRepository = new ItemSubclassRepository(Context);
                }
                return _itemSubclassRepository;
            }
        }
        public IRealmRepository RealmRepository
        {
            get
            {
                if (_realmRepository == null)
                {
                    _realmRepository = new RealmRepository(Context);
                }
                return _realmRepository;
            }
        }
        public IRegionRepository RegionRepository
        {
            get
            {
                if (_regionRepository == null)
                {
                    _regionRepository = new RegionRepository(Context);
                }
                return _regionRepository;
            }
        }
        public IMarketNotificationRepository MarketNotificationRepository
        {
            get
            {
                if (_marketNotificationRepository == null)
                {
                    _marketNotificationRepository = new MarketNotificationRepository(Context);
                }
                return _marketNotificationRepository;
            }
        }
        public IMarketNotificationTypeRepository MarketNotificationTypeRepository
        {
            get
            {
                if (_marketNotificationTypeRepository == null)
                {
                    _marketNotificationTypeRepository = new MarketNotificationTypeRepository(Context);
                }
                return _marketNotificationTypeRepository;
            }
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                var save = await Context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
