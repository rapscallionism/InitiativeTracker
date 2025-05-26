using InitiativeTracker.Interfaces;

namespace InitiativeTracker.Items
{
    public partial class ScaleOfTheBronzeTyrant : ItemClass, ItemInterface
    {
        public new String Description = "Feeling along its material, the armor flexes and tenses instinctively.";
        public new Tags Tags = new Tags
        {
            RequiresAttunement = true,
            Rarity = Rarity.VERY_RARE,
            EquipmentType = new Chest
            {
                Name = "Scale of the Bronze Tyrant",
                EquipmentType = Type.CHEST.ToString(),
                ArmorType = ArmorType.MEDIUM
            }
        };
        public new String onAction = "None";
        public new String onBonusAction = "None";
        public new String onReaction = "Electric Discharge: When hit, the wielder can choose to release a shockwave of " +
            "lightning energy around them in a 10 ft. radius. Creatures in the radius must make a DC 14 Dex Save or take " +
            "**1d6 Lightning Damage** per charge used or half as much on a save. When this feature is used, it cannot be " +
            "used until the next short rest.";
        public new List<String> Effects = new List<String>
        {
            "AC: 16 + Dex Modifier (Max 2)",
            "Disadvantage on Stealth Checks",
            "Charge Accumulation: When struck, gain 1 charge.",
            "Conditional Lightning Resistance: While the wearer has charges, gain resistance against Lightning Damage"
        };
        public int Charges;
        public Boolean hasBeenUsedThisShortRest = false;

        public bool OnLongRest()
        {
            return OnShortRest();
        }

        public bool OnShortRest()
        {
            if (hasBeenUsedThisShortRest)
            {
                hasBeenUsedThisShortRest = !hasBeenUsedThisShortRest;
            }

            return true;
        }
    }
}
