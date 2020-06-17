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
    public class AuctionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuctionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
    }
}
