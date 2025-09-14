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

        /// <inheritdoc/>
        public async Task<List<Equipment>> GetAllEquipmentAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Equipment?> GetEquipmentByNameAsync(string equipmentName)
        {
            return await _collection.Find(e => e.Name == equipmentName).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<Equipment?> GetEquipmentByIdAsync(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<Equipment> CreateEquipmentAsync(Equipment equipment)
        {
            await _collection.InsertOneAsync(equipment);
            return equipment;
        }

        /// <inheritdoc/>
        public async Task<Equipment> UpdateEquipmentByIdAsync(string equipmentToUpdateId, Equipment equipmentToUpdate)
        {
            // To ensure that the id is correct
            // TODO: double check if this doesn't just leave the previous entry in the DB still
            equipmentToUpdate.Id = equipmentToUpdateId;
            await _collection.ReplaceOneAsync(e => e.Id == equipmentToUpdate.Id, equipmentToUpdate);
            return equipmentToUpdate;
        }

        /// <inheritdoc/>
        public async Task<Equipment> UpdateEquipmentByNameAsync(string originalEquipmentName, Equipment equipmentToUpdate)
        {
            await _collection.ReplaceOneAsync(e => e.Name == originalEquipmentName, equipmentToUpdate);
            return equipmentToUpdate;
        }
    }
}
