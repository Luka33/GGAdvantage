using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GGAdvantage.Application;
using GGAdvantage.Application.Interfaces;
using GGAdvantage.Application.Models;
using GGAdvantage.Application.Models.Item;
using GGAdvantage.Application.Models.Realm;
using GGAdvantage.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GGAdvantage.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("{search}")]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetSearchItemsAsync([FromBody] SearchDto searchDto)
        {
            //PropertyInfo filter = typeof(Realm).GetProperty("RegionId");

            var items = await _unitOfWork.ItemRepository.GetAsync(_ => _.Name.Contains(searchDto.name), take: searchDto.Paging, includeExpressions: _ => _.ItemSubclass.ItemClass);

            var data = new List<ItemDto>();

            foreach (var item in items)
            {
                data.Add(item.ToItemDto());
            }

            return Ok(data);
        }


        [HttpGet]
        [Route("subclass/{itemSubclassId}")]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItemsBySubclassAsync(Guid itemSubclassId)
        {
            var items = await _unitOfWork.ItemRepository.GetAsync(_ => _.ItemSubclassId == itemSubclassId);

            var data = new List<ItemDto>();

            foreach (var item in items)
            {
                data.Add(item.ToItemDto());
            }

            return Ok(data);
        }



        [HttpGet]
        [Route("subclass/{itemSubclassId}/with-current-summary")]
        public async Task<ActionResult<IEnumerable<ItemWithCurrentAuctionSummaryDto>>> GetItemsBySubclassWithAuctionCurrentSummaryAsync(Guid itemSubclassId)
        {
            var items = await _unitOfWork.ItemRepository.GetAsync(_ => _.ItemSubclassId == itemSubclassId);

            var auctionCurrentRealmAssocs = await _unitOfWork.AuctionCurrentRealmAssocRepository
                .GetAsync(_ => _.AuctionCurrent.Item.ItemSubclassId == itemSubclassId,
                _ => _.OrderBy(ac => ac.AuctionCurrent.Buyout),
                null,
                _ => _.AuctionCurrent, 
                _ => _.Realm, _ => 
                _.AuctionCurrent.Item);

            return Ok(items.ToItemsWithCurrentAuctionSummaryDto(auctionCurrentRealmAssocs));
        }

        //[HttpGet]
        //[Route("{id}")]
        //public async Task<ActionResult<ItemDto>> GetItemAsync(int id)
        //{
        //    var item = await _unitOfWork.ItemRepository.GetByIDAsync(id);

        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(item.ToItemDto());
        //}

        [HttpGet]
        [Route("sidebar-menu-items")]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetSidebarMenuItemsAsync()
        {
            var itemClasses = await _unitOfWork.ItemClassRepository.GetAsync(orderBy: _ => _.OrderBy(ic => ic.Name), includeExpressions: _ => _.Subclasses);            

            return Ok(itemClasses.ToMenuItemDtos());
        }

        [HttpGet]
        [Route("{id}/realm/{realmId}")]
        public async Task<ActionResult<ItemWithRealmAuctionDailyStatisticsDto>> GetItemWithAuctionDailyStatisticAsync(Guid id, Guid realmId)
        {
            var auctionDailyStatsRealmAssocs = await _unitOfWork.AuctionDailyStatisticRealmAssocRepository.GetAsync(_ => 
                _.RealmId == realmId && _.AuctionDailyStatistic.ItemId == id,
                null, 
                null,
                _ => _.AuctionDailyStatistic,
                _ => _.Realm,
                _ => _.Realm.Region,
                _ => _.AuctionDailyStatistic.Item
            );
            
            return Ok(auctionDailyStatsRealmAssocs.SingleOrDefault().ToItemWithRealmAuctionDailyStatisticsDto());
        }

        [HttpGet]
        [Route("{id}/realm/{realmId}/with-current-auctions")]
        public async Task<ActionResult<ItemWithRealmAuctionDailyStatisticsDto>> GetItemWithCurrentAuctionAndDailyStatisticsAsync(Guid id, Guid realmId)
        {
            var auctionDailyStatsRealmAssocs = await _unitOfWork.AuctionDailyStatisticRealmAssocRepository.GetAsync(_ =>
                _.RealmId == realmId && _.AuctionDailyStatistic.ItemId == id,
                null,
                null,
                _ => _.AuctionDailyStatistic,
                _ => _.Realm,
                _ => _.Realm.Region,
                _ => _.AuctionDailyStatistic.Item
            );

            var auctionCurrentRealmAssocs = await _unitOfWork.AuctionCurrentRealmAssocRepository.GetAsync(_ =>
                 _.RealmId == realmId && _.AuctionCurrent.ItemId == id,
                _ => _.OrderBy(a => a.AuctionCurrent.Buyout),
                null,
                _ => _.AuctionCurrent,
                _ => _.AuctionCurrent.AuctionTimeLeftLU
             );





            return Ok(auctionDailyStatsRealmAssocs.SingleOrDefault().ToItemWithRealmAuctionDailyStatisticsDto(auctionCurrentRealmAssocs.Select(_ => _.AuctionCurrent).ToList()));
        }


    }
}
