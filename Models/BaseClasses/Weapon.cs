using Turn_Based_Game.Models.Interfaces;

namespace Turn_Based_Game.Models.BaseClasses
{

    public class Weapon : IWeapon
    {
        public required string _name { get; set; }
        public required string _description { get; set; }
        public required string _type { get; set; }
        public int _numberOfDiceForDamage { get; set; }
        public int _maximumRollForDice { get; set; }

        public required List<WeaponCategories> _weaponCategories;

        public int attackWithWeapon()
        {
            int damageDone = 0;

            // Roll for damage here 
            damageDone = Utils.Roll(_numberOfDiceForDamage, _maximumRollForDice);

            return damageDone;
        }
    }

}