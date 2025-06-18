using InitiativeTracker.Classes.Enums;

namespace InitiativeTracker.Classes
{
    public abstract class ItemClass
    {
        int id;
        string description;
        Slot slot;
        Enchantment enchantment;
        bool isMagical;
        int? enhancement;
    }
}
