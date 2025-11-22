using System.Text.Json;

namespace Frontend.Services
{
    public class Monster
    {
        public string Name { get; set; }
        public int InitiativeBonus { get; set; }
        public CurrentHealth CurrentHealth { get; set; }

        public Monster(string Name, int InitiativeBonus, CurrentHealth currentHealth) {
            this.Name = Name;
            this.InitiativeBonus = InitiativeBonus;
            CurrentHealth = currentHealth;
        }
    }

    public class CurrentHealth
    {
        public int NumberOfDice { get; set; }
        public int MaxNumberOnDice { get; set; }
        public int OtherHealthBonuses { get; set; }
        public string healthRollValueAsString { get; set; }
        public CurrentHealth(int NumberOfDice,  int MaxNumberOnDice, int otherHealthBonuses)
        {
            this.NumberOfDice = NumberOfDice;
            this.MaxNumberOnDice = MaxNumberOnDice;
            OtherHealthBonuses = otherHealthBonuses;
            setHealthRollValueAsString();
        }

        public void setHealthRollValueAsString()
        {
            healthRollValueAsString = $"{NumberOfDice}d{MaxNumberOnDice}";
            if (OtherHealthBonuses > 0)
            {
                healthRollValueAsString += $"+{OtherHealthBonuses}";
            } else if (OtherHealthBonuses < 0)
            {
                healthRollValueAsString += OtherHealthBonuses;
            } 
        }
    }

    public class MonstersReader
    {
        public static void ReadAllMonstersData(string folderPath, MonsterLoaderService service)
        {
            var jsonFiles = Directory.GetFiles(folderPath, "*.json");

            foreach (var file in jsonFiles)
            {
                // For each file in the folder, read each of them
                string fileContent = File.ReadAllText(file);

                Monster monster = JsonSerializer.Deserialize<Monster>(fileContent);

                if (monster != null)
                {
                    service.AddData(monster);
                }
            }
        }
    }
}
