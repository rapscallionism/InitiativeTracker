using Backend.Models.Entities;

namespace Backend.Models.Requests
{
    public class UpdateRequest
    {
        public Equipment? EquipmentToBeUpdatedTo { get; set; }
    }
}
