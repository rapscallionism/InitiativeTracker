namespace Backend.Models.Utilities.Enums
{
    /// <summary>
    ///     Enum representation of all the valid tags that
    ///     a piece of equipment can have. Will also have
    ///     other tags that is needed for this application
    ///     mainly for meta-data purposes.
    /// </summary>
    public enum Tags
    {
        // Armor Designations
        HEAVY_ARMOR,
        MEDIUM_ARMOR,
        LIGHT_ARMOR,

        // Weapon Designations
        VERSATILE,
        TWO_HANDED,
        HEAVY,
        LIGHT,
        REACH,
        MELEE,
        RANGED,
        THROWN,
        FINESSE
    }
}
