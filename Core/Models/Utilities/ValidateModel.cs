namespace Core.Models.Utilities
{
    public class ValidateModel<DTO, Entity>
    {
        public bool IsValid { get; set; }
        public List<string> FailedValidations { get; set; } = [];
        public DTO? Source { get; set; }
        public Entity? Destination { get; set; }
    }
}
