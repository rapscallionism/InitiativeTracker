namespace Core.Models.Utilities
{
    public enum ActionEconomyType
    {
        /// <summary>
        ///     Costs an Action to activate.
        /// </summary>
        ACTION,

        /// <summary>
        ///     Costs a Bonus Action to activate.
        /// </summary>
        BONUS_ACTION,

        /// <summary>
        ///     Costs a Reaction to activate.
        /// </summary>
        REACTION,

        /// <summary>
        ///     Costs nothing to activate, is permanently on.
        /// </summary>
        EFFECT,
    }
}
