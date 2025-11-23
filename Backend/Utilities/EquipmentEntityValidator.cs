using Backend.Interfaces;
using Backend.Models.Entities;
using Core.Models.DTOs;
using Core.Models.Utilities;

namespace Backend.Utilities
{
    public class EquipmentEntityValidator : IEquipmentEntityValidator
    {
        private readonly ILogger<EquipmentEntityValidator> _logger;

        public EquipmentEntityValidator(ILogger<EquipmentEntityValidator> logger)
        {
            this._logger = logger;
        }

        public ValidateModel<EquipmentDTO, EquipmentEntity> ValidateEquipment(EquipmentDTO equipmentToValidate)
        {
            throw new NotImplementedException();
        }
    }
}
