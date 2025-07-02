using InitiativeTracker.Classes.Enums;

namespace InitiativeTracker.Classes
{
    public abstract class ItemClass
    {
        public int id;
        public string description;
        public Slot slot;
        public Enchantment enchantment;
        public bool isMagical;
        public int? enhancement;
        public string imageUrl; 
    }
}
