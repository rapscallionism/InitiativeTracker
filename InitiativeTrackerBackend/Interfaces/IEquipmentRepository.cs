using InitiativeTrackerBackend.Models.DTOs;

namespace InitiativeTrackerBackend.Interfaces
{
    public interface IEquipmentRepository
    {
        /// <summary>
        ///     Returns a list of all the <see cref="Equipment"/> objects in the
        ///     database.
        /// </summary>
        /// <returns></returns>
        public Task<List<Equipment>> GetAllEquipmentAsync();

        /// <summary>
        ///     Returns the first <see cref="Equipment"/> that matches the
        ///     <paramref name="equipmentName"/> provided.
        /// </summary>
        /// <param name="equipmentName"></param>
        /// <returns></returns>
        public Task<Equipment> GetEquipmentByNameAsync(string equipmentName);

        /// <summary>
        ///     Returns the first <see cref="Equipment"/> that matches the
        ///     <paramref name="id"/> provided.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Equipment> GetEquipmentById(string id);

        /// <summary>
        ///     Creates an entry with the provided <paramref name="equipment"/>
        /// </summary>
        /// <param name="equipment"></param>
        /// <returns></returns>
        public Task<Equipment> CreateEquipmentAsync(Equipment equipment);

        /// <summary>
        ///     Uses the <paramref name="originalEquipmentId"/> and updates the resulting entry
        ///     to the provided <paramref name="equipmentToUpdate"/>
        /// </summary>
        /// <param name="originalEquipmentId"></param>
        /// <param name="equipmentToUpdate"></param>
        /// <returns></returns>
        public Task<Equipment> UpdateEquipmentByIdAsync(string originalEquipmentId, Equipment equipmentToUpdate);

        /// <summary>
        ///     Uses the <paramref name="originalEquipmentName"/> and updates the resulting entry
        ///     to the provided <paramref name="equipmentToUpdate"/>
        /// </summary>
        /// <param name="originalEquipmentName"></param>
        /// <param name="equipmentToUpdate"></param>
        /// <returns></returns>
        public Task<Equipment> UpdateEquipmentByNameAsync(string originalEquipmentName, Equipment equipmentToUpdate);
    }
}
