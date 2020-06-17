using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GGAdvantage.Application;
using GGAdvantage.Application.Interfaces;
using GGAdvantage.Application.Models.Region;
using GGAdvantage.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GGAdvantage.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetAllRegionsAsync()
        {
            var regions = await _unitOfWork.RegionRepository.GetAsync();

            var data = new List<RegionDto>();

            foreach (var region in regions)
            {
                data.Add(region.ToRegionDto());
            }


            return Ok(data.OrderBy(_ => _.Name).ToList());
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<RegionDto>> GetRegionAsync(Guid id)
        {
            var region = await _unitOfWork.RegionRepository.GetByIDAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(region.ToRegionDto());
        }

        [HttpGet]
        [Route("{id}/region-with-realms")]
        public async Task<ActionResult<RegionWithRealmsDto>> GetRegionWithRealmsAsync(Guid id)
        {
            var realmsDB = await _unitOfWork.RealmRepository.GetAsync(_ => _.RegionId == id, _ => _.OrderBy(r => r.Name), null, _ => _.Region);
         
            if (realmsDB == null)
                return NotFound();

            return Ok(realmsDB.ToRegionWithRealmsDto());
        }
    }
}
