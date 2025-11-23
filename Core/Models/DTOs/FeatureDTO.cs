using Core.Models.Entities;
using Core.Models.Utilities;

namespace Core.Models.DTOs
{
    public class FeatureDTO
    {
        /// <summary>
        ///     Unique identifier.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        ///     The unique name of this specific action economy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     A brief description of what this specific action
        ///     will occur.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     A representation of what this BaseActionEntity will cost to activate.
        ///     This is determined through <see cref="ActionEconomyType"/>.
        /// </summary>
        public ActionEconomyType ActionEconomyType { get; set; }

        /// <summary>
        ///     Representation of when this feature resets, if at all.
        /// </summary>
        public Core.Models.Utilities.ResetsOn[] ResetsOn { get; set; }

        /// <summary>
        ///     A numerical value indicating how much charge this will
        ///     cost the item if this action is utilized. By default,
        ///     this should be 0 or null to represent that it does
        ///     not cost any charge since, typically, there are some
        ///     which do not require a charge to occur (e.g.
        ///     enchantments, passive effects, etc.)
        /// </summary>
        public int? ChargeCost { get; set; }

        /// <summary>
        ///     Unique id in which this action economy type 
        ///     ties back to the equipment this entity belongs
        ///     to.
        /// </summary>
        public string? EquipmentId { get; set; }
    }
}
