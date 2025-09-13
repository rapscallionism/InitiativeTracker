namespace InitiativeTrackerBackend.Models.Requests
{
    /// <summary>
    ///     Request format to be used when querying anything via Id
    /// </summary>
    public class IdRequest
    {
        public string Id { get; set; } = string.Empty;
    }
}
