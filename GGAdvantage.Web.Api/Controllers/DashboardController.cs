using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GGAdvantage.Application;
using GGAdvantage.Application.Interfaces;
using GGAdvantage.Application.Models;
using GGAdvantage.Application.Models.Item;
using GGAdvantage.Application.Models.MarketNotification;
using GGAdvantage.Application.Models.Realm;
using GGAdvantage.Domain.Entities;
using GGAdvantage.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GGAdvantage.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DashboardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("market-notifications")]
        public async Task<ActionResult<List<MarketNotificationDto>>> GetMarketNotifications()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var marketNotifications = await _unitOfWork.MarketNotificationRepository.GetAsync(_ => _.UserId == user.Id,
                _ => _.OrderBy(mn => mn.Id),
                null,
                _ => _.Realm.Region,
                _ => _.Item.ItemSubclass.ItemClass,
                _ => _.PriceType,
                _ => _.QuantityType);

            var results = marketNotifications.Select(_ => _.ToMarketNotificationDto()).ToList();

            return Ok(results);
        }

        [HttpPost]
        [Route("market-notification")]
        public async Task<ActionResult<MarketNotificationDto>> SaveMarketNotification([FromBody] MarketNotificationDto dto) 
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = dto;
            if (user == null)
            {
                return Unauthorized(result);
            }

            if (dto.ActionState == eActionState.Insert)
            {
                var marketNotification = new MarketNotification
                {
                    Id = Guid.NewGuid(),
                    ItemId = dto.Item.Id,
                    PriceTypeId = dto.PriceType != null ? (int?)dto.PriceType.Id : null,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    QuantityTypeId = dto.QuantityType != null ? (int?)dto.QuantityType.Id : null,
                    RealmId = dto.Realm.Id,
                    UserId = user.Id,                   
                };
                await _unitOfWork.MarketNotificationRepository.InsertAsync(marketNotification);
                await _unitOfWork.SaveAsync();
                result.Id = marketNotification.Id;
            }
            else if (dto.ActionState == eActionState.Update)
            {

                var marketNotification = await _unitOfWork.MarketNotificationRepository.GetByIDAsync(dto.Id);
                if (marketNotification == null || marketNotification.UserId != user.Id)
                {
                    return Unauthorized(result);
                }

                marketNotification.ItemId = dto.Item.Id;
                marketNotification.PriceTypeId = dto.PriceType != null ? (int?)dto.PriceType.Id : null;
                marketNotification.Price = dto.Price;
                marketNotification.Quantity = dto.Quantity;
                marketNotification.QuantityTypeId = dto.QuantityType != null ? (int?)dto.QuantityType.Id : null;
                marketNotification.RealmId = dto.Realm.Id;

                await _unitOfWork.MarketNotificationRepository.UpdateAsync(marketNotification);
                await _unitOfWork.SaveAsync();
            }
            else if(dto.ActionState == eActionState.Delete){

                var marketNotification = await _unitOfWork.MarketNotificationRepository.GetByIDAsync(dto.Id);
                if (marketNotification == null || marketNotification.UserId != user.Id)
                {
                    return Unauthorized(result);
                }

                await _unitOfWork.MarketNotificationRepository.DeleteAsync(dto.Id);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                return BadRequest(false);

            }

            result.ActionState = eActionState.None;
            return Ok(result);

        }

        [HttpGet]
        [Route("market-notification-types")]
        public async Task<ActionResult<List<MarketNotificationTypeDto>>> GetMarketNotificationTypes()
        {
            var marketNotificationTypes = await _unitOfWork.MarketNotificationTypeRepository.GetAsync(orderBy: _ => _.OrderBy(mnt => mnt.SortOrder));

            var result = marketNotificationTypes.Select(_ => _.ToMarketNotificationTypeDto()).ToList();

            return Ok(result);
        }

    }
}
