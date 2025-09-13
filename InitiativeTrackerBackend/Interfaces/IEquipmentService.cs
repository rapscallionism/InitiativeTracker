using InitiativeTrackerBackend.Models.DTOs;
using InitiativeTrackerBackend.Models.Requests;

namespace InitiativeTrackerBackend.Interfaces
{
    public interface IEquipmentService
    {
        public Task<List<Equipment>> GetAllEquipment();
        public Task<Equipment> GetEquipment(NameRequest nameRequest);
        public Task<Equipment> GetEquipment(IdRequest idRequest);
        public Task<Equipment> CreateEquipment(Equipment equipment);
        public Task<Equipment> UpdateEquipment(NameRequest nameRequest, Equipment equipment);
        public Task<Equipment> UpdateEquipment(IdRequest idRequest, Equipment equipment);
    }
}