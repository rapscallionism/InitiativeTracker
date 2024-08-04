using System.Runtime.InteropServices;

namespace Turn_Based_Game.Models.Interfaces
{
    public interface ICreature
    {
        // Basic information
        public int _health { get; set; }
        public string _name { get; set; }
        public int _level { get; set; }
        public int _armorClass { get; set; }
        public int _movementSpeed { get; set; }
        public int _proficiencyBonus {  get; set; }
        public int _initiative { get; set; }

        // Stat information
        public Stat _strength { get; set; }
        public Stat _dexterity { get; set; }
        public Stat _constitution { get; set; }
        public Stat _intelligence { get; set; }
        public Stat _wisdom { get; set; }
        public Stat _charisma { get; set; }

        // Equipped Weapon
        public IWeapon? _weapon { get; set; }

        // Equipped armor
        public IArmor? _armor { get; set; }

        // Necklace 
        public INecklace? _necklace { get; set; }

        // Possibly two rings
        public IRing? _leftRing { get; set; }
        public IRing? _rightRing { get; set; }

        // Shield slot
        public IShield _shield { get; set; }

        public List<Item> items { get; set; }

        public List<IAction> _actions { get; set; }

        public List<IBonusAction> _bonusActions { get; set; }

        /// <summary>
        ///     Method to print out the actions and the corresponding description of the action
        /// </summary>
        public void printActions();
        /// <summary>
        ///     Method to print out the bonus actions and the corresponding description of the bonus action
        /// </summary>
        public void printBonusActions();
        /// <summary>
        ///     Method to print out all of the information (stats + basic information of hp, AC, etc.)
        /// </summary>
        public void printAllInformation();
        /// <summary>
        ///     Method to print out all the stats for the creature (str, dex, ... charisma)
        /// </summary>
        public void printStats();

        /// <summary>
        ///     Method to print out the basic information (hp, AC, ...)
        /// </summary>
        public void printBasicInformation();

        /// <summary>
        ///     Method to print out everything that is currently in the items attribute of this creature
        /// </summary>
        public void printAllItems();

        /// <summary>
        ///     Method to set the calculate and set the current stat bonuses of the creature
        /// </summary>
        public void setStatBonuses();
        /// <summary>
        ///     Method to set the calculate and set the current stat save bonuses of the creature
        /// </summary>
        public void setSaveBonuses();

        
    }
}
