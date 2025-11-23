namespace Core.Models.Utilities
{
    /// <summary>
    ///     Represents the condition whereby the specific equipments' charges will reset.
    /// </summary>
    public enum ResetsOn
    {
        LONG_REST,
        SHORT_REST,
        AT_DAWN,
        AT_24_HOURS,
        AT_1_WEEK,
        SINGLE_USE,

        /// <summary>
        ///     Indicates that the effect is always on; 
        /// </summary>
        PASSIVE,
        
        /// <summary>
        ///     If the item is deemed to have a custom resets on condition, this should be
        ///     explained in the description of the item
        /// </summary>
        CUSTOM
    }
}
