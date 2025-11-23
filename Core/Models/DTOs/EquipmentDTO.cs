using Core.Models.Utilities;

namespace Core.Models.DTOs
{
    /// <summary>
    ///     The downstream consumed version of the <see cref="Backend.Entities.EquipmentEntity"/>.
    /// </summary>
    public class EquipmentDTO
    {
        /// <summary>
        ///     Unique Identifier
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        ///     Unique name of the equipment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Short description of the equipment
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     List of tags associated with this piece of equipment.
        /// </summary>
        public Core.Models.Utilities.Tags[] Tags { get; set; } = [];

        /// <summary>
        ///     Enumerator which indicates where this item will go
        ///     on the player.
        /// </summary>
        public EquipmentSlot[] EquipmentSlot { get; set; } = [];

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
