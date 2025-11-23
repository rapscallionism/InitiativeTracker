using Core.Models.DTOs;
using Core.Models.Entities;

namespace Core.Utilities
{
    public static class MapperUtils
    {
        public static EquipmentDTO Map(EquipmentEntity entity)
        {
            EquipmentDTO dto = new();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
            dto.Tags = entity.Tags;
            dto.EquipmentSlot = entity.EquipmentSlot;
            dto.Charges = entity.Charges;
            dto.MaxCharges = entity.MaxCharges;
            return dto;
        }

        public static EquipmentEntity Map(EquipmentDTO dto)
        {
            EquipmentEntity entity = new();
            entity.Id = string.IsNullOrEmpty(dto.Id) || 
                string.IsNullOrWhiteSpace(dto.Id) ? 
                string.Empty : 
                dto.Id;
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.Tags = dto.Tags;
            entity.EquipmentSlot = dto.EquipmentSlot;
            entity.Charges = dto.Charges;
            entity.MaxCharges = dto.MaxCharges;
            return entity;
        }
    }
}
