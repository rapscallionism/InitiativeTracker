namespace Core.Models.Requests
{
    public class UpdateRequestByName : UpdateRequest
    {
        public NameRequest? RequestedName { get; set; }
    }
}
