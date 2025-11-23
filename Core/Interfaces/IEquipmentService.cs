using Core.Models.DTOs;

namespace Core.Interfaces
{
    public interface IEquipmentService
    {
        /// <summary>
        ///     Queries the database to return all equipment that
        ///     may have a matching <paramref name="name"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<EquipmentDTO[]> GetEquipmentByNameAsync(string name);

        /// <summary>
        ///     Queries the database to return the equipment that
        ///     may have a matching <paramref name="id"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EquipmentDTO?> GetEquipmentByIdAsync(string id);

        /// <summary>
        ///     Returns a list of equipment from the database.
        /// </summary>
        /// <returns></returns>
        Task<List<EquipmentDTO>> GetAllEquipment();

        /// <summary>
        ///     Given a <paramref name="equipmentToUpdateTo"/>, will update
        ///     the equipment to this new version provided.
        /// </summary>
        /// <param name="equipmentToUpdateTo"></param>
        /// <returns></returns>
        Task<EquipmentDTO> UpdateEquipment(EquipmentDTO equipmentToUpdateTo);

        /// <summary>
        ///     Creates the <paramref name="equipmentToCreate"/> in the database,
        ///     after doing some validation.
        /// </summary>
        /// <param name="equipmentToCreate"></param>
        /// <returns></returns>
        Task<EquipmentDTO> CreateEquipment(EquipmentDTO equipmentToCreate);
    }
}
