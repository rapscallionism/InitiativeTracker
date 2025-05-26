namespace InitiativeTracker.Items
{
    public class Chest : EquipmentType
    {
        public String Name;
        public String EquipmentType = Type.CHEST.ToString();
        public ArmorType ArmorType;
    }

    public enum ArmorType
    {
        CLOTHING,
        LIGHT,
        MEDIUM,
        HEAVY
    }
}
