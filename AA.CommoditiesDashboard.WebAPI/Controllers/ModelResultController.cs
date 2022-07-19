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
    public class ModelResultController : ControllerBase
    {
        private readonly IModelResultService _modelResultService;
        private readonly ILogger<ModelController> _logger;

        public ModelResultController(IModelResultService modelResultService, ILogger<ModelController> logger)
        {
            _modelResultService = modelResultService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _modelResultService.GetAllAsync();
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
