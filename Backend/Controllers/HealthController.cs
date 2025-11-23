using Core.Interfaces;
using Core.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;
        private readonly IEquipmentService _service;

        public HealthController(ILogger<HealthController> logger, IEquipmentService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("ping")]
        public async Task<ActionResult<List<EquipmentDTO>>> Ping()
        {
            try
            {
                var allEquipment = await _service.GetAllEquipment();
                return Ok(allEquipment);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return StatusCode(500, "Something went wrong...");
            }
        }
    }
}
