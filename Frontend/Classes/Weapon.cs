using Frontend.Classes.Enums;

namespace Frontend.Classes
{
    public class Weapon : ItemClass
    {
        public int maxRollForDamage;
        public int maxDiceForDamage;
        public int range;
        public List<WeaponTags> weaponTags = new();
    }
}
