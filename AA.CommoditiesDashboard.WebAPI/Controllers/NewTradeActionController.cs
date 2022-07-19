using AA.CommoditiesDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewTradeActionController : ControllerBase
    {
        private readonly INewTradeActionService _newTradeActionService;
        private readonly ILogger<NewTradeActionController> _logger;

        public NewTradeActionController(INewTradeActionService newTradeActionService, ILogger<NewTradeActionController> logger)
        {
            _newTradeActionService = newTradeActionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _newTradeActionService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest();
        }
    }
}
