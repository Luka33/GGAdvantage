using GGAdvantage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GGAdvantage.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IRealmRepository RealmRepository { get; } //example
        IAuctionCurrentRepository AuctionCurrentRepository { get; }
        IAuctionCurrentRealmAssocRepository AuctionCurrentRealmAssocRepository { get; }
        IAuctionDailyStatisticRepository AuctionDailyStatisticRepository { get; }
        IAuctionDailyStatisticRealmAssocRepository AuctionDailyStatisticRealmAssocRepository { get; }
        IAuctionTimeLeftRepository AuctionTimeLeftRepository { get; }
        IItemRepository ItemRepository { get; }
        IItemClassRepository ItemClassRepository { get; }
        IItemSubclassRepository ItemSubclassRepository { get; }
        IRegionRepository RegionRepository { get; }
        IMarketNotificationRepository MarketNotificationRepository { get; }
        IMarketNotificationTypeRepository MarketNotificationTypeRepository { get; }
        Task<bool> SaveAsync();
    }
}

