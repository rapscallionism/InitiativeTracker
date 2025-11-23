using Backend.Models.Entities;
using Core.Models.DTOs;
using Core.Models.Utilities;

namespace Backend.Interfaces
{
    public interface IEquipmentEntityValidator
    {
        /// <summary>
        ///     Validates that the <paramref name="equipmentToValidate"/> is valid to be 
        ///     saved into the database.
        /// </summary>
        /// <param name="equipmentToValidate"></param>
        /// <returns></returns>
        public ValidateModel<EquipmentDTO, EquipmentEntity> ValidateEquipment(EquipmentDTO equipmentToValidate);
    }
}
