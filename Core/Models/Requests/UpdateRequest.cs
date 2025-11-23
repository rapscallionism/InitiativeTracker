using Core.Models.DTOs;

namespace Core.Models.Requests
{
    public class UpdateRequest
    {
        public EquipmentDTO? EquipmentToBeUpdatedTo { get; set; }
    }
}
