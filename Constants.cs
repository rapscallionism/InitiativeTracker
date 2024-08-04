namespace Turn_Based_Game
{
    /// <summary>
    ///     Weapon type which does more damage but does not allow for the casting of spells
    /// </summary>
    public enum TwoHandedWeaponTypes
    {
        Greataxe, 
        Greatsword,
        Maul,
        Pike,
        Lance
    }

    /// <summary>
    ///     Weapon type which does more damage but allows the casting of spells with the freehand
    /// </summary>
    public enum OneHandedWeaponTypes  
    {
        Shortsword,
        Dagger,
        Scimitar,
        Longsword
    }

    public enum WeaponCategories
    {
        /// <summary>
        ///     Can be dual wielded
        /// </summary>
        Light, 
        /// <summary>
        ///     Can be used as two handed OR one handed
        /// </summary>
        Versatile, 
        /// <summary>
        ///     Uses the Dexterity OR Strength Modifier to calculate to hit (uses the higher one)
        /// </summary>
        Finesse, 
        /// <summary>
        ///     Allows an attack roll when a creature attempts to attack the creature wielding it
        /// </summary>
        Reach, // 
    }

    
    public class Utils {
        public static int Roll(int numberOfDice, int maximumRollForDice) {
            int roll = 0;
            var random = new Random();

            for (int i = 0; i < numberOfDice; i++) {
                roll += random.Next(1, maximumRollForDice);
            }

            return roll;
        }
    }

}
