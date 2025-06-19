using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;


namespace InitiativeTracker.Components
{
    public class Monster
    {
        public string Name { get; set; }
        public int InitiativeBonus { get; set; }
        public CurrentHealth CurrentHealth { get; set; }

        public Monster(string Name, int InitiativeBonus, CurrentHealth currentHealth) {
            this.Name = Name;
            this.InitiativeBonus = InitiativeBonus;
            this.CurrentHealth = currentHealth;
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
            this.OtherHealthBonuses = otherHealthBonuses;
            this.setHealthRollValueAsString();
        }

        public void setHealthRollValueAsString()
        {
            this.healthRollValueAsString = $"{NumberOfDice}d{MaxNumberOnDice}";
            if (this.OtherHealthBonuses > 0)
            {
                this.healthRollValueAsString += $"+{OtherHealthBonuses}";
            } else if (this.OtherHealthBonuses < 0)
            {
                this.healthRollValueAsString += OtherHealthBonuses;
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
