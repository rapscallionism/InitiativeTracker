using Core.Models.DTOs;
using Core.Models.Utilities;

namespace Frontend.Models
{
    /// <summary>
    ///     Class which is to be utilized when handling the frontend table.
    /// </summary>
    public class Item
    {
        private EquipmentDTO EquipmentMetaData { get; set; }
        public Compact Compact { get; private set; }
        public Detailed Detailed { get; private set; }

        public Item(EquipmentDTO equipment)
        {
            this.Compact = new(equipment);
            this.Detailed = new(equipment);
            this.EquipmentMetaData = equipment;
        }
    }

    public class Compact
    {
        /// <summary>
        ///     Unique name of the equipment.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     List of tags associated with this piece of equipment.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        ///     Enumerator which indicates where this item will go
        ///     on the player.
        /// </summary>
        public string EquipmentSlot { get; set; }

        /// <summary>
        ///     Enumerator which indicates how this equipments' charges
        ///     will reset (if at all).
        /// </summary>
        public string ResetsOn { get; set; }

        public Compact(EquipmentDTO equipment)
        {
            this.Name = equipment.Name;
            this.Tags = string.Join(", ", equipment.Tags);
            this.EquipmentSlot = string.Join(", ", equipment.EquipmentSlot);
            this.ResetsOn = string.Join(", ", equipment.ResetsOn);
        }
    }

    public class Detailed 
    {
        /// <summary>
        ///     Unique Identifier
        /// </summary>
        public string Id { get; set; }

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
        ///     Enumerator which indicates how this equipments' charges
        ///     will reset (if at all).
        /// </summary>
        public Core.Models.Utilities.ResetsOn[] ResetsOn { get; set; } = [];

        /// <summary>
        ///     The number of maximum charges a piece of equipment
        ///     may have.
        /// </summary>
        public int? MaxCharges { get; set; }

        public Detailed(EquipmentDTO equipment)
        {
            this.Name = equipment.Name;
            this.Description = equipment.Description;
            this.Tags = equipment.Tags;
            this.EquipmentSlot = equipment.EquipmentSlot;
            this.ResetsOn = equipment.ResetsOn;

            // We don't map charges since we don't care how many charges it currently has
            // that is information for the character, not the item itself.
            this.MaxCharges = equipment.MaxCharges;
        }
    }
}
