using Microsoft.AspNetCore.Mvc.TagHelpers;
using Turn_Based_Game.Models.Interfaces;

namespace Turn_Based_Game.Models.BaseClasses
{
    public class Attack : IAction
    {
        public string _name { get; set; } = "Attack";
        public string _description { get; set; } = "Swing with your weapon or throw hands!";
        public bool _isUsable { get; set; } = true;
        /// <summary>
        ///     Represents the number of times that this action can be used. By default, should be set to -1 (meaning can be repeated infinite number of times)
        ///     and has no limit. An example of this would be the attack action. Anything else other than that means that the action can only be used
        ///     by the certain amount defined by this attribute. 
        /// </summary>
        public int _numberOfUses { get; set; } = -1;

        /// <summary>
        ///     Represents the maximum number of times that this action can be used. Mainly used for reference to identify the amount of times time an
        ///     action can be used as well as to keep tabs on what <c>_numberOfUses</c> can be reset to. If set to -1, then that means it can be infinitely 
        ///     used.
        /// </summary>
        public int _maxNumberOfUses { get; set; } = -1;

        public Dictionary<int, ICreature> UseAction (Dictionary<int, ICreature> affectedCreatures)
        {
            // Create a clone of the affected creatures within this dictionary first
            Dictionary<int, ICreature> creaturesAffected = affectedCreatures.ToList().ToDictionary<int, ICreature>();

            // The 0th index creature is the one who is casting said action
            ICreature creatureUsingAction = affectedCreatures[0];

            // Initialize the weapon; will be used later down the line
            IWeapon weaponToUse = null;

            // Check if the creature using the action has a weapon; if so, use that as what is going to be used as damage
            if (creatureUsingAction._weapon != null) {
                weaponToUse = creatureUsingAction._weapon;
            } else {
                weaponToUse = null;
            }

            // TODO: CODE THIS 
            return creaturesAffected;
        }
        
    }
}
