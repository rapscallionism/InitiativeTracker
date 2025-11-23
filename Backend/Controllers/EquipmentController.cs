using Backend.Utilities;
using Core.Interfaces;
using Core.Models.DTOs;
using Core.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
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
        public async Task<ActionResult<List<EquipmentDTO>>> GetAll()
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

        [Route("name")]
        [HttpPost]
        public async Task<ActionResult<EquipmentDTO>> GetOne([FromBody] NameRequest name)
        {
            try
            {
                if (name is null || string.IsNullOrEmpty(name.Name))
                {
                    throw new ArgumentNullException("Name is not provided in the request body.");
                }

                var equipment = await _service.GetEquipmentByNameAsync(name.Name);

                if (equipment is null)
                {
                    return new NotFoundObjectResult($"Unable to find any equipment with the " +
                        $"given name of {GlobalUtils.Sanitize(name.Name)}");
                }

                return Ok(equipment);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError(e.StackTrace);
                return StatusCode(500, "Something went wrong...");
            }
        }

        [Route("id")]
        [HttpPost]
        public async Task<ActionResult<EquipmentDTO>> GetById([FromBody] IdRequest id)
        {
            try
            {
                if (string.IsNullOrEmpty(id.Id) || string.IsNullOrWhiteSpace(id.Id))
                {
                    throw new ArgumentNullException("Id is not provided in the request body.");
                }

                var equipment = await _service.GetEquipmentByIdAsync(id.Id);
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
        public async Task<ActionResult<EquipmentDTO>> Create([FromBody] EquipmentDTO equipment)
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
        public async Task<ActionResult<EquipmentDTO>> Update([FromBody] UpdateRequestById request)
        {
            try
            {
                if (request.RequestedId is null || request.RequestedId.Id is null ||
                    string.IsNullOrEmpty(request.RequestedId.Id) || string.IsNullOrWhiteSpace(request.RequestedId.Id))
                {
                    throw new ArgumentNullException("Missing Id from Update Request.");
                }

                if (request.EquipmentToBeUpdatedTo is null)
                {
                    throw new ArgumentNullException("Missing Equpment from Update Request.");
                }

                string id = request.RequestedId.Id;
                EquipmentDTO requestedEquipment = request.EquipmentToBeUpdatedTo;
                requestedEquipment.Id = id;
                var updated = await _service.UpdateEquipment(requestedEquipment);
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
        public async Task<ActionResult<EquipmentDTO>> Update([FromBody] UpdateRequestByName request)
        {
            try
            {
                if (request.RequestedName is null || request.RequestedName.Name is null || 
                    string.IsNullOrEmpty(request.RequestedName.Name) || string.IsNullOrWhiteSpace(request.RequestedName.Name))
                {
                    throw new ArgumentNullException("Missing Name from Update Request.");
                }

                if (request.EquipmentToBeUpdatedTo is null)
                {
                    throw new ArgumentNullException("Missing Equpment from Update Request.");
                }

                NameRequest requestedName = request.RequestedName;
                EquipmentDTO requestedEquipment = request.EquipmentToBeUpdatedTo;
                var updated = await _service.UpdateEquipment(requestedEquipment);
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
