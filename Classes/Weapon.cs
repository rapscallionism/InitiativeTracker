using InitiativeTracker.Classes.Enums;

namespace InitiativeTracker.Classes
{
    public class Weapon : ItemClass
    {
        int maxRollForDamage;
        int maxDiceForDamage;
        int range;
        List<WeaponTags> weaponTags = new();
    }
}
