namespace Turn_Based_Game.Models.Interfaces
{
    public interface IWeapon : Item
    {
        public int _numberOfDiceForDamage { get; set; }

        public int _maximumRollForDice {get; set; }

    }
}
