namespace Backend.Models.Entities
{
    /// <summary>
    ///     Represents the basic structure of the entity for an action. In this case,
    ///     the "action" refers to the action economy type (action, bonus action, reaction, etc.).
    /// </summary>
    public class BaseActionEntity
    {
        /// <summary>
        ///     Unique identifier.
        /// </summary>
        public string Id { get; set; }

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
        public string EquipmentId { get; set; }
    }
}
