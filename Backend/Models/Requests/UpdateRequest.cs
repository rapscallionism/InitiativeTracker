using Backend.Models.DTOs;

namespace Backend.Models.Requests
{
    public class UpdateRequest
    {
        public Equipment? EquipmentToBeUpdatedTo { get; set; }
    }
}
