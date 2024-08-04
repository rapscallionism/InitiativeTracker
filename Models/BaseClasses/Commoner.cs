using Turn_Based_Game.Models.Interfaces;
using IAction = Turn_Based_Game.Models.Interfaces.IAction;
using IBonusAction = Turn_Based_Game.Models.Interfaces.IBonusAction;

namespace Turn_Based_Game.Models.BaseClasses
{
    public class Commoner : ICreature
    {
        public int _health { get; set; } = 4;
        public string _name { get; set; } = "Commoner";
        public int _level { get; set; } = 0;
        public int _armorClass { get; set; } = 8;
        public int _movementSpeed { get; set; } = 30;
        public int _proficiencyBonus { get; set; } = 0;
        public int _initiative { get; set; } = -1;

        // Stat information
        public Stat _strength { get; set; } = new Stat("strength", 8);
        public Stat _dexterity { get; set; } = new Stat("dexterity", 8);
        public Stat _constitution { get; set; } = new Stat("constitution", 8);
        public Stat _intelligence { get; set; } = new Stat("intelligence", 8);
        public Stat _wisdom { get; set; } = new Stat("wisdom", 8);
        public Stat _charisma { get; set; } = new Stat("charisma", 8);

        public List<Item> items { get; set; }
        public List<IAction> _actions { get; set; }

        public List<IBonusAction> _bonusActions { get; set; }
        public IWeapon? _weapon { get; set; }
        public IArmor? _armor { get; set; }
        public INecklace? _necklace { get; set; }
        public IRing? _leftRing { get; set; }
        public IRing? _rightRing { get; set; }
        public IShield _shield { get; set; }

        public Commoner() { }

        /// <summary>
        ///     Method to print out the actions and the corresponding description of the action
        /// </summary>
        public void printActions()
        {
            Console.WriteLine("---- Available Actions ----");
            foreach (IAction action in _actions) {
                // String concatenation to check if an action can be used an infinite number of times
                // This is default -1 
                string numberOfUses = "";
                if (action._numberOfUses != -1)
                {
                    numberOfUses = $"( Can be used {action._numberOfUses} time(s) ) ";
                }

                Console.WriteLine($"- Action: {action._name} {numberOfUses}");
                Console.WriteLine($"- Description: {action._description}");
            }
        }
        /// <summary>
        ///     Method to print out the bonus actions and the corresponding description of the bonus action
        /// </summary>
        public void printBonusActions()
        {
            Console.WriteLine("---- Available Bonus Actions ----");
            foreach (IBonusAction bonusAction in _bonusActions)
            {
                // String concatenation to check if an action can be used an infinite number of times
                // This is default -1 
                string numberOfUses = "";
                if (bonusAction._numberOfUses != -1)
                {
                    numberOfUses = $"( Can be used {bonusAction._numberOfUses} time(s) ) ";
                }

                Console.WriteLine($"- Bonus Action: {bonusAction._name} {numberOfUses}");
                Console.WriteLine($"- Description: {bonusAction._description}");
            }
        }
        /// <summary>
        ///     Method to print out all of the information (stats + basic information of hp, AC, etc.)
        /// </summary>
        public void printAllInformation()
        {
            printBasicInformation();
            printStats();
        }
        /// <summary>
        ///     Method to print out all the stats for the creature (str, dex, ... charisma)
        /// </summary>
        public void printStats()
        {
            // Should be in a formatted table of score | bonus | save
            Console.WriteLine("Score\t|\tBonus\t|\tSave");

            // Throw them into a list of stats just to help for looping later
            List<Stat> stats = new List<Stat>
            {
                _strength, _dexterity, _constitution, _wisdom, _intelligence, _charisma
            };
            // TODO: CODE THIS 
            // for (Stat stat : )
        }

        /// <summary>
        ///     Method to print out the basic information (hp, AC, ...)
        /// </summary>
        public void printBasicInformation() {}

        /// <summary>
        ///     Method to set the calculate and set the current stat bonuses of the creature
        /// </summary>
        public void setStatBonuses(){}
        /// <summary>
        ///     Method to set the calculate and set the current stat save bonuses of the creature
        /// </summary>
        public void setSaveBonuses(){}

        public void printAllItems()
        {
        }
    }
}
