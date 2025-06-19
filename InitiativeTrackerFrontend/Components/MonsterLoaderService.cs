namespace InitiativeTracker.Components
{
    public class MonsterLoaderService
    {
        // List to store data read from JSON files
        public List<Monster> Data { get; private set; } = new List<Monster>();

        // Method to load data into the service
        public void AddData(Monster data)
        {
            if (data != null)
            {
                Data.Add(data);
            }
        }

        // Optional method to retrieve all data
        public IEnumerable<Monster> GetData()
        {
            return Data;
        }
    }
}
