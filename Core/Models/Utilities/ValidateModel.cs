namespace Core.Models.Utilities
{
    public class ValidateModel<DTO, Entity>
    {
        public bool IsValid { get; set; }
        public List<string> FailedValidations { get; set; } = [];
        public DTO? Source { get; set; }
        public Entity? Destination { get; set; }
        
        public ValidateModel(DTO source, Entity destination)
        {
            this.Source = Source;
            this.Destination = Destination;
        }

        public ValidateModel(bool isValid, List<string> failedValidationMsgs, DTO source, Entity destination)
        {
            this.IsValid = isValid;
            this.FailedValidations = failedValidationMsgs;
            this.Source = Source;
            this.Destination = Destination;
        }
    }
}
