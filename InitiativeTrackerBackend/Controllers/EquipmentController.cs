using InitiativeTrackerBackend.Interfaces;
using InitiativeTrackerBackend.Models.DTOs;
using InitiativeTrackerBackend.Models.Requests;
using Microsoft.AspNetCore.Mvc;

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

        [Route("name")]
        [HttpPost]
        public async Task<ActionResult<Equipment>> GetOne([FromBody] NameRequest name)
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

        [Route("id")]
        [HttpPost]
        public async Task<ActionResult<Equipment>> GetOne([FromBody] IdRequest id)
        {
            try
            {
                var equipment = await _service.GetEquipment(id);
                return Ok(equipment);
            }
            catch (Exception e)
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

        [Route("update/id")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<Equipment>> Update([FromBody] (IdRequest idRequest, Equipment equipment) request)
        {
            try
            {
                IdRequest requestedId = request.idRequest;
                Equipment requestedEquipment = request.equipment;
                var updated = await _service.UpdateEquipment(requestedId, requestedEquipment);
                return Ok(updated);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return StatusCode(500, "Something went wrong...");
            }
        }

        [Route("update/name")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<Equipment>> Update([FromBody] (NameRequest nameRequest, Equipment equipment) request)
        {
            try
            {
                NameRequest requestedName = request.nameRequest;
                Equipment requestedEquipment = request.equipment;
                var updated = await _service.UpdateEquipment(requestedName, requestedEquipment);
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
