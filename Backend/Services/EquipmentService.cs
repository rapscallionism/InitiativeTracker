using Core.Models.DTOs;

namespace Backend.Services
{
    public class EquipmentService : Core.Interfaces.IEquipmentService
    {
        private readonly ILogger<EquipmentService> _logger;

        public Task<EquipmentDTO> CreateEquipment(EquipmentDTO equipmentToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<List<EquipmentDTO>> GetAllEquipment()
        {
            throw new NotImplementedException();
        }

        public Task<EquipmentDTO> GetEquipmentByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<EquipmentDTO> GetEquipmentByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<EquipmentDTO> UpdateEquipment(EquipmentDTO equipmentToUpdateTo)
        {
            throw new NotImplementedException();
        }
    }
}
