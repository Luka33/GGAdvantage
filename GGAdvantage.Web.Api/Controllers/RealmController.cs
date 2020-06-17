using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GGAdvantage.Application;
using GGAdvantage.Application.Interfaces;
using GGAdvantage.Application.Models;
using GGAdvantage.Application.Models.Realm;
using GGAdvantage.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GGAdvantage.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RealmController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RealmController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RealmDto>>> GetRealmsAsync()
        {
            var realms = await _unitOfWork.RealmRepository.GetAsync(includeExpressions: _ => _.Region);

            var data = new List<RealmDto>();

            foreach (var realm in realms)
            {
                data.Add(realm.ToRealmDto());
            }

            return Ok(data);
        }

        [HttpPost]
        [Route("{search}")]
        public async Task<ActionResult<IEnumerable<RealmDto>>> GetSearchRealmsAsync([FromBody] SearchDto searchDto)
        {
            //PropertyInfo filter = typeof(Realm).GetProperty("RegionId");

            var realms = await _unitOfWork.RealmRepository.GetAsync(_ => searchDto.filterName != null && searchDto.filterValue != null && searchDto.filterName.Equals("RegionId") ? 
                _.Region.Id == Guid.Parse(searchDto.filterValue) && _.Name.Contains(searchDto.name) : _.Name.Contains(searchDto.name),  
                take: searchDto.Paging, 
                includeExpressions: _ => _.Region);

            var data = new List<RealmDto>();

            foreach (var realm in realms)
            {
                data.Add(realm.ToRealmDto());
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Realm>> GetRealmAsync(Guid id)
        {
            var realm = await _unitOfWork.RealmRepository.GetByIDAsync(id);

            if (realm == null)
            {
                return NotFound();
            }

            return Ok(realm.ToRealmDto());
        }

        //[HttpGet]
        //[Route("{id}/realm-with-region")]
        //public async Task<ActionResult<Realm>> GetRealmWithRegionAsync(Guid id)
        //{
        //    var realms = await _unitOfWork.RealmRepository.GetAsync(_ => _.Id == id, includeExpressions: _ => _.RegionLU);

        //    if (realms == null || realms.Count != 1)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(realms.First().ToRealmDto());
        //}

        //[HttpGet]
        //[Route("{id}/realm-with-region")]
        //public async Task<ActionResult<RealmWithRegionDto>> GetRealmConnectedGroupAsync(Guid id)
        //{
        //    var realmConnectedGroup = await _realmConnectedGroupRepository.GetRealmConnectedGroupByRealm(false, false, id);

        //    if (realmConnectedGroup == null)
        //        return NotFound();

        //    return Ok(realmConnectedGroup.ToRealmWithRegionDto(id));
        //}
    }
}
