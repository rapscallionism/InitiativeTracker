using System.Text.Json;

namespace InitiativeTracker.Items
{
    // Responsible for parsing through the JSON that is provided into proper objects that will be used in the runtime
    // of the application
    public class ItemParser
    {
        public static Item ParseJsonToItem(string FilePath)
        {
            string jsonString = File.ReadAllText(FilePath);
            Item item = JsonSerializer.Deserialize<Item>(jsonString)!;
            return item;
        }

        public static List<Item> ParseAllJsonToItems(string folderPath)
        {
            List<Item> items = new List<Item>();
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
            {
                Item item = ParseJsonToItem(folderPath + file);
            }
            return items;
        }

    }
}
