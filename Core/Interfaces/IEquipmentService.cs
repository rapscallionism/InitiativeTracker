using Core.Models.DTOs;

namespace Core.Interfaces
{
    public interface IEquipmentService
    {
        Task<EquipmentDTO> GetEquipmentByNameAsync(string name);
        Task<EquipmentDTO> GetEquipmentByIdAsync(string id);
        Task<List<EquipmentDTO>> GetAllEquipment();
        Task<EquipmentDTO> UpdateEquipment(EquipmentDTO equipmentToUpdateTo);
        Task<EquipmentDTO> CreateEquipment(EquipmentDTO equipmentToCreate);
    }
}
