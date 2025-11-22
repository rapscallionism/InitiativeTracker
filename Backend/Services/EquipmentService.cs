
using Backend.Interfaces;
using Backend.Models.Entities;
using Backend.Models.Requests;

namespace Backend.Services;

public class EquipmentService : IEquipmentService
{

    private readonly IEquipmentRepository _equipmentRepository;
    private readonly ILogger<EquipmentService> _logger;
    private readonly IConfiguration _configuration;
    public EquipmentService(IEquipmentRepository repository, ILogger<EquipmentService> logger, IConfiguration configuration)
    {
        _equipmentRepository = repository;
        _logger = logger;
        _configuration = configuration;
    }
    
    public async Task<List<Equipment>> GetAllEquipment()
    {
        return await _equipmentRepository.GetAllEquipmentAsync();
    }

    public async Task<Equipment?> GetEquipment(NameRequest nameRequest)
    {
        // Since all names are stored as upper case, need to query via upper casing
        string name = nameRequest.Name.ToUpperInvariant();

        return await _equipmentRepository.GetEquipmentByNameAsync(name);
    }

    public async Task<Equipment?> GetEquipment(IdRequest idRequest)
    {
        string id = idRequest.Id;
        return await _equipmentRepository.GetEquipmentByIdAsync(id);
    }

    public async Task<Equipment> CreateEquipment(Equipment equipment)
    {
        // Need to capitalize the name so its unique on all 
        equipment.Name = equipment.Name.ToUpperInvariant();

        Equipment created = await _equipmentRepository.CreateEquipmentAsync(equipment);
        return created;
    }

    public async Task<Equipment?> UpdateEquipment(NameRequest nameRequest, Equipment equipment)
    {
        string name = nameRequest.Name.ToUpperInvariant();

        // Check if it exists already; if not, throw an argument exception
        Equipment? existingEquipment = await GetEquipment(nameRequest);

        if (existingEquipment is null)
        {
            return null;
        }

        // Otherwise, bind with the id
        equipment.Id = existingEquipment.Id;
        return await _equipmentRepository.UpdateEquipmentByNameAsync(name, equipment);
    }

    public async Task<Equipment?> UpdateEquipment(IdRequest idRequest, Equipment equipment)
    {
        string id = idRequest.Id;
        return await _equipmentRepository.UpdateEquipmentByIdAsync(id, equipment);
    }
}