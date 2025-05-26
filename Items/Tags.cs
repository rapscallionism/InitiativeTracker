namespace InitiativeTracker.Items
{
    public class Tags
    {
        public Boolean RequiresAttunement;
        public Rarity Rarity;
        public EquipmentType EquipmentType;
    }

    public enum Rarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        VERY_RARE,
        LEGENDARY
    }

    public abstract class EquipmentType
    {
    }

    public enum ResetsOn
    {
        ALWAYS,
        SHORT_REST,
        LONG_REST,
        SINGLE_USE,
        CUSTOM
    }

    public enum Type
    {
        HELMET,
        CHEST,
        GAUNTLETS,
        BOOTS,
        CLOAK,
        NECKLACE,
        RING_ONE,
        RING_TWO,
        MELEE_ONE,
        MELEE_TWO,
        RANGED_ONE,
        RANGED_TWO,
    }
}
