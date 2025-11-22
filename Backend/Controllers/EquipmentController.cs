using Backend.Interfaces;
using Backend.Models.Entities;
using Backend.Models.Requests;
using Backend.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/equipment")]
    public class EquipmentController : ControllerBase
    {
        private readonly ILogger<EquipmentController> _logger;
        private readonly IEquipmentNoSQLService _service;

        public EquipmentController(ILogger<EquipmentController> logger, IEquipmentNoSQLService service)
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
                if (name is null || string.IsNullOrEmpty(name.Name))
                {
                    throw new ArgumentNullException("Name is not provided in the request body.");
                }

                var equipment = await _service.GetEquipment(name);

                if (equipment is null)
                {
                    return new NotFoundObjectResult($"Unable to find any equipment with the " +
                        $"given name of {GlobalUtils.Sanitize(name.Name)}");
                }

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
        public async Task<ActionResult<Equipment>> Update([FromBody] UpdateRequestById request)
        {
            try
            {
                if (request.RequestedId is null || request.RequestedId.Id is null)
                {
                    throw new ArgumentNullException("Missing Id from Update Request.");
                }

                if (request.EquipmentToBeUpdatedTo is null)
                {
                    throw new ArgumentNullException("Missing Equpment from Update Request.");
                }

                IdRequest requestedId = request.RequestedId;
                Equipment requestedEquipment = request.EquipmentToBeUpdatedTo;
                var updated = await _service.UpdateEquipment(requestedId, requestedEquipment);
                return Ok(updated);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return BadRequest(e);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return BadRequest(e);
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
        public async Task<ActionResult<Equipment>> Update([FromBody] UpdateRequestByName request)
        {
            try
            {
                if (request.RequestedName is null || request.RequestedName.Name is null)
                {
                    throw new ArgumentNullException("Missing Name from Update Request.");
                }

                if (request.EquipmentToBeUpdatedTo is null)
                {
                    throw new ArgumentNullException("Missing Equpment from Update Request.");
                }

                NameRequest requestedName = request.RequestedName;
                Equipment requestedEquipment = request.EquipmentToBeUpdatedTo;
                var updated = await _service.UpdateEquipment(requestedName, requestedEquipment);
                return Ok(updated);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return BadRequest(e);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return BadRequest(e);
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
