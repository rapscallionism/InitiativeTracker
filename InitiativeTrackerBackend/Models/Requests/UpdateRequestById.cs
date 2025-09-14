namespace InitiativeTrackerBackend.Models.Requests
{
    public class UpdateRequestById : UpdateRequest
    {
        public IdRequest? RequestedId { get; set; }
    }
}
