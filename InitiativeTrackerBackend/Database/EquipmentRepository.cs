using InitiativeTrackerBackend.Interfaces;
using InitiativeTrackerBackend.Models.DTOs;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace InitiativeTrackerBackend.Database
{
    public class EquipmentRepository : IEquipmentRepository
    {

        private readonly IMongoCollection<Equipment> _collection;

        public EquipmentRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.Database);
            _collection = database.GetCollection<Equipment>("equipment");
        }

        public async Task<List<Equipment>> GetAllEquipmentAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Equipment> GetEquipmentByNameAsync(string equipmentName)
        {
            return await _collection.Find(e => e.Name == equipmentName).FirstOrDefaultAsync();
        }

        public async Task<Equipment> GetEquipmentById(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Equipment> CreateEquipmentAsync(Equipment equipment)
        {
            await _collection.InsertOneAsync(equipment);
            return equipment;
        }

        public async Task<Equipment> UpdateEquipmentAsync(string equipmentToUpdateId, Equipment equipmentToUpdate)
        {
            // To ensure that the id is correct
            equipmentToUpdate.Id = equipmentToUpdateId;
            await _collection.ReplaceOneAsync(e => e.Id == equipmentToUpdate.Id, equipmentToUpdate);
            return equipmentToUpdate;
        }
    }
}
