using InitiativeTrackerBackend.Models.DTOs;

namespace InitiativeTrackerBackend.Interfaces
{
    public interface IEquipmentRepository
    {
        public Task<List<Equipment>> GetAllEquipmentAsync();
        public Task<Equipment> GetEquipmentByNameAsync(string equipmentName);
        public Task<Equipment> CreateEquipmentAsync(Equipment equipment);
        public Task<Equipment> UpdateEquipmentAsync(string equipmentToUpdateId, Equipment equipmentToUpdate);
    }
}
