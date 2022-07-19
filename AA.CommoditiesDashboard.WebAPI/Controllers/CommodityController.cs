using AA.CommoditiesDashboard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommodityController : ControllerBase
    {
        private readonly ICommodityService _commodityService;
        private readonly ILogger<CommodityController> _logger;

        public CommodityController(ICommodityService commodityService, ILogger<CommodityController> logger)
        {
            _commodityService = commodityService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _commodityService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest();
        }


        [HttpGet("PnlYTDMetrics")]
        public async Task<IActionResult> GetPnlYTDMetricAsync()
        {
            try
            {
                var result = await _commodityService.GetAllPnlYTDMetricAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest();
        }


        [HttpGet("PnlYTDMetrics/{id}")]
        public async Task<IActionResult> GetPnlYTDMetricAsync(int id)
        {
            try
            {
                var result = await _commodityService.GetPnlYTDMetricByIdAsync(id);
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
