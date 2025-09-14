using InitiativeTrackerBackend.Models.DTOs;

namespace InitiativeTrackerBackend.Models.Requests
{
    public class UpdateRequest
    {
        public Equipment? EquipmentToBeUpdatedTo { get; set; }
    }
}
