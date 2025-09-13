
using InitiativeTrackerBackend.Interfaces;
using InitiativeTrackerBackend.Models.DTOs;

namespace InitiativeTracker.Services;

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

    public async Task<Equipment> GetEquipment(string name)
    {
        return await _equipmentRepository.GetEquipmentByNameAsync(name);
    }

    public async Task<Equipment> CreateEquipment(Equipment equipment)
    {
        Equipment created = await _equipmentRepository.CreateEquipmentAsync(equipment);
        return created;
    }

    public async Task<Equipment> UpdateEquipment(string id, Equipment equipment)
    {
        return await _equipmentRepository.UpdateEquipmentByIdAsync(id, equipment);
    }
}