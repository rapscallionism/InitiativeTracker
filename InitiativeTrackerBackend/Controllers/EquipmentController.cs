using InitiativeTrackerBackend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InitiativeTracker.Controllers
{
    [ApiController]
    [Route("api/equipment")]
    public class EquipmentController : ControllerBase
    {
        private readonly ILogger<EquipmentController> _logger;
        private readonly IEquipmentService _service;

        public EquipmentController(ILogger<EquipmentController> logger, IEquipmentService service)
        {
            _logger = logger;
            _service = service;
        }

        [Route("all")]
        [HttpGet]
        public async Task<ActionResult<List<Equipment>>> GetAll()
        {
            try
            {
                var allEquipment = await _service.GetAllEquipment();
                return Ok(allEquipment);
            } catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return StatusCode(500, "Something went wrong...");
            }
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult<Equipment>> GetOne([FromQuery] string name)
        {
            try
            {
                var equipment = await _service.GetEquipment(name);
                return Ok(equipment);
            } catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return StatusCode(500, "Something went wrong...");
            }
        }

        [Route("create")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<Equipment>> Create([FromBody] Equipment equipment)
        {
            try
            {
                var created = await _service.CreateEquipment(equipment);
                return Ok(created);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return StatusCode(500, "Something went wrong...");
            }
        }


        [Route("update/{id}")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<Equipment>> Update([FromQuery] string id, [FromBody] Equipment equipment)
        {
            try
            {
                var updated = await _service.UpdateEquipment(id, equipment);
                return Ok(updated);
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
