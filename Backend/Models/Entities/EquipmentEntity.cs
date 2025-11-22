namespace Backend.Models.Entities
{
    public class EquipmentEntity
    {
        /// <summary>
        ///     Unique Identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Short description of the equipment
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     List of tags associated with this piece of equipment.
        /// </summary>
        public Utilities.Enums.Tags[] Tags { get; set; } = [];

        /// <summary>
        ///     Enumerator which indicates where this item will go
        ///     on the player.
        /// </summary>
        public Utilities.Enums.EquipmentSlot[] EquipmentSlot { get; set; } = [];

        /// <summary>
        ///     Enumerator which indicates how this equipments' charges
        ///     will reset (if at all).
        /// </summary>
        public Utilities.Enums.ResetsOn?[] ResetsOn { get; set; } = [];

        /// <summary>
        ///     The number of current charges the equipment has.
        /// </summary>
        public int? Charges { get; set; }

        /// <summary>
        ///     The number of maximum charges a piece of equipment
        ///     may have.
        /// </summary>
        public int? MaxCharges { get; set; }
    }
}
