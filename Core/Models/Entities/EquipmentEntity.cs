using Core.Models.Utilities;

namespace Core.Models.Entities
{
    public class EquipmentEntity
    {
        /// <summary>
        ///     Unique Identifier
        /// </summary>
        public Guid? Id { get; set; } = Guid.NewGuid();

        /// <summary>
        ///     Name of the Equipment
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Short description of the equipment
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     List of tags associated with this piece of equipment.
        /// </summary>
        public Tags[] Tags { get; set; } = [];

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

        /// <summary>
        ///     Navigation entity that, as a list, represents
        ///     the effects (activatable or not) that this equipment
        ///     has access to.
        /// </summary>
        public List<FeatureEntity> Features { get; set; }
    }
}
