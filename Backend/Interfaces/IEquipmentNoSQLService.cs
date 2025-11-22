using Backend.Models.Entities;
using Backend.Models.Requests;

namespace Backend.Interfaces
{
    public interface IEquipmentNoSQLService
    {
        public Task<List<Equipment>> GetAllEquipment();
        public Task<Equipment?> GetEquipment(NameRequest nameRequest);
        public Task<Equipment?> GetEquipment(IdRequest idRequest);
        public Task<Equipment> CreateEquipment(Equipment equipment);
        public Task<Equipment?> UpdateEquipment(NameRequest nameRequest, Equipment equipment);
        public Task<Equipment?> UpdateEquipment(IdRequest idRequest, Equipment equipment);
    }
}