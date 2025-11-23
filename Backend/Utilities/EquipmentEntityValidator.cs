using Backend.Interfaces;
using Core.Models.DTOs;
using Core.Models.Entities;
using Core.Models.Utilities;
using Core.Utilities;

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
            _logger.LogCritical("IMPLEMENTED " + nameof(ValidateEquipment));

            EquipmentEntity entity = MapperUtils.Map(equipmentToValidate);
            return new ValidateModel<EquipmentDTO, EquipmentEntity>(isValid: true, [], equipmentToValidate, entity);
        }
    }
}
